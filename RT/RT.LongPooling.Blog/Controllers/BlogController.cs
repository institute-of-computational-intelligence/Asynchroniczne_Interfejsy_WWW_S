using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using DynamicData;
using Microsoft.AspNetCore.Mvc;
using RT.LongPooling.Blog.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace RT.LongPooling.Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly ISourceCache<Post, int> _blogPosts;
        private CancellationTokenSource _cancellationTokenSource;
        public BlogController(ISourceCache<Post, int> blogPosts, CancellationTokenSource cancellationTokenSource)
        {
            _blogPosts = blogPosts;
            _cancellationTokenSource = cancellationTokenSource;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Subscribe()
        {
            _blogPosts.Connect()
                    .Subscribe(x =>
                    {
                        _cancellationTokenSource.Cancel();
                    });
            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;
            cancellationToken.WaitHandle.WaitOne();
            return Json(_blogPosts.Items);
        }

        [HttpPost]
        public IActionResult AddPost([FromBody] Post post)
        {
            _blogPosts.AddOrUpdate(post);
            return Ok();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RT.SSE.Lotto.Models;

namespace RT.SSE.Lotto.Controllers
{
    public class LottoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task StartDrawing()
        {
            Response.Headers.Add("Content-Type", "text/event-stream");
            var rand = new Random();
            while (true)
            {
                var drawMessage = new LottoDrawMessage()
                {
                    DrawTimestamp = DateTime.Now,
                    Nr1 = rand.Next(1, 45),
                    Nr2 = rand.Next(1, 45),
                    Nr3 = rand.Next(1, 45),
                    Nr4 = rand.Next(1, 45),
                    Nr5 = rand.Next(1, 45),
                    Nr6 = rand.Next(1, 45)
                };
                string jsonMessageObj = Newtonsoft.Json.JsonConvert.SerializeObject(drawMessage); // serialization to json.
                var messageTemplate = $"data: {jsonMessageObj} \n\n"; // message template. Critical for SSE functioning.
                var messageBytes = Encoding.ASCII.GetBytes(messageTemplate);
                await Response.Body.WriteAsync(messageBytes, 0, messageBytes.Length);
                await Response.Body.FlushAsync();
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.LongPooling.Blog.Models
{
    public class Post
    {
        private static int _count = 0;
        public int Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }

        public Post()
        {
            ++_count;
            Id = _count;
        }
    }
}

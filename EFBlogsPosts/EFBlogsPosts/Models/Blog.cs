﻿using System.Collections.Generic;
using System.Data.Entity;
namespace BlogsConsole.Models
{
    public class Blog
    {

        public int BlogId { get; set; }
        public string Name { get; set; }

        public List<Post> Posts { get; set; }

       

    }
}

﻿using System;
using System.Collections.Generic;

namespace JiraConfluenceApi.Models
{
    public class BlogsViewModel
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByAvatar { get; set; }
    }
}

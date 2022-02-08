using System;

namespace JiraConfluenceApi.Models
{
    public class BlogBodyDetails
    {
        public string value { get; set; }
    }
    public class BlogBody
    {
        public BlogBodyDetails view { get; set; }
    }
    public class BlogDetails
    {
        public long id { get; set; }
        public string title { get; set; }
        public BlogBody body { get; set; }
    }
}

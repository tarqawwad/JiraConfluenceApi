using System;
using System.Collections.Generic;

namespace JiraConfluenceApi.Models
{
    public class BlogLatestBlogs
    {
        public long id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public LatestBlogsHistory history { get; set; }
    }
    public class ProfilePicture
    {
        public string path { get; set; }
    }
    public class LatestBlogsHistory
    {
        public CreatedBy createdBy { get; set; }
        public DateTime createdDate { get; set; }
    }
    public class CreatedBy
    {
        public ProfilePicture profilePicture { get; set; }
        public string displayName { get; set; }
    }
}
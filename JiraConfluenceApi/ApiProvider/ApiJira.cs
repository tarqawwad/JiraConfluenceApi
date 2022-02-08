using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace JiraConfluenceApi.ApiProvider
{
    public class ApiJira
    {
        public List<JiraConfluenceApi.Models.BlogsViewModel> GetBlogDetails(string SpaceKey, List<long> ListIds)
        {
            var Model = new List<JiraConfluenceApi.Models.BlogsViewModel>();

            foreach (var item in ListIds)
            {
                // Get item details From Functions Private 
                var Details1 = GetBlogDetails1(item, SpaceKey);
                var Details2 = GetBlogDetails2(item, SpaceKey);


                // Add item details to Model 
                Model.Add(new Models.BlogsViewModel
                {
                    Title = Details1.title,
                    Description = Details1.body.view.value,
                    ID = Details1.id,
                    CreatedBy = Details2.history.createdBy.displayName,
                    CreatedByAvatar = Details2.history.createdBy.profilePicture.path,
                    Date = Details2.history.createdDate.Date,
                });
            }

            return Model;
        }
      
        
        // Get Blog Details From Jira Confluence Title,ID,Body
        private JiraConfluenceApi.Models.BlogDetails GetBlogDetails1(long ID, string SpaceKey)
        {
            var client = new HttpClient();
            JiraConfluenceApi.Models.BlogDetails model = new JiraConfluenceApi.Models.BlogDetails();

            string url = "http://confluenceapitest.atlassian.net/wiki/rest/api/content/" + ID.ToString() + "?spaceKey=" + SpaceKey + "&type=page&expand=body.view";

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<Models.BlogDetails>(result);
            }

            return model;
        }

        // Get Blog Details From Jira Confluence Date,CreatedBy,Avatar
        private JiraConfluenceApi.Models.BlogLatestBlogs GetBlogDetails2(long ID, string SpaceKey)
        {
            var client = new HttpClient();
            JiraConfluenceApi.Models.BlogLatestBlogs model = new JiraConfluenceApi.Models.BlogLatestBlogs();

            string url = "http://confluenceapitest.atlassian.net/wiki/rest/api/content/" + ID.ToString() + "?spaceKey=" + SpaceKey + "&type=page&expand=history";

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<JiraConfluenceApi.Models.BlogLatestBlogs>(result);
            }

            return model;
        }
    }
}
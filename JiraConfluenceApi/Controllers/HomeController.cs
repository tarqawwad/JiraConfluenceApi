using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiraConfluenceApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(GetDataSpaces());
        }

        // Prepare Data For Some Spaces
        private JiraConfluenceApi.Models.BlogsFinalModel GetDataSpaces()
        {
            var obj =new  JiraConfluenceApi.ApiProvider.ApiJira();

            return new Models.BlogsFinalModel {
                Space1 = obj.GetBlogDetails("GS",new List<long>{ 229382, 262145, 262152 }),
                Space2= obj.GetBlogDetails("STEP1", new List<long> { 196747, 65556 })
            };
        }
    }
}
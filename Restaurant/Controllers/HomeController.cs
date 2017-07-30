using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;

namespace Restaurant.Controllers
{
    [RequireHttps]
    //[Authorize(Users = "lofongi")]
    public class HomeController : Controller
    {

        Food _db = new Food();

        public ActionResult Autocomplete(string term)
        {

            var model = _db.Restaurants
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                .Select(r => new
                {
                    label = r.Name
                });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //mvc able to cache small part of code independently
        //for demonstration
        //[ChildActionOnly]
        //[OutputCache(Duration = 60)]
        //public ActionResult SayHello()
        //{
        //    return Content("hello");
        //}



        //[OutputCache(Duration =360, VaryByHeader ="X-Requested-With", Location =OutputCacheLocation.Server)]//for perfomence

        //now we having duration in Web.config
        [OutputCache(CacheProfile ="long", VaryByHeader = "X-Requested-With", Location = OutputCacheLocation.Server)]


        //in browser if we go to bookmark https://localhost:44306/?searchT=M
        //we will get a cache we missing syles and scripts
        //to fix this we need VaryByHeader ="X-Requested-With"
        //because it will be present on ajax request not on a full request
        //asp.net will be able to tell te difference between those 2
        //and cache different responses
        // Location =OutputCacheLocation.Server allowing cache on a server
        //it will send instruction to the browser
        //browser will always come to the server to check
        //we need to clear browser cache before debuging

        //[AllowAnonymous]
        //providing an ability to find an item. assuming that initial query is empty
        public ActionResult Index(int? page,string searchT = null )
        {
            var pageNumber = (page ?? 1);
            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var id = RouteData.Values["id"];

            //var message = String.Format("{0}::{1} {2}", controller, action, id);

            //ViewBag.Message = message;
            //go to db and find restaurants
            //retrive all and turn into a list
            //var model = from r in _db.Restaurants
            //            orderby r.Reviews.Average(rev => rev.Rating) descending
            //            //orderby r.Reviews.Count descending
            //            //select r;
            //            //we defined a new class
            //            select new RestaurantListVM{
            //                Id = r.Id,
            //                Name = r.Name,
            //                City = r.City,
            //                Country = r.Country,
            //                CountOfReviews = r.Reviews.Count()
            //            };
            //we can do the same using extention method
            var model = _db.Restaurants
                .OrderByDescending(r =>
                //r.Id)//for correct work of paging
                r.Reviews.Average(rev => rev.Rating))
                //if null we return all restaurants or finding the right one
                //we can add /?search=m in url address to look up for query
                .Where(r=>searchT == null || r.Name.StartsWith(searchT))
                //Take(2) displays first 2
                
                .Select(r => new RestaurantListVM
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count()
                }).ToPagedList(pageNumber, 2);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

            return View(model);
        }

        [Authorize]//only authorized users can view about

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            //ViewBag.Location = "Ukraine, Lviv";

            var model = new AboutModel();
            model.Name = "Andriy";
            model.Location = "Ukraine, Lviv";
            //use this model
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {

            //to clean up resources that might be opened
            if (_db != null)
                _db.Dispose();

            base.Dispose(disposing);
        }
    }
}
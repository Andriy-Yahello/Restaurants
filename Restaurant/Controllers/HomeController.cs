﻿using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {

        Food _db = new Food();
        //providing an ability to find an item. assuming that initial query is empty
        public ActionResult Index(string searchT = null)
        {
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
                r.Reviews.Average(rev => rev.Rating))
                //if null we return all restaurants or finding the right one
                //we can add /?search=m in url address to look up for query
                .Where(r=>searchT == null || r.Name.StartsWith(searchT))
                //Take(2) displays first 2
                //.Take(2)
                .Select(r => new RestaurantListVM
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count()
                });

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

            return View(model);
        }

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
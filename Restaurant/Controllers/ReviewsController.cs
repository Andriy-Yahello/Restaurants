﻿using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class ReviewsController : Controller
    {
        // GET: Reviews
        public ActionResult Index()
        {
            //ordering with linq
            var model = from r in _reviews
                        orderby r.Country
                        select r;
            //passing model in to a view
            return View(model);
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //fake data t osee how it looks like in browser
        static List<Review> _reviews = new List<Review>
        {
            new Review {
                Id = 456456,
                Name = "Corteg",
                City = "Berlin",
                Country = "Germany",
                Rating = 4.5f
            },
            new Review {
                Id = 84815,
                Name = "Revron",
                City = "Prag",
                Country = "Czech Republic",
                Rating = 4.8f
            },
            new Review {
                Id = 234235,
                Name = "Exite",
                City = "Madrid",
                Country = "Spain",
                Rating = 4.1f
            },
            new Review {
                Id = 45767,
                Name = "Likely",
                City = "Paris",
                Country = "France",
                Rating = 4.4f
            }
        };
    }
}
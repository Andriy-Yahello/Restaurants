using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//namespace Restaurant.Controllers
//{
//    public class ReviewsController : Controller
//    {
//        // GET: Reviews
//        public ActionResult Index()
//        {
//            //ordering with linq
//            var model = from r in _reviews
//                        orderby r.Country
//                        select r;
//            //passing model in to a view
//            return View(model);
//        }

//        // GET: Reviews/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: Reviews/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Reviews/Create
//        [HttpPost]
//        public ActionResult Create(FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add insert logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Reviews/Edit/5
//        public ActionResult Edit(int id)
//        {
//            var review = _reviews.Single(r => r.Id == id);

//            return View(review);
//        }

//        // POST: Reviews/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, FormCollection collection)
//        {
//            var review = _reviews.Single(r => r.Id == id);
//            //TryUpdateModel is looking for name of the prop review and match with what is gonna be pushed to the model
//            //and it finds due to @Html.EditorFor in 
//            if (TryUpdateModel(review))
//            {
//                return RedirectToAction("Index");
//            }
//            return View(review);
//        }

//        // GET: Reviews/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Reviews/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//        //fake data t osee how it looks like in browser
//        static List<Review> _reviews = new List<Review>
//        {
//            new Review {
//                Id = 456456,
//                Name = "Corteg",
//                City = "Berlin",
//                Country = "Germany",
//                Rating = 4.5f
//            },
//            new Review {
//                Id = 84815,
//                Name = "Revron",
//                City = "Prag",
//                Country = "Czech Republic",
//                Rating = 4.8f
//            },
//            new Review {
//                Id = 234235,
//                Name = "Exite",
//                City = "Madrid",
//                Country = "Spain",
//                Rating = 4.1f
//            },
//            new Review {
//                Id = 45767,
//                Name = "Likely",
//                City = "Paris",
//                Country = "France",
//                Rating = 4.4f
//            }
//        };
//        [ChildActionOnly]//is to make illigal to go Reviews/BestReview
//        public ActionResult BestReview()
//        {
//            var bestReviews = from r in _reviews
//                              orderby r.Rating descending
//                              select r;
//            return PartialView("_Review", bestReviews.First());
//        }
//    }
//}


namespace Restaurant.Controllers
{
    public class ReviewsController : Controller
    {
        Food _db = new Food();

        // GET: Reviews
        //Bind tells mvc model binderthat when it looks to find restaurantId param value
        //look for somthing called id
        //when it looks for restaurantid itwill look for the name id
        public ActionResult IndexView([Bind(Prefix="id")]int RestaurantId)
        {
            var restaurant = _db.Restaurants.Find(RestaurantId);
            if(restaurant != null)
            {
                return View(restaurant);
            }
            return HttpNotFound();
        }


        [HttpGet]
        public ActionResult Create(int RestaurantId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Review r)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(r);
                _db.SaveChanges();
                return RedirectToAction("IndexView", new { id = r.RestaurantId });
            }
            return View(r);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var model = _db.Reviews.Find(Id);
            return View(model);
        }

        [HttpPost]
        //[Bind(Exclude ="ReviewerName")] frevants model from editig even if
        //its not shown 
        //public ActionResult Edit([Bind(Exclude ="ReviewerName")] Review r)
        public ActionResult Edit(Review r)
        {
            if (ModelState.IsValid)
            {
                //Entry IPA is a way to tell EF here is a review that I want you to start tracking
                //so it can make changes for this review
                //its not a new review 
                //this is the review that already in data base
                //we just want to take a oversheet of this object
                //and treat it as if it had data inside
                _db.Entry(r).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("IndexView", new { id = r.RestaurantId });
            }
            return View(r);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
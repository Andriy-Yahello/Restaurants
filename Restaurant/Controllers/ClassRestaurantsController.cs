using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class ClassRestaurantsController : Controller
    {
        private Food db = new Food();

        // GET: ClassRestaurants
        public ActionResult Index()
        {
            return View(db.Restaurants.ToList());
        }



        // GET: ClassRestaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassRestaurants/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City,Country")] ClassRestaurant classRestaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(classRestaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classRestaurant);
        }

        // GET: ClassRestaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRestaurant classRestaurant = db.Restaurants.Find(id);
            if (classRestaurant == null)
            {
                return HttpNotFound();
            }
            return View(classRestaurant);
        }

        // POST: ClassRestaurants/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City,Country")] ClassRestaurant classRestaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classRestaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classRestaurant);
        }

        // GET: ClassRestaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRestaurant classRestaurant = db.Restaurants.Find(id);
            if (classRestaurant == null)
            {
                return HttpNotFound();
            }
            return View(classRestaurant);
        }

        // POST: ClassRestaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassRestaurant classRestaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(classRestaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

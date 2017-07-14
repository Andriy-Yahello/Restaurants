using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class LoudController : Controller
    {
        // GET: Loud
                                //setting default value to chips
        public ActionResult Search(string name = "chips")
        {
            var message = Server.HtmlEncode(name);

            //return View(message);
            //to display a message from /Loud/{name}
            //return Content(message);

            //redirecting to home if the path doesn't exist
            //return RedirectToAction("Index", "Home", new { name = name });

            //
            //return RedirectToRoute("Default", new { controlle = "Home", action = "About" });
            //prints the content of owner.txt if we go to /loud
            //return File(Server.MapPath("~/Content/Owner.txt"), "text/text");

            //return Json
            return Json(new { Message = message, Name = "Robert" }, JsonRequestBehavior.AllowGet);
        }
    }
}
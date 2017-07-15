using Restaurant.Filters;
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
        //Log from Restaurant.Filters;
        [Log]

          //  [Authorize]//says that a user has to be loged in to perform a search loud/search
                                //setting default value to chips
        public ActionResult Search(string name = "chips")
        {
            //we can throw own error message
            //in web.config we set <customErrors mode="On" defaultRedirect="~/Views/Shared/Error.cshtml"/>
            //and mark don't stop execution if exception occurs
            throw new Exception("This is my error message");
            try { 
            
            }
            catch (Exception) { }
            var message = Server.HtmlEncode(name);

            //return View(message);
            //to display a message from /Loud/{name}
            return Content(message);

            //redirecting to home if the path doesn't exist
            //return RedirectToAction("Index", "Home", new { name = name });

            //
            //return RedirectToRoute("Default", new { controlle = "Home", action = "About" });
            //prints the content of owner.txt if we go to /loud
            //return File(Server.MapPath("~/Content/Owner.txt"), "text/text");

            //return Json
            //return Json(new { Message = message, Name = "Robert" }, JsonRequestBehavior.AllowGet);
        }
    }
}
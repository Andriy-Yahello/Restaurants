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
            return Content(message);
        }
    }
}
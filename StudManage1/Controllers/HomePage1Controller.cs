using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudManage.Models
{
    public class HomePage1Controller : Controller
    {
        // GET: HomePage1
     
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Album()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult calendar()
        {
            return View();
        }
    }
}

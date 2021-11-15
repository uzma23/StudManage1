using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudManage.Models
{
[Authorize]
    public class HomePage2Controller : Controller
    {
      
        // GET: HomePage2
        public ActionResult menu2()
        {
            return View();
        }
        public ActionResult regplace()
        {
            return View();
        }
        //Registrstion, branch, placement, result

    }
}




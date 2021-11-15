using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using PagedList;
using StudManage1.Models;

namespace WebApplication1.Controllers
{
    public class PlacementController : Controller
    {
        // GET: Branch
        public ActionResult Companies()
        {
            StudentManagement1Entities db = new StudentManagement1Entities();
            List<company> lb = db.companies.ToList();

            return View(lb);
        }

        public ActionResult Students(int compid, string searchString)
        {

            StudentManagement1Entities db = new StudentManagement1Entities();
            //List<stuDetail> lb = db.stuDetails.Where(s => s.cid == compid).ToList();
            var ModelList = new List<stuDetail>();

            using (var context = new StudentManagement1Entities())
            {
                var model = from s in context.stuDetails
                            select s;
                //Added this area to, Search and match data, if search string is not null or empty
                if (!String.IsNullOrEmpty(searchString))
                {
                    model = model.Where(s => s.name.Contains(searchString)
                                           || s.gender.Contains(searchString));

                }
                model = model.OrderBy(s => s.name);
                ModelList = model.Where(s => s.cid == compid).ToList();


                return View(ModelList);

            }
        }



        public ActionResult Studentdeet(int stid)
        {
            StudentManagement1Entities db = new StudentManagement1Entities();
            stuDetail st = db.stuDetails.FirstOrDefault(s => s.sid == stid);

            return View(st);
           
        }

    }
}




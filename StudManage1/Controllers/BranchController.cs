using StudManage1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication1.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        public ActionResult Branches()
        {
            StudentManagement1Entities db = new StudentManagement1Entities();
            List<branch> lb = db.branches.ToList();

            return View(lb);
        }

        public ActionResult Students(int branchid, string searchString)
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
                ModelList = model.Where(s => s.branchId == branchid).ToList();


                return View(ModelList);

            }
        }

        public ActionResult Studentdeet(int sid)
        {
            StudentManagement1Entities db = new StudentManagement1Entities();
            eduDetail st = db.eduDetails.FirstOrDefault(s => s.id == sid);

            return View(st);
        }
    }
}


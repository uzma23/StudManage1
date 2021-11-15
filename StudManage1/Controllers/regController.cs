using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudManage1.Models;
namespace StudManage1.Controllers
{
    public class regController : Controller
    {
        // GET: reg
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(stuDetail student)
        {
            StudentManagement1Entities db = new StudentManagement1Entities();
            if (ModelState.IsValid)
            {
                student.cid = 10;
                db.stuDetails.Add(student);
                db.SaveChanges();
                TempData["id"] = student.sid;
                return RedirectToAction("Create");

            }

            return View(student);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(eduDetail student)
        {
            StudentManagement1Entities db = new StudentManagement1Entities();
            if (ModelState.IsValid)
            {

                student.id = Convert.ToInt32(TempData["id"]);
                db.eduDetails.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index", "stuDetails");

            }

            return View(student);

        }
        public ActionResult Index1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index1(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/fileupload"), filename);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "file uploaded";
                return View();
            }
            catch
            {
                ViewBag.Message = "file uploading failed";
                return View();
            }

        }
        public ActionResult Index2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index2(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/fileupload1"), filename);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "file uploaded";
                return View();
            }
            catch
            {
                ViewBag.Message = "file uploading failed";
                return View();
            }

        }
        public ActionResult CheckUserNameExists(string rollNo)

        {

            bool UserExists = false;



            try

            {

                using (var dbcontext = new StudentManagement1Entities())

                {

                    var nameexits = from temprec in dbcontext.stuDetails

                                    where temprec.rollNo.Equals(rollNo.Trim())

                                    select temprec;

                    if (nameexits.Count() > 0)

                    {

                        UserExists = true;

                    }

                    else

                    {

                        UserExists = false;

                    }

                }

                return Json(!UserExists, JsonRequestBehavior.AllowGet);

            }

            catch (Exception)

            {

                return Json(false, JsonRequestBehavior.AllowGet);

            }

        }
    }

}


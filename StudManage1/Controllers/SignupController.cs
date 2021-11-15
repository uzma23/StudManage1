
using CaptchaMvc.HtmlHelpers;
using StudManage1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudManage.Controllers
{
    
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult Index()
        {
            return View(new signup());
        }


        [HttpPost]
        public ActionResult Index(signup obj)
        {
           
                StudentManagement1Entities c = new StudentManagement1Entities();
                if (ModelState.IsValid)
                {
                    var isEmailAlreadyExists = c.signups.Any(x => x.username == obj.username);
                    if (isEmailAlreadyExists)
                    {


                        ModelState.AddModelError("Username", "User with this Name already exists");
                        return View(obj);
                    }
                    userrollmap var1 = new userrollmap();
                    var1.rid = 3;
                    var1.signupid = obj.signid;
                    c.signups.Add(obj);
                    c.userrollmaps.Add(var1);

                if (this.IsCaptchaValid("Captcha is not valid"))
                {
                    
                        c.SaveChanges();

                        return RedirectToAction("Login");
                    


                }
                else
                {
                    ViewBag.ErrMessage = "Error: captcha is not valid.";
                    return View(obj);
                }

                return RedirectToAction("Index");
                }
                return View(obj);
            
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(signup model)
        {
            using (StudentManagement1Entities context = new StudentManagement1Entities())
            {
                bool IsValidUser = context.signups.Any(user => user.username.ToLower() ==
                     model.username.ToLower() && user.pword == model.pword);
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.username, false);
                    return RedirectToAction("menu2", "HomePage2");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
        }
        public ActionResult forgot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult forgot(signup r)
        {
            using (var abc = new StudentManagement1Entities())
            {
                bool IsValidUser = abc.signups.Any(x => x.username.ToLower() == r.username.ToLower());
                if (IsValidUser)
                {
                    var cols = abc.signups.Where(x => x.username.Equals(r.username));
                    foreach (signup c in cols)
                    {
                        c.pword = r.pword;
                        c.cpword = r.cpword;
                    }
                    abc.Configuration.ValidateOnSaveEnabled = false;
                    abc.SaveChanges();
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", " Username does not exist!! ");
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult Login1(signup model)
        {
            using (StudentManagement1Entities context = new StudentManagement1Entities())
            {
                bool IsValidUser = context.signups.Any(user => user.username.ToLower() ==
                     model.username.ToLower() && user.pword == model.pword);
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.username, false);
                    return RedirectToAction("" +
                        "Index", "results");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudManage1.Models;

namespace StudManage1.Controllers
{
    [Authorize]
    public class resultsController : Controller
    {
        private StudentManagement1Entities db = new StudentManagement1Entities();

        // GET: results
      
        public ActionResult Index()
        {
            var results = db.results.Include(r => r.stuDetail);
            return View(results.ToList());
        }

        // GET: results/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            result result = db.results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: results/Create
        [Authorize(Roles = "teacher")]
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.stuDetails, "sid", "rollNo");
            return View();
        }

        // POST: results/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "teacher")]
        public ActionResult Create([Bind(Include = "sid,id,m1,m2,m3,total,grade")] result result)
        {
            if (ModelState.IsValid)
            {
                var isrollAlreadyExists = db.results.Any(x => x.stuDetail.sid == result.id );
                if (isrollAlreadyExists)
                {


                    ModelState.AddModelError("id",  "Roll number exists");
                    return View(result);
                }
                var isstu = db.stuDetails.Any(x => x.sid == result.id);
                if (!isstu)
                {


                    ModelState.AddModelError("id", "id does not  exists");
                    return View(result);
                }



                db.results.Add(result);
                    result.total = result.m1 + result.m2 + result.m3;
                    if (result.total >= 250) { result.grade = "A"; }
                    else if (result.total >= 200 && result.total < 250) { result.grade = "B"; }
                    else if (result.total >= 150 && result.total < 200) { result.grade = "C"; }
                    else { result.grade = "FAIL"; }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
            }

            ViewBag.id = new SelectList(db.stuDetails, "sid", "rollNo", result.id);
            return View(result);
        }
        [Authorize(Roles = "teacher")]
        // GET: results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            result result = db.results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.stuDetails, "sid", "rollNo", result.id);
            return View(result);
        }

        // POST: results/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "teacher")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sid,id,m1,m2,m3,total,grade")] result result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.stuDetails, "sid", "rollNo", result.id);
            return View(result);
        }
        [Authorize(Roles = "teacher")]
        // GET: results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            result result = db.results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }
        [Authorize(Roles = "teacher")]
        // POST: results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            result result = db.results.Find(id);
            db.results.Remove(result);
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

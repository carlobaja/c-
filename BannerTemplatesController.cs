using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudEntity.Context;
using CrudEntity.Models;

namespace CrudEntity.Controllers
{
    public class BannerTemplatesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: BannerTemplates
        public ActionResult Index()
        {
            return View(db.BannerTemplates.ToList());
        }
        // GET: BannerTemplates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BannerTemplate bannerTemplate = db.BannerTemplates.Find(id);
            if (bannerTemplate == null)
            {
                return HttpNotFound();
            }
            return View(bannerTemplate);
        }
        // GET: BannerTemplates/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult GetBanner(string template)
        {
            return PartialView();
        }
        //public ActionResult GetBanner()
        //{
        //    return View();
        //}

        // POST: BannerTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TemplateBanner")] BannerTemplate bannerTemplate)
        {
            var items = db.TemplateBanners.ToList();
            if (items!=null)
            {
                ViewBag.data = items;
            }
            if (ModelState.IsValid)
            {
                db.BannerTemplates.Add(bannerTemplate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bannerTemplate);
        }
        
        // GET: BannerTemplates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BannerTemplate bannerTemplate = db.BannerTemplates.Find(id);
            if (bannerTemplate == null)
            {
                return HttpNotFound();
            }
            return View(bannerTemplate);
        }
        // POST: BannerTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TemplateBanner")] BannerTemplate bannerTemplate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bannerTemplate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bannerTemplate);
        }
        // GET: BannerTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BannerTemplate bannerTemplate = db.BannerTemplates.Find(id);
            if (bannerTemplate == null)
            {
                return HttpNotFound();
            }
            return View(bannerTemplate);
        }
        // POST: BannerTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BannerTemplate bannerTemplate = db.BannerTemplates.Find(id);
            db.BannerTemplates.Remove(bannerTemplate);
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

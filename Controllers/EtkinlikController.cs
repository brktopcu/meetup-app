using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EtkinlikSitesi.Models;
using etkinlikSitesi.Models;

namespace EtkinlikSitesi.Controllers
{
    
    public class EtkinlikController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Etkinlik
        public ActionResult Index()
        {

            var etkinlik = db.Etkinlik;

            return View(etkinlik.ToList());
        }
 
        public ActionResult Filter(int? id)
        {
            var etkinlik = db.Etkinlik.Where(x=> x.EtkinlikTuruID==id);
            return View("Index",etkinlik.ToList());

        }
       



        // GET: Etkinlik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etkinlik etkinlik = db.Etkinlik.Find(id);
            if (etkinlik == null)
            {
                return HttpNotFound();
            }
            return View(etkinlik);
        }

        // GET: Etkinlik/Create
        
        public ActionResult Create()
        {
            ViewBag.EtkinlikTuruID = new SelectList(db.EtkinlikTuru, "EtkinlikTuruID", "EtkinlikTuruAdi");
            return View();
        }

        // POST: Etkinlik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EtkinlikID,EtkinlikTuruID,EtkinlikAdi,EtkinlikAciklama,EtkinlikZamani,EtkinlikYeri")] Etkinlik etkinlik)
        {
            if (ModelState.IsValid)
            {
                db.Etkinlik.Add(etkinlik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EtkinlikTuruID = new SelectList(db.EtkinlikTuru, "EtkinlikTuruID", "EtkinlikTuruAdi", etkinlik.EtkinlikTuruID);
            return View(etkinlik);
        }

        // GET: Etkinlik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etkinlik etkinlik = db.Etkinlik.Find(id);
            if (etkinlik == null)
            {
                return HttpNotFound();
            }
            ViewBag.EtkinlikTuruID = new SelectList(db.EtkinlikTuru, "EtkinlikTuruID", "EtkinlikTuruAdi", etkinlik.EtkinlikTuruID);
            return View(etkinlik);
        }

        // POST: Etkinlik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EtkinlikID,EtkinlikTuruID,EtkinlikAdi")] Etkinlik etkinlik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etkinlik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EtkinlikTuruID = new SelectList(db.EtkinlikTuru, "EtkinlikTuruID", "EtkinlikTuruAdi", etkinlik.EtkinlikTuruID);
            return View(etkinlik);
        }

        // GET: Etkinlik/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etkinlik etkinlik = db.Etkinlik.Find(id);
            if (etkinlik == null)
            {
                return HttpNotFound();
            }
            return View(etkinlik);
        }

        // POST: Etkinlik/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etkinlik etkinlik = db.Etkinlik.Find(id);
            db.Etkinlik.Remove(etkinlik);
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

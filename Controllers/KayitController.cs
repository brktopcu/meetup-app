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
    public class KayitController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Kayit
        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                var kayitlar = db.Kayit.Include(k => k.ApplicationUser).Include(k => k.Etkinlik).Where(x => x.EtkinlikID == id);
                if (kayitlar != null)
                {
                    return View("Katilacaklar", kayitlar.ToList());
                }
                else return View("KatilanYok");

            }
            var kayits = db.Kayit.Include(k => k.ApplicationUser).Include(k => k.Etkinlik);
            return View(kayits.ToList());
        }

        public ActionResult Katil(int? id)
        {
            if( id.HasValue && User.Identity.IsAuthenticated)
            { 
            Kayit yeni = new Kayit();
            yeni.EtkinlikID = id.Value;
               
            var kullanici = Session["id"].ToString();
            yeni.ApplicationUserID = kullanici;
            db.Kayit.Add(yeni);
            db.SaveChanges();

            var kayits = db.Kayit.Include(k => k.ApplicationUser).Include(k => k.Etkinlik).Where(x => x.ApplicationUserID == kullanici);

            return View("Index", kayits.ToList());
            }
            return View("../Account/Register");
        }
        public ActionResult Katildiklarim()
        {
            if (User.Identity.IsAuthenticated && Session["id"]!=null)
            {
                var kullanici = Session["id"].ToString();
                var kayits = db.Kayit.Include(k => k.ApplicationUser).Include(k => k.Etkinlik).Where(x=>x.ApplicationUserID==kullanici);
                return View("Index",kayits.ToList());
            }
            return View("../Account/Register");
        }

        // GET: Kayit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kayit kayit = db.Kayit.Find(id);
            if (kayit == null)
            {
                return HttpNotFound();
            }
            return View(kayit);
        }

        // GET: Kayit/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.ApplicationUserID = new SelectList(db.ApplicationUser, "Id", "AdiSoyadi");
            ViewBag.EtkinlikID = new SelectList(db.Etkinlik, "EtkinlikID", "EtkinlikAdi");
            return View();
        }

        // POST: Kayit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KayitID,EtkinlikID,ApplicationUserID")] Kayit kayit)
        {
            if (ModelState.IsValid)
            {
                db.Kayit.Add(kayit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserID = new SelectList(db.ApplicationUser, "Id", "AdiSoyadi", kayit.ApplicationUserID);
            ViewBag.EtkinlikID = new SelectList(db.Etkinlik, "EtkinlikID", "EtkinlikAdi", kayit.EtkinlikID);
            return View(kayit);
        }

        // GET: Kayit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kayit kayit = db.Kayit.Find(id);
            if (kayit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserID = new SelectList(db.ApplicationUser, "Id", "AdiSoyadi", kayit.ApplicationUserID);
            ViewBag.EtkinlikID = new SelectList(db.Etkinlik, "EtkinlikID", "EtkinlikAdi", kayit.EtkinlikID);
            return View(kayit);
        }

        // POST: Kayit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KayitID,EtkinlikID,ApplicationUserID")] Kayit kayit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kayit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserID = new SelectList(db.ApplicationUser, "Id", "AdiSoyadi", kayit.ApplicationUserID);
            ViewBag.EtkinlikID = new SelectList(db.Etkinlik, "EtkinlikID", "EtkinlikAdi", kayit.EtkinlikID);
            return View(kayit);
        }

        // GET: Kayit/Delete/5
       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kayit kayit = db.Kayit.Find(id);
            if (kayit == null)
            {
                return HttpNotFound();
            }
            return View(kayit);
        }

        // POST: Kayit/Delete/5
      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kayit kayit = db.Kayit.Find(id);
            db.Kayit.Remove(kayit);
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

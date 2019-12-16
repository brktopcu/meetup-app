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
using System.IO;

namespace EtkinlikSitesi.Controllers
{
    public class EtkinlikTuruController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EtkinlikTuru
        public ActionResult Index()
        {
            return View(db.EtkinlikTuru.ToList());
        }

        // GET: EtkinlikTuru/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtkinlikTuru etkinlikTuru = db.EtkinlikTuru.Find(id);
            if (etkinlikTuru == null)
            {
                return HttpNotFound();
            }
            return View(etkinlikTuru);
        }

        // GET: EtkinlikTuru/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EtkinlikTuru/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EtkinlikTuruID,EtkinlikTuruAdi,EtkinlikTuruAciklama,EtkinlikTuruResmi")] EtkinlikTuru etkinlikTuru, HttpPostedFileBase resim)
        {
            if (ModelState.IsValid)
            {
                if (resim != null && resim.ContentLength > 0)
                {
                    MemoryStream memoryStream = resim.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        resim.InputStream.CopyTo(memoryStream);
                    }
                    etkinlikTuru.EtkinlikTuruResmi = memoryStream.ToArray();
                }

                db.EtkinlikTuru.Add(etkinlikTuru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etkinlikTuru);
        }

        // GET: EtkinlikTuru/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtkinlikTuru etkinlikTuru = db.EtkinlikTuru.Find(id);
            if (etkinlikTuru == null)
            {
                return HttpNotFound();
            }
            return View(etkinlikTuru);
        }

        // POST: EtkinlikTuru/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EtkinlikTuruID,EtkinlikTuruAdi,EtkinlikTuruAciklama")] EtkinlikTuru etkinlikTuru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etkinlikTuru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etkinlikTuru);
        }

        // GET: EtkinlikTuru/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtkinlikTuru etkinlikTuru = db.EtkinlikTuru.Find(id);
            if (etkinlikTuru == null)
            {
                return HttpNotFound();
            }
            return View(etkinlikTuru);
        }

        // POST: EtkinlikTuru/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EtkinlikTuru etkinlikTuru = db.EtkinlikTuru.Find(id);
            db.EtkinlikTuru.Remove(etkinlikTuru);
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

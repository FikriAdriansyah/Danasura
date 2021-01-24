using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Danasura_Project.Models;

namespace Danasura_Project.Controllers
{
    public class msSekolahsController : Controller
    {
        private danasuraEntities db = new danasuraEntities();

        // GET: msSekolahs
        public ActionResult Index()
        {
            return View(db.msSekolahs.ToList());
        }

        // GET: msSekolahs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msSekolah msSekolah = db.msSekolahs.Find(id);
            if (msSekolah == null)
            {
                return HttpNotFound();
            }
            return View(msSekolah);
        }

        // GET: msSekolahs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: msSekolahs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_sekolah,nama_sekolah,akreditasi,nama_cp,no_cp,alamat_sekolah,provinsi,kota,kecamatan,jml_penerimaKIP,harga_spp,harga_seragam,deskripsi,status,created_date,created_by,modified_date,modified_by")] msSekolah msSekolah)
        {
            if (ModelState.IsValid)
            {
                msSekolah.status = 1;
                msSekolah.created_date = DateTime.Now;
                msSekolah.modified_date = DateTime.Now;
                msSekolah.created_by = "Fikri Adriansyah";
                msSekolah.modified_by = "Fikri Adriansyah";
                db.msSekolahs.Add(msSekolah);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(msSekolah);
        }

        // GET: msSekolahs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msSekolah msSekolah = db.msSekolahs.Find(id);
            if (msSekolah == null)
            {
                return HttpNotFound();
            }
            return View(msSekolah);
        }

        // POST: msSekolahs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_sekolah,nama_sekolah,akreditasi,nama_cp,no_cp,alamat_sekolah,provinsi,kota,kecamatan,jml_penerimaKIP,harga_spp,harga_seragam,deskripsi,status,created_date,created_by,modified_date,modified_by")] msSekolah msSekolah)
        {
            if (ModelState.IsValid)
            {
                msSekolah.status = 1;
                msSekolah.modified_date = DateTime.Now;
                msSekolah.modified_by = "Fikri Adriansyah";
                db.Entry(msSekolah).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(msSekolah);
        }

        // GET: msSekolahs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msSekolah msSekolah = db.msSekolahs.Find(id);
            if (msSekolah == null)
            {
                return HttpNotFound();
            }
            return View(msSekolah);
        }

        // POST: msSekolahs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            msSekolah msSekolah = db.msSekolahs.Find(id);
            msSekolah.status = 0;
            msSekolah.modified_date = DateTime.Now;
            msSekolah.modified_by = "Fikri Adriansyah";
            db.Entry(msSekolah).State = EntityState.Modified;
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

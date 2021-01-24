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
    public class msSiswasController : Controller
    {
        private danasuraEntities db = new danasuraEntities();

        // GET: msSiswas
        public ActionResult Index()
        {
            var msSiswas = db.msSiswas.Include(m => m.dtNISNKJP).Include(m => m.msSekolah);
            return View(msSiswas.ToList());
        }

        // GET: msSiswas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msSiswa msSiswa = db.msSiswas.Find(id);
            if (msSiswa == null)
            {
                return HttpNotFound();
            }
            return View(msSiswa);
        }

        // GET: msSiswas/Create
        public ActionResult Create()
        {
            ViewBag.nisn = new SelectList(db.dtNISNKJPs, "nisn", "no_kip");
            ViewBag.id_sekolah = new SelectList(db.msSekolahs, "id_sekolah", "nama_sekolah");
            return View();
        }

        // POST: msSiswas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_siswa,nisn,nama,jenis_kelamin,tempat_lahir,tanggal_lahir,alamat,no_telp,nomor_kip,jenjang,id_sekolah,semester_awal,status,nama_ayah,pekerjaan_ayah,nama_ibu,pekerjaan_ibu,sb_kuota,sb_seragam,username,password,created_date,created_by,modified_date,modified_by")] msSiswa msSiswa)
        {
            if (ModelState.IsValid)
            {
                msSiswa.status = 1;
                msSiswa.created_date = DateTime.Now;
                msSiswa.modified_date = DateTime.Now;
                msSiswa.created_by = "Fikri Adriansyah";
                msSiswa.modified_by = "Fikri Adriansyah";
                db.msSiswas.Add(msSiswa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nisn = new SelectList(db.dtNISNKJPs, "nisn", "no_kip", msSiswa.nisn);
            ViewBag.id_sekolah = new SelectList(db.msSekolahs, "id_sekolah", "nama_sekolah", msSiswa.id_sekolah);
            return View(msSiswa);
        }

        // GET: msSiswas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msSiswa msSiswa = db.msSiswas.Find(id);
            if (msSiswa == null)
            {
                return HttpNotFound();
            }
            ViewBag.nisn = new SelectList(db.dtNISNKJPs, "nisn", "no_kip", msSiswa.nisn);
            ViewBag.id_sekolah = new SelectList(db.msSekolahs, "id_sekolah", "nama_sekolah", msSiswa.id_sekolah);
            return View(msSiswa);
        }

        // POST: msSiswas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_siswa,nisn,nama,jenis_kelamin,tempat_lahir,tanggal_lahir,alamat,no_telp,nomor_kip,jenjang,id_sekolah,semester_awal,status,nama_ayah,pekerjaan_ayah,nama_ibu,pekerjaan_ibu,sb_kuota,sb_seragam,username,password,created_date,created_by,modified_date,modified_by")] msSiswa msSiswa)
        {
            if (ModelState.IsValid)
            {
                msSiswa.status = 1;
                msSiswa.modified_date = DateTime.Now;
                msSiswa.modified_by = "Fikri Adriansyah";
                db.Entry(msSiswa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nisn = new SelectList(db.dtNISNKJPs, "nisn", "no_kip", msSiswa.nisn);
            ViewBag.id_sekolah = new SelectList(db.msSekolahs, "id_sekolah", "nama_sekolah", msSiswa.id_sekolah);
            return View(msSiswa);
        }

        // GET: msSiswas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msSiswa msSiswa = db.msSiswas.Find(id);
            if (msSiswa == null)
            {
                return HttpNotFound();
            }
            return View(msSiswa);
        }

        // POST: msSiswas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            msSiswa msSiswa = db.msSiswas.Find(id);
            msSiswa.status = 0;
            msSiswa.modified_date = DateTime.Now;
            msSiswa.modified_by = "Fikri Adriansyah";
            db.Entry(msSiswa).State = EntityState.Modified;
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

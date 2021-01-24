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
    public class trPermintaanBarangsController : Controller
    {
        private danasuraEntities db = new danasuraEntities();

        // GET: trPermintaanBarangs
        public ActionResult Index()
        {
            var trPermintaanBarangs = db.trPermintaanBarangs.Include(t => t.msBarang).Include(t => t.msSiswa).Include(t => t.msStaff);
            return View(trPermintaanBarangs.ToList());
        }

        // GET: trPermintaanBarangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trPermintaanBarang trPermintaanBarang = db.trPermintaanBarangs.Find(id);
            if (trPermintaanBarang == null)
            {
                return HttpNotFound();
            }
            return View(trPermintaanBarang);
        }

        // GET: trPermintaanBarangs/Create
        public ActionResult Create()
        {
            ViewBag.id_barang = new SelectList(db.msBarangs, "id_barang", "nama");
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn");
            ViewBag.id_staff = new SelectList(db.msStaffs, "id_staff", "nama_staff");
            return View();
        }

        // POST: trPermintaanBarangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_trans,tgl_trans,id_siswa,id_staff,id_barang,status,created_date,created_by,modified_date,modified_by")] trPermintaanBarang trPermintaanBarang)
        {
            if (ModelState.IsValid)
            {
                trPermintaanBarang.tgl_trans = DateTime.Now;
                trPermintaanBarang.id_siswa = Convert.ToInt32(Session["id"]);
                trPermintaanBarang.status = 1;
                trPermintaanBarang.created_date = DateTime.Now;
                trPermintaanBarang.created_by = Session["nama"].ToString();
                trPermintaanBarang.modified_date = DateTime.Now;
                trPermintaanBarang.modified_by = Session["nama"].ToString();
                db.trPermintaanBarangs.Add(trPermintaanBarang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_barang = new SelectList(db.msBarangs, "id_barang", "nama", trPermintaanBarang.id_barang);
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn", trPermintaanBarang.id_siswa);
            ViewBag.id_staff = new SelectList(db.msStaffs, "id_staff", "nama_staff", trPermintaanBarang.id_staff);
            return View(trPermintaanBarang);
        }

        // GET: trPermintaanBarangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trPermintaanBarang trPermintaanBarang = db.trPermintaanBarangs.Find(id);
            if (trPermintaanBarang == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_barang = new SelectList(db.msBarangs, "id_barang", "nama", trPermintaanBarang.id_barang);
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn", trPermintaanBarang.id_siswa);
            ViewBag.id_staff = new SelectList(db.msStaffs, "id_staff", "nama_staff", trPermintaanBarang.id_staff);
            return View(trPermintaanBarang);
        }

        // POST: trPermintaanBarangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_trans,tgl_trans,id_siswa,id_staff,id_barang,status,created_date,created_by,modified_date,modified_by")] trPermintaanBarang trPermintaanBarang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trPermintaanBarang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_barang = new SelectList(db.msBarangs, "id_barang", "nama", trPermintaanBarang.id_barang);
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn", trPermintaanBarang.id_siswa);
            ViewBag.id_staff = new SelectList(db.msStaffs, "id_staff", "nama_staff", trPermintaanBarang.id_staff);
            return View(trPermintaanBarang);
        }

        // GET: trPermintaanBarangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trPermintaanBarang trPermintaanBarang = db.trPermintaanBarangs.Find(id);
            if (trPermintaanBarang == null)
            {
                return HttpNotFound();
            }
            return View(trPermintaanBarang);
        }

        // POST: trPermintaanBarangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trPermintaanBarang trPermintaanBarang = db.trPermintaanBarangs.Find(id);
            db.trPermintaanBarangs.Remove(trPermintaanBarang);
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

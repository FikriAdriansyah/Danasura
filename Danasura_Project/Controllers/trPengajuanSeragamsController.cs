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
    public class trPengajuanSeragamsController : Controller
    {
        private danasuraEntities db = new danasuraEntities();

        // GET: trPengajuanSeragams
        public ActionResult Index()
        {
            var trPengajuanSeragams = db.trPengajuanSeragams.Include(t => t.msSiswa).Include(t => t.msStaff);
            return View(trPengajuanSeragams.ToList());
        }

        // GET: trPengajuanSeragams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trPengajuanSeragam trPengajuanSeragam = db.trPengajuanSeragams.Find(id);
            if (trPengajuanSeragam == null)
            {
                return HttpNotFound();
            }
            return View(trPengajuanSeragam);
        }

        // GET: trPengajuanSeragams/Create
        public ActionResult Create()
        {
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn");
            ViewBag.id_staff = new SelectList(db.msStaffs, "id_staff", "nama_staff");
            return View();
        }

        // POST: trPengajuanSeragams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_trans,tgl_trans,id_siswa,id_staff,ukuran,keterangan,total_biaya,status,created_date,created_by,modified_date,modified_by")] trPengajuanSeragam trPengajuanSeragam)
        {
            if (ModelState.IsValid)
            {
                trPengajuanSeragam.tgl_trans = DateTime.Now;
                trPengajuanSeragam.id_siswa = Convert.ToInt32(Session["id"]);
                trPengajuanSeragam.status = 1;
                trPengajuanSeragam.created_date = DateTime.Now;
                trPengajuanSeragam.created_by = Session["nama"].ToString();
                trPengajuanSeragam.modified_date = DateTime.Now;
                trPengajuanSeragam.modified_by = Session["nama"].ToString();
                db.trPengajuanSeragams.Add(trPengajuanSeragam);
                db.SaveChanges();
                return RedirectToAction("Index");

                msSiswa siswa = db.msSiswas.Find(Convert.ToInt32(Session["id"]));

                return View("~/Views/msSiswas/Details.cshtml", siswa);
            }

            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn", trPengajuanSeragam.id_siswa);
            ViewBag.id_staff = new SelectList(db.msStaffs, "id_staff", "nama_staff", trPengajuanSeragam.id_staff);
            return View(trPengajuanSeragam);
        }

        // GET: trPengajuanSeragams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trPengajuanSeragam trPengajuanSeragam = db.trPengajuanSeragams.Find(id);
            if (trPengajuanSeragam == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn", trPengajuanSeragam.id_siswa);
            ViewBag.id_staff = new SelectList(db.msStaffs, "id_staff", "nama_staff", trPengajuanSeragam.id_staff);
            return View(trPengajuanSeragam);
        }

        // POST: trPengajuanSeragams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_trans,tgl_trans,id_siswa,id_staff,ukuran,keterangan,total_biaya,status,created_date,created_by,modified_date,modified_by")] trPengajuanSeragam trPengajuanSeragam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trPengajuanSeragam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn", trPengajuanSeragam.id_siswa);
            ViewBag.id_staff = new SelectList(db.msStaffs, "id_staff", "nama_staff", trPengajuanSeragam.id_staff);
            return View(trPengajuanSeragam);
        }

        // GET: trPengajuanSeragams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trPengajuanSeragam trPengajuanSeragam = db.trPengajuanSeragams.Find(id);
            if (trPengajuanSeragam == null)
            {
                return HttpNotFound();
            }
            return View(trPengajuanSeragam);
        }

        // POST: trPengajuanSeragams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trPengajuanSeragam trPengajuanSeragam = db.trPengajuanSeragams.Find(id);
            db.trPengajuanSeragams.Remove(trPengajuanSeragam);
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

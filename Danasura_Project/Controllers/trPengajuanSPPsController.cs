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
    public class trPengajuanSPPsController : Controller
    {
        private danasuraEntities db = new danasuraEntities();

        // GET: trPengajuanSPPs
        public ActionResult Index()
        {
            var trPengajuanSPPs = db.trPengajuanSPPs.Include(t => t.msSiswa).Include(t => t.msStaff);
            return View(trPengajuanSPPs.ToList());
        }

        // GET: trPengajuanSPPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trPengajuanSPP trPengajuanSPP = db.trPengajuanSPPs.Find(id);
            if (trPengajuanSPP == null)
            {
                return HttpNotFound();
            }
            return View(trPengajuanSPP);
        }

        // GET: trPengajuanSPPs/Create
        public ActionResult Create()
        {
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn");
            ViewBag.id_staff = new SelectList(db.msStaffs, "id_staff", "nama_staff");
            return View();
        }

        // POST: trPengajuanSPPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_trans,tgl_trans,id_siswa,id_staff,jml_bulan,total_biaya,status,created_date,created_by,modified_date,modified_by")] trPengajuanSPP trPengajuanSPP)
        {
            if (ModelState.IsValid)
            {
                trPengajuanSPP.tgl_trans = DateTime.Now;
                trPengajuanSPP.id_siswa = Convert.ToInt32(Session["id"]);
                trPengajuanSPP.status = 1;
                trPengajuanSPP.created_date = DateTime.Now;
                trPengajuanSPP.created_by = Session["nama"].ToString();
                trPengajuanSPP.modified_date = DateTime.Now;
                trPengajuanSPP.modified_by = Session["nama"].ToString();
                db.trPengajuanSPPs.Add(trPengajuanSPP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn", trPengajuanSPP.id_siswa);
            ViewBag.id_staff = new SelectList(db.msStaffs, "id_staff", "nama_staff", trPengajuanSPP.id_staff);
            return View(trPengajuanSPP);
        }

        // GET: trPengajuanSPPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trPengajuanSPP trPengajuanSPP = db.trPengajuanSPPs.Find(id);
            if (trPengajuanSPP == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn", trPengajuanSPP.id_siswa);
            ViewBag.id_staff = new SelectList(db.msStaffs, "id_staff", "nama_staff", trPengajuanSPP.id_staff);
            return View(trPengajuanSPP);
        }

        // POST: trPengajuanSPPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_trans,tgl_trans,id_siswa,id_staff,jml_bulan,total_biaya,status,created_date,created_by,modified_date,modified_by")] trPengajuanSPP trPengajuanSPP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trPengajuanSPP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn", trPengajuanSPP.id_siswa);
            ViewBag.id_staff = new SelectList(db.msStaffs, "id_staff", "nama_staff", trPengajuanSPP.id_staff);
            return View(trPengajuanSPP);
        }

        // GET: trPengajuanSPPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trPengajuanSPP trPengajuanSPP = db.trPengajuanSPPs.Find(id);
            if (trPengajuanSPP == null)
            {
                return HttpNotFound();
            }
            return View(trPengajuanSPP);
        }

        // POST: trPengajuanSPPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trPengajuanSPP trPengajuanSPP = db.trPengajuanSPPs.Find(id);
            db.trPengajuanSPPs.Remove(trPengajuanSPP);
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

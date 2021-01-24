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
    public class msStaffsController : Controller
    {
        private danasuraEntities db = new danasuraEntities();

        // GET: msStaffs
        public ActionResult Index()
        {
            return View(db.msStaffs.ToList());
        }

        // GET: msStaffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msStaff msStaff = db.msStaffs.Find(id);
            if (msStaff == null)
            {
                return HttpNotFound();
            }
            return View(msStaff);
        }

        // GET: msStaffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: msStaffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_staff,nama_staff,jenis_kelamin,no_ktp,tempat_lahir,tanggal_lahir,alamat,no_telp,pendidikan_terakhir,tahun_masuk,username,password,role,status,created_date,created_by,modified_date,modified_by")] msStaff msStaff)
        {
            if (ModelState.IsValid)
            {
                msStaff.status = 1;
                msStaff.created_date = DateTime.Now;
                msStaff.modified_date = DateTime.Now;
                msStaff.created_by = "Fikri Adriansyah";
                msStaff.modified_by = "Fikri Adriansyah";
                db.msStaffs.Add(msStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(msStaff);
        }

        // GET: msStaffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msStaff msStaff = db.msStaffs.Find(id);
            if (msStaff == null)
            {
                return HttpNotFound();
            }
            return View(msStaff);
        }

        // POST: msStaffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_staff,nama_staff,jenis_kelamin,no_ktp,tempat_lahir,tanggal_lahir,alamat,no_telp,pendidikan_terakhir,tahun_masuk,username,password,role,status,created_date,created_by,modified_date,modified_by")] msStaff msStaff)
        {
            if (ModelState.IsValid)
            {
                msStaff.status = 1;
                msStaff.modified_date = DateTime.Now;
                msStaff.modified_by = "Fikri Adriansyah";
                db.Entry(msStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(msStaff);
        }

        // GET: msStaffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msStaff msStaff = db.msStaffs.Find(id);
            if (msStaff == null)
            {
                return HttpNotFound();
            }
            return View(msStaff);
        }

        // POST: msStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            msStaff msStaff = db.msStaffs.Find(id);
            msStaff.status = 0;
            msStaff.modified_date = DateTime.Now;
            msStaff.modified_by = "Fikri Adriansyah";
            db.Entry(msStaff).State = EntityState.Modified;
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

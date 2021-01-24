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
    public class msDonatursController : Controller
    {
        private danasuraEntities db = new danasuraEntities();

        // GET: msDonaturs
        public ActionResult Index()
        {
            return View(db.msDonaturs.ToList());
        }

        // GET: msDonaturs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msDonatur msDonatur = db.msDonaturs.Find(id);
            if (msDonatur == null)
            {
                return HttpNotFound();
            }
            return View(msDonatur);
        }

        // GET: msDonaturs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: msDonaturs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_donatur,nama,no_ktp,tempat_lahir,tanggal_lahir,jenis_kelamin,alamat,agama,pekerjaan,kewarganegaraan,username,password,email,created_date,modified_date")] msDonatur msDonatur)
        {
            if (ModelState.IsValid)
            {
                msDonatur.created_date = DateTime.Now;
                msDonatur.modified_date = DateTime.Now;
                db.msDonaturs.Add(msDonatur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(msDonatur);
        }

        // GET: msDonaturs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msDonatur msDonatur = db.msDonaturs.Find(id);
            if (msDonatur == null)
            {
                return HttpNotFound();
            }
            return View(msDonatur);
        }

        // POST: msDonaturs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_donatur,nama,no_ktp,tempat_lahir,tanggal_lahir,jenis_kelamin,alamat,agama,pekerjaan,kewarganegaraan,username,password,email,created_date,modified_date")] msDonatur msDonatur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(msDonatur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(msDonatur);
        }

        // GET: msDonaturs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msDonatur msDonatur = db.msDonaturs.Find(id);
            if (msDonatur == null)
            {
                return HttpNotFound();
            }
            return View(msDonatur);
        }

        // POST: msDonaturs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            msDonatur msDonatur = db.msDonaturs.Find(id);
            db.msDonaturs.Remove(msDonatur);
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

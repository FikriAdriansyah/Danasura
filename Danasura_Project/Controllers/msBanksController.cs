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
    public class msBanksController : Controller
    {
        private danasuraEntities db = new danasuraEntities();
        
        // GET: msBanks
        public ActionResult Index()
        {
            return View(db.msBanks.ToList());
        }

        // GET: msBanks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msBank msBank = db.msBanks.Find(id);
            if (msBank == null)
            {
                return HttpNotFound();
            }
            return View(msBank);
        }

        // GET: msBanks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: msBanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_bank,nama_bank,atas_nama,no_rekening,status,created_date,created_by,modified_date,modified_by")] msBank msBank)
        {
            if (ModelState.IsValid)
            {
                msBank.status = 1;
                msBank.created_date = DateTime.Now;
                msBank.modified_date = DateTime.Now;
                msBank.created_by = "Fikri Adriansyah";
                msBank.modified_by = "Fikri Adriansyah";
                db.msBanks.Add(msBank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(msBank);
        }

        // GET: msBanks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msBank msBank = db.msBanks.Find(id);
            if (msBank == null)
            {
                return HttpNotFound();
            }
            return View(msBank);
        }

        // POST: msBanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_bank,nama_bank,atas_nama,no_rekening,status,created_date,created_by,modified_date,modified_by")] msBank msBank)
        {
            if (ModelState.IsValid)
            {
                msBank.status = 1;
                msBank.modified_date = DateTime.Now;
                msBank.modified_by = "Fikri Adriansyah";
                db.Entry(msBank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(msBank);
        }

        // GET: msBanks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msBank msBank = db.msBanks.Find(id);
            if (msBank == null)
            {
                return HttpNotFound();
            }
            return View(msBank);
        }

        // POST: msBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            msBank msBank = db.msBanks.Find(id);
            msBank.status = 0;
            msBank.modified_date = DateTime.Now;
            msBank.modified_by = "Fikri Adriansyah";
            db.Entry(msBank).State = EntityState.Modified;
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

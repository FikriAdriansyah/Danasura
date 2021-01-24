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
    public class msKategoriBarangsController : Controller
    {
        private danasuraEntities db = new danasuraEntities();

        // GET: msKategoriBarangs
        public ActionResult Index()
        {
            return View(db.msKategoriBarangs.ToList());
        }

        // GET: msKategoriBarangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msKategoriBarang msKategoriBarang = db.msKategoriBarangs.Find(id);
            if (msKategoriBarang == null)
            {
                return HttpNotFound();
            }
            return View(msKategoriBarang);
        }

        // GET: msKategoriBarangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: msKategoriBarangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_kategori,nama,status,created_date,created_by,modified_date,modified_by")] msKategoriBarang msKategoriBarang)
        {
            if (ModelState.IsValid)
            {
                msKategoriBarang.status = 1;
                msKategoriBarang.created_date = DateTime.Now;
                msKategoriBarang.modified_date = DateTime.Now;
                msKategoriBarang.created_by = "Fikri Adriansyah";
                msKategoriBarang.modified_by = "Fikri Adriansyah";
                db.msKategoriBarangs.Add(msKategoriBarang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(msKategoriBarang);
        }

        // GET: msKategoriBarangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msKategoriBarang msKategoriBarang = db.msKategoriBarangs.Find(id);
            if (msKategoriBarang == null)
            {
                return HttpNotFound();
            }
            return View(msKategoriBarang);
        }

        // POST: msKategoriBarangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_kategori,nama,status,created_date,created_by,modified_date,modified_by")] msKategoriBarang msKategoriBarang)
        {
            if (ModelState.IsValid)
            {
                msKategoriBarang.status = 1;
                msKategoriBarang.modified_date = DateTime.Now;
                msKategoriBarang.modified_by = "Fikri Adriansyah";
                db.Entry(msKategoriBarang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(msKategoriBarang);
        }

        // GET: msKategoriBarangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msKategoriBarang msKategoriBarang = db.msKategoriBarangs.Find(id);
            if (msKategoriBarang == null)
            {
                return HttpNotFound();
            }
            return View(msKategoriBarang);
        }

        // POST: msKategoriBarangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            msKategoriBarang msKategoriBarang = db.msKategoriBarangs.Find(id);
            msKategoriBarang.status = 0;
            msKategoriBarang.modified_date = DateTime.Now;
            msKategoriBarang.modified_by = "Fikri Adriansyah";
            db.Entry(msKategoriBarang).State = EntityState.Modified;
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

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
    public class msBarangsController : Controller
    {
        private danasuraEntities db = new danasuraEntities();

        // GET: msBarangs
        public ActionResult Index()
        {
            var msBarangs = db.msBarangs.Include(m => m.msKategoriBarang);
            return View(msBarangs.ToList());
        }

        // GET: msBarangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msBarang msBarang = db.msBarangs.Find(id);
            if (msBarang == null)
            {
                return HttpNotFound();
            }
            return View(msBarang);
        }

        // GET: msBarangs/Create
        public ActionResult Create()
        {
            ViewBag.id_kategori = new SelectList(db.msKategoriBarangs, "id_kategori", "nama");
            return View();
        }

        // POST: msBarangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_barang,nama,id_kategori,merk,berat,kondisi,keterangan,status,created_date,created_by,modified_date,modified_by")] msBarang msBarang)
        {
            if (ModelState.IsValid)
            {
                msBarang.status = 1;
                msBarang.created_date = DateTime.Now;
                msBarang.created_by = Session["nama"].ToString();
                msBarang.modified_date = DateTime.Now;
                msBarang.modified_by = Session["nama"].ToString();
                db.msBarangs.Add(msBarang);
                db.SaveChanges();
                return RedirectToAction("Create", "trDonasiBarangs", new { id_barang = msBarang.id_barang });
            }

            ViewBag.id_kategori = new SelectList(db.msKategoriBarangs, "id_kategori", "nama", msBarang.id_kategori);
            return RedirectToAction("Index");
            //return View(msBarang);
        }

        // GET: msBarangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msBarang msBarang = db.msBarangs.Find(id);
            if (msBarang == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_kategori = new SelectList(db.msKategoriBarangs, "id_kategori", "nama", msBarang.id_kategori);
            return View(msBarang);
        }

        // POST: msBarangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_barang,nama,id_kategori,merk,berat,kondisi,keterangan,status,created_date,created_by,modified_date,modified_by")] msBarang msBarang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(msBarang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_kategori = new SelectList(db.msKategoriBarangs, "id_kategori", "nama", msBarang.id_kategori);
            return View(msBarang);
        }

        // GET: msBarangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msBarang msBarang = db.msBarangs.Find(id);
            if (msBarang == null)
            {
                return HttpNotFound();
            }
            return View(msBarang);
        }

        // POST: msBarangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            msBarang msBarang = db.msBarangs.Find(id);
            db.msBarangs.Remove(msBarang);
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

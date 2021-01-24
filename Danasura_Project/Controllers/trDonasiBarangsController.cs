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
    public class trDonasiBarangsController : Controller
    {
        private danasuraEntities db = new danasuraEntities();

        // GET: trDonasiBarangs
        public ActionResult Index()
        {
            var trDonasiBarangs = db.trDonasiBarangs.Include(t => t.msDonatur).Include(t => t.msKategoriBarang);
            return View(trDonasiBarangs.ToList());
        }

        // GET: trDonasiBarangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trDonasiBarang trDonasiBarang = db.trDonasiBarangs.Find(id);
            if (trDonasiBarang == null)
            {
                return HttpNotFound();
            }
            return View(trDonasiBarang);
        }

        // GET: trDonasiBarangs/Create
        //public ActionResult Create()
        //{
        //    ViewBag.id_donatur = new SelectList(db.msDonaturs, "id_donatur", "nama");
        //    ViewBag.id_kategori = new SelectList(db.msKategoriBarangs, "id_kategori", "nama");
        //    return View();
        //}

        // POST: trDonasiBarangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_trans,tgl_trans,nama_barang,id_donatur,id_kategori,kondisi,keterangan,status,created_date,created_by,modified_date,modified_by")] trDonasiBarang trDonasiBarang)
        {
            if (ModelState.IsValid)
            {
                trDonasiBarang.tgl_trans = DateTime.Now;
                trDonasiBarang.id_donatur = Convert.ToInt32(Session["id"]);
                trDonasiBarang.status = 1;
                trDonasiBarang.created_date = DateTime.Now;
                trDonasiBarang.created_by = Session["nama"].ToString();
                trDonasiBarang.modified_date = DateTime.Now;
                trDonasiBarang.modified_by = Session["nama"].ToString();
                db.trDonasiBarangs.Add(trDonasiBarang);
                db.SaveChanges();
                
                msDonatur donatur = db.msDonaturs.Find(Convert.ToInt32(Session["id"]));

                return View("~/Views/msDonaturs/Details.cshtml", donatur);
            }

            ViewBag.id_donatur = new SelectList(db.msDonaturs, "id_donatur", "nama", trDonasiBarang.id_donatur);
            ViewBag.id_kategori = new SelectList(db.msKategoriBarangs, "id_kategori", "nama", trDonasiBarang.id_kategori);
            return View(trDonasiBarang);
        }

        public ActionResult Create(int? id_barang)
        {
            msBarang msBarang = db.msBarangs.Find(id_barang);

            trDonasiBarang trDonasiBarang = new trDonasiBarang();

            trDonasiBarang.tgl_trans = DateTime.Now;
            trDonasiBarang.nama_barang = msBarang.nama;
            trDonasiBarang.id_donatur = Convert.ToInt32(Session["id"]);
            trDonasiBarang.id_kategori = msBarang.id_kategori;
            trDonasiBarang.kondisi = msBarang.kondisi;
            trDonasiBarang.keterangan = msBarang.keterangan;
            trDonasiBarang.status = 1;
            trDonasiBarang.created_date = DateTime.Now;
            trDonasiBarang.created_by = Session["nama"].ToString();
            trDonasiBarang.modified_date = DateTime.Now;
            trDonasiBarang.modified_by = Session["nama"].ToString();
            db.trDonasiBarangs.Add(trDonasiBarang);
            db.SaveChanges();

            msDonatur donatur = db.msDonaturs.Find(Convert.ToInt32(Session["id"]));

            return View("~/Views/msDonaturs/Details.cshtml", donatur);
        }

        // GET: trDonasiBarangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trDonasiBarang trDonasiBarang = db.trDonasiBarangs.Find(id);
            if (trDonasiBarang == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_donatur = new SelectList(db.msDonaturs, "id_donatur", "nama", trDonasiBarang.id_donatur);
            ViewBag.id_kategori = new SelectList(db.msKategoriBarangs, "id_kategori", "nama", trDonasiBarang.id_kategori);
            return View(trDonasiBarang);
        }

        // POST: trDonasiBarangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_trans,tgl_trans,nama_barang,id_donatur,id_kategori,kondisi,keterangan,status,created_date,created_by,modified_date,modified_by")] trDonasiBarang trDonasiBarang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trDonasiBarang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_donatur = new SelectList(db.msDonaturs, "id_donatur", "nama", trDonasiBarang.id_donatur);
            ViewBag.id_kategori = new SelectList(db.msKategoriBarangs, "id_kategori", "nama", trDonasiBarang.id_kategori);
            return View(trDonasiBarang);
        }

        // GET: trDonasiBarangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trDonasiBarang trDonasiBarang = db.trDonasiBarangs.Find(id);
            if (trDonasiBarang == null)
            {
                return HttpNotFound();
            }
            return View(trDonasiBarang);
        }

        // POST: trDonasiBarangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trDonasiBarang trDonasiBarang = db.trDonasiBarangs.Find(id);
            db.trDonasiBarangs.Remove(trDonasiBarang);
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

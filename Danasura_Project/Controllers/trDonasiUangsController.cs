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
    public class trDonasiUangsController : Controller
    {
        private danasuraEntities db = new danasuraEntities();

        // GET: trDonasiUangs
        public ActionResult Index()
        {
            var trDonasiUangs = db.trDonasiUangs.Include(t => t.msBank).Include(t => t.msDonatur);
            return View(trDonasiUangs.ToList());
        }

        // GET: trDonasiUangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trDonasiUang trDonasiUang = db.trDonasiUangs.Find(id);
            if (trDonasiUang == null)
            {
                return HttpNotFound();
            }
            return View(trDonasiUang);
        }

        // GET: trDonasiUangs/Create
        public ActionResult Create()
        {
            ViewBag.id_bank = new SelectList(db.msBanks, "id_bank", "nama_bank");
            ViewBag.id_donatur = new SelectList(db.msDonaturs, "id_donatur", "nama");
            return View();
        }

        // POST: trDonasiUangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_trans,tgl_trans,id_donatur,id_bank,total_donasi,status,created_date,created_by,modified_date,modified_by")] trDonasiUang trDonasiUang)
        {
            if (ModelState.IsValid)
            {
                trDonasiUang.tgl_trans = DateTime.Now;
                trDonasiUang.id_donatur = Convert.ToInt32(Session["id"]);
                trDonasiUang.status = 1;
                trDonasiUang.created_date = DateTime.Now;
                trDonasiUang.created_by = Session["nama"].ToString();
                trDonasiUang.modified_date = DateTime.Now;
                trDonasiUang.modified_by = Session["nama"].ToString();
                db.trDonasiUangs.Add(trDonasiUang);
                db.SaveChanges();

                msDonatur donatur = db.msDonaturs.Find(Convert.ToInt32(Session["id"]));

                return View("~/Views/msDonaturs/Details.cshtml", donatur);
            }

            ViewBag.id_bank = new SelectList(db.msBanks, "id_bank", "nama_bank", trDonasiUang.id_bank);
            ViewBag.id_donatur = new SelectList(db.msDonaturs, "id_donatur", "nama", trDonasiUang.id_donatur);

            return RedirectToAction("Index");
        }

        // GET: trDonasiUangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trDonasiUang trDonasiUang = db.trDonasiUangs.Find(id);
            if (trDonasiUang == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_bank = new SelectList(db.msBanks, "id_bank", "nama_bank", trDonasiUang.id_bank);
            ViewBag.id_donatur = new SelectList(db.msDonaturs, "id_donatur", "nama", trDonasiUang.id_donatur);
            return View(trDonasiUang);
        }

        // POST: trDonasiUangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_trans,tgl_trans,id_donatur,id_bank,total_donasi,status,created_date,created_by,modified_date,modified_by")] trDonasiUang trDonasiUang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trDonasiUang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_bank = new SelectList(db.msBanks, "id_bank", "nama_bank", trDonasiUang.id_bank);
            ViewBag.id_donatur = new SelectList(db.msDonaturs, "id_donatur", "nama", trDonasiUang.id_donatur);
            return View(trDonasiUang);
        }

        // GET: trDonasiUangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trDonasiUang trDonasiUang = db.trDonasiUangs.Find(id);
            if (trDonasiUang == null)
            {
                return HttpNotFound();
            }
            return View(trDonasiUang);
        }

        // POST: trDonasiUangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trDonasiUang trDonasiUang = db.trDonasiUangs.Find(id);
            db.trDonasiUangs.Remove(trDonasiUang);
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

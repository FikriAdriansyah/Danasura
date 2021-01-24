using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Danasura_Project.Models;

namespace Danasura_Project.Controllers
{
    public class trPencairanKuotasController : Controller
    {
        private danasuraEntities db = new danasuraEntities();

        // GET: trPencairanKuotas
        public ActionResult Index()
        {
            var trPencairanKuotas = db.trPencairanKuotas.Include(t => t.msProvider).Include(t => t.msSiswa);
            return View(trPencairanKuotas.ToList());
        }

        // GET: trPencairanKuotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trPencairanKuota trPencairanKuota = db.trPencairanKuotas.Find(id);
            if (trPencairanKuota == null)
            {
                return HttpNotFound();
            }
            return View(trPencairanKuota);
        }

        // GET: trPencairanKuotas/Create
        public ActionResult Create()
        {
            ViewBag.id_provider = new SelectList(db.msProviders, "id_provider", "nama_provider");
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn");
            return View();
        }

        // POST: trPencairanKuotas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_trans,tgl_trans,id_provider,id_siswa,jml_kuota,total_biaya,status,created_date,created_by,modified_date,modified_by")] trPencairanKuota trPencairanKuota)
        {
            //msProvider provider = db.msProviders.Find(Convert.ToInt32(trPencairanKuota.id_provider));
            if (ModelState.IsValid)
            {
                trPencairanKuota.jml_kuota = 1;
                trPencairanKuota.total_biaya = 50000;
                trPencairanKuota.tgl_trans = DateTime.Now;
                trPencairanKuota.id_siswa = Convert.ToInt32(Session["id"]);
                trPencairanKuota.status = 1;
                trPencairanKuota.created_date = DateTime.Now;
                trPencairanKuota.created_by = Session["nama"].ToString();
                trPencairanKuota.modified_date = DateTime.Now;
                trPencairanKuota.modified_by = Session["nama"].ToString();
                db.trPencairanKuotas.Add(trPencairanKuota);
                db.SaveChanges();
                //return RedirectToAction("Index");
                

                //trPencairanKuota.total_biaya = provider.harga;

                //db.Entry(trPencairanKuota).State = EntityState.Modified;
                

                msSiswa siswa = db.msSiswas.Find(Convert.ToInt32(Session["id"]));

                return View("~/Views/msSiswas/Details.cshtml", siswa);
            }

            ViewBag.id_provider = new SelectList(db.msProviders, "id_provider", "nama_provider", trPencairanKuota.id_provider);
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn", trPencairanKuota.id_siswa);
            return View(trPencairanKuota);
        }

        // GET: trPencairanKuotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trPencairanKuota trPencairanKuota = db.trPencairanKuotas.Find(id);
            if (trPencairanKuota == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_provider = new SelectList(db.msProviders, "id_provider", "nama_provider", trPencairanKuota.id_provider);
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn", trPencairanKuota.id_siswa);
            return View(trPencairanKuota);
        }

        // POST: trPencairanKuotas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_trans,tgl_trans,id_provider,id_siswa,jml_kuota,total_biaya,status,created_date,created_by,modified_date,modified_by")] trPencairanKuota trPencairanKuota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trPencairanKuota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_provider = new SelectList(db.msProviders, "id_provider", "nama_provider", trPencairanKuota.id_provider);
            ViewBag.id_siswa = new SelectList(db.msSiswas, "id_siswa", "nisn", trPencairanKuota.id_siswa);
            return View(trPencairanKuota);
        }

        // GET: trPencairanKuotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trPencairanKuota trPencairanKuota = db.trPencairanKuotas.Find(id);
            if (trPencairanKuota == null)
            {
                return HttpNotFound();
            }
            return View(trPencairanKuota);
        }

        // POST: trPencairanKuotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trPencairanKuota trPencairanKuota = db.trPencairanKuotas.Find(id);
            db.trPencairanKuotas.Remove(trPencairanKuota);
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

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
    public class msProvidersController : Controller
    {
        private danasuraEntities db = new danasuraEntities();

        // GET: msProviders
        public ActionResult Index()
        {
            return View(db.msProviders.ToList());
        }

        // GET: msProviders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msProvider msProvider = db.msProviders.Find(id);
            if (msProvider == null)
            {
                return HttpNotFound();
            }
            return View(msProvider);
        }

        // GET: msProviders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: msProviders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_provider,nama_provider,jenis_provider,harga,deskripsi,status,created_date,created_by,modified_date,modified_by")] msProvider msProvider)
        {
            if (ModelState.IsValid)
            {
                msProvider.status = 1;
                msProvider.created_date = DateTime.Now;
                msProvider.modified_date = DateTime.Now;
                msProvider.created_by = "Fikri Adriansyah";
                msProvider.modified_by = "Fikri Adriansyah";
                if (msProvider.jenis_provider == "SD")
                {
                    msProvider.harga = 50000;
                }
                else if (msProvider.jenis_provider == "SMP")
                {
                    msProvider.harga = 75000;
                }
                else if (msProvider.jenis_provider == "SMA")
                {
                    msProvider.harga = 100000;
                }
                db.msProviders.Add(msProvider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(msProvider);
        }

        // GET: msProviders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msProvider msProvider = db.msProviders.Find(id);
            if (msProvider == null)
            {
                return HttpNotFound();
            }

            //string currHarga = msProvider.harga.ToString();
            //currHarga.Substring(0, currHarga.Length - 3);
            //msProvider.harga = decimal.Parse(currHarga);
            
            return View(msProvider);
        }

        // POST: msProviders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_provider,nama_provider,jenis_provider,harga,deskripsi,status,created_date,created_by,modified_date,modified_by")] msProvider msProvider)
        {
            if (ModelState.IsValid)
            {
                msProvider.status = 1;
                msProvider.modified_date = DateTime.Now;
                msProvider.modified_by = "Fikri Adriansyah";
                db.Entry(msProvider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(msProvider);
        }

        // GET: msProviders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            msProvider msProvider = db.msProviders.Find(id);
            if (msProvider == null)
            {
                return HttpNotFound();
            }
            return View(msProvider);
        }

        // POST: msProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            msProvider msProvider = db.msProviders.Find(id);
            msProvider.status = 0;
            msProvider.modified_date = DateTime.Now;
            msProvider.modified_by = "Fikri Adriansyah";
            db.Entry(msProvider).State = EntityState.Modified;
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

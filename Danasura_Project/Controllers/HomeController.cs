using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Danasura_Project.Models;

namespace Danasura_Project.Controllers
{
    public class HomeController : Controller
    {
        #region login donatur
        public ActionResult LoginDonatur()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginDonatur(msDonatur donatur)
        {
            if (ModelState.IsValid)
            {
                using (danasuraEntities db = new danasuraEntities())
                {
                    var obj = db.msDonaturs.Where(x => x.username == donatur.username && x.password == donatur.password).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["id"] = obj.id_donatur.ToString();
                        Session["nama"] = obj.nama.ToString();
                        //return RedirectToAction("DonaturMenu");
                        return View("~/Views/msDonaturs/Details.cshtml", obj);
                    }
                }
            }
            return View(donatur);
        }


        #endregion

        #region login siswa
        public ActionResult LoginSiswa()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginSiswa(msSiswa siswa)
        {
            if (ModelState.IsValid)
            {
                using (danasuraEntities db = new danasuraEntities())
                {
                    var obj = db.msSiswas.Where(x => x.username == siswa.username && x.password == siswa.password).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["id"] = obj.id_siswa.ToString();
                        Session["nama"] = obj.nama.ToString();
                        Session["jenjang"] = obj.jenjang.ToString();
                        //return RedirectToAction("DonaturMenu");
                        return View("~/Views/msSiswas/Details.cshtml", obj);
                    }
                }
            }
            return View(siswa);
        }


        #endregion

        #region login staff
        public ActionResult LoginStaff()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginStaff(msStaff staff)
        {
            if (ModelState.IsValid)
            {
                using (danasuraEntities db = new danasuraEntities())
                {
                    var obj = db.msStaffs.Where(x => x.username == staff.username && x.password == staff.password).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["id"] = obj.id_staff.ToString();
                        Session["nama"] = obj.nama_staff.ToString();
                        //return RedirectToAction("DonaturMenu");
                        return View("~/Views/msStaffs/Details.cshtml", obj);
                    }
                }
            }
            return View(staff);
        }


        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
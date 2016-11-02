using HardBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardBank.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            checkSession();
            return View();
        }

        public ActionResult OmOss()
        {
            checkSession();

            var nyAntall = new BankService();
            int tell = nyAntall.antallKunder();

            ViewBag.OmOss = tell;

            return View();
        }


        [HttpPost]
        public ActionResult RedirectLogin(Kunde kunde)
        {
            return RedirectToAction("Login", "", new { id = kunde.id });
        }

        public void checkSession()
        {
            if (Session["LoggetInn"] == null)
            {
                Session["Id"] = null;
                ViewBag.Id = null;
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Id = Session["Id"];

                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }

        }

    }
}
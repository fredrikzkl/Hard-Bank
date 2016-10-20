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

            return View();
        }

        [HttpPost]
        public ActionResult RedirectLogin(Kunde kunde)
        {
            return RedirectToAction("Login", "", new { id = kunde.id });
        }

    }
}
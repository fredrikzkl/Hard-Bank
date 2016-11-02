using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardAdmin.Models;
using HardBank;
using HardBank.Models;
using System.Web.Services;

namespace HardAdmin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminSide()
        {
            var user = Session["LoggedIn"]; //Dette skal byttes til "hent bruker med dette navnet"
            if (Session["LoggedIn"] != null) //Dette skal sjekke om den innloggede sitt navn er likt session 
            {
                var db = new BankContext();
                List<Betalinger> bl = db.Betalinger.ToList();
                AdminSideModel model = new AdminSideModel(bl);

                return View(model);
            }else
            {
                return RedirectToAction("Index","");
            }
        }

        [WebMethod]
        public bool Login(string username, string password)
        {
            if (username.Equals("admin") && password.Equals("admin"))
            {
                Session["LoggedIn"] = username;
                return true;
            }

            return false;
        }

        public ActionResult Logout()
        {
            Session["LoggedIn"] = null;
            return RedirectToAction("Index", "Index");
        }

        public ActionResult GetPartial()
        {
            return PartialView("_RegBetalingPartial");
        }

    }
}
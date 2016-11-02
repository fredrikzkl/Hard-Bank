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
            var db = new BankContext();
            List<Betalinger> bl = db.Betalinger.ToList();
            AdminSideModel model = new AdminSideModel(bl);
           
            return View(model);
        }

        [WebMethod]
        public bool Login(string username, string password)
        {
            if (username.Equals("admin") && password.Equals("admin"))
            {
                return true;
            }

            return false;
        }

        public ActionResult GetPartial()
        {
            return PartialView("_RegBetalingPartial");
        }

    }
}
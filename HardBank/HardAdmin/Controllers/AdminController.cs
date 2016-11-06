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
using BLL;

namespace HardAdmin.Controllers
{
    public class AdminController : Controller
    {

        private IAdminService _adminService;

        public AdminController()
        {
            _adminService = new AdminService();
        }

        public AdminController(IAdminService stub)
        {
            _adminService = stub;
        }

        // GET: Admin
        public ActionResult AdminSide()
        {
            if (Session["LoggedIn"] != null) //Dette skal sjekke om den innloggede sitt navn er likt session 
            {
                var db = new BankContext();
                List<Betalinger> bl = _adminService.hentAlleBetalinger();
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
            if (_adminService.validateLogin(username, password))
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
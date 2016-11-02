using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace HardAdmin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminSide()
        {
            return View();
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

      


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Web.Services;

namespace HardAdmin.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            if(Session["LoggedIn"] != null)
            {
                return RedirectToAction("AdminSide", "Admin");
            }
            else
            {
                return View();
            }
        }


    }
}
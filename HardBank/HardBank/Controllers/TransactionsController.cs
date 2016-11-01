using DAL;
using HardBank.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardBank.Controllers
{
    public class TransactionsController : Controller
    {
        

        public JsonResult HentAlleKontoerTilKunde(string id)
        {
            using (var db = new BankContext())
            {

                List<Kontoer> transactions = db.Kontoer.Where(k => k.KundeId == id).ToList();
                return Json(transactions, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
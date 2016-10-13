using HardBank.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardBank.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            checkSession();
            return View();
        }

        public ActionResult NewMember()
        {
            checkSession();
            return View();
        }


        [HttpPost]
        public ActionResult NewMember(Kunde innListe)
        {
            checkSession();
            try
            {
                using (var database = new Models.KundeContext())
                {
                    var nyKunde = new Models.Kunder();
                    nyKunde.Fornavn = innListe.fornavn;
                    nyKunde.Etternavn = innListe.etternavn;
                    nyKunde.PersonNr = innListe.personnr;
                    nyKunde.Adresse = innListe.adresse;

                    nyKunde.Passord = lagHash(innListe.passord);
     
                    database.Kunder.Add(nyKunde);
                    database.SaveChanges();
                    return RedirectToAction("Index", "");
                }
            }
            catch(Exception feil)
            {
                Response.Write("<div style='padding-top:1em;' class='container centered'><div class='alert alert-danger'>Kunne ikke legge til bruker</div></div>");
                return View();
            }

            return View();
        }

        private static byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }        private static bool Bruker_i_DB(Kunde innKunde)
        {

            using (var db = new KundeContext())
            {
                byte[] passordDb = lagHash(innKunde.passord);
                Kunder funnetBruker = db.Kunder.FirstOrDefault
                (b => b.Passord == passordDb && b.PersonNr == innKunde.personnr);
                if (funnetBruker == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        [HttpPost]
        public ActionResult Login(Kunde loginForm)
        {
            checkSession();

            if (Bruker_i_DB(loginForm))
            {
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                Session["ID"] = loginForm.id;
                Console.WriteLine("ID: " + loginForm.id);
                return RedirectToAction("MinSide", new {loginForm.id});
            }
            else
            {
                Response.Write("<div style='padding-top:1em;' class='container centered'><div class='alert alert-danger'>Brukernavn eller passord er feil!</div></div>");
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }

            
        }


        public ActionResult Login()
        {
            checkSession();
            return View();
        }

        public ActionResult Logout()
        {
            Session["LoggetInn"] = false;
            ViewBag.Innlogget = false;
            checkSession();
            return RedirectToAction("Index", "");
        }


        public ActionResult Minside(int id)
        {
            checkSession();
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    var db = new DBKunde();
                    var kunde = db.hentKunde(id);

                    return View(kunde);
                }
            }
            return RedirectToAction("Index","");
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
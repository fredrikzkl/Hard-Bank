using HardBank.Models;
using HardBank.ViewModels;
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
            

            if (ModelState.IsValid) { 
            try
            {
               if (Bruker_i_DB(innListe))
               {
                return RedirectToAction("Error", new { message = "En kunde med dette personnummeret er allerede registrert" });
               }
                using (var database = new Models.KundeContext())
                {
                    var nyKunde = new Models.Kunder();
                    nyKunde.Fornavn = innListe.fornavn;
                    nyKunde.Etternavn = innListe.etternavn;
                    nyKunde.PersonNr = innListe.personnr;
                    nyKunde.Adresse = innListe.adresse;

                    nyKunde.Passord = lagHash(innListe.passord);

                    var startKonto = new Models.Kontoer();
                    startKonto.KundeId = innListe.personnr;
                    startKonto.KontoNavn = innListe.fornavn + "'s konto";
                    startKonto.Saldo = 1000;
                    

                    database.Kunder.Add(nyKunde);
                    database.Kontoer.Add(startKonto);
                    database.SaveChanges();
                    return RedirectToAction("Index", "");
                }
            }
            catch(Exception)
            {
                return RedirectToAction("Error", new { message = "Kunne ikke legge til bruker, en feil oppsto!" });            }
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
                Kunder funnetBruker = db.Kunder.FirstOrDefault
                (b => b.PersonNr == innKunde.personnr);
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

            Session["tempId"] = loginForm.personnr;
            
            if (Bruker_i_DB(loginForm))
            {
                return View();
            }
            else
            {
                Response.Write("<div style='padding-top:1em;' class='container centered'><div class='alert alert-danger'>Bruker-ID feil!</div></div>");
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return RedirectToAction("Error", new { message = "Bruker med id " + loginForm.personnr + " finnes ikke" });
            }


        }

        
        
        
        [HttpPost]
        public ActionResult LoginAuth(Kunde loginForm)
        {
            checkSession();

            if (Auth_i_DB(loginForm))
            {
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                var db = new DBKunde();
                string kundeId = (string)Session["tempId"];
                ViewBag.Id = kundeId;
                Session["Id"] = kundeId;
                Kunde kunden = db.hentKunde(kundeId);
                Session["Navn"] = kunden.fornavn + " " +kunden.etternavn;
                return RedirectToAction("MinSide", new { id = kundeId });
            }
            else
            {
                Response.Write("<div style='padding-top:1em;' class='container centered'><div class='alert alert-danger'>Kode fra kodebrikke eller passord er feil!</div></div>");
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return RedirectToAction("Error", new { message = "Feil passord" });
            }

        }

        private static bool Auth_i_DB(Kunde innKunde)
        {
            using (var db = new KundeContext())
            {
                byte[] passordDb = lagHash(innKunde.passord);
               
                Kunder funnetBruker = db.Kunder.FirstOrDefault
                (b => b.Passord == passordDb);
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


        public ActionResult Login()
        {
            checkSession();
            return View();
        }

        public ActionResult Logout()
        {
            Session["LoggetInn"] = false;
            ViewBag.Innlogget = false;
            Session["Id"] = null;
            Session["tempId"] = null;
            Session["Navn"] = null;
            checkSession();


            return RedirectToAction("Index", "");
        }


        public ActionResult Minside(string id)
        {
            checkSession();
            if (Session["LoggetInn"] != null && id == ViewBag.Id)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                string SessionKundeId = (string) Session["Id"];

                if (loggetInn)
                {
                    var db = new DBKunde();
                    var kunde = db.hentKunde(id);
                    List<Betaling> bl = db.hentBetalinger(id);
                    List<Kontoer> k1 = db.hentKontoer(kunde);

                    MinSideModel model = new MinSideModel(kunde,bl,k1);

                    return View(model);
                }
            }
            return RedirectToAction("Error", new {message = "Du må logge inn for å ha tilgang til denne siden"});
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


        [HttpPost]
        public ActionResult LeggTilBetaling(Betaling form)
        {
            try
            {
                using (var database = new Models.KundeContext())
                {
                    var nyBetaling = new Models.Betalinger();
                    nyBetaling.TilKontonr = form.tilKontonr;
                    nyBetaling.FraKontonr = form.fraKontonr;
                    nyBetaling.Kid = form.kid;
                    nyBetaling.Belop = form.belop;

                    if (form.dato == null)
                    {
                        nyBetaling.Dato = DateTime.Today.ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        nyBetaling.Dato = form.dato;
                    }
                    nyBetaling.KundeId = (string)Session["Id"];

                    database.Betalinger.Add(nyBetaling);
                    database.SaveChanges();


                    return RedirectToAction("MinSide", new { id = Session["Id"] });
                }
            }
            catch (Exception feil)
            {
                return RedirectToAction("Error", new { message = "Betaling kunne ikke gjennomføres! " + feil });
            }

        }

        public ActionResult SletteBetaling(int id)
        {
            checkSession();

            var db = new DBKunde();
            bool slettOK = db.slettBetaling(id);
            if (slettOK)
            {
                return RedirectToAction("MinSide", new { id = Session["Id"] });
            }
            return RedirectToAction("Error", new { message = "Ordre kunne ikke slettes"});


        }

        [HttpPost]
        public ActionResult EndreBetaling(int id, Betaling endring)
        {
            checkSession();

            if (ModelState.IsValid)
            {
                var kundeDb = new DBKunde();
                bool endringOK = kundeDb.endreBetaling(id, endring);
                if (endringOK)
                {
                    return RedirectToAction("MinSide", new { id = Session["Id"] });
                }
            }
            return RedirectToAction("Error", new { message = "Ordre kunne ikke endres" });
        }


        public ActionResult Error(string message)
        {
            checkSession();
            ViewBag.ErrorMessage = "" + message;
            return View("~/Views/Shared/Error.cshtml");
        }


    }
}
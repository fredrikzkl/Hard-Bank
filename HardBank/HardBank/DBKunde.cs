using HardBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardBank
{
    public class DBKunde
    {
        public bool settInn(Kunde innKunde)
        {
            var nyKunde = new Kunder()
            {
                Fornavn = innKunde.fornavn,
                Etternavn = innKunde.etternavn,
                Adresse = innKunde.adresse,
                
                PersonNr = innKunde.personnr

            };

            var db = new KundeContext();
            try
            {
                db.Kunder.Add(nyKunde);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }

        public List<Kunde> hentAlle()
        {
            var db = new KundeContext();
            List<Kunde> alleKunder = db.Kunder.Select(k => new Kunde()
            {
                personnr = k.PersonNr,
                id = k.ID,
                fornavn = k.Fornavn,
                etternavn = k.Etternavn,
                adresse = k.Adresse,
               
            }
            ).ToList();
            return alleKunder;
        
            
        }

        public Kunde hentKunde(int id)
        {
            var db = new KundeContext();

            var kunden = db.Kunder.Where(k => k.ID == id).First();
            if (kunden == null) return null;

            var value = new Kunde()
            {
                id = kunden.ID,
                fornavn = kunden.Fornavn,
                etternavn = kunden.Etternavn,
                personnr = kunden.PersonNr,
            };
            return value;
        }

        public Kunde hentKundeMedPersonnr(int personNr)
        {
            var db = new KundeContext();
            var kunden = db.Kunder.Where(k => k.PersonNr == personNr).First();
            var value = new Kunde()
            {
                id = kunden.ID,
                fornavn = kunden.Fornavn,
                etternavn = kunden.Etternavn,
                personnr = kunden.PersonNr,
            };
            if (kunden == null) return null;
            return value;
        }

        public List<Betaling> hentBetalinger(int id)
        {
            var db = new KundeContext();
            var query = db.Betalinger.Where(b => b.KundeId == id);
            List<Betaling> alleTransaksjoner = query.Select(b => new Betaling()
            {
                tilKontonr = b.TilKontonr,
                fraKontonr = b.FraKontonr,
                belop = b.Belop,
                kid = b.Kid,
                dato = b.Dato
            }).ToList();
            return alleTransaksjoner;
        }
      
    }
}
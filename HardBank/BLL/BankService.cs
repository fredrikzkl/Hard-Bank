using DAL;

using HardBank.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static DAL.BankContext;

namespace HardBank
{
    public class DBKunde
    {

        public int antallKunder()
        {
            var db = new BankContext();
            int count = (from k in db.Kunder select k.ID).Count();
            return count;
        }

        public bool settInn(Kunde innKunde)
        {
            var nyKunde = new Kunder()
            {
                Fornavn = innKunde.fornavn,
                Etternavn = innKunde.etternavn,
                Adresse = innKunde.adresse,
                
                PersonNr = innKunde.personnr

            };

            var db = new BankContext();
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
            var db = new BankContext();
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

        public Kunde hentKunde(string id)
        {
            var db = new BankContext();

            var kunden = db.Kunder.Where(k => k.PersonNr == id).First();
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

        public Kunder hentKunder(int id)
        {
            var db = new BankContext();
            var query = db.Kunder.Where(k => k.ID == id).First();
            return query;
        }

        public Kunde hentKundeMedPersonnr(string personNr)
        {
            var db = new BankContext();
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

        public List<Betaling> hentBetalinger(string id)
        {
            var db = new BankContext();
            var query = db.Betalinger.Where(b => b.KundeId == id);
            List<Betaling> alleTransaksjoner = query.Select(b => new Betaling()
            {
                betalingsnr = b.Betalingsnr,
                tilKontonr = b.TilKontonr,
                fraKontonr = b.FraKontonr,
                belop = b.Belop,
                kid = b.Kid,
                dato = b.Dato
            }).ToList();
            return alleTransaksjoner;
        }



        public bool slettBetaling(int id)
        {
            var db = new BankContext();
            try
            {
                Betalinger slettBetaling = db.Betalinger.Find(id);
                db.Betalinger.Remove(slettBetaling);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool endreBetaling(int id, Betaling endring)
        {
            var db = new BankContext();
            try
            {
                Betalinger endreKunde = db.Betalinger.Find(id);
                
                if(endring.dato != null) endreKunde.Dato = endring.dato;
                if (endring.kid != null) endreKunde.Kid = endring.kid;
                if (endring.belop != null) endreKunde.Belop = endring.belop;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool nyKonto(Kunder eier, int belop, string navn)
        {
            var nyKonto = new Kontoer()
            {
                KontoNavn = navn,
                Saldo = belop,
                KundeId= eier.PersonNr,
            };

            var db = new BankContext();
            try
            {
                db.Kontoer.Add(nyKonto);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Kontoer> hentKontoer(Kunde kunden)
        {
            var db = new BankContext();
            var query = db.Kontoer.Where(k => k.KundeId == kunden.personnr).ToList();
            return query;
        }

    }


    
}
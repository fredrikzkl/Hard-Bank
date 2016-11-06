using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminRepository : IAdminRepository
    {

        public Administratorer hentAdmin(string username)
        {
            using (var db = new BankContext())
            {
                var admin = db.Administratorer.Where(a => a.brukernavn == username).First();
                return admin;
            }
        }

        public bool brukerFinnes(string username)
        {
            using (var db = new BankContext())
            {
                Administratorer funnetBruker = db.Administratorer.FirstOrDefault
                (a => a.brukernavn == username);
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

        public List<Betalinger> hentAlleBetalinger()
        {
            using (var db = new BankContext())
            {
                return db.Betalinger.ToList();
            }
        }

        public List<Betalinger> hentAlleBetalingerFraKonto(string fraKontonr)
        {
            using (var db = new BankContext())
            {
                List<Betalinger> betalinger = db.Betalinger.Where(b => b.FraKontonr == fraKontonr).ToList();
                return betalinger;
            }
        }
    }
}

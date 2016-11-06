using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdminService : IAdminService
    {

        private IAdminRepository _repository;
        
        public AdminService()
        {
            _repository = new AdminRepository();
        }

        public AdminService(IAdminRepository stub)
        {
            _repository = stub;
        }

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

        public bool validateLogin(string username, string password)
        {
            if (!brukerFinnes(username)) return false;
            var temp = hentAdmin(username).passord;
            
            if(temp != null)
            {
                byte[] passHashed = lagHash(password);
                if (temp.SequenceEqual(passHashed))
                    return true;
            }
            return false;
        }

        private static byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }


    }
}

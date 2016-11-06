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
            return _repository.hentAdmin(username);
        }

        public bool brukerFinnes(string username)
        {
            return _repository.brukerFinnes(username);
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

        public List<Betalinger> hentAlleBetalinger()
        {
            return _repository.hentAlleBetalinger();
        }

        public List<Betalinger> hentAlleBetalingerFraKonto(string fraKontonr)
        {
            return _repository.hentAlleBetalingerFraKonto(fraKontonr);
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

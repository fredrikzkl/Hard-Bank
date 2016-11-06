using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DataBaseInitializer : CreateDatabaseIfNotExists<BankContext>
    {
        protected override void Seed(BankContext context)
        {
            generateDefaultAdmin();
        }

        public static void generateDefaultAdmin()
        {

            string username = "admin";
            string password = "admin";
            string email = "defaultAdmin@gmail.com";

            byte[] hashedpassword = lagHash(password);

            using(var db = new BankContext())
            {
                var nyadmin = new Administratorer();
                nyadmin.brukernavn = username;
                nyadmin.passord = hashedpassword;
                nyadmin.email = email;

                db.Administratorer.Add(nyadmin);
                db.SaveChanges();
            }

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

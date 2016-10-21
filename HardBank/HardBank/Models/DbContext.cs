using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace HardBank.Models
{
    public class Kunder
    {
        [Key]
        public int ID { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public byte[] Passord { get; set; }
        public int PersonNr { get; set; }
       
    }

    public class Kontoer
    {
        [Key]
        public int Kontonr { get; set; }
        public string KontoNavn { get; set; }
        public int Saldo { get; set; }
        public int KundeId { get; set; }
    }

    public class Betalinger
    {
        [Key]
        public int Betalingsnr { get; set; }
        public string TilKontonr { get; set; }
        public string FraKontonr { get; set; }
        public string Dato { get; set; }
        public string Kid { get; set; }
        public string Belop { get; set; }
        public int KundeId { get; set; }
    }

    public class KundeContext : DbContext
    {
        public KundeContext()
        : base("name=Bank")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Kunder> Kunder { get; set; }

        public DbSet<Betalinger> Betalinger { get; set; }

        public DbSet<Kontoer> Kontoer { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
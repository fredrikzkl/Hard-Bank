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
        public string Kontonr { get; set; }
        public byte[] Passord { get; set; }
        public int PersonNr { get; set; }
        public virtual Kontoer Kontoer { get; set; }
    }

    public class Kontoer
    {
        [Key]
        public int Kontonr { get; set; }
        public int Saldo { get; set; }
        public virtual List<Kunder> Kunder { get; set; }
    }

    public class KundeContext : DbContext
    {
        public KundeContext()
        : base("name=Bank")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Kunder> Kunder { get; set; }

        public DbSet<Kontoer> Kontoer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class Kunder
    {
        [Key]
        public int ID { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public byte[] Passord { get; set; }
        public string PersonNr { get; set; }

        [InverseProperty("Kunde")]
        public virtual IEnumerable<Kontoer> Kontoer { get; set; }
    }

    public class Kontoer
    {
        [Key]
        public int Kontonr { get; set; }
        public string KontoNavn { get; set; }
        public int Saldo { get; set; }

        // Foriegn key:
        public string KundeId { get; set; }

        [ForeignKey("KundeId")]
        public virtual Kunder Kunde { get; set; } // Eier av konto

        [InverseProperty("FraKonto")]
        public virtual IEnumerable<Transaksjoner> sendteTransaksjoner { get; set; }
        [InverseProperty("TilKonto")]
        public virtual IEnumerable<Transaksjoner> mottatTransaksjoner { get; set; }

        [InverseProperty("FraKonto")]
        public virtual IEnumerable<Betalinger> sendteBetalinger { get; set; }
        [InverseProperty("TilKonto")]
        public virtual IEnumerable<Betalinger> mottatBetalinger { get; set; }
    }

    public class Betalinger // Forfallsbetaling
    {
        [Key]
        public int Betalingsnr { get; set; }

        public string Dato { get; set; }
        public string Kid { get; set; }
        public string Belop { get; set; }
        public string KundeId { get; set; }

        // Foreign keys:
        public string FraKontonr { get; set; }
        public string TilKontonr { get; set; }


        [ForeignKey("FraKontonr")]
        public virtual Kontoer FraKonto { get; set; } //FraKonto
        [ForeignKey("TilKontonr")]
        public virtual Kontoer TilKonto { get; set; } //TilKonto
    }

    public class Transaksjoner // Gjennomført betaling
    {
        [Key]
        public int TransaksjonsID { get; set; }

        public string ForfallsDato { get; set; }
        public string DatoBetalt { get; set; }
        public string Kid { get; set; }
        public string Belop { get; set; }

        // Foreign keys:
        public string FraKontonr { get; set; }
        public string TilKontonr { get; set; }
        

        [ForeignKey("FraKontonr")]
        public virtual Kontoer FraKonto { get; set; } //FraKonto
        [ForeignKey("TilKontonr")]
        public virtual Kontoer TilKonto { get; set; } //TilKonto
    }

    public class Administratorer
    {
        [Key]
        public string brukernavn { get; set; }
        public byte[] passord { get; set; }
        public string email { get; set; }
    }

    public class BankContext : DbContext
    {
        

        public BankContext()
        : base("name=Bank")
        {
            //Database.CreateIfNotExists();
            Database.SetInitializer<BankContext>(new DataBaseInitializer());
        }

        public DbSet<Kunder> Kunder{ get; set; }

        public DbSet<Betalinger> Betalinger { get; set; }

        public DbSet<Transaksjoner> Transaksjoner { get; set; }

        public DbSet<Kontoer> Kontoer { get; set; }

        public DbSet<Administratorer> Administratorer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
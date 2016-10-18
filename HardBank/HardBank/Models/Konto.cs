using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardBank.Models
{
    public class Konto
    {
        public int kontonr { get; set; }
        public string kontonavn { get; set; }
        public int saldo { get; set; }
        public virtual Kunde eier { get; set; }
    }
}
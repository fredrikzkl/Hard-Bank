using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HardBank.Models
{
    public class Konto
    {
        public int kontonr { get; set; }
        public string kontoNavn { get; set; }
        public int saldo { get; set; }
        public string kundeId { get; set; }
    }
}

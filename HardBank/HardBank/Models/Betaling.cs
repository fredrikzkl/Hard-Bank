using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardBank.Models
{
    public class Betaling
    {
        public int betalingsnr { get; set; }

        public string tilKontonr { get; set; }

        public string fraKontonr { get; set; }

        public string dato { get; set; }

        public string kid { get; set; }

        public string belop { get; set; }

        public virtual int kundeId { get; set; }

    }
}
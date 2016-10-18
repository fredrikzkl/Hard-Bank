using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HardBank.Models
{
    public class Kunde
    {
        public string passord { get; set; }
        public int personnr { get; set; }
        public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string adresse { get; set; }
    }
}
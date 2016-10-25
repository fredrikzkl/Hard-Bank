using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HardBank.Models
{
    public class Kunde
    {
        

        [Display(Name = "Passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        [RegularExpression(@"[0-9a-zA-Z]{8,}", ErrorMessage = "Passord må være minimum 8 tegn, kun tall og store/små bokstaver")]
        [DataType(DataType.Password)]
        public string passord { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekreft password")]
        [Compare("passord", ErrorMessage = "Passord er forskjellig")]
        public string bekreftPassord { get; set; }

        [Display(Name = "Personnummer")]
        [Required(ErrorMessage = "Personnummer må oppgis")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Personnummer må være 11 siffer")]
        public string personnr { get; set; }

        public int id { get; set; }

        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis")]
        public string fornavn { get; set; }

        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppgis")]
        public string etternavn { get; set; }

        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Adresse må oppgis")]
        public string adresse { get; set; }

        public string kontonr { get; set; }

        public string saldo { get; set; }
    }
}
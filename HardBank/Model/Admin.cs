
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Admin
    {
        [Display(Name = "Personnummer")]
        [Required(ErrorMessage = "BrukerId må oppgis")]
        public string brukerId { get; set; }

        [Display(Name = "Passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        [DataType(DataType.Password)]
        public string passord { get; set; }
    }
}

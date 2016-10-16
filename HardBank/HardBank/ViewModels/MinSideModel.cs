using HardBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardBank.ViewModels
{
    public class MinSideModel
    {
        public Kunde kunde { get; set; }

        public List<Betaling> betalinger { get; set; }

        public MinSideModel(Kunde k, List<Betaling> b)
        {
            kunde = k;
            betalinger = b;
        }
    }
}
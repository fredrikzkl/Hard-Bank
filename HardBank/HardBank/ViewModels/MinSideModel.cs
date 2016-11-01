using DAL;
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

        public List<Kontoer> kontoer { get; set; }

        public MinSideModel(Kunde kunden, List<Betaling> betalingListen, List<Kontoer> kontoListen)
        {
            kunde = kunden;
            betalinger = betalingListen;
            kontoer = kontoListen;
        }
    }
}
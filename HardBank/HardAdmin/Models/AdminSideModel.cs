using DAL;
using HardBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardAdmin.Models
{
    public class AdminSideModel
    {
        public List<Betaling> betalinger { get; set; }

        public AdminSideModel (List<Betaling> betalingListen)
        {
            betalinger = betalingListen;
        }
    }
}
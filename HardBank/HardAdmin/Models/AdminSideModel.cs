using DAL;
using HardBank.Models;
using HardAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardAdmin.Models
{
    public class AdminSideModel
    {

        public List<Betalinger> betalinger { get; set; }

        public AdminSideModel(List<Betalinger> betalingListen)
        {
            betalinger = betalingListen;
        }
    }
}
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IAdminService
    {
        Administratorer hentAdmin(string username);
        bool brukerFinnes(string username);
        bool validateLogin(string username, string password);
        List<Betalinger> hentAlleBetalinger();
        List<Betalinger> hentAlleBetalingerFraKonto(string fraKontonr);

    }
}

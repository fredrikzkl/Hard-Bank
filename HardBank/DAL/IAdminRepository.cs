using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAdminRepository
    {
        Administratorer hentAdmin(string username);
        bool brukerFinnes(string username);
        List<Betalinger> hentAlleBetalinger();
        List<Betalinger> hentAlleBetalingerFraKonto(string fraKontonr);
    }   
}

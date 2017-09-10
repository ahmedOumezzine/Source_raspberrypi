using AppDesktop.Persistance;
using SourieCSharp.AppDesktop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourieCSharp.AppDesktop.Persistance
{
    public class log_Persistance
    {
        AccesJDBC access = new AccesJDBC();

        public List<log> FindBy(String _id_souris)
        {
            String reqSql = "SELECT * FROM `log` WHERE `id_souris`=" + _id_souris;
            return Mapping.C2listLog(access.get(reqSql));
        }
    }
}

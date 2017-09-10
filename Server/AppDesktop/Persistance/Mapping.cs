using SourieCSharp.AppDesktop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppDesktop.Persistance
{
    public class Mapping
    {
        public static List<listsouris> C2ListSouris(List<List<String>> LSouris)
        {
            List<listsouris> ListSouris = new List<listsouris>();
            int nbrow = LSouris.Count;
            listsouris Ct;
            List<String> LS = new List<String>();
            for (int i = 0; i < nbrow; i++)
            {
                LS = LSouris[i];
                Ct = new listsouris();
                Ct._Identification_Souris =Int32.Parse(LS[0]);
                Ct._Ip_Souris = LS[1];
                Ct._online_Souris = Int32.Parse(LS[2]);
                ListSouris.Add(Ct);
            }
            return ListSouris;
        }


        public static List<log> C2listLog(List<List<String>> Llog)
        {
            List<log> Listlogs = new List<log>();
            int nbrow = Llog.Count;
            log Ct;
            List<String> LS = new List<String>();
            for (int i = 0; i < nbrow; i++)
            {
                LS = Llog[i];
                Ct = new log();
                Ct._id_log = Int32.Parse(LS[0]);
                Ct._id_souris = Int32.Parse(LS[1]);
                Ct._msg_log = LS[2];
                Ct._date = DateTime.Parse(LS[3]);
                Listlogs.Add(Ct);
            }
            return Listlogs;
        }
    }
}

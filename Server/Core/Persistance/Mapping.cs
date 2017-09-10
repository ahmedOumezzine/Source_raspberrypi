using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core
{
    public class Mapping
    {
        public static List<listsouris> C2ListSouris(List<List<String>> ListClient)
        {
            List<listsouris> ListSouris = new List<listsouris>();
            int nbrow = ListClient.Count;
            listsouris Ct;
            List<String> LS = new List<String>();
            for (int i = 0; i < nbrow; i++)
            {
                LS = ListClient[i];
                Ct = new listsouris();
                Ct._Identification_Souris =Int32.Parse(LS[0]);
                Ct._Ip_Souris = LS[1];
                Ct._online_Souris = Int32.Parse(LS[2]);
                ListSouris.Add(Ct);
            }
            return ListSouris;
        }
    }
}

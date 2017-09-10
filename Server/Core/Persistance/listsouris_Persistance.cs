using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourieCSharp.Core.Persistance
{
    class listsouris_Persistance
    {
        AccesJDBC access = new AccesJDBC();

        public void insert(listsouris ct)
        {
            String reqSql = "INSERT INTO `listsouris`(`Identification_Souris`, `Ip_Souris`, `online_Souris`) VALUES("+ct._Identification_Souris+","+ct._Ip_Souris+",0)";
            access.update(reqSql);
        }
        public void Update(listsouris ct)
        {
            String reqSql = "UPDATE `listsouris` SET `Ip_Souris`="+ct._Ip_Souris+" ,`online_Souris`= "+ct._online_Souris+" WHERE  `Identification_Souris`="+ct._Identification_Souris;
            access.update(reqSql);
        }
        public void Delet(listsouris ct)
        {
            String reqSql = "DELETE FROM `listsouris` WHERE `Identification_Souris`="+ct._Identification_Souris;
            access.update(reqSql);
        }

        public List<listsouris> getList()
        {
            String reqSql = "SELECT * FROM `listsouris`";
            return Mapping.C2ListSouris(access.get(reqSql));
        }
        public List<listsouris> FindBy(listsouris ct)
        {
            String reqSql = "SELECT * FROM `listsouris` WHERE `Identification_Souris`="+ct._Identification_Souris;
            return Mapping.C2ListSouris(access.get(reqSql));
        }
        public int count(String Value)
        {
            return access.count("`listsouris`", " `Identification_Souris`", Value);
        }
    }
}
using System;
using SourieCSharp.Log;
using SourieCSharp.Mesure;
using SourieCSharp;

namespace SourieWebservice
{
    public class MethodApp
    {
        public void AddSouris(string identificationSouris, string ipSouris)
        {
            if(AccesJDBC.count("","", identificationSouris)==1)
            {
                OnlineEtat(identificationSouris);
            }
            else
            {
                addSouris(identificationSouris, ipSouris);
            }
        }

        private void addSouris(string identificationSouris, string ipSouris)
        {
            String ReqSql = "INSERT INTO `listsouris`(`Identification_Souris`, `Ip_Souris`, `online_Souris`) VALUES ('"+identificationSouris+"','"+ipSouris+"',0)";
            AccesJDBC.update(ReqSql);
        }

        private void OnlineEtat(string identificationSouris)
        {
            String ReqSql = "UPDATE `listsouris` SET `online_Souris`=1 WHERE `Identification_Souris`='"+identificationSouris+"'";
            AccesJDBC.update(ReqSql);
        }

        public void addData(data[] listDatas,string identificationSouris)
        {
            for(int i = 0; i < listDatas.Length; i++)
            {
                String ReqSql = "INSERT INTO `data`( `id_souris`, `id_TypeData`, `Value`, `date`) VALUES ('"+ identificationSouris + "','"+listDatas[i].id_typedata+"','"+listDatas[i].value+"','"+DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") +"')";
                AccesJDBC.update(ReqSql);
            }
        }

        public void addLog(log[] listLogs, string identificationSouris)
        {
            for (int i = 0; i < listLogs.Length; i++)
            {
                String ReqSql = "INSERT INTO `log`( `id_souris`, `msg_log`, `date`) VALUES ('" + identificationSouris + "','" + listLogs[i].msg + "','" + listLogs[i].date + "')";
                AccesJDBC.update(ReqSql);
            }
        }
    }
}
using System;
using System.Web.Services;
using System.ServiceModel;

namespace SourieWebservice
{
    /// <summary>
    /// Summary description for SourieWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SourieWebService : System.Web.Services.WebService
    {
        System.Timers.Timer timerMesure,TimeData;
        MethodApp method = new MethodApp();

        [WebMethod]
        public String Ping()
        {
            return "ping";
        }

        [WebMethod]
        public String enregistrerSouris(String IdentificationSouris,String IpSouris)
        {
            method.AddSouris(IdentificationSouris, IpSouris);

            timerMesure = new System.Timers.Timer();
            timerMesure.Interval = 2000;
            timerMesure.Elapsed += delegate { runMesure(timerMesure, IdentificationSouris, IpSouris); };
            timerMesure.Enabled = true;
            // If AutoReset=false then the timer will only tick once
            timerMesure.AutoReset = true;
            timerMesure.Start();

            TimeData = new System.Timers.Timer();
            TimeData.Interval = 10000;
            TimeData.Elapsed += delegate { runLog(TimeData, IdentificationSouris, IpSouris); };
            TimeData.Enabled = true;
            // If AutoReset=false then the timer will only tick once
            TimeData.AutoReset = true;
            TimeData.Start();
            return "ok";
            
        }


        private void runLog(System.Timers.Timer timer,String IdentificationSouris,String IpSouris)
        {
            try
            {
                SourieCSharp.Log.Log_ServiceClient log = new SourieCSharp.Log.Log_ServiceClient();
                log.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri("http://" + IpSouris + "/ws/data?wsdl"),
                    log.Endpoint.Address.Identity, log.Endpoint.Address.Headers);
                SourieCSharp.Log.log[] listLogs = log.getListLog();
                method.addLog(listLogs, IdentificationSouris);

            }
            catch (EndpointNotFoundException e)
            {
                timer.Stop();
            }
        }

        private void runMesure(System.Timers.Timer timer,String IdentificationSouris,String IpSouris)
        {
            try
            {
                SourieCSharp.Mesure.Data_ServiceClient data = new SourieCSharp.Mesure.Data_ServiceClient();
                data.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri("http://"+ IpSouris + "/ws/data?wsdl"),
                    data.Endpoint.Address.Identity, data.Endpoint.Address.Headers);
                SourieCSharp.Mesure.data[] listDatas=data.getListData();
                method.addData(listDatas, IdentificationSouris);

            }
            catch(EndpointNotFoundException e){
                timer.Stop();
            }
             
        }

    }
}

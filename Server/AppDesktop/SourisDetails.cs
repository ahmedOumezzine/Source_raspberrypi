using SourieCSharp.AppDesktop.Entities;
using AppDesktop.Persistance;
using MySql.Data.MySqlClient;
using SourieCSharp.AppDesktop.Persistance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SourieCSharp.AppDesktop
{
    public partial class SourisDetails : Form
    {
        listsouris list;
        public SourisDetails()
        {
            InitializeComponent();
        }
        public SourisDetails(listsouris l)
        {
            InitializeComponent();
            this.list = l;
        }

        //fillChart method  
        private void fillChart()
        {
            try
            {       
            MySqlConnection con = new MySqlConnection("SERVER=" + AccesJDBC.server + ";" + "DATABASE=" + AccesJDBC.database + ";" + "UID=" + AccesJDBC.uid + ";" + "PASSWORD=" + AccesJDBC.password + ";");
            DataSet ds = new DataSet();
            con.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter("SELECT count(*)  as nbr, sum(`Value`) as Value FROM data where id_souris='" + list._Identification_Souris+ "' and `id_TypeData`=1  GROUP BY ( 4 * HOUR( date ) + FLOOR( MINUTE( date ) / 15 ))", con);
            adapt.Fill(ds);
            chart.DataSource = ds;
            //set the member of the chart data source used to data bind to the X-values of the series  
            chart.Series[0].XValueMember = "nbr";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chart.Series[0].YValueMembers = "Value";
            chart.Titles.Add("Value Tempurature");
                con.Close();

            }
            catch (Exception e)
            {

            }
        }
        private void fillChart2()
        {
            try
            {
                MySqlConnection con = new MySqlConnection("SERVER=" + AccesJDBC.server + ";" + "DATABASE=" + AccesJDBC.database + ";" + "UID=" + AccesJDBC.uid + ";" + "PASSWORD=" + AccesJDBC.password + ";");
                DataSet ds = new DataSet();
                con.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter("SELECT count(*)  as nbr, sum(`Value`) as Value FROM data where id_souris='" + list._Identification_Souris + "' and `id_TypeData`=2  GROUP BY ( 4 * HOUR( date ) + FLOOR( MINUTE( date ) / 15 ))", con);
                adapt.Fill(ds);
                chart1.DataSource = ds;
                //set the member of the chart data source used to data bind to the X-values of the series  
                chart1.Series[0].XValueMember = "nbr";
                //set the member columns of the chart data source used to data bind to the X-values of the series  
                chart1.Series[0].YValueMembers = "Value";
                chart1.Titles.Add("Value humidite");
                con.Close();
            }
            catch (Exception e)
            {

            }
        }

        private void fillChart3()
        {
            try
            {
                MySqlConnection con = new MySqlConnection("SERVER=" + AccesJDBC.server + ";" + "DATABASE=" + AccesJDBC.database + ";" + "UID=" + AccesJDBC.uid + ";" + "PASSWORD=" + AccesJDBC.password + ";");
                DataSet ds = new DataSet();
                con.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter("SELECT count(*)  as nbr, sum(`Value`) as Value FROM data where id_souris='" + list._Identification_Souris + "' and `id_TypeData`=3  GROUP BY ( 4 * HOUR( date ) + FLOOR( MINUTE( date ) / 15 ))", con);
                adapt.Fill(ds);
                chart2.DataSource = ds;
                //set the member of the chart data source used to data bind to the X-values of the series  
                chart2.Series[0].XValueMember = "nbr";
                //set the member columns of the chart data source used to data bind to the X-values of the series  
                chart2.Series[0].YValueMembers = "Value";
                chart2.Titles.Add("nbr click");
                con.Close();
            }
            catch (Exception e)
            {

            }
        }

        private void SourisDetails_Load(object sender, EventArgs e)
        {
            log_Persistance s = new log_Persistance();
            GridView.DataSource = s.FindBy(list._Identification_Souris.ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            fillChart();
            checkBox1.Enabled = false;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            fillChart2();
            checkBox2.Enabled = false;

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            fillChart3();
            checkBox3.Enabled = false;

        }
    }
}

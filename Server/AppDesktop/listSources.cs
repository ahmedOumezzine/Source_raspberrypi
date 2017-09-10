
using AppDesktop.Persistance.Persistance;
using SourieCSharp.AppDesktop.Entities;
using System;
using System.Windows.Forms;


namespace SourieCSharp.AppDesktop
{
    public partial class listSources : Form
    {
        public listSources()
        {
            InitializeComponent();
        }

        listsouris_Persistance a = new listsouris_Persistance();


        private void button1_Click(object sender, EventArgs e)
        {
            listsouris l = new listsouris();
            l._Identification_Souris = 222;
            l._Ip_Souris = "192.122.111.11";
            l._online_Souris = 0;
            a.insert(l);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Collections.Generic.List<listsouris> list = a.getList();
            GridView.DataSource = list;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                System.Collections.Generic.List<listsouris> list = a.getListonline();
                GridView.DataSource = list;
            }
            else
            {
                System.Collections.Generic.List<listsouris> list = a.getList();
                GridView.DataSource = list;
            }
        }

        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = GridView.Rows[index];
            listsouris ls = new listsouris();
            ls._Identification_Souris =Int32.Parse( selectedRow.Cells[0].Value.ToString());
            ls._Ip_Souris = selectedRow.Cells[1].Value.ToString();
            ls._online_Souris = Int32.Parse(selectedRow.Cells[2].Value.ToString());
            SourisDetails a = new SourisDetails(ls);
            a.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using MetroFramework;
using MetroFramework.Forms;

namespace Jamals_Yellow_Pages
{
    public partial class Bus_Class : MetroFramework.Forms.MetroForm
    {
        public Bus_Class()
        {
            InitializeComponent();
        }
        string strProvider = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Asad\Documents\Visual Studio 2013\Projects\Jamals Yellow Pages\Database\Jamals.accdb";

        private void Bus_Class_Load(object sender, EventArgs e)
        {
            
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            Form1 fo = new Form1();
            fo.Show();
            this.Hide();
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            string strSql = "select * from jamals where company like 'A%'";
            OleDbConnection con = new OleDbConnection(strProvider);
            OleDbCommand cmd = new OleDbCommand(strSql, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable scores = new DataTable();
            da.Fill(scores);
            metroGrid1.DataSource = scores;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }
    }
}

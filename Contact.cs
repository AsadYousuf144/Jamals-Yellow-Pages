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
    public partial class Contact : MetroFramework.Forms.MetroForm
    {
        public Contact()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R5P588T\SQLEXPRESS;Initial Catalog=Jamals;Persist Security Info=True;User ID=JamalsDatabase;Password=jamals");

        private void Contact_Load(object sender, EventArgs e)
        {
            metroPanel1.BackColor = Color.FromArgb(0, 174, 219);

        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
           
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void metroLink1_Click_1(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Form1 fo = new Form1();
            fo.Show();
            this.Hide();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Test t1 = new Test();
            t1.Show();
            this.Hide();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Companies s = new Companies();
            s.Show();
            this.Hide();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Foreign f = new Foreign();
            f.Show();
            this.Hide();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Representatives r = new Representatives();
            r.Show();
            this.Hide();
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Trade t = new Trade();
            t.Show();
            this.Hide();
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {

        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Help h = new Help();
            h.Show();
            this.Hide();
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            About a = new About();
            a.Show();
            this.Hide();
        }

        private void Contact_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {

                DialogResult result = MetroMessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    con.Close();
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void metroTile1_MouseEnter(object sender, EventArgs e)
        {
            metroTile1.Style = MetroColorStyle.Yellow;
        }

        private void metroTile1_MouseLeave(object sender, EventArgs e)
        {
            metroTile1.Style = MetroColorStyle.Default;
        }

        private void metroTile2_MouseEnter(object sender, EventArgs e)
        {
            metroTile2.Style = MetroColorStyle.Yellow;
        }

        private void metroTile2_MouseLeave(object sender, EventArgs e)
        {
            metroTile2.Style = MetroColorStyle.Default;
        }

        private void metroTile3_MouseEnter(object sender, EventArgs e)
        {
            metroTile3.Style = MetroColorStyle.Yellow;
        }

        private void metroTile3_MouseLeave(object sender, EventArgs e)
        {
            metroTile3.Style = MetroColorStyle.Default;
        }

        private void metroTile4_MouseEnter(object sender, EventArgs e)
        {
            metroTile4.Style = MetroColorStyle.Yellow;
        }

        private void metroTile4_MouseLeave(object sender, EventArgs e)
        {
            metroTile4.Style = MetroColorStyle.Default;
        }

        private void metroTile5_MouseEnter(object sender, EventArgs e)
        {
            metroTile5.Style = MetroColorStyle.Yellow;
        }

        private void metroTile5_MouseLeave(object sender, EventArgs e)
        {
            metroTile5.Style = MetroColorStyle.Default;
        }

        private void metroTile6_MouseEnter(object sender, EventArgs e)
        {
            metroTile6.Style = MetroColorStyle.Yellow;
        }

        private void metroTile6_MouseLeave(object sender, EventArgs e)
        {
            metroTile6.Style = MetroColorStyle.Default;
        }

        private void metroTile7_MouseEnter(object sender, EventArgs e)
        {
            metroTile7.Style = MetroColorStyle.Yellow;
        }

        private void metroTile7_MouseLeave(object sender, EventArgs e)
        {
            metroTile7.Style = MetroColorStyle.Default;
        }

        private void metroTile8_MouseEnter(object sender, EventArgs e)
        {
            metroTile8.Style = MetroColorStyle.Yellow;
        }

        private void metroTile8_MouseLeave(object sender, EventArgs e)
        {
            metroTile8.Style = MetroColorStyle.Default;
        }

        private void metroTile9_MouseEnter(object sender, EventArgs e)
        {
            metroTile9.Style = MetroColorStyle.Yellow;
        }

        private void metroTile9_MouseLeave(object sender, EventArgs e)
        {
            metroTile9.Style = MetroColorStyle.Default;
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            CPEC c = new CPEC();
            c.Show();
            this.Hide();
        }

        private void metroTile10_MouseEnter(object sender, EventArgs e)
        {
            metroTile10.Style = MetroColorStyle.Yellow;
        }

        private void metroTile10_MouseLeave(object sender, EventArgs e)
        {
            metroTile10.Style = MetroColorStyle.Default;
        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }
    }
}

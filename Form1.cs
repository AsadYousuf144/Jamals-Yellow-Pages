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
using System.Threading;
//using System.Runtime.InteropServices;


namespace Jamals_Yellow_Pages
{


   
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        //[DllImport("user32.dll")]
        //static extern bool AnimateWindow(IntPtr hWnd, int time, AnimateWindowFlags flags);

        public Form1()
        {
            InitializeComponent();


        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R5P588T\SQLEXPRESS;Initial Catalog=Jamals;Persist Security Info=True;User ID=JamalsDatabase;Password=jamals;MultipleActiveResultSets=True");
        private void Form1_Load(object sender, EventArgs e)
        {

          //  this.BringToFront();
            //pictureBox4.Hide();
            //pictureBox4.Visible = false;
          //  this.metroProgressSpinner1.Hide();
            metroPanel1.BackColor = Color.FromArgb(0, 174, 219);
            metroTile1.BackColor = Color.FromArgb(0, 174, 219);
            con.Open();
            
            //this.ControlBox = true;

            //int h = Screen.PrimaryScreen.WorkingArea.Height;
            //int w = Screen.PrimaryScreen.WorkingArea.Width;
            //this.ClientSize = new Size(w, h);
            //this.WindowState = FormWindowState.Maximized;
        }

        //public void Startform()
        //{
        //    Application.Run(new Splash());
        //}

        private void metroTile2_Click(object sender, EventArgs e)
        {
          
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            
            //switch (MetroMessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo,MessageBoxIcon.Information))
            //{
            //    case DialogResult.Yes:
            //        con.Close();
            //        Application.Exit();
            //        break;
            //    default:
            //        break;
            //}
            

        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
           
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void CreateMyTopMostForm()
        {
         
        }
        

        private void set_Restore()
        {
           
        }
        private void button2_Click(object sender, EventArgs e)
        {

           


        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            
        }

        private void metroLink3_Click(object sender, EventArgs e)
        {

        }

    

        private void metroTile5_Click(object sender, EventArgs e)
        {
          
        }

      

        private void metroTile1_MouseEnter(object sender, EventArgs e)
        {
            metroTile1.Style = MetroColorStyle.Yellow;
        }

        private void metroTile1_MouseLeave(object sender, EventArgs e)
        {
            metroTile1.Style = MetroColorStyle.Blue;
        }

        private void metroTile6_MouseEnter(object sender, EventArgs e)
        {
            metroTile6.Style = MetroColorStyle.Yellow;
        }

        private void metroTile6_MouseLeave(object sender, EventArgs e)
        {
            metroTile6.Style = MetroColorStyle.Blue;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             
        }

        private void metroTile2_MouseEnter(object sender, EventArgs e)
        {
            metroTile2.Style = MetroColorStyle.Yellow;
        }

        private void metroTile2_MouseLeave(object sender, EventArgs e)
        {
            metroTile2.Style = MetroColorStyle.Blue;
        }

        private void metroTile4_MouseEnter(object sender, EventArgs e)
        {
            metroTile4.Style = MetroColorStyle.Yellow;
        }

        private void metroTile4_MouseLeave(object sender, EventArgs e)
        {
            metroTile4.Style = MetroColorStyle.Blue;
        }

        private void metroTile3_MouseEnter(object sender, EventArgs e)
        {
            metroTile3.Style = MetroColorStyle.Yellow;
        }

        private void metroTile3_MouseLeave(object sender, EventArgs e)
        {
            metroTile3.Style = MetroColorStyle.Blue;
        }

        private void metroTile7_MouseEnter(object sender, EventArgs e)
        {
            metroTile7.Style = MetroColorStyle.Yellow;
        }

        private void metroTile7_MouseLeave(object sender, EventArgs e)
        {
            metroTile7.Style = MetroColorStyle.Blue;
        }

        private void metroTile8_MouseEnter(object sender, EventArgs e)
        {
            metroTile8.Style = MetroColorStyle.Yellow;
        }

        private void metroTile8_MouseLeave(object sender, EventArgs e)
        {
            metroTile8.Style = MetroColorStyle.Blue;
        }

        private void metroTile9_MouseEnter(object sender, EventArgs e)
        {
            metroTile9.Style = MetroColorStyle.Yellow;
        }

        private void metroTile9_MouseLeave(object sender, EventArgs e)
        {
            metroTile9.Style = MetroColorStyle.Blue;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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

        private void metroTile5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTile2_Click_1(object sender, EventArgs e)
        {
                pictureBox4.Visible = true;
                this.Enabled = false;
                Test t1 = new Test();
                t1.Show();
                this.Hide();  
        }


        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void metroTile3_Click_1(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Companies s = new Companies();
            s.Show();
            this.Hide();

        }

        

        private void metroTile4_Click_1(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Foreign f = new Foreign();
            f.Show();
            this.Hide();
        }

        private void metroTile5_Click_2(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Representatives r = new Representatives();
            r.Show();
            this.Hide();
        }

        private void metroTile6_Click_1(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Trade t = new Trade();
            t.Show();
            this.Hide();
        }

        private void metroTile7_Click_1(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Contact c = new Contact();
            c.Show();
            this.Hide();
        }

        private void metroTile8_Click_1(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            Help h = new Help();
            h.Show();
            this.Hide();
        }

        private void metroTile9_Click_1(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            this.Enabled = false;
            About a = new About();
            a.Show();
            this.Hide();
        }

        private void metroTile1_MouseEnter_1(object sender, EventArgs e)
        {

            metroTile1.Style = MetroColorStyle.Yellow;
        }

        private void metroTile1_MouseLeave_1(object sender, EventArgs e)
        {

            metroTile1.Style = MetroColorStyle.Blue;
        }

        private void metroTile2_MouseEnter_1(object sender, EventArgs e)
        {

            metroTile2.Style = MetroColorStyle.Yellow;
        }

        private void metroTile2_MouseLeave_1(object sender, EventArgs e)
        {

            metroTile2.Style = MetroColorStyle.Blue;
        }

        private void metroTile3_MouseEnter_1(object sender, EventArgs e)
        {
            metroTile3.Style = MetroColorStyle.Yellow;
        }

        private void metroTile3_MouseLeave_1(object sender, EventArgs e)
        {

            metroTile3.Style = MetroColorStyle.Blue;
        }

        private void metroTile4_MouseEnter_1(object sender, EventArgs e)
        {

            metroTile4.Style = MetroColorStyle.Yellow;
        }

        private void metroTile4_MouseLeave_1(object sender, EventArgs e)
        {

            metroTile4.Style = MetroColorStyle.Blue;
        }

        private void metroTile5_MouseEnter(object sender, EventArgs e)
        {

            metroTile5.Style = MetroColorStyle.Yellow;
        }

        private void metroTile5_MouseLeave(object sender, EventArgs e)
        {

            metroTile5.Style = MetroColorStyle.Blue;
        }

        private void metroTile6_MouseEnter_1(object sender, EventArgs e)
        {

            metroTile6.Style = MetroColorStyle.Yellow;
        }

        private void metroTile6_MouseLeave_1(object sender, EventArgs e)
        {

            metroTile6.Style = MetroColorStyle.Blue;
        }

        private void metroTile7_MouseEnter_1(object sender, EventArgs e)
        {

            metroTile7.Style = MetroColorStyle.Yellow;
        }

        private void metroTile7_MouseLeave_1(object sender, EventArgs e)
        {

            metroTile7.Style = MetroColorStyle.Blue;
        }

        private void metroTile8_MouseEnter_1(object sender, EventArgs e)
        {

            metroTile8.Style = MetroColorStyle.Yellow;
        }

        private void metroTile8_MouseLeave_1(object sender, EventArgs e)
        {

            metroTile8.Style = MetroColorStyle.Blue;
        }

        private void metroTile9_MouseEnter_1(object sender, EventArgs e)
        {

            metroTile9.Style = MetroColorStyle.Yellow;
        }

        private void metroTile9_MouseLeave_1(object sender, EventArgs e)
        {

            metroTile9.Style = MetroColorStyle.Blue;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_MouseEnter_2(object sender, EventArgs e)
        {
            metroTile1.Style = MetroColorStyle.Yellow;
        }

        private void metroTile1_MouseLeave_2(object sender, EventArgs e)
        {
            metroTile1.Style = MetroColorStyle.Default;
        }

        private void metroTile10_Click_1(object sender, EventArgs e)
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

        private void button1_Click_3(object sender, EventArgs e)
        {

        }

     
    }
}

﻿using System;
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
using System.Drawing.Printing;
//using System.Runtime.InteropServices;

namespace Jamals_Yellow_Pages
{
    public partial class Companies : MetroFramework.Forms.MetroForm
    {

        //[DllImport("user32.dll")]
        //static extern bool AnimateWindow(IntPtr hWnd, int time, AnimateWindowFlags flags);

        public Companies()
        {
            InitializeComponent();
        }



        //[Flags]

        //enum AnimateWindowFlags
        //{

        //    AW_HOR_POSITIVE = 0x00000001,

        //    AW_HOR_NEGATIVE = 0x00000002,

        //    AW_VER_POSITIVE = 0x00000004,

        //    AW_VER_NEGATIVE = 0x00000008,

        //    AW_CENTER = 0x00000010,

        //    AW_HIDE = 0x00010000,

        //    AW_ACTIVATE = 0x00020000,

        //    AW_SLIDE = 0x00040000,

        //    AW_BLEND = 0x00080000

        //}



        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R5P588T\SQLEXPRESS;Initial Catalog=Jamals;Persist Security Info=True;User ID=JamalsDatabase;Password=jamals;MultipleActiveResultSets=True");
        ComboBox cm;
        string c = "";

        SqlCommand command;
        SqlDataReader reader;
        private void Companies_Load(object sender, EventArgs e)
        {
            metroPanel1.BackColor = Color.FromArgb(0, 174, 219);
            label7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");
            label7.UseMnemonic = false;

            con.Open();
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            SqlCommand command = new SqlCommand("select distinct[Company] from Company", con);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                    namesCollection.Add(dr[0].ToString());
            }
            dr.Close();
            metroTextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            metroTextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            metroTextBox1.AutoCompleteCustomSource = namesCollection;
            con.Close();
        }
        string ab;
        string g = "";
        public void calls()
        {
            if (metroTextBox1.Text == "") { }
            else
            {
                c = metroTextBox1.Text;
                
            }
            label7.Text = metroTextBox1.Text;
            metroComboBox1.Items.Clear();
            try
            {
                panel1.Controls.Clear();
                ab = metroTextBox1.Text;
                if (con.State == ConnectionState.Closed)
                {
                    // ab = metroTextBox1.Text;
                    if (metroTextBox1.Text.Contains("'") == true)
                    {
                        //ab = "A SOUTH TRAVEL & TOURS";
                        //ab.Remove("'") = false;
                        ab = metroTextBox1.Text;
                        metroTextBox1.Text = metroTextBox1.Text.Replace("'", "''");
                        g = metroTextBox1.Text;
                    }
                    //else if (metroTextBox1.Text.Contains("&") == true)
                    //{
                    //    //ab = "A SOUTH TRAVEL & TOURS";
                    //    //ab.Remove("'") = false;
                    //    ab = metroTextBox1.Text;
                    //    metroTextBox1.Text = metroTextBox1.Text.Replace("&", "&");
                    //}

                    
                    con.Open();
                    command = new SqlCommand("select c.COMPANY,c.ADDRESS,c.CITY,c.COUNTRY,c.[PHONE NO#],c.[PHONE NO# 2],c.UAN,c.FAX,c.EMAIL,c.URL,c.[CONTACT PERSON],c.STATUS,c.MOBILE from Company c where c.COMPANY = '" + metroTextBox1.Text + "'  ", con);
                    reader = command.ExecuteReader();
                    calls2();

                    con.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
        }

        public void calls123()
        {
            if (metroTextBox1.Text == "") { }
            else
            {
                c = metroTextBox1.Text;
                label7.Text = metroTextBox1.Text;
            }

           // metroComboBox1.Items.Clear();
            try
            {
                panel1.Controls.Clear();
                ab = metroTextBox1.Text;
                if (con.State == ConnectionState.Closed)
                {
                    // ab = metroTextBox1.Text;
                    if (metroTextBox1.Text.Contains("'") == true)
                    {
                        //ab = "A SOUTH TRAVEL & TOURS";
                        //ab.Remove("'") = false;
                        ab = metroTextBox1.Text;
                        metroTextBox1.Text = metroTextBox1.Text.Replace("'", "''");
                        g = metroTextBox1.Text;
                    }
                    //else if (metroTextBox1.Text.Contains("&") == true)
                    //{
                    //    //ab = "A SOUTH TRAVEL & TOURS";
                    //    //ab.Remove("'") = false;
                    //    ab = metroTextBox1.Text;
                    //    metroTextBox1.Text = metroTextBox1.Text.Replace("&", "&");
                    //}


                    con.Open();
                    command = new SqlCommand("select COMPANY,ADDRESS,CITY,COUNTRY,[PHONE NO#],[PHONE NO# 2],UAN,FAX,EMAIL,URL,[CONTACT PERSON],STATUS,MOBILE from Company c where COMPANY = '" + metroTextBox1.Text + "'  and CITY = '"+metroComboBox1.Text+"' ", con);
                    reader = command.ExecuteReader();
                    calls2();

                    con.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
        }
        


        public void calls2() {

            int a = 5;

            if (reader.HasRows == false)
            {
                label7.Text = "No Records Found..!";
                panel1.Controls.Clear();
                c = "";
            }
            else
            {
                while (reader.Read())
                {
                    Label l0 = new Label();
                    l0.Location = new Point(5, a);
                    l0.Font = new System.Drawing.Font("Segoe UI Semibold", 12);
                    l0.Size = new Size(550, 25);
                    l0.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");
                    l0.AutoEllipsis = true;
                    l0.UseMnemonic = false;

                    if (reader.IsDBNull(0))
                    {
                        l0.Text = "-----";

                    }
                    else
                    {
                        l0.Text = reader.GetString(0);
                    }

                    PictureBox pb30 = new PictureBox();
                    pb30.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\1.png"));
                    panel1.Controls.Add(pb30);
                    pb30.Location = new Point(20, a + 25);
                    pb30.Size = new Size(18, 18);

                    Label l1 = new Label();
                    l1.Location = new Point(40, a + 28);
                    l1.Font = new Font("Segoe UI", 9);
                    l1.Size = new Size(52, 15);
                    l1.Text = "Contact:";

                    Label l2 = new Label();
                    l2.Location = new Point(89, a + 28);
                    l2.Font = new Font("Segoe UI", 9);
                    l2.Size = new Size(170, 23);
                    l2.AutoEllipsis = true;
                    if (reader.IsDBNull(10))
                    {
                        l2.Text = "-----";
                    }
                    else
                    {
                        l2.Text = reader.GetString(10);
                        if (l2.Text == "")
                        {
                            l2.Text = "-----";

                        }
                    }

                    PictureBox pb1 = new PictureBox();
                    pb1.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\37.png"));
                    panel1.Controls.Add(pb1);
                    pb1.Location = new Point(265, a + 25);
                    pb1.Size = new Size(18, 18);

                    Label l3 = new Label();
                    l3.Location = new Point(285, a + 28);
                    l3.Font = new Font("Segoe UI", 9);
                    l3.Size = new Size(42, 20);
                    l3.Text = "Status:";


                    Label l4 = new Label();
                    l4.Location = new Point(325, a + 28);
                    l4.Font = new Font("Segoe UI", 9);
                    l4.Size = new Size(140, 20);
                    l4.AutoEllipsis = true;

                    if (reader.IsDBNull(11))
                    {
                        l4.Text = "-----";
                    }
                    else
                    {
                        l4.Text = reader.GetString(11);
                        if (l4.Text == "")
                        {
                            l4.Text = "-----";

                        }
                    }

                    PictureBox pb2 = new PictureBox();
                    pb2.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\41.png"));
                    panel1.Controls.Add(pb2);
                    pb2.Location = new Point(467, a + 25);
                    pb2.Size = new Size(18, 18);

                    Label l5 = new Label();
                    l5.Location = new Point(486, a + 28);
                    l5.Font = new Font("Segoe UI", 9);
                    l5.Size = new Size(47, 20);
                    l5.Text = "Mobile:";

                    Label l6 = new Label();
                    l6.Location = new Point(532, a + 28);
                    l6.Font = new Font("Segoe UI", 9);
                    l6.Size = new Size(92, 20);
                    l6.AutoEllipsis = true;

                    if (reader.IsDBNull(12))
                    {
                        l6.Text = "-----";
                    }
                    else
                    {
                        l6.Text = reader.GetString(12);
                        if (l6.Text == "")
                        {
                            l6.Text = "-----";

                        }
                    }

                    PictureBox pb3 = new PictureBox();
                    pb3.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\Line128.png"));
                    panel1.Controls.Add(pb3);
                    pb3.Location = new Point(5, a + 50);
                    pb3.Size = new Size(700, 18);

                    PictureBox pb4 = new PictureBox();
                    pb4.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\22.png"));
                    panel1.Controls.Add(pb4);
                    pb4.Location = new Point(20, a + 70);
                    pb4.Size = new Size(18, 18);

                    Label l7 = new Label();
                    l7.Location = new Point(40, a + 73);
                    l7.Font = new Font("Segoe UI", 9);
                    l7.Size = new Size(52, 20);
                    l7.Text = "Address:";

                    Label l8 = new Label();
                    l8.Location = new Point(90, a + 73);
                    l8.Font = new Font("Segoe UI", 9);
                    l8.Size = new Size(535, 20);
                    l8.AutoEllipsis = true;

                    if (reader.IsDBNull(1))
                    {
                        l8.Text = "-----";
                    }
                    else
                    {
                        l8.Text = reader.GetString(1);
                        if (l8.Text == "")
                        {
                            l8.Text = "-----";

                        }
                    }

                    PictureBox pb5 = new PictureBox();
                    pb5.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\52.png"));
                    panel1.Controls.Add(pb5);
                    pb5.Location = new Point(20, a + 100);
                    pb5.Size = new Size(18, 18);

                    Label l9 = new Label();
                    l9.Location = new Point(40, a + 103);
                    l9.Font = new Font("Segoe UI", 9);
                    l9.Size = new Size(31, 20);
                    l9.Text = "City:";

                    Label l10 = new Label();
                    l10.Location = new Point(69, a + 103);
                    l10.Font = new Font("Segoe UI", 9);
                    l10.Size = new Size(118, 20);
                    l10.AutoEllipsis = true;
                    if (reader.IsDBNull(2))
                    {
                        l10.Text = "-----";
                    }
                    else
                    {
                        l10.Text = reader.GetString(2);
                        if (l10.Text == "")
                        {
                            l10.Text = "-----";

                        }
                        if (metroComboBox1.Items.Contains("ALL"))
                        {

                        }
                        else
                        {

                            metroComboBox1.Items.Add("ALL");
                        }
                        if (metroComboBox1.Items.Contains(reader.GetString(2)))
                        {
                        }
                        else
                        {

                            metroComboBox1.Items.Add(reader.GetString(2));
                        }
                    }


                    PictureBox pb6 = new PictureBox();
                    pb6.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\72.png"));
                    panel1.Controls.Add(pb6);
                    pb6.Location = new Point(185, a + 100);
                    pb6.Size = new Size(18, 18);

                    Label l11 = new Label();
                    l11.Location = new Point(203, a + 103);
                    l11.Font = new Font("Segoe UI", 9);
                    l11.Size = new Size(40, 20);
                    l11.Text = "Email:";

                    Label l12 = new Label();
                    l12.Location = new Point(240, a + 103);
                    l12.Font = new Font("Segoe UI", 9);
                    l12.Size = new Size(185, 20);
                    l12.AutoEllipsis = true;

                    if (reader.IsDBNull(8))
                    {
                        l12.Text = "-----";
                    }
                    else
                    {
                        l12.Text = reader.GetString(8);
                        if (l12.Text == "")
                        {
                            l12.Text = "-----";

                        }
                    }


                    PictureBox pb7 = new PictureBox();
                    pb7.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\81.png"));
                    panel1.Controls.Add(pb7);
                    pb7.Location = new Point(430, a + 100);
                    pb7.Size = new Size(18, 18);

                    Label l13 = new Label();
                    l13.Location = new Point(450, a + 102);
                    l13.Font = new Font("Segoe UI", 9);
                    l13.Size = new Size(34, 20);
                    l13.Text = "Web:";

                    Label l14 = new Label();
                    l14.Location = new Point(482, a + 102);
                    l14.Font = new Font("Segoe UI", 9);
                    l14.Size = new Size(150, 20);
                    l14.Text = reader.GetString(9);
                    l14.AutoEllipsis = true;

                    if (reader.IsDBNull(9))
                    {
                        l14.Text = "-----";
                    }
                    else
                    {
                        l14.Text = reader.GetString(9);
                        if (l14.Text == "")
                        {
                            l14.Text = "-----";

                        }
                    }

                    PictureBox pb8 = new PictureBox();
                    pb8.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\93.png"));
                    panel1.Controls.Add(pb8);
                    pb8.Location = new Point(20, a + 130);
                    pb8.Size = new Size(18, 18);


                    Label l15 = new Label();
                    l15.Location = new Point(40, a + 133);
                    l15.Font = new Font("Segoe UI", 9);
                    l15.Size = new Size(44, 20);
                    l15.Text = "Phone:";

                    Label l16 = new Label();
                    l16.Location = new Point(80, a + 133);
                    l16.Font = new Font("Segoe UI", 9);
                    l16.Size = new Size(145, 20);
                    l16.AutoEllipsis = true;
                    if (reader.IsDBNull(5))
                    {
                        l16.Text = "-----";
                    }
                    else
                    {
                        l16.Text = reader.GetString(5);
                        if (l16.Text == "")
                        {
                            l16.Text = "-----";

                        }
                    }
                    

                    PictureBox pb9 = new PictureBox();
                    pb9.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\10.png"));
                    panel1.Controls.Add(pb9);
                    pb9.Location = new Point(225, a + 130);
                    pb9.Size = new Size(18, 18);

                    Label l17 = new Label();
                    l17.Location = new Point(243, a + 133);
                    l17.Font = new Font("Segoe UI", 9);
                    l17.Size = new Size(35, 20);
                    l17.Text = "UAN:";

                    Label l18 = new Label();
                    l18.Location = new Point(275, a + 133);
                    l18.Font = new Font("Segoe UI", 9);
                    l18.Size = new Size(150, 20);
                    l18.AutoEllipsis = true;
                    if (reader.IsDBNull(6))
                    {
                        l18.Text = "-----";
                    }
                    else
                    {
                        l18.Text = reader.GetString(6);
                        if (l18.Text == "")
                        {
                            l18.Text = "-----";

                        }
                    }
                    

                    PictureBox pb10 = new PictureBox();
                    pb10.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\11.png"));
                    panel1.Controls.Add(pb10);
                    pb10.Location = new Point(430, a + 131);
                    pb10.Size = new Size(18, 18);

                    Label l19 = new Label();
                    l19.Location = new Point(450, a + 133);
                    l19.Font = new Font("Segoe UI", 9);
                    l19.Size = new Size(31, 20);
                    l19.Text = "FAX:";

                    Label l20 = new Label();
                    l20.Name = a.ToString();
                    l20.Location = new Point(478, a + 133);
                    l20.Font = new Font("Segoe UI", 9);
                    l20.Size = new Size(150, 20);
                    l20.AutoEllipsis = true;
                    if (reader.IsDBNull(7))
                    {
                        l20.Text = "-----";
                    }
                    else
                    {
                        l20.Text = reader.GetString(7);
                        if (l20.Text == "")
                        {
                            l20.Text = "-----";

                        }
                    }

                    PictureBox pb12 = new PictureBox();
                    pb12.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\203.png"));
                    panel1.Controls.Add(pb12);
                    pb12.Location = new Point(20, a + 160);
                    pb12.Size = new Size(18, 18);

                    Label l21 = new Label();
                    l21.Location = new Point(40, a + 163);
                    l21.Font = new Font("Segoe UI", 9);
                    l21.AutoSize = true;
                    l21.Text = "Business Classifications:";

                    cm = new ComboBox();
                    cm.Location = new Point(177, a + 160);
                    cm.Size = new Size(200, 20);
                    cm.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                    cm.DropDownStyle = ComboBoxStyle.DropDownList;



                    PictureBox pb11 = new PictureBox();
                    pb11.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\Red05.png"));
                    panel1.Controls.Add(pb11);
                    pb11.Location = new Point(0, a + 200);
                    pb11.Size = new Size(709, 18);


                    this.Controls.Add(l0);
                    panel1.Controls.Add(l0);

                    this.Controls.Add(l1);
                    panel1.Controls.Add(l1);

                    this.Controls.Add(l2);
                    panel1.Controls.Add(l2);

                    this.Controls.Add(l3);
                    panel1.Controls.Add(l3);

                    this.Controls.Add(l4);
                    panel1.Controls.Add(l4);

                    this.Controls.Add(l5);
                    panel1.Controls.Add(l5);

                    this.Controls.Add(l6);
                    panel1.Controls.Add(l6);

                    this.Controls.Add(l7);
                    panel1.Controls.Add(l7);

                    this.Controls.Add(l8);
                    panel1.Controls.Add(l8);

                    this.Controls.Add(l9);
                    panel1.Controls.Add(l9);

                    this.Controls.Add(l10);
                    panel1.Controls.Add(l10);

                    this.Controls.Add(l11);
                    panel1.Controls.Add(l11);

                    this.Controls.Add(l12);
                    panel1.Controls.Add(l12);

                    this.Controls.Add(l13);
                    panel1.Controls.Add(l13);

                    this.Controls.Add(l14);
                    panel1.Controls.Add(l14);

                    this.Controls.Add(l15);
                    panel1.Controls.Add(l15);

                    this.Controls.Add(l16);
                    panel1.Controls.Add(l16);

                    this.Controls.Add(l17);
                    panel1.Controls.Add(l17);

                    this.Controls.Add(l18);
                    panel1.Controls.Add(l18);

                    this.Controls.Add(l19);
                    panel1.Controls.Add(l19);

                    this.Controls.Add(l20);
                    panel1.Controls.Add(l20);

                    this.Controls.Add(l21);
                    panel1.Controls.Add(l21);

                    this.Controls.Add(cm);
                    panel1.Controls.Add(cm);





                    SqlCommand sa = new SqlCommand("select distinct(b.[BUSINESS CLASSIFICATIONS]) from Bus_Class b, Company c where b.CODE_NO = c.CODE_NO and c.COMPANY = '" + metroTextBox1.Text + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(sa);
                    //DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    cm.ValueMember = "BUSINESS CLASSIFICATIONS";
                    cm.DataSource = dt;
                    sa.ExecuteNonQuery();

                    metroTextBox1.Text = ab;

                    a = a + 220;

                }
            }
        
        }

       


        private void metroLink1_Click(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Form1 fo = new Form1();
            fo.Show();
            this.Hide();


            //Form1 fo = new Form1();
            //fo.Show();
            //this.Hide();
        }

        private void Companies_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {

                DialogResult result = MetroMessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    //con.Close();
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

        private void metroButton3_Click(object sender, EventArgs e)
        {

            if (c == metroTextBox1.Text)
            {

            }
            else if (metroTextBox1.Text == "")
            {
                label7.Text = "Wrong input. Company name is required..!";
                panel1.Controls.Clear();
                c = "";
            }
            else
            {
                calls();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroComboBox1.Items.Clear();
            metroTextBox1.Clear();
            c = "";
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Test t1 = new Test();
            t1.Show();
            this.Hide();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            //Companies s = new Companies();
            //s.Show();
            //this.Hide();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Foreign f = new Foreign();
            f.Show();
            this.Hide();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Representatives r = new Representatives();
            r.Show();
            this.Hide();

        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Trade t = new Trade();
            t.Show();
            this.Hide();
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Contact c = new Contact();
            c.Show();
            this.Hide();
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Help h = new Help();
            h.Show();
            this.Hide();
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            About a = new About();
            a.Show();
            this.Hide();
        }

        private void metroTextBox1_Enter(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    calls();
            //}
            if (e.KeyCode == Keys.Enter)
            {

                if (c == metroTextBox1.Text) { }
                else
                {
                    calls();
                }

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

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox1.Text == "ALL")
            {
                calls();
            }

            else
            {
                calls123();
            }
        }

        public void print()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            int w = Convert.ToInt32(Width / 2.54) * 100;
            int h = Convert.ToInt32(Width / 2.54) * 100;
            //pdoc.DefaultPageSettings.Landscape = true;
            PaperSize psize = new PaperSize("Custom", w, h);
            pdoc.DefaultPageSettings.PaperSize = psize;
            pd.Document = pdoc;
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            DialogResult result = pd.ShowDialog();
            if (result == DialogResult.OK)
            {
                PrintPreviewDialog ppd = new PrintPreviewDialog();
                ppd.Document = pdoc;
                ((Form)ppd).WindowState = FormWindowState.Maximized;
                DialogResult ppdResult = ppd.ShowDialog();
            }
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            panel1.Height = 900;
            Bitmap bmp = new Bitmap(712, 1200, panel1.CreateGraphics());
            panel1.DrawToBitmap(bmp, new Rectangle(0, 30, panel1.Width, panel1.Height));
            label4.DrawToBitmap(bmp, new Rectangle(0, 0, label4.Width, label4.Height));
            label7.DrawToBitmap(bmp, new Rectangle(100, 3, label7.Width, label7.Height));
            metroLabel1.DrawToBitmap(bmp, new Rectangle(128, 950, metroLabel1.Width, metroLabel1.Height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(bmp, ((pagearea.Width / 2) - (this.panel1.Width / 2)) - 30, this.panel1.Location.Y - 130);
            Graphics g = e.Graphics; 
            g.TranslateTransform(350, 170); 
            g.RotateTransform(e.PageSettings.Landscape ? 30 : 60); 
            g.DrawString("JAMALS YELLOW "+Environment.NewLine+"PAGES PAKISTAN", new Font("Calibri", 75, FontStyle.Bold), new SolidBrush(Color.FromArgb(64, Color.Black)), 0, 0);
       
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            print();
            panel1.Height = 546;
        }
    }
}

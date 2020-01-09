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
using System.Drawing.Printing;

namespace Jamals_Yellow_Pages
{
    public partial class Trade : MetroFramework.Forms.MetroForm
    {
        public Trade()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R5P588T\SQLEXPRESS;Initial Catalog=Jamals;Persist Security Info=True;User ID=JamalsDatabase;Password=jamals");

        public static string Text123 = "";

        SqlCommand command1;
        SqlDataReader reader1;

        SqlCommand command;
        SqlDataReader reader;
        string c = "abc";

        private void Trade_Load(object sender, EventArgs e)
        {
            
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ec1c24");
            label7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");
            label7.UseMnemonic = false;
            
            metroPanel1.BackColor = Color.FromArgb(0, 174, 219);
            con.Open();
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            SqlCommand command = new SqlCommand("select distinct[country] from [Trade]", con);
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

        protected void l123_MouseEnter(object sender, EventArgs e)
        {
            //string cName = ((Label)sender).Name;
            Label lbl = sender as Label;
            // MessageBox.Show(cName.ToString());
            lbl.Font = new Font(lbl.Font.Name, lbl.Font.SizeInPoints, FontStyle.Underline);
        }

        protected void l123_MouseLeave(object sender, EventArgs e)
        {
            //string cName = ((Label)sender).Name;
            Label lbl = sender as Label;
            // MessageBox.Show(cName.ToString());
            lbl.Font = new Font(lbl.Font.Name, lbl.Font.SizeInPoints, FontStyle.Regular);
        }

        protected void l123_Click(object sender, EventArgs e)
        {
            //string cName = ((Label)sender).Name;
            Label lbl = sender as Label;
            //label2.Text = lbl.Text;
            Text123 = lbl.Text;
            Trade2 r2 = new Trade2();
            r2.Show();
            this.Hide();
            // MessageBox.Show(cName.ToString());
            //lbl.Font = new Font(lbl.Font.Name, lbl.Font.SizeInPoints, FontStyle.Regular);

        }

        public void calls()
        {
            if (metroTextBox1.Text == "") { }
            else
            {
                c = metroTextBox1.Text;
                label7.Text = metroTextBox1.Text;
            }

            
            try
            {
                panel1.Controls.Clear();

                if (con.State == ConnectionState.Closed)
                {
                    // ab = metroTextBox1.Text;

                    //else if (metroTextBox1.Text.Contains("&") == true)
                    //{
                    //    //ab = "A SOUTH TRAVEL & TOURS";
                    //    //ab.Remove("'") = false;
                    //    ab = metroTextBox1.Text;
                    //    metroTextBox1.Text = metroTextBox1.Text.Replace("&", "&");
                    //}

                    con.Open();
                    command = new SqlCommand("select mission,name,status, mobile,ad1,city,email1,url,phone_code,poff_1,fax1 from [Trade] where [country] = '" + metroTextBox1.Text + "'  ", con);
                    reader = command.ExecuteReader();
                    calls12();
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
            try
            {
                panel1.Controls.Clear();

                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    command = new SqlCommand("select mission,name,status, mobile,ad1,city,email1,url,phone_code,poff_1,fax1 from [Trade] where [country] = '" + c + "' and city = '"+metroComboBox1.Text+"' ", con);
                    reader = command.ExecuteReader();
                    calls12();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
        }


        public void calls12() {
            int a = 5;
            //int b = 55;

            if (reader.HasRows == false)
            {

                label7.Text = "No Records Found..!";
                panel1.Controls.Clear();
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
                    l2.Size = new Size(220, 23);
                    l2.AutoEllipsis = true;
                    if (reader.IsDBNull(1))
                    {
                        l2.Text = "-----";
                    }
                    else
                    {
                        l2.Text = reader.GetString(1);
                        if (l2.Text == "")
                        {
                            l2.Text = "-----";

                        }
                    }

                    PictureBox pb1 = new PictureBox();
                    pb1.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\37.png"));
                    panel1.Controls.Add(pb1);
                    pb1.Location = new Point(320, a + 25);
                    pb1.Size = new Size(18, 18);

                    Label l3 = new Label();
                    l3.Name = a.ToString();
                    l3.Location = new Point(340, a + 28);
                    l3.Font = new Font("Segoe UI", 9);
                    l3.Size = new Size(42, 20);
                    l3.Text = "Status:";


                    Label l4 = new Label();
                    l4.Location = new Point(380, a + 28);
                    l4.Font = new Font("Segoe UI", 9);
                    l4.Size = new Size(220, 20);
                    l4.AutoEllipsis = true;

                    if (reader.IsDBNull(2))
                    {
                        l4.Text = "-----";
                    }
                    else
                    {
                        l4.Text = reader.GetString(2);
                        if (l4.Text == "")
                        {
                            l4.Text = "-----";

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

                    if (reader.IsDBNull(4))
                    {
                        l8.Text = "-----";
                    }
                    else
                    {
                        l8.Text = reader.GetString(4);
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
                    l10.Size = new Size(115, 20);
                    l10.AutoEllipsis = true;
                    if (reader.IsDBNull(5))
                    {
                        l10.Text = "-----";
                    }
                    else
                    {
                        l10.Text = reader.GetString(5);
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
                        if (metroComboBox1.Items.Contains(reader.GetString(5)))
                        {
                        }
                        else
                        {

                            metroComboBox1.Items.Add(reader.GetString(5));
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
                    l12.Location = new Point(239, a + 103);
                    l12.Font = new Font("Segoe UI", 9);
                    l12.Size = new Size(185, 20);
                    l12.AutoEllipsis = true;

                    if (reader.IsDBNull(6))
                    {
                        l12.Text = "-----";
                    }
                    else
                    {
                        l12.Text = reader.GetString(6);
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

                    if (reader.IsDBNull(7))
                    {
                        l14.Text = "-----";
                    }
                    else
                    {
                        l14.Text = reader.GetString(7);
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

                    Label l16a = new Label();
                    l16a.Location = new Point(80, a + 133);
                    l16a.Font = new Font("Segoe UI", 9);
                    l16a.Size = new Size(315, 20);
                    l16a.AutoEllipsis = true;
               
                    if (reader.IsDBNull(8))
                    {
                        l16a.Text = "-----";
                    }
                    else
                    {
                        l16a.Text = reader.GetString(8);
                        if (l16a.Text == "")
                        {
                            l16a.Text = "-----";

                        }
                    }
                    

                    PictureBox pb10 = new PictureBox();
                    pb10.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\11.png"));
                    panel1.Controls.Add(pb10);
                    pb10.Location = new Point(401, a + 131);
                    pb10.Size = new Size(18, 18);

                    Label l19 = new Label();
                    l19.Location = new Point(421, a + 133);
                    l19.Font = new Font("Segoe UI", 9);
                    l19.Size = new Size(33, 20);
                    l19.Text = "FAX:";

                    Label l20 = new Label();
                    l20.Name = a.ToString();
                    l20.Location = new Point(451, a + 133);
                    l20.Font = new Font("Segoe UI", 9);
                    l20.Size = new Size(150, 20);
                    l20.AutoEllipsis = true;
                    if (reader.IsDBNull(10))
                    {
                        l20.Text = "-----";
                    }
                    else
                    {
                        l20.Text = reader.GetString(10);
                        if (l20.Text == "")
                        {
                            l20.Text = "-----";
                        }
                    }

                    PictureBox pb11 = new PictureBox();
                    pb11.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\Red05.png"));
                    panel1.Controls.Add(pb11);
                    pb11.Location = new Point(0, a + 170);
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

                    this.Controls.Add(l16a);
                    panel1.Controls.Add(l16a);

                    this.Controls.Add(l19);
                    panel1.Controls.Add(l19);

                    this.Controls.Add(l20);
                    panel1.Controls.Add(l20);

                    a = a + 190;

                }
            }
        
        }
        public void Catagories()
        {
            panel1.Controls.Clear();

            int a = 5;
            //int c = 10;
            int d = 340;

            while (reader1.Read())
            {


                Label l123 = new Label();
                l123.Name = reader1.GetString(0);

                //if (c == 10)
                //{
                //    l123.Location = new Point(5, a);
                //    c = 20;
                //}
                //else if (c == 20)
                //{
                //    l123.Location = new Point(5 + d, a);
                //    c = 10;
                //    a = a + 20;
                //}
                //else
                //{
                //}

                l123.Font = new System.Drawing.Font("Segoe UI Semibold", 10);

                if (a >= 400)
                {
                    //a = 5;
                    l123.Location = new Point(5 + d, a - 400);
                    // a = a + 20;
                }
                else
                {
                    l123.Location = new Point(5, a);
                }


                l123.Cursor = Cursors.Hand;
                l123.MouseEnter += new EventHandler(l123_MouseEnter);
                l123.MouseLeave += new EventHandler(l123_MouseLeave);
                l123.Click += new EventHandler(l123_Click);
                l123.Size = new Size(340, 25);
                //l0.AutoSize = true;
                l123.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");
                //l0.Text = reader.GetString(0);
                l123.AutoEllipsis = true;
                if (reader1.IsDBNull(0))
                {
                    l123.Text = "-----";
                }
                else
                {
                    l123.Text = reader1.GetString(0);
                }
                this.Controls.Add(l123);
                panel1.Controls.Add(l123);
                a = a + 20;
            }

        }


        private void calls2()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select distinct[country] from [Trade] order by [country]", con);
                    reader1 = command1.ExecuteReader();
                    Catagories();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
        }


        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Trade_FormClosing(object sender, FormClosingEventArgs e)
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

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Form1 fo = new Form1();
            fo.Show();
            this.Hide();
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
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Companies s = new Companies();
            s.Show();
            this.Hide();
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
            //Trade t = new Trade();
            //t.Show();
            //this.Hide();
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
        string pass = "ASAD";
        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            if (c == metroTextBox1.Text) { }
            if (pass == metroTextBox1.Text) {
                MetroFramework.MetroMessageBox.Show(this, "ASAD YOUSUF", "This Software is Designed and Developed By:", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
            else if (metroTextBox1.Text == "")
            {
                label7.Text = "Wrong input. Country name is required..!";
                panel1.Controls.Clear();
                c = "";
            }
            else
            {
                calls();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            calls2();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.Font = new Font(label3.Font.Name, label3.Font.SizeInPoints, FontStyle.Underline);

        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.Font = new Font(label3.Font.Name, label3.Font.SizeInPoints, FontStyle.Regular);

        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (c == metroTextBox1.Text) { }
                if (pass == metroTextBox1.Text)
                {
                    MetroFramework.MetroMessageBox.Show(this, "ASAD YOUSUF", "This Software is Designed and Developed By:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else if (metroTextBox1.Text == "")
                {
                    label7.Text = "Wrong input. Country name is required..!";
                    panel1.Controls.Clear();
                    c = "";
                }
                else
                {
                    calls();
                }
            
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroTextBox1.Clear();
            metroComboBox1.Items.Clear();
            c = "";
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

        private void metroTile9_MouseHover(object sender, EventArgs e)
        {

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

        private void metroLink1_Click(object sender, EventArgs e)
        {
            print();
            panel1.Height = 546;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            panel1.Height = 765;
            Bitmap bmp = new Bitmap(712, 1200, panel1.CreateGraphics());
            panel1.DrawToBitmap(bmp, new Rectangle(0, 30, panel1.Width, panel1.Height));
            label4.DrawToBitmap(bmp, new Rectangle(0, 0, label4.Width, label4.Height));
            label7.DrawToBitmap(bmp, new Rectangle(100, 3, label7.Width, label7.Height));
            metroLabel4.DrawToBitmap(bmp, new Rectangle(128, 950, metroLabel4.Width, metroLabel4.Height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(bmp, ((pagearea.Width / 2) - (this.panel1.Width / 2)) - 30, this.panel1.Location.Y - 130);
       
        }

        private void Trade_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsNumber(e.KeyChar))
            //{
            //    metroTextBox1.PasswordChar = '*';
            //   // MetroFramework.MetroMessageBox.Show(this, "ASAD YOUSUF", "This Software is Designed and Developed By:", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
        }

        private void metroTextBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

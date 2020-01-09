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
    public partial class About : MetroFramework.Forms.MetroForm
    {
        public About()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R5P588T\SQLEXPRESS;Initial Catalog=Jamals;Persist Security Info=True;User ID=JamalsDatabase;Password=jamals");

        SqlCommand command;
        SqlDataReader reader;
        string click = "abc";
        private void About_Load(object sender, EventArgs e)
        {
            
            //label5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ec1c24");
          //  pictureBox2.Visible = false;
            metroPanel1.BackColor = Color.FromArgb(0, 174, 219);
            label7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");
        //    label8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");
            label6.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");
            label7.UseMnemonic = false;

            //label8.MouseEnter += label8_MouseEnter;
            
            con.Open();
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            SqlCommand comm = new SqlCommand("select distinct area,class from CPEC", con);
            SqlDataReader dr = comm.ExecuteReader();
            
                while (dr.Read())
                {
                    // namesCollection.Add(dr[0].ToString());
                    if (metroComboBox1.Items.Contains(dr.GetString(0)))
                    {
                        // metroComboBox1.Items.Add("ALL");
                    }
                    else
                    {

                        metroComboBox1.Items.Add(dr.GetString(0));
                    }

                    if (metroComboBox3.Items.Contains(dr.GetString(1)))
                    {
                        // metroComboBox1.Items.Add("ALL");
                    }
                    else
                    {

                        metroComboBox3.Items.Add(dr.GetString(1));
                    }
                }



            
            dr.Close();
            //metroTextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //metroTextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //metroTextBox1.AutoCompleteCustomSource = namesCollection;
            con.Close();
           
            
        }

        int perpage = 5;
        int total;
        int s;
        string ac = "";
        string ad = "";
        public void call()
        {
            click = "C";
            perpage = 5;
            label6.Text = "";
           // pictureBox2.Visible = false;
            ac = metroComboBox3.Text;
            ad = metroComboBox1.Text;
            label7.Text = string.Concat(ac," / ", ad);     
           // label7.Text = metroTextBox1.Text;
            //metroComboBox1.Items.Clear();
            metroComboBox2.Items.Clear();
            //metroComboBox3.Items.Clear();
           // metroLabel2.Text = "1";
            SqlDataAdapter da = new SqlDataAdapter("select count(company) from CPEC where area = '" + metroComboBox1.Text + "' and class = '" + metroComboBox3.Text + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
           // label3.Text = dt.Rows[0][0].ToString();
            total = Convert.ToInt32(dt.Rows[0][0].ToString());
            s = total / perpage;

            if (dt.Rows[0][0].ToString() == "0")
            {
                label7.Text = "No Records Found.!";
                panel1.Controls.Clear();

            }
            else
            {
                 calls(0, 5);

            }

            if ((total % perpage) == 0)
            {

            }
            else
            {
                s = s + 1;
            }
            int i = 0;
            for (i = 1; i <= s; i++)
            {

                metroComboBox2.Items.Add(i);
            }
        }
       

        public void calls(int start, int end)
        {
            try
            {
                panel1.Controls.Clear();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command = new SqlCommand("select area,company,mainproduc,address,tel,fax,website from CPEC where  class = '"+metroComboBox3.Text+"' and area = '"+metroComboBox1.Text+"' order by company OFFSET " + start + " ROWS  FETCH NEXT 5 ROWS ONLY", con);
                    reader = command.ExecuteReader();
                    panel1.Controls.Clear();
                    calls123();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
        }


        Label l0;


        public void calls123()
        {

            int a = 5;

            while (reader.Read())
            {

                l0 = new Label();
                l0.Location = new Point(5, a);
                l0.Font = new System.Drawing.Font("Segoe UI Semibold", 12);
                l0.Size = new Size(610, 25);
                l0.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");
                l0.AutoEllipsis = true;
                if (reader.IsDBNull(1))
                {
                    l0.Text = "-----";
                }
                else
                {
                    l0.Text = reader.GetString(1);
                }

                PictureBox pb3 = new PictureBox();
                pb3.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\Line128.png"));
                panel1.Controls.Add(pb3);
                pb3.Location = new Point(5, a + 30);
                pb3.Size = new Size(700, 18);
                
                PictureBox pb4 = new PictureBox();
                pb4.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\22.png"));
                panel1.Controls.Add(pb4);
                pb4.Location = new Point(20, a + 50);
                pb4.Size = new Size(18, 18);

                Label l7 = new Label();
                l7.Location = new Point(40, a + 53);
                l7.Font = new Font("Segoe UI", 9);
                l7.Size = new Size(52, 20);
                l7.Text = "Address:";

                Label l8 = new Label();
                l8.Location = new Point(90, a + 53);
                l8.Font = new Font("Segoe UI", 9);
                l8.Size = new Size(535, 20);
                l8.AutoEllipsis = true;

                if (reader.IsDBNull(3))
                {
                    l8.Text = "-----";
                }
                else
                {
                    l8.Text = reader.GetString(3);
                    if (l8.Text == "")
                    {
                        l8.Text = "-----";

                    }
                }


                PictureBox pb5 = new PictureBox();
                pb5.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\52.png"));
                panel1.Controls.Add(pb5);
                pb5.Location = new Point(20, a + 80);
                pb5.Size = new Size(18, 18);

                Label l9 = new Label();
                l9.Location = new Point(40, a + 83);
                l9.Font = new Font("Segoe UI", 9);
                l9.Size = new Size(31, 20);
                l9.Text = "City:";


                Label l10 = new Label();

                l10.Location = new Point(67, a + 83);
                l10.Font = new Font("Segoe UI", 9);
                l10.Cursor = Cursors.Hand;
                l10.Size = new Size(128, 20);
                l10.AutoEllipsis = true;
                if (reader.IsDBNull(0))
                {
                    l10.Text = "-----";
                }
                else
                {
                    l10.Text = reader.GetString(0);
                    if (l10.Text == "")
                    {
                        l10.Text = "-----";

                    }
                }

                PictureBox pb7 = new PictureBox();
                pb7.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\81.png"));
                panel1.Controls.Add(pb7);
                pb7.Location = new Point(210, a + 80);
                pb7.Size = new Size(18, 18);

                Label l13 = new Label();
                l13.Location = new Point(228, a + 83);
                l13.Font = new Font("Segoe UI", 9);
                l13.Size = new Size(34, 20);
                l13.Text = "Web:";

                Label l14 = new Label();
                l14.Location = new Point(260, a + 83);
                l14.Font = new Font("Segoe UI", 9);
                l14.Size = new Size(175, 20);
                l14.AutoEllipsis = true;

                if (reader.IsDBNull(6))
                {
                    l14.Text = "-----";
                }
                else
                {
                    l14.Text = reader.GetString(6);
                    if (l14.Text == "")
                    {
                        l14.Text = "-----";

                    }
                }

                PictureBox pb8 = new PictureBox();
                pb8.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\93.png"));
                panel1.Controls.Add(pb8);
                pb8.Location = new Point(20, a + 110);
                pb8.Size = new Size(18, 18);


                Label l15 = new Label();
                l15.Location = new Point(40, a + 113);
                l15.Font = new Font("Segoe UI", 9);
                l15.Size = new Size(44, 20);
                l15.Text = "Phone:";

                Label l16 = new Label();
                l16.Location = new Point(80, a + 113);
                l16.Font = new Font("Segoe UI", 9);
                l16.Size = new Size(123, 20);
                l16.AutoEllipsis = true;
                if (reader.IsDBNull(4))
                {
                    l16.Text = "-----";
                }
                else
                {
                    l16.Text = reader.GetString(4);
                    if (l16.Text == "")
                    {
                        l16.Text = "-----";

                    }
                }
                

                PictureBox pb10 = new PictureBox();
                pb10.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\11.png"));
                panel1.Controls.Add(pb10);
                pb10.Location = new Point(445, a + 80);
                pb10.Size = new Size(18, 18);

                Label l19 = new Label();
                l19.Location = new Point(465, a + 82);
                l19.Font = new Font("Segoe UI", 9);
                l19.Size = new Size(30, 20);
                l19.Text = "FAX:";

                Label l20 = new Label();
                l20.Name = a.ToString();
                l20.Location = new Point(493, a + 82);
                l20.Font = new Font("Segoe UI", 9);
                l20.Size = new Size(130, 20);
                if (reader.IsDBNull(5))
                {
                    l20.Text = "-----";
                }
                else
                {
                    l20.Text = reader.GetString(5);
                    if (l20.Text == "")
                    {
                        l20.Text = "-----";

                    }
                }

                PictureBox pb12 = new PictureBox();
                pb12.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\p.png"));
                panel1.Controls.Add(pb12);
                pb12.Location = new Point(210, a + 110);
                pb12.Size = new Size(18, 18);

                Label l21 = new Label();
                l21.Location = new Point(228, a + 113);
                l21.Font = new Font("Segoe UI", 9);
                l21.Size = new Size(57, 20);
                l21.Text = "Products:";

                Label l12 = new Label();
                l12.Location = new Point(282, a + 113);
                l12.Font = new Font("Segoe UI", 9);
                l12.Size = new Size(345, 32);
                l12.AutoEllipsis = true;

                if (reader.IsDBNull(2))
                {
                    l12.Text = "-----";
                }
                else
                {
                    l12.Text = reader.GetString(2);
                    if (l12.Text == "")
                    {
                        l12.Text = "-----";

                    }
                }

                PictureBox pb11 = new PictureBox();
                pb11.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\Red05.png"));
                panel1.Controls.Add(pb11);
                pb11.Location = new Point(0, a + 152);
                pb11.Size = new Size(709, 18);


                this.Controls.Add(l0);
                panel1.Controls.Add(l0);

                this.Controls.Add(l7);
                panel1.Controls.Add(l7);

                this.Controls.Add(l8);
                panel1.Controls.Add(l8);

                this.Controls.Add(l9);
                panel1.Controls.Add(l9);

                this.Controls.Add(l10);
                panel1.Controls.Add(l10);

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

                this.Controls.Add(l19);
                panel1.Controls.Add(l19);

                this.Controls.Add(l20);
                panel1.Controls.Add(l20);

                this.Controls.Add(l21);
                panel1.Controls.Add(l21);

                a = a + 172;

            }
        }
       
   
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroLink3_Click(object sender, EventArgs e)
        {

        }

        private void metroLink4_Click(object sender, EventArgs e)
        {

        }

        private void metroLink2_Click(object sender, EventArgs e)
        {

        }

        private void metroLink2_Click_1(object sender, EventArgs e)
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
            //About a = new About();
            //a.Show();
            //this.Hide();
            
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (metroComboBox3.Text == "" && metroComboBox1.Text == "") {
                //pictureBox2.Visible = true;
                label7.Text = "Wrong input. Classification and City not selected.!";

            }
            else if (metroComboBox3.Text == "") {
              //  pictureBox2.Visible = true;
                label7.Text = "Wrong input. Classification not selected.!";
            
            }
            else if (metroComboBox1.Text == "")
            {
                //pictureBox2.Visible = true;
                label7.Text = "Wrong input. City not selected.!";
            }
            else {
                call();
            
            }
            
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
       {
            //int page = Convert.ToInt32(metroLabel2.Text);
            int page;
            //int perpage = 5;
            int offset = 0;
            int start = 0;


            if (Convert.ToInt32(metroComboBox2.Text) != 0)
            {
                page = Convert.ToInt32(metroComboBox2.Text);

                offset = perpage * page;

                start = offset - perpage;

            }

            else
            {
                page = 0;
                offset = 0;
            }

            if (click == "C")
            {
                calls(start, offset);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void metroTile10_Click(object sender, EventArgs e)
        {

        }

        private void metroTile10_MouseEnter(object sender, EventArgs e)
        {
            metroTile10.Style = MetroColorStyle.Yellow;
        }

        private void metroTile10_MouseLeave(object sender, EventArgs e)
        {
            metroTile10.Style = MetroColorStyle.Default;
        }

        private void metroTile10_Click_1(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            CPEC c = new CPEC();
            c.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        

       // Bitmap bmp;


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            panel1.Height = 865;
            Bitmap bmp = new Bitmap(712, 1200, panel1.CreateGraphics());          
            panel1.DrawToBitmap(bmp, new Rectangle(0, 30, panel1.Width, panel1.Height));
            label4.DrawToBitmap(bmp, new Rectangle(0, 0, label4.Width, label4.Height));
            label7.DrawToBitmap(bmp, new Rectangle(100, 3, label7.Width, label7.Height));
            metroLabel4.DrawToBitmap(bmp, new Rectangle(128, 950, metroLabel4.Width, metroLabel4.Height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(bmp, ((pagearea.Width / 2) - (this.panel1.Width / 2))-30, this.panel1.Location.Y-130 );
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Graphics g = this.CreateGraphics();
           // bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
           //// this.Controls.Add(new LiteralControl("&nbsp;"));
           // Graphics mg = Graphics.FromImage(bmp);
           // //int x = this.Location.X + 270;
           // mg.CopyFromScreen(this.Location.X+278, this.Location.Y, 25, 0, this.Size);
           // printPreviewDialog1.ShowDialog();
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
        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //panel1.Height = 547;
        }

        private void metroLink1_Click_1(object sender, EventArgs e)
        {
          
            print();
            panel1.Height = 547;

            
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            //label8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ec1c24");

        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
           // label8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");

        }

        private void metroLink1_MouseEnter(object sender, EventArgs e)
        {
         //   label8.Font = new Font(label8.Font.Name, label8.Font.SizeInPoints, FontStyle.Underline);
         //   label8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ec1c24");

        }

        private void metroLink1_MouseLeave(object sender, EventArgs e)
        {
           // label8.Font = new Font(label8.Font.Name, label8.Font.SizeInPoints, FontStyle.Regular);
           // label8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

      


        
    }
}

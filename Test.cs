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
using System.Drawing.Printing;
using System.Threading;


namespace Jamals_Yellow_Pages
{
    public partial class Test : MetroFramework.Forms.MetroForm
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R5P588T\SQLEXPRESS;Initial Catalog=Jamals;Persist Security Info=True;User ID=JamalsDatabase;Password=jamals;MultipleActiveResultSets=True");
        string c;
        public Test()
        {
            InitializeComponent();
           // conn.Open();
        }
        string click = "abc";
        int perpage = 5;
        //Label l0 = new Label();
        public static string Text1 = "";
        int total;
        SqlCommand command1;
        SqlDataReader reader1;

        SqlDataAdapter daa;
        DataTable dtt;
        private delegate void DisplayImage(Image i);
        
         private void Test_Load(object sender, EventArgs e)
        {
            //metroComboBox1.SelectedIndex = 1;
            //orginalindex = comboBox1.SelectedIndex;
            //metroComboBox1.Text = "Please, select any value";
           // metroComboBox2.Items.Insert(0, "Please select any value");
         //   this.metroProgressSpinner1.Hide();
            
            //this.Enabled = false;
            

            metroTextBox1.Text = metroTextBox1.Text.ToUpper();
            metroPanel1.BackColor = Color.FromArgb(0, 174, 219);
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ec1c24");
            label7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");
            label7.UseMnemonic = false;
            con.Open();
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            SqlCommand command = new SqlCommand("select distinct[BUSINESS CLASSIFICATIONS] from Bus_Class", con);
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
      
        

         //private void ShowGifImage(string i)
         //{
             
         //    if (this.InvokeRequired)
         //    {
         //        DisplayImage display = new DisplayImage(ShowGifImage);
         //        this.Invoke(display, new object[] { i });
         //    }
         //    else
         //    {
         //        //show gif image
         //    }
         //}
        //    }
        //}


    

         //private Label jobNumStatic;
         protected void l0_MouseEnter(object sender, EventArgs e)
         {            
             //string cName = ((Label)sender).Name;
             Label lbl = sender as Label;            
             // MessageBox.Show(cName.ToString());
             lbl.Font = new Font(lbl.Font.Name, lbl.Font.SizeInPoints, FontStyle.Underline);
         }

         protected void l0_MouseLeave(object sender, EventArgs e)
         {
             //string cName = ((Label)sender).Name;
             Label lbl = sender as Label;
             // MessageBox.Show(cName.ToString());
             lbl.Font = new Font(lbl.Font.Name, lbl.Font.SizeInPoints, FontStyle.Regular);
         }

          protected void l0_Click(object sender, EventArgs e)
         {
             //string cName = ((Label)sender).Name;
             Label lbl = sender as Label;
             //label2.Text = lbl.Text;
             Text1 = lbl.Text;
             Test2 t2 = new Test2();
             t2.Show();
             this.Hide();
             // MessageBox.Show(cName.ToString());
             //lbl.Font = new Font(lbl.Font.Name, lbl.Font.SizeInPoints, FontStyle.Regular);

         }

          //private void metroTextBox1_Enter(object sender, EventArgs e)
          //{
          //    MessageBox.Show("Jamals");
          //}



        
        private void metroLink1_Click(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Form1 fo = new Form1();
            fo.Show();
            this.Hide();
        }

        SqlCommand command;
        SqlDataReader reader;
        
        //int a = 5;



        public void call() 
        {
            click = "Search";
            perpage = 5;
            label7.Text = metroTextBox1.Text;
            metroComboBox1.Items.Clear();
            metroComboBox2.Items.Clear();
            metroLabel2.Text = "1";
            SqlDataAdapter da = new SqlDataAdapter("select count(c.Company) from Company c inner join Bus_Class b on c.code_no = b.code_no and b.[BUSINESS CLASSIFICATIONS] = '" + metroTextBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //label1.Text = dtt.Rows[0][0].ToString();
            total = Convert.ToInt32(dt.Rows[0][0].ToString());
            s = total / perpage;

            if (dt.Rows[0][0].ToString() == "0")
            {
                label7.Text = "No Records Found..!";
                panel1.Controls.Clear();
                c = "";
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
      
        public void calls1234()
        {
            try
            {

                panel1.Controls.Clear();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command = new SqlCommand("select c.COMPANY,c.ADDRESS,c.CITY,c.COUNTRY,c.[PHONE NO#],c.[PHONE NO# 2],c.UAN,c.FAX,c.EMAIL,c.URL,c.[CONTACT PERSON],c.STATUS,c.MOBILE from Company c inner join Bus_Class b on c.code_no = b.code_no and b.[BUSINESS CLASSIFICATIONS] = '" + c + "' and c.CITY = '" + metroComboBox1.Text + "' order by company", con);
                    reader = command.ExecuteReader();
                    panel1.Controls.Clear();
                    //metroComboBox1.ValueMember = "City";
                    //metroComboBox1.DataSource = dtt;
                   

                    calls123();

                    //int b = 55;


                    con.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
        }


        public void calls(int start, int end)
        {
            if (metroTextBox1.Text == "") { }
            else {
                c = metroTextBox1.Text;
            }
            
            try
            {
                
                panel1.Controls.Clear();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command = new SqlCommand("select c.COMPANY,c.ADDRESS,c.CITY,c.COUNTRY,c.[PHONE NO#],c.[PHONE NO# 2],c.UAN,c.FAX,c.EMAIL,c.URL,c.[CONTACT PERSON],c.STATUS,c.MOBILE from Company c inner join Bus_Class b on c.code_no = b.code_no and b.[BUSINESS CLASSIFICATIONS] = '" + metroTextBox1.Text + "' order by company OFFSET  " + start + " ROWS  FETCH NEXT 5 ROWS ONLY", con);
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

        ComboBox cm;
        Label l0;
        

        public void calls123() {

            int a = 5;       

                while (reader.Read())
                {

                    l0 = new Label();
                    l0.Location = new Point(5, a);
                    l0.Font = new System.Drawing.Font("Segoe UI Semibold", 12);
                    l0.Size = new Size(610, 25);
                    l0.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");
                    l0.AutoEllipsis = true;
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
                    l2.Size = new Size(170, 20);
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
                 //   l3.Name = a.ToString();
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
                        if (l12.Text == "") {
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
                  //  l20.Name = a.ToString();
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

                    SqlCommand sa = new SqlCommand("select distinct(b.[BUSINESS CLASSIFICATIONS]) from Bus_Class b inner join Company c on b.CODE_NO = c.CODE_NO and c.COMPANY = '" + l0.Text + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(sa);
                    //DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    cm.ValueMember = "BUSINESS CLASSIFICATIONS";
                    cm.DataSource = dt;
                    sa.ExecuteNonQuery();

                    a = a + 220;

                }  
        }
       
        public void Catagories() 
        {
            panel1.Controls.Clear();

            int a = 5;
            int c = 10;
            int d = 340;

            while (reader1.Read())
            {


                Label l123 = new Label();
                l123.Name = reader1.GetString(0);

                if (c == 10)
                {
                    l123.Location = new Point(5, a);
                    c = 20;
                }
                else if (c == 20)
                {
                    l123.Location = new Point(5 + d, a);
                    c = 10;
                    a = a + 20;
                }
                else
                {
                }

                l123.Font = new System.Drawing.Font("Segoe UI Semibold", 10);
                l123.Cursor = Cursors.Hand;
                l123.UseMnemonic = false;
                l123.MouseEnter += new EventHandler(l0_MouseEnter);
                l123.MouseLeave += new EventHandler(l0_MouseLeave);
                l123.Click += new EventHandler(l0_Click);
                l123.Size = new Size(340, 25);
                l123.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74c3c");
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

            }
        
        }


        private void calls2(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'A%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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

        private void calls3(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'B%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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

        private void calls4(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'C%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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

        private void calls5(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'D%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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

        private void calls6(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'E%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls7(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'F%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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

        private void calls8(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'G%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls9(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'H%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls10(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'I%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls11(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'J%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls12(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'K%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls13(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'L%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls14(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'M%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls15(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'N%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls16(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'O%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls17(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'P%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls18(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'Q%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls19(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'R%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls20(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'S%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls21(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'T%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls22(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'U%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls23(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'V%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls24(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'W%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls25(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'X%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls26(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'Y%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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
        private void calls27(int start, int end)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    command1 = new SqlCommand("select DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'Z%' order by ([BUSINESS CLASSIFICATIONS]) OFFSET " + start + " ROWS  FETCH NEXT 60 ROWS ONLY", con);
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

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           // int page = Convert.ToInt32(metroLabel2.Text);
            int page;
          
            //int perpage = 5;
            int offset  = 0;
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

            if (click == "Search")
            {
                calls(start, offset);
            }

            else if (click == "A")
            {
                calls2(start, offset);   
            }
            else if (click == "B")
            {
                calls3(start, offset);
            }
            else if (click == "C")
            {
                calls4(start, offset);
            }
            else if (click == "D")
            {
                calls5(start, offset);
            }
            else if (click == "E")
            {
                calls6(start, offset);
            }
            else if (click == "F")
            {
                calls7(start, offset);
            }
            else if (click == "G")
            {
                calls8(start, offset);
            }
            else if (click == "H")
            {
                calls9(start, offset);
            }
            else if (click == "I")
            {
                calls10(start, offset);
            }
            else if (click == "J")
            {
                calls11(start, offset);
            }
            else if (click == "K")
            {
                calls12(start, offset);
            }
            else if (click == "L")
            {
                calls13(start, offset);
            }
            else if (click == "M")
            {
                calls14(start, offset);
            }
            else if (click == "N")
            {
                calls15(start, offset);
            }
            else if (click == "O")
            {
                calls16(start, offset);
            }
            else if (click == "P")
            {
                calls17(start, offset);
            }
            else if (click == "Q")
            {
                calls18(start, offset);
            }
            else if (click == "R")
            {
                calls19(start, offset);
            }
            else if (click == "S")
            {
                calls20(start, offset);
            }
            else if (click == "T")
            {
                calls21(start, offset);
            }
            else if (click == "U")
            {
                calls22(start, offset);
            }
            else if (click == "V")
            {
                calls23(start, offset);
            }
            else if (click == "W")
            {
                calls24(start, offset);
            }
            else if (click == "X")
            {
                calls25(start, offset);
            }
            else if (click == "Y")
            {
                calls26(start, offset);
            }
            else if (click == "Z")
            {
                calls27(start, offset);
            }
            else { 
            
            }

           

            // MessageBox.Show(start.ToString()+" "+offset.ToString());

            var next = page - 1;
            var prv = page + 1;
            metroLabel2.Text = metroComboBox2.Text;
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        int s;
        string pass = "ASAD";
        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (c == metroTextBox1.Text) {
                
            }
            if (pass == metroTextBox1.Text)
            {
                MetroFramework.MetroMessageBox.Show(this, "ASAD YOUSUF", "This Software is Designed and Developed By:", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (metroTextBox1.Text == "")
            {
                 label7.Text = "Wrong input. Classification is required..!";
                 panel1.Controls.Clear();
                 c = "";

            }
            else
            {
                call();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroTextBox1.Clear();
            metroComboBox1.Items.Clear();
            metroComboBox2.Items.Clear();

            c = "";
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
                 
            
        }

        

        public void cata1() {

           
            perpage = 60;
            metroComboBox1.Items.Clear();
            metroComboBox2.Items.Clear();
            metroLabel2.Text = "1";
            dtt = new DataTable();
            daa.Fill(dtt);
            //label1.Text = dtt.Rows[0][0].ToString();
            int total = Convert.ToInt32(dtt.Rows[0][0].ToString());
            s = total / perpage;

            

            if ((total % perpage) == 0)
            {

            }
            else
            {
                s = s + 1;
            }

            for (int i = 1; i <= s; i++)
            {

                metroComboBox2.Items.Add(i);

            }
        
        }

        private void metroLink19_Click(object sender, EventArgs e)
        {
            click = "B";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'B%'", con);
            cata1();
            calls3(0, 60);
          
           
        }

        private void metroLink28_Click(object sender, EventArgs e)
        {
            
        }

        private void metroLink28_MouseHover(object sender, EventArgs e)
        {
            
        }


        private void metroLabel4_MouseEnter(object sender, EventArgs e)
        {
            metroLabel4.Font = new Font(metroLabel4.Font.Name, metroLabel4.Font.SizeInPoints, FontStyle.Underline);
        }

        private void metroLabel4_MouseLeave(object sender, EventArgs e)
        {
            metroLabel4.Font = new Font(metroLabel4.Font.Name, metroLabel4.Font.SizeInPoints, FontStyle.Regular);
        }

        private void metroLabel4_MouseHover(object sender, EventArgs e)
        {
            metroLabel4.Font = new Font(metroLabel4.Font.Name, metroLabel4.Font.SizeInPoints, FontStyle.Underline);

        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.Font = new Font(label3.Font.Name, label3.Font.SizeInPoints, FontStyle.Underline);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.Font = new Font(label3.Font.Name, label3.Font.SizeInPoints, FontStyle.Regular);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
            Search_C s = new Search_C();
            s.Show();
            this.Hide();
        }

        private void metroLink28_Click_1(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.Hand;
            click = "A";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'A%'", con);
            cata1();
            calls2(0, 60);
        }
        int y = 0;
        private void metroTile2_Click(object sender, EventArgs e)
        {
                //Test t1 = new Test();
                //t1.Show();
                //this.Hide();
                //y = 1;

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

        private void metroTile7_Click(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Contact c = new Contact();
            c.Show();
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

        private void Test_FormClosing(object sender, FormClosingEventArgs e)
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

        private void metroLink18_Click(object sender, EventArgs e)
        {
            click = "C";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'C%'", con);
            cata1();
            calls4(0, 60);
        }

        private void metroLink17_Click(object sender, EventArgs e)
        {
            click = "D";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'D%'", con);
            cata1();
            calls5(0, 60);
        }

        private void metroLink16_Click(object sender, EventArgs e)
        {
            click = "E";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'E%'", con);
            cata1();
            calls6(0, 60);
        }

        private void metroLink15_Click(object sender, EventArgs e)
        {
            click = "F";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'F%'", con);
            cata1();
            calls7(0, 60);
        }

        private void metroLink14_Click(object sender, EventArgs e)
        {
            click = "G";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'G%'", con);
            cata1();
            calls8(0, 60);
        }

        private void metroLink13_Click(object sender, EventArgs e)
        {
            click = "H";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'H%'", con);
            cata1();
            calls9(0, 60);
        }

        private void metroLink12_Click(object sender, EventArgs e)
        {
            click = "I";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'I%'", con);
            cata1();
            calls10(0, 60);
        }

        private void metroLink11_Click(object sender, EventArgs e)
        {
            click = "J";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'J%'", con);
            cata1();
            calls11(0, 60);
        }

        private void metroLink10_Click(object sender, EventArgs e)
        {
            click = "K";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'K%'", con);
            cata1();
            calls12(0, 60);
        }

        private void metroLink9_Click(object sender, EventArgs e)
        {
            click = "L";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'L%'", con);
            cata1();
            calls13(0, 60);
        }

        private void metroLink8_Click(object sender, EventArgs e)
        {
            click = "M";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'M%'", con);
            cata1();
            calls14(0, 60);
        }

        private void metroLink7_Click(object sender, EventArgs e)
        {
            click = "N";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'N%'", con);
            cata1();
            calls15(0, 60);
        }

        private void metroLink6_Click(object sender, EventArgs e)
        {
            click = "O";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'O%'", con);
            cata1();
            calls16(0, 60);
        }

        private void metroLink5_Click(object sender, EventArgs e)
        {
            click = "P";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'P%'", con);
            cata1();
            calls17(0, 60);
        }

        private void metroLink4_Click(object sender, EventArgs e)
        {
            click = "Q";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'Q%'", con);
            cata1();
            calls18(0, 60);
        }

        private void metroLink3_Click(object sender, EventArgs e)
        {
            click = "R";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'R%'", con);
            cata1();
            calls19(0, 60);
        }

        private void metroLink22_Click(object sender, EventArgs e)
        {
            click = "S";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'S%'", con);
            cata1();
            calls20(0, 60);
        }

        private void metroLink21_Click(object sender, EventArgs e)
        {
            click = "T";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'T%'", con);
            cata1();
            calls21(0, 60);
        }

        private void metroLink20_Click(object sender, EventArgs e)
        {
            click = "U";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'U%'", con);
            cata1();
            calls22(0, 60);
        }

        private void metroLink27_Click(object sender, EventArgs e)
        {
            click = "V";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'V%'", con);
            cata1();
            calls23(0, 60);
        }

        private void metroLink26_Click(object sender, EventArgs e)
        {
            click = "W";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'W%'", con);
            cata1();
            calls24(0, 60);
        }

        private void metroLink25_Click(object sender, EventArgs e)
        {
            click = "X";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'X%'", con);
            cata1();
            calls25(0, 60);
        }

        private void metroLink24_Click(object sender, EventArgs e)
        {
            click = "Y";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'Y%'", con);
            cata1();
            calls26(0, 60);
        }

        private void metroLink23_Click(object sender, EventArgs e)
        {
            click = "Z";
            daa = new SqlDataAdapter("select count(DISTINCT([BUSINESS CLASSIFICATIONS])) from Bus_Class where [BUSINESS CLASSIFICATIONS] like 'Z%'", con);
            cata1();
            calls27(0, 60);
        }

        private void metroLink28_MouseHover_1(object sender, EventArgs e)
        {
           // this.Cursor = Cursors.Hand;
        }

        private void metroLink28_MouseEnter(object sender, EventArgs e)
        {
            //metroLink28.Font = new Font(metroLink28.Font.Name, metroLink28.Font.SizeInPoints, FontStyle.Underline);
            //this.metroLink28.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
           // metroLink28.TextDecorations = TextDecorations.Underline;
            //metroLink28.Font = new Font(System.Windows.Forms.Font.Underline);

            var font = metroLink28.Font;
            metroLink28.Font = new Font(font, FontStyle.Underline);
           // this.Cursor = Cursors.Hand;
            //Font f = metroLink28.Font;
            //metroLink28.Font = new Font(f, f.Style && !FontStyle.Underline);
            
            //this.metroLink28.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;






        }

        private void metroLink28_MouseLeave(object sender, EventArgs e)
        {
            metroLink28.Font = new Font(metroLink28.Font.Name, metroLink28.Font.SizeInPoints, FontStyle.Regular);
           // this.Cursor = Cursors.Arrow;
        }

        private void metroLink19_MouseEnter(object sender, EventArgs e)
        {
            var font = metroLink19.Font;
            metroLink19.Font = new Font(font, FontStyle.Underline);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Enter(object sender, EventArgs e)
        {
            // MessageBox.Show("Jamals");
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
                    label7.Text = "Wrong input. Classification is required..!";
                    panel1.Controls.Clear();
                    c = "";

                }
                else
                {
                    call();
                }
            
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
    

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //label8.Text = metroComboBox1.Text;
            if (metroComboBox1.Text == "ALL")
            {
                click = "Search";
                perpage = 5;
                metroComboBox1.Items.Clear();
                metroComboBox2.Items.Clear();
                metroLabel2.Text = "1";
                SqlDataAdapter da = new SqlDataAdapter("select count(c.Company) from Company c inner join Bus_Class b on c.code_no = b.code_no and b.[BUSINESS CLASSIFICATIONS] = '" + c + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //label1.Text = dtt.Rows[0][0].ToString();
                total = Convert.ToInt32(dt.Rows[0][0].ToString());
                s = total / perpage;

                calls(0, 5);

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
            else {
                metroComboBox2.Items.Clear();
                calls1234();
            }
            
            
        }

        private void metroComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
     
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

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
            e.Graphics.DrawImage(bmp, ((pagearea.Width / 2) - (this.panel1.Width / 2)) - 30, this.panel1.Location.Y - 190);
          
            Graphics g = e.Graphics;
            g.TranslateTransform(350, 150);
            g.RotateTransform(e.PageSettings.Landscape ? 30 : 60);
            g.DrawString("JAMALS YELLOW " + Environment.NewLine + "PAGES PAKISTAN", new Font("Calibri", 75, FontStyle.Bold), new SolidBrush(Color.FromArgb(60, Color.LightGray)), 0, 0);
       
           
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            print();
            panel1.Height = 490;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Test_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
    }
}

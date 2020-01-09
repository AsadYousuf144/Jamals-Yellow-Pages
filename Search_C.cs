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
    public partial class Search_C : MetroFramework.Forms.MetroForm
    {
        //string strProvider = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Asad\Documents\Visual Studio 2013\Projects\Jamals Yellow Pages\Database\Jamals.accdb";
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R5P588T\SQLEXPRESS;Initial Catalog=Jamals;Persist Security Info=True;User ID=JamalsDatabase;Password=jamals");
     // OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=orcl;User ID=Asad;Password=jamals;Unicode=True");
       
        public Search_C()
        {
            InitializeComponent();
              // StartPosition was set to FormStartPosition.Manual in the properties window.
            
        }




        DataSet d1 = new DataSet();
        DataSet d2 = new DataSet();
        DataTable dt;
        SqlDataAdapter da;

        //private void metroGrid1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        //{
        //    e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            
        //}



        private void Search_C_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            int h = Screen.PrimaryScreen.WorkingArea.Height;
            int w = Screen.PrimaryScreen.WorkingArea.Width;
            this.ClientSize = new Size(w, h);
            metroPanel1.BackColor = Color.FromArgb(0, 174, 219);
  
     
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {
            ////con.Open();
            //OleDbDataAdapter oda = new OleDbDataAdapter("select * from jamals where company like 'A%'", con);
            //DataTable dt = new DataTable();
            //oda.Fill(dt);


            //metroGrid1.DataSource = dt;
            //metroGrid1.Columns[0].Visible = false;

            //metroGrid1.Columns[1].DefaultCellStyle.Font = new Font("Verdana", 16, FontStyle.Bold);
       
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            //this.MouseHover += new EventHandler(Search);
            //this.MouseLeave += new EventHandler(Form1_MouseLeave);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("Select  DISTINCT([BUSINESS CLASSIFICATIONS]) from Bus_Class where [business classifications]  like '" + textBox2.Text + "%'", con);
            try
            {

                dt = new DataTable();
                da.Fill(dt);
                metroGrid1.DataSource = dt;
                //metroListView1.DataSource = dt;

                //da.Fill(dt);
                //BindingSource bsource = new BindingSource();
                //bsource.DataSource = dt;
                //metroGrid1.DataSource = bsource;



                //metroGrid1.Columns[0].Visible = false;
                metroGrid1.Columns[0].Width = 300;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            ///////////////////////////////////////////////////////////////////

            //metroListView1.Columns.Add("First Name", 150);
            //metroListView1.Columns.Add("Last Name", 150);
            //metroListView1.Columns.Add("Last Name", 150);

            ////con.Open();
            //SqlCommand command = new SqlCommand("select country,company,city from Company where COMPANY like 'A%'", con);
            //SqlDataReader reader = command.ExecuteReader();

            //// int a = 5;
            ////int b = 55;
            //metroListView1.Items.Clear();
            //while (reader.Read())
            //{
            //    ListViewItem lv = new ListViewItem();

            //    //lv.SubItems.Add(reader.(0));
            //    //lv.SubItems.Add(reader.GetString(0));
            //    lv.SubItems.Add(reader.GetString(0));
            //    lv.SubItems.Add(reader.GetString(1));
            //    lv.SubItems.Add(reader.GetString(2));

            //    //lv.SubItems.Add(reader.GetString(3));


            //    metroListView1.Items.Add(lv);

            //}


            ///////////////////////////////////////////////////////////
        }


        private void metroLabel28_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel27_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel26_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel25_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel24_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel23_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel22_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel21_Click(object sender, EventArgs e)
        {
            //OleDbDataAdapter oda = new OleDbDataAdapter("select * from emp where ename like 'B%'", con);
            //DataTable dt = new DataTable();
            //oda.Fill(dt);
            //metroGrid1.DataSource = dt;

            //OleDbDataAdapter oda2 = new OleDbDataAdapter("select count(*) from emp where ename like 'A%' ", con);
            //DataTable dt2 = new DataTable();
            //oda.Fill(dt2);
            //metroLabel3.Text = dt2.ToString();
            
        }

        private void metroLabel20_Click(object sender, EventArgs e)
        {
            //OleDbDataAdapter oda = new OleDbDataAdapter("select ename from emp where ename like 'C%'", con);
            //DataTable dt = new DataTable();
            //oda.Fill(dt);
            //metroGrid1.DataSource = dt;
        }

        private void metroLabel19_Click(object sender, EventArgs e)
        {
            //OleDbDataAdapter oda = new OleDbDataAdapter("select ename from emp where ename like 'D%'", con);
            //DataTable dt = new DataTable();
            //oda.Fill(dt);
            //metroGrid1.DataSource = dt;
        }

        private void metroLabel18_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel17_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel16_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel15_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel14_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel13_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel12_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel11_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel10_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel8_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel7_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel6_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {

            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox1.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

            //pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            //pictureBox1.Cursor = Cursors.Default;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_MouseLeave_1(object sender, EventArgs e)
        {
           
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            //con.Open();
            //OleDbDataAdapter oda = new OleDbDataAdapter("select * from emp where ename = '" + metroTextBox1.Text + "' ", con);
            //DataTable dt = new DataTable();
            //oda.Fill(dt);
            //metroGrid1.DataSource = dt;
            //con.Close();
        }

        private void Search_C_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
              
        }

        private void Search_C_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {

                DialogResult result = MetroMessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    //con.Dispose();
                   
                    //con.Clone();
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
            
            
            //In case windows is trying to shut down, don't hold the process up
            //if (e.CloseReason == CloseReason.WindowsShutDown) return;

            //if (this.DialogResult == DialogResult.Cancel)
            //{
            //    // Assume that X has been clicked and act accordingly.
            //    // Confirm user wants to close
            //    switch (MessageBox.Show(this, "Are you sure?", "Do you still want ... ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            //    {
            //        //Stay on this form
            //        case DialogResult.No:
            //            e.Cancel = true;
            //            break;
            //        default:
            //            break;
            //    }
            //}
            
            
            //switch (MetroMessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            //{
            //    case DialogResult.Yes:
            //        con.Close();
            //        Application.Exit();
            //        break;
            //    default:
            //        break;
            //}

            //if (MessageBox.Show("Exit or no?",
            //          "My First Application",
            //           MessageBoxButtons.YesNo,
            //           MessageBoxIcon.Information) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
            //else {
            //    Application.Exit();
            //}
        }

        private void metroGrid1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        
            
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = metroGrid1.Rows[rowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();

            SqlCommand cmd = new SqlCommand("select c.COMPANY,c.ADDRESS,c.CITY,c.COUNTRY,c.[PHONE NO#],c.[PHONE NO# 2],c.UAN,c.FAX,c.EMAIL,c.URL,c.[CONTACT PERSON],c.STATUS,c.MOBILE from Company c,Bus_Class b where c.code_no = b.code_no and b.[BUSINESS CLASSIFICATIONS] = '" + textBox1.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            metroGrid2.DataSource = bsource;

           // //where code_no = '" + textBox1.Text + "'
           // string strSql = "select * from Bus_class where code_no = "+ textBox1.Text+"";
           // OleDbConnection con = new OleDbConnection(strProvider);
           // OleDbCommand cmdd = new OleDbCommand(strSql, con);
           //// con.Open();
           // cmdd.CommandType = CommandType.Text;
            
           // OleDbDataAdapter daa = new OleDbDataAdapter(cmdd);
           // DataTable scoress = new DataTable();
           // daa.Fill(scoress);
           // metroGrid2.DataSource = scoress;
           
        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Clear();
        }

        private void metroLabel29_Click(object sender, EventArgs e)
        {

        }

        private void Search_C_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
        public void call() {
            metroGrid1.Columns[0].Visible = false;
            metroGrid1.Columns[1].Width = 250;
            metroGrid1.Columns[3].Width = 250;
            metroGrid1.Columns[4].Width = 120;
            metroGrid1.Columns[5].Width = 120;
            metroGrid1.Columns[10].Width = 150;
        }
        private void metroLink2_Click(object sender, EventArgs e)
        {
            //string strSql = "select * from jamals where company like 'A%'";
            //OleDbConnection con = new OleDbConnection(strProvider);
            //OleDbCommand cmd = new OleDbCommand(strSql, con);
            //con.Open();
            //cmd.CommandType = CommandType.Text;
            //OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //DataTable scores = new DataTable();
            //da.Fill(scores);
            //metroGrid1.DataSource = scores;
            //call();







            //////OleDbDataAdapter oda = new OleDbDataAdapter("select * from jamals where company like 'A%'", con);
            //////DataTable dt = new DataTable();
            //////oda.Fill(dt);


            //////metroGrid1.DataSource = dt;
            
            //////call();
            //metroGrid1.Columns[1].Width = 250;
            //metroGrid1.Columns[3].Width = 250;
            //metroGrid1.Columns[4].Width = 120;
            //metroGrid1.Columns[5].Width = 120;
            //metroGrid1.Columns[10].Width = 150;
            //metroGrid1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //metroGrid1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            
        }

        private void metroLabel1_Click_1(object sender, EventArgs e)
        {
            //////OleDbDataAdapter oda = new OleDbDataAdapter("select * from jamals where company like 'A%'", con);
            //////DataTable dt = new DataTable();
            //////oda.Fill(dt);


            //////metroGrid1.DataSource = dt;
            //////metroGrid1.Columns[0].Visible = false;
        }

        private void metroLink19_Click(object sender, EventArgs e)
        {
            //////OleDbDataAdapter oda = new OleDbDataAdapter("select * from jamals where company like 'B%'", con);
            //////DataTable dt = new DataTable();
            //////oda.Fill(dt);


            //////metroGrid1.DataSource = dt;

            //////call();
        }






        void MakeColumnsSortable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //Add this as an event on DataBindingComplete
            //DataGridView dataGridView = sender as DataGridView;
            //if (dataGridView == null)
            //{
            //    var ex = new InvalidOperationException("This event is for a DataGridView type senders only.");
            //    ex.Data.Add("Sender type", sender.GetType().Name);
            //    throw ex;
            //}

            //foreach (DataGridViewColumn column in dataGridView.Columns)
            //    column.SortMode = DataGridViewColumnSortMode.Automatic;
            
        }
        
        //metroGrid1.DataBindingComplete += MakeColumnsSortable_DataBindingComplete;







        private void metroGrid1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //this.SortMode = DataGridViewColumnSortMode.NotSortable;   
            //ColumnStyle.SortMode = DataGridViewColumnSortMode.Automatic;
            //if (sortAscending)
            //    metroGrid1.DataSource = list.OrderBy(metroGrid1.Columns[e.ColumnIndex].DataPropertyName).ToList();
            //else
            //    metroGrid1.DataSource = list.OrderBy(metroGrid1.Columns[e.ColumnIndex].DataPropertyName).Reverse().ToList();
            //sortAscending = !sortAscending;
     
        }



        public DataGridViewColumnSortMode SortMode { get; set; }

        public bool EnableSorting { get; set; }

        private void metroLink18_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroGrid1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void metroLink2_Click_1(object sender, EventArgs e)
        {
            metroGrid1.Parent = pictureBox4;
            metroGrid2.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Test fo = new Test();
            fo.Show();
            this.Hide();  



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            metroGrid1.Parent = pictureBox4;
            metroGrid2.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
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

        private void metroTile2_Click(object sender, EventArgs e)
        {
            metroGrid1.Parent = pictureBox4;
            metroGrid2.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Test t1 = new Test();
            t1.Show();
            this.Hide();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            metroGrid1.Parent = pictureBox4;
            metroGrid2.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Companies s = new Companies();
            s.Show();
            this.Hide();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            metroGrid1.Parent = pictureBox4;
            metroGrid2.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Foreign f = new Foreign();
            f.Show();
            this.Hide();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            metroGrid1.Parent = pictureBox4;
            metroGrid2.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Representatives r = new Representatives();
            r.Show();
            this.Hide();
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            metroGrid1.Parent = pictureBox4;
            metroGrid2.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Trade t = new Trade();
            t.Show();
            this.Hide();
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            metroGrid1.Parent = pictureBox4;
            metroGrid2.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Contact c = new Contact();
            c.Show();
            this.Hide();
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            metroGrid1.Parent = pictureBox4;
            metroGrid2.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            Help h = new Help();
            h.Show();
            this.Hide();
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            metroGrid1.Parent = pictureBox4;
            metroGrid2.Parent = pictureBox4;
            pictureBox4.Visible = true;
            this.Enabled = false;
            About a = new About();
            a.Show();
            this.Hide();
        }
    }
}

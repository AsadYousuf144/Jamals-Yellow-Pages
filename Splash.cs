using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamals_Yellow_Pages
{
    public partial class Splash : MetroFramework.Forms.MetroForm
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }


        private void metroProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void metroProgressSpinner1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Tick = 2000;
            if (metroProgressBar1.Value >= 10)
            {
                //timer1.Interval = 10000;
                timer1.Stop();
                this.Hide();
                Form1 lp = new Form1();
                lp.Show();
                //this.Hide();

            }
            metroProgressBar1.Value += 1;
            
        }
    }
}

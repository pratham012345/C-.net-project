using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pratham_Project_Sem_5
{
    public partial class Form2 : Form
    {
        bool sidebarExpand;
        public Form2()
        {
            InitializeComponent();
        }
        Form4 prd = new Form4();
        productform prd1 = new productform();
        salesform sl = new salesform();
        Clientform cl = new Clientform();
        feedbackform fd = new feedbackform();

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 log = new Form1();
            log.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fd.Show();
            prd.Hide();
            prd1.Hide();
            sl.Hide();
            cl.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            prd.Show();
            fd.Hide();
            prd1.Hide();
            sl.Hide();
            cl.Hide();
        }

        private void sidebarTImer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 30;
                if(sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTImer.Stop();
                }
            }
            else
            {
                sidebar.Width += 30;
                if(sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTImer.Stop();
                }
            }
        }

        private void menubutton_Click(object sender, EventArgs e)
        {
            sidebarTImer.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            prd1.Show();
            prd.Hide();
            fd.Hide();
            sl.Hide();
            cl.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sl.Show();
            prd.Hide();
            prd1.Hide();
            fd.Hide();
            cl.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cl.Show();
            prd.Hide();
            prd1.Hide();
            sl.Hide();
            fd.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pratham_Project_Sem_5
{
    public partial class feedbackform : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public feedbackform()
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Project5;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }



        private void button4_Click_1(object sender, EventArgs e)
        {
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    string sql = "insert into Feedback values('" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                    cmd = new SqlCommand(sql, con);
                    int ans = cmd.ExecuteNonQuery();
                    if (ans > 0)
                    {
                        MessageBox.Show("Feedback Submited");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid");

                    }
                }
            }
        }
    }
}
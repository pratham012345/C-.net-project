using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pratham_Project_Sem_5
{
    public partial class productform : Form
    {
        SqlConnection con;
        SqlCommand cmd1;
        SqlDataAdapter da;
        
        public productform()
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Project5;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
           
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void productform_Load(object sender, EventArgs e)
        {
           
        }
       
        private void button3_Click_1(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from Products where name like'" + textBox5.Text + "%'", con);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text != "")
            {
                string sql1 = "delete from Products where id=" + textBox1.Text + "";
                cmd1 = new SqlCommand(sql1, con);
                int ans1 = cmd1.ExecuteNonQuery();
                if (ans1 > 0)
                {
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("Not deleted,Invalid ID");
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                con.Open();
                string sql2 = "update Products set name='" + textBox2.Text + "',quantity=" + textBox3.Text + ",price=" + textBox4.Text + " , category='" + comboBox1.Text + "'where id=" + textBox1.Text + "";
                cmd1 = new SqlCommand(sql2, con);
                int ans2 = cmd1.ExecuteNonQuery();
                if (ans2 > 0)
                {
                    MessageBox.Show("Record Updated");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("Record Not Updated");
                }
            }
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();

            if (textBox1.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select name,quantity,price,category from Products where id=@id", con);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = dr.GetValue(0).ToString();
                    textBox3.Text = dr.GetValue(1).ToString();
                    textBox4.Text = dr.GetValue(2).ToString();
                    comboBox1.Text = dr.GetValue(3).ToString();
                }
            }
            else
            {
                MessageBox.Show("No Record Exixts", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            }
    }
}

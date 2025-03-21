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
    public partial class salesform : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        public salesform()
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Project5;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
           
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                string sql = "insert into Sales values(" + textBox1.Text + ",'" + textBox2.Text + "'," + textBox3.Text + ",'" + textBox4.Text + "','" + comboBox1.Text + "')";
                cmd = new SqlCommand(sql, con);
                int ans = cmd.ExecuteNonQuery();
                if (ans > 0)
                {
                    MessageBox.Show("Records inserted successfully");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("Records not inserted");

                }

            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from Sales where name like'" + textBox5.Text + "%'", con);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                string sql2 = "update Sales set name='" + textBox2.Text + "',quantity=" + textBox3.Text + ",price=" + textBox4.Text + " , category='" + comboBox1.Text + "'where id=" + textBox1.Text + "";
                cmd = new SqlCommand(sql2, con);
                int ans2 = cmd.ExecuteNonQuery();
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

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text != "")
            {
                string sql1 = "delete from Sales where id=" + textBox1.Text + "";
                cmd = new SqlCommand(sql1, con);
                int ans1 = cmd.ExecuteNonQuery();
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

        private void button5_Click(object sender, EventArgs e)
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


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
    public partial class Form4 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        public Form4()
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Project5;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }
        public void GetproductID()
        {
            string proid;
            string query = "select id from Products order by id Desc";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int i = int.Parse(dr[0].ToString()) + 1;
                proid = i.ToString("000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("001");
            }
            else
            {
                proid = ("001");
            }
            con.Close();
            textBox1.Text = proid.ToString();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                con.Open();
                string sql = "insert into products values(" + textBox1.Text + ",'" + textBox2.Text + "'," + textBox3.Text + ",'" + textBox4.Text + "','" + comboBox1.Text + "')";
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
                    MessageBox.Show("records not inserted");

                }
           
            }
            con.Close();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            da = new SqlDataAdapter("select * from Products where name like'"+textBox5.Text+"%'", con);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            GetproductID();
        }
    }
}

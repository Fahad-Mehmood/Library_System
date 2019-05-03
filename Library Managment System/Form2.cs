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
using System.IO;
using System.Data.Sql;

namespace Library_Managment_System
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 fs = new Form1();
            fs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=FAHAD-PC\FAHAD;Initial Catalog=Library;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("(select Book_Name from BOOK where Condition=0   )", con);
            con.Open();
             try
            {
                SqlDataReader fa = cmd.ExecuteReader();
                while (fa.Read())
                {
                    comboBox1.Items.Add(fa["Book_Name"]);

                }

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=FAHAD-PC\FAHAD;Initial Catalog=Library;Integrated Security=True");
            string query = "select * from BOOK where Book_Name = '" + comboBox1.Text + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dbr;
                try
                {
                    con.Open();
                    dbr = cmd.ExecuteReader();
                    while (dbr.Read())
                    {
                        textBox1.Text = dbr[0].ToString();
                        textBox2.Text = dbr[1].ToString();
                        textBox3.Text = dbr[2].ToString();
                        textBox4.Text = dbr[3].ToString();
                        byte[] img = (byte[])(dbr[4]);
                        if (img != null)
                        {
                            MemoryStream ms = new MemoryStream(img);
                            pictureBox1.Image = Image.FromStream(ms);


                        }
                    
                
                        else
                        {
                            MemoryStream f = new MemoryStream(img);
                            f = null;
                            pictureBox1.Image = Image.FromStream(f);
                        }

                    }

                    con.Close();


                }

                catch (Exception ex)
                {
                    pictureBox1.Image = null;
                    MessageBox.Show(ex.Message);
                }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 fs = new Form4();
            fs.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You want Delete Record?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=FAHAD-PC\FAHAD;Initial Catalog=Library;Integrated Security=True");
                SqlCommand fa = new SqlCommand("delete from BOOK where Book_ID= '" + textBox1.Text + "' ", con);
                try
                {
                    
                    con.Open();
                    fa.ExecuteNonQuery();
                    MessageBox.Show("Record Has Been Deleted");
                }
                catch (Exception ex)
                {

                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            pictureBox1.Image = null;
            comboBox1.Text =null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
             }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.CornflowerBlue;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Aqua;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

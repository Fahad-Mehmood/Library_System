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

namespace Library_Managment_System
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=FAHAD-PC\FAHAD;Initial Catalog=Library;Integrated Security=True");
            SqlCommand cnn = new SqlCommand("update BOOK set Book_ID='" + textBox2.Text + "',Book_Name='" + textBox3.Text + "',Book_Author='" + textBox4.Text + "',Book_Eidtion='" + textBox5.Text + "' where Book_ID='" + textBox1.Text + "'", con);

            try
            {
                con.Open();
                cnn.ExecuteNonQuery();
                MessageBox.Show("Updated");
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);

            }
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

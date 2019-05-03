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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=FAHAD-PC\FAHAD;Initial Catalog=Library;Integrated Security=True");

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO ISSUE ( Book_ID,Student_ID, Issue_Date,Expired_Date)  VALUES ('" + textBox3.Text + "' ,'" + textBox1.Text+ "', GETDATE() ,GETDATE()+1)", con);
                SqlCommand cn = new SqlCommand("update BOOK set Condition=1 where Book_ID='" + textBox3.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                cn.ExecuteNonQuery();
                MessageBox.Show("Book Reserved");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                
                con.Close();
                
            }
            textBox1.Text = "";
            textBox3.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fa = new Form2();
            fa.Show();
            this.Hide();
        }
    }
}

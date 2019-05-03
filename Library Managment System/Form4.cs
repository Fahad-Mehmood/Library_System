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
using System.Data.Sql;
namespace Library_Managment_System
{
    public partial class Form4 : Form
    {
       
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fa = new Form2();
            fa.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=FAHAD-PC\FAHAD;Initial Catalog=Library;Integrated Security=True");
            SqlDataAdapter s = new SqlDataAdapter("select count(*) from STUDENT where Student_Name='" + textBox1.Text + "'and Pasword='" + textBox2.Text + "' ", con);
            DataTable d = new DataTable();
            s.Fill(d);
            if (d.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form5 fs = new Form5();
                fs.Show();
            }
            else
                MessageBox.Show("Please Enter Correct Information");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

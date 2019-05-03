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
namespace Library_Managment_System
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=FAHAD-PC\FAHAD;Initial Catalog=Library;Integrated Security=True");

            try
            {
                  SqlCommand cmd = new SqlCommand("INSERT INTO BACK (Student_ID, Book_ID,[Current_Date])  VALUES ('" + textBox1.Text + "','" + textBox2.Text + "',GETDATE())", con);
                SqlCommand ss = new SqlCommand("update BOOK set Condition=0 where Book_ID='" + textBox2.Text + "'", con);
                SqlCommand s = new SqlCommand("UPDATE BACK SET BACK.Issue_Date = ISSUE.Issue_Date FROM BACK JOIN ISSUE ON  ISSUE.Book_ID ='" + textBox2.Text + "' and BACK.Book_ID ='" + textBox2.Text + "' ", con);
                SqlCommand sa = new SqlCommand("UPDATE BACK SET BACK.Expired_Date = ISSUE.Expired_Date FROM BACK JOIN ISSUE ON  ISSUE.Book_ID ='" + textBox2.Text + "'  and BACK.Book_ID ='" + textBox2.Text + "' ", con);
               SqlCommand sd = new SqlCommand("UPDATE BACK SET BACK.Student_ID = ISSUE.Student_ID FROM BACK JOIN ISSUE ON  ISSUE.Book_ID ='" + textBox2.Text + "' and  BACK.Book_ID ='" + textBox2.Text + "'", con);
                SqlCommand cn = new SqlCommand("declare @PTIMEIN datetime SET @PTIMEIN = (SELECT Expired_Date FROM ISSUE WHERE Book_ID = '" + textBox2.Text + "'); " +
                "declare @TTIME datetime SET @TTIME = (SELECT DATEDIFF(DAY, @PTIMEIN, GETDATE()));" +
                "declare @CST float SET @CST = CAST((SELECT DATEDIFF(DAY, @PTIMEIN, GETDATE())) as float) *100;" +
                "UPDATE BACK SET  Fine = @CST WHERE Book_ID = '"+ textBox2.Text + "'", con);
                SqlCommand fa = new SqlCommand("update BACK set Fine=0 where Fine=-100", con);
                con.Open();
                cmd.ExecuteNonQuery();
                ss.ExecuteNonQuery();
               s.ExecuteNonQuery();
                sa.ExecuteNonQuery();
                sd.ExecuteNonQuery();
                cn.ExecuteNonQuery();
                fa.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("select Fine from BACK where Book_ID='"+ textBox2.Text +"' ", con);
               sda.Fill(dt);
                MessageBox.Show("Fine=" + dt.Rows[0][0].ToString());

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
            textBox2.Text = "";
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fa = new Form1();
            fa.Show();
            this.Hide();
        }
    }
}

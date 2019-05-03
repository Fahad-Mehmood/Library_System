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
    
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=FAHAD-PC\FAHAD;Initial Catalog=Library;Integrated Security=True");
        SqlCommand command;
        string imgLoc = "";
        public Form3()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string cmd = "INSERT INTO BOOK (Book_ID, Book_Name, Book_Author,Book_Eidtion,Picture,Condition)  VALUES ('" + textBox1.Text + "' ,'" + textBox2.Text + "', '" + textBox3.Text + "','" + textBox4.Text + "',@img,0)";
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    command = new SqlCommand(cmd, con);
                    command.Parameters.Add(new SqlParameter("@img", img));
                    int x = command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show(x.ToString() + "Record Saved");

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                pictureBox1.Image = null;
            
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter= "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            dlg.Title = "select BOOK Picture";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imgLoc = dlg.FileName.ToString();
                pictureBox1.ImageLocation = imgLoc;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 fs = new Form1();
            fs.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Library_Managment_System
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            Thread s = new Thread(new ThreadStart(splashscreen));
            s.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            s.Abort();
        }
        public void splashscreen()
        {
            Application.Run(new Form8());
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pass = "6545";
            if (textBox1.Text == pass)
            {
                MessageBox.Show("WELLCOME TO Book House");
                Form1 fa = new Form1();
                fa.Show();
            }
            else
                MessageBox.Show("***INCORRECT PASSWORD***");
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}

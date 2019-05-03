using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Managment_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fa = new Form2();
            fa.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fa = new Form3();
            fa.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form6 fa = new Form6();
            fa.Show();
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkCyan;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkCyan;

        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkCyan;

        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.DarkCyan;

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.AntiqueWhite;

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.AntiqueWhite;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.AntiqueWhite;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.AntiqueWhite;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 fa = new Form7();
            fa.Show();
        }
    }
}

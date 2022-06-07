using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace p1
{
    
    public partial class Form1 : KryptonForm
    {

        public string u1 = "Admin";
        public int p1 = 12345;
        
        public string u2 = "Manager";
        public int p2 = 54321;


        public Form1()
        {
            InitializeComponent();

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Username")
            {
                kryptonTextBox1.Text = "";
                kryptonTextBox1.ForeColor = Color.Black;
            }
        }

        private void kryptonTextBox1_Text(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Username";
                kryptonTextBox1.ForeColor = Color.Silver;
            }

        }

        private void enter2(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "Password")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.ForeColor = Color.Black;
            }
        }

        private void leave2(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "Password";
                kryptonTextBox2.ForeColor = Color.Silver;
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            /* if (kryptonTextBox1.Text == u1 && kryptonTextBox2.Text == Convert.ToString(p1))
             {
                 Form2 f2 = new Form2();
                 f2.Show();
             }
             else if (kryptonTextBox1.Text == u2 && kryptonTextBox2.Text == Convert.ToString(p2))
             {
                 Form3 f3 = new Form3();
                 f3.Show();
             }
             else
             {
                 KryptonMessageBox.Show("Bhag Chutiye");
             }*/

            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}

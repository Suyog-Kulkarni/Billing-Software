using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using  ComponentFactory.Krypton.Toolkit;
using System.Data.SqlClient;
namespace p1
{
    public partial class Form4 : KryptonForm
    {
        
        
        public Form4()
        {
            InitializeComponent();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //Form3.OpenFile();
            
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
         
            product.Visible = true;
            name.Visible = true;
            add.Visible = true;
            price.Visible = true;
            pricet.Visible = true;
            kryptonListBox1.Visible = false; kryptonListBox2.Visible = false;
            kryptonLabel1.Visible = false; kryptonLabel2.Visible = false;mov.Visible = false;
            product.Clear();
            kryptonListBox1.Items.Clear(); kryptonListBox2.Items.Clear();
            
        }
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            product.Visible = false;
            name.Visible = false;
            add.Visible = false;
            price.Visible = false;
            pricet.Visible = false;
            mov.Visible = false;
            kryptonListBox1.Visible = true;
            kryptonListBox2.Visible= true;
            kryptonLabel1.Visible= true;
            kryptonLabel2.Visible= true;
            kryptonListBox1.Items.Clear();
            kryptonListBox2.Items.Clear();
            using (SqlConnection conn = new SqlConnection("Data Source=THUNDER;Initial Catalog=BillingDB;Integrated Security=True"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select Item,Rate from BillingT", conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            kryptonListBox1.Items.Add(name);
                            kryptonListBox2.Items.Add(reader.GetInt32(1));
                        }
                    }
                }
            }
         
            
        }

        

        public void add_Click(object sender, EventArgs e)
        {

            if (file_exception() == 0)
            {
                int c = 0;
                string q = "select count(*) from BillingT";
                using (SqlConnection conn = new SqlConnection("Data Source=THUNDER;Initial Catalog=BillingDB;Integrated Security=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {

                        c = (int)cmd.ExecuteScalar();

                        
                    }
                }
                c += 1;
                try
                {
                    using (SqlConnection conn = new SqlConnection("Data Source=THUNDER;Initial Catalog=BillingDB;Integrated Security=True"))
                    {
                        conn.Open();
                        string prod = product.Text;
                        using (SqlCommand cmd = new SqlCommand("insert into BillingT values(" + c + ",'" + prod + "'," + Convert.ToInt32(pricet.Text) + ")", conn))
                        {
                            cmd.ExecuteNonQuery();

                        }
                    }
                   
                }
                catch (System.FormatException)
                {

                }
                
            }
            KryptonMessageBox.Show("Product added successfully.");
            product.Clear();
            pricet.Clear();
            

        }
        private int file_exception()
        {
            string product1 = product.Text;
            string price = pricet.Text;
            
            if (String.IsNullOrWhiteSpace(product1) || String.IsNullOrEmpty(product1))
            {
                KryptonMessageBox.Show("Please add Product.");
                return 1;
            }
            if (String.IsNullOrEmpty(price) || String.IsNullOrEmpty(price))
            {
                KryptonMessageBox.Show("Please add Price.");

                return 1;
            }
            for(int i = 0; i < price.Length; i++)
            {
                if (!char.IsDigit(price[i]))
                {
                    KryptonMessageBox.Show("Price cannot contains letters.");
                    product.Clear();
                    pricet.Clear();
                    return 1;
                }
            }
            
            return 0;


            
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Form3 f3 = new Form3();
                f3.Show();
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            mov.Visible = true;
            product.Visible = true;
            name.Visible = true;
            kryptonListBox1.Visible = false;
            kryptonListBox2.Visible = false;
            kryptonLabel1.Visible = false;
            kryptonLabel2.Visible = false;
            add.Visible = false;
            price.Visible = false;
            pricet.Visible = false;
            
        }

        private void kryptonButton2_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=THUNDER;Initial Catalog=BillingDB;Integrated Security=True"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("delete from BillingT where Item = '" + product.Text + "' ", conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            KryptonMessageBox.Show("Item Deleted Successfully.");
               

        }
    }

}

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
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace p1
{
    public partial class Form3 : KryptonForm
    {
        

        /*SqlConnection conn = new SqlConnection("Data Source=LAPTOP-54J6M5AI;Initial Catalog=BillingDB;Integrated Security=True;MultipleActiveResultSets=True;");
        SqlCommand cmd;
        SqlDataReader dr;*/
        /*SqlDataReader d;
        SqlCommand cmd1;*/
        public Form3()
        {
            InitializeComponent();
            
        }

        public void Form3_Load(object sender, EventArgs e)
        {
            OpenFile();
            
        }

        public void OpenFile()// adding items in combo-box
        {


           
            string query = "select Item from BillingT";
            using(SqlConnection conn = new SqlConnection("Data Source=THUNDER;Initial Catalog=BillingDB;Integrated Security=True"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string name = dr.GetString(0);
                            search.Items.Add(name);
                        }
                    }
                }
            }
           /* cmd = new SqlCommand(query, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string name = dr.GetString(1);
                search.Items.Add(name);
            }
            conn.Close();*/
        }

        private void searchbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = items.Items.Count;
            int j = quantity.Items.Count;
            
            if (i < j)
            {
                KryptonMessageBox.Show("Please add product");
            }
            else if (i == j)
            {
                items.Items.Add(search.SelectedItem);
                
            }
            else
            {
                KryptonMessageBox.Show("Please add quantity");
            }
            
        }

        private void checkout_Click(object sender, EventArgs e)
        {
            if (items.SelectedItem != null)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show($"Do you want to remove {items.SelectedItem}.", "Remove Product", buttons);
                if (result == DialogResult.Yes)
                {
                    int j = items.SelectedIndex;
                    try
                    {
                        int a = int.Parse(total.Text);
                        int b = int.Parse(price.Items[j].ToString());
                        total.Text = (a - b).ToString();
                        rateperitem.Items.RemoveAt(j);
                        gst.Items.RemoveAt(j);
                        quantity.Items.RemoveAt(j);
                        
                        price.Items.RemoveAt(j);
                        items.Items.RemoveAt(j);
                    }
                    catch
                    {
                        items.Items.RemoveAt(j);
                    }

                }
            }
            else
            {
                KryptonMessageBox.Show("Please select a product to remove.");
                
            }
            
        }

        private void kryptonListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonLabel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void quantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            quantity.SelectedItems.Add(quantity.Items);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            
            if (itemquantity_validation()==1)
            {
                KryptonMessageBox.Show("Invalid Quantity");
                
            }
            else
            {
                int i = items.Items.Count;
                int j = quantity.Items.Count;
                if (j > i)
                {
                    KryptonMessageBox.Show("Please add Product");
                }
                else if (i==j)
                {
                    
                    KryptonMessageBox.Show("Please add Product.");

                }
                
                else
                {
                    double e2 = 0;
                    double c = 0;
                    double gst_amount = 0;

                    if (fun1() == 1)
                    {

                    }
                    else
                    {
                        gst_amount = (fun1() * 18) / 100;
                        
                        try
                        {
                            
                            rateperitem.Items.Add(fun1().ToString());
                            quantity.Items.Add(itemquantity.Text);
                            gst.Items.Add("18%");
                            e2 = (fun1() * Convert.ToDouble(itemquantity.Text));
                            price.Items.Add(e2+gst_amount);
                        }
                        catch
                        {
                            KryptonMessageBox.Show("Invalid Quantity.");
                          


                            
                        }
                    }
                    
                    for (var l = 0 ;l<price.Items.Count; l++)
                    {
                        c+=Convert.ToDouble(price.Items[l].ToString());
                        
                        total.Text=c.ToString();
                        
                        
                    }
                }
            }
            
        }
        private int fun1()
        {
            //conn.Open();

            string query = "select Rate from BillingT where Item = '"+search.Text+"' ";
            //string query = "select * from BillingT";

            int a = 0;
            using(SqlConnection conn = new SqlConnection("Data Source=THUNDER;Initial Catalog=BillingDB;Integrated Security=True"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    /*using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                       *//* while (dr.Read())
                        {
                            if (search.Text == dr.GetString(1))
                            {
                                a = dr.GetInt32(2);
                                break;

                            }
                        }*//*
                        a = dr.GetInt32(1);

                    }*/
                    a = (int)cmd.ExecuteScalar();
                }
            }

           
            /*string q = "select count(*) from BillingT";
            using(SqlConnection conn = new SqlConnection("Data Source=LAPTOP-54J6M5AI;Initial Catalog=BillingDB;Integrated Security=True;MultipleActiveResultSets=True;"))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(q, conn))
                {
                    
                        int c = (int)cmd.ExecuteScalar();
                        MessageBox.Show(c.ToString());
                    
                }
            }*/
            return a;
        }

        private int itemquantity_validation() {

            if (String.IsNullOrEmpty(itemquantity.Text) || String.IsNullOrWhiteSpace(itemquantity.Text))
            {
                return 1;
            }

            for (var i = 0; i < itemquantity.TextLength; i++)
            {
                
                    if (char.IsDigit(itemquantity.Text[i]) || itemquantity.Text[i]=='.')
                    {
                    
                    }
                    else
                    {
                        return 1;
                    }
                    
            }
            return 0;
        }
        private int Email_validation()
        {
            for(var i = 0; i < number.TextLength; i++)
            {
                if (char.IsDigit(number.Text[i]))
                {

                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }

        

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            /*if (whatapp_validation()==0 && number.Text.Length==10)
            {
                KryptonMessageBox.Show("Checkout Successful.");
            }
            else
            {
                KryptonMessageBox.Show("Invalid WhatsApp Number.");
            }*/
            string path = cname.Text + ".txt";
            
            using (TextWriter text = File.CreateText(path))
            {
                text.WriteLine("Products  -  Price");
                text.WriteLine(" ");
                for (var i = 0; i < items.Items.Count; i++)
                {
                    text.WriteLine(items.Items[i]+"  -  " + price.Items[i]);
                }
                text.WriteLine(" ");
                text.WriteLine(" ");
                text.WriteLine("Total Amount - " + total.Text);

            }
            FileInfo f = new FileInfo(path);
            string fullname = f.FullName;

            MailMessage mail = new MailMessage();
            mail.To.Add(number.Text);
            mail.From = new MailAddress("kulkarnisuyog192@gmail.com", "Suyog Kulkarni", Encoding.UTF8);
            mail.Subject = "Receipt";
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Attachments.Add(new Attachment(fullname));
            //mail.Body = "This is Email Body Text";
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("kulkarnisuyog192@gmail.com", "Suyog@123");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            //client.Send(mail);
            try
            {
                client.Send(mail);
               
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                MessageBox.Show(ex.Message);
                //Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
            KryptonMessageBox.Show("Checkout Successfull.");

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();
            f4.Show();
        }

     

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            if (itemquantity_validation() == 1)
            {
                KryptonMessageBox.Show("Invalid Quantity");

            }
            else
            {
                int i = items.Items.Count;
                int j = quantity.Items.Count;
                if (j > i)
                {
                    KryptonMessageBox.Show("Please add Product");
                }
                else if (i == j)
                {

                    KryptonMessageBox.Show("Please add Product.");

                }

                else
                {
                    double e2 = 0;
                    double c = 0;
                    int gst_amount = 0;

                    if (fun1() == 1)
                    {

                    }
                    else
                    {
                        gst_amount = (fun1() * 18) / 100;
                        c = gst_amount;
                        try
                        {
                            rateperitem.Items.Add(fun1().ToString());
                            gst.Items.Add("18%");
                            quantity.Items.Add(itemquantity.Text);
                            e2 = (fun1() * Convert.ToDouble(itemquantity.Text));
                            price.Items.Add(e2);
                        }
                        catch
                        {
                            KryptonMessageBox.Show("Invalid Quantity.");

                        }
                    }

                    for (var l = 0; l < price.Items.Count; l++)
                    {
                        c += Convert.ToDouble(price.Items[l].ToString());

                        total.Text = c.ToString();


                    }
                }
            }

        }



        private void itemquantity_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void number_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (!Regex.IsMatch(number.Text,pattern))
            {
                number.Focus();
                errorProvider1.SetError(this.number, "Invalid Email");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
    
}

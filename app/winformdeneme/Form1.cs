using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;



namespace winformdeneme
    
{
    public partial class Form1 : Form
    {
        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CDGUF5D;Initial Catalog=kayitgiris; Integrated Security=TRUE");

        public Form1()
        {
            InitializeComponent();
        }
        


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            bool isThere = false;

            connection.Open();
            SqlCommand command = new SqlCommand("SELECT *FROM Kayit", connection);
            SqlDataReader reader = command.ExecuteReader();
            //Console.WriteLine("durumu  "+ reader.Read());
                       
            while (reader.Read())
            {
                if (username == reader["username"].ToString().TrimEnd() && password == reader["password"].ToString().TrimEnd())
                {

                    isThere = true;
                    break;

                }
                else
                {
                    isThere = false;
                }

            }


            if (isThere)
            {

                this.Hide();
                Form3 form3 = new Form3();
                form3.Show();

            }
            else
            {
                MessageBox.Show("Hatali Giris Yaptiniz !");
            }

            connection.Close();

            
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı adı")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
          
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı adı";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Şifre")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = '*';
            }
        }

        char? none = null;
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Şifre";
                textBox2.ForeColor = Color.Silver;
                textBox2.PasswordChar = Convert.ToChar(none);

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
                    }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
         
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select *from Kayit", connection);
            SqlDataReader reader = command.ExecuteReader( );
            connection.Close();
        }

    }
}

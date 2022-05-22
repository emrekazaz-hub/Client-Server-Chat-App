using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;


namespace winformdeneme
{
    public partial class Form2 : Form
    {

        SqlConnection connection = Form1.connection;

        public static string kullaniciadiprofil = "";
        public static string epostaprofil = "";

        

        //kullaniciadiprofil = textBox1.Text;
        //epostaprofil = textBox2.Text;


        public Form2()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Insert Into Kayit (username,e_mail,password) values ('" + textBox1.Text + "','" 
                + textBox2.Text + "','" + textBox3.Text + "')", connection);
            int result = command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayit Olusturuldu");

            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();

            kullaniciadiprofil = textBox1.Text;
            epostaprofil = textBox2.Text;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}

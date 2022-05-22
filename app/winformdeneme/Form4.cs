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
using System.Net;
using System.Net.Mail;


namespace winformdeneme
{
    public partial class Form4 : Form
    {
        SqlConnection connection = Form1.connection;
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            connection.Open();
            SqlCommand command = new SqlCommand("select * from Kayit where e_mail='"+textBox1.Text.ToString()+"'",connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    
                    if (connection.State == ConnectionState.Closed)
                    {
                       connection.Open();
                    }
                    
                    SmtpClient smptserver = new SmtpClient();

                    MailMessage mail = new MailMessage();
                    String tarih = DateTime.Now.ToLongDateString();
                    String pass = ("E20135846");
                    //String mailladress = textBox1.Text;
                    String mailadress = ("wooxchat@gmail.com");
                   

                    /////////////////////////////////////////////////////////////////////
                    
                    
                    String smtpsrvr = "smtp.gmail.com";
                    String kime = (reader["e_mail"].ToString());
                    String konu = ("sifre hatirlatma");
                    //String write = ("sayin" + reader["us"].ToString() + "\n" + "Bizden" + tarih + "tarihinde" + "\n" + "parolaniz" + reader["password"].ToString() + "\n Aciklama...");
                    String yaz = ("sayin"+ reader["username"].ToString() + "Parolaniz:" + reader["password"].ToString() + "");

                    smptserver.Credentials = new NetworkCredential(mailadress, pass);
                    smptserver.Port = 587;
                    smptserver.Host = smtpsrvr;
                    smptserver.EnableSsl = true;

                    mail.From = new MailAddress(mailadress);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yaz;
                    smptserver.Send(mail);
                    DialogResult bilgi = new DialogResult();
                    bilgi = MessageBox.Show("sifre gonderildi");
                    this.Hide();

                    
                }
                catch(Exception Hata)
                {
                    MessageBox.Show("Mail gonderilemedi", Hata.Message);
                }
            }

            connection.Close();

            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();

        }
    }
}

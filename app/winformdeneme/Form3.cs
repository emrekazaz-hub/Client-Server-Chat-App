using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace winformdeneme
{
    public partial class Form3 : Form
    {
        // Sql baglanti kismi

        SqlConnection connection = Form1.connection;




        public Form3()
        {
            InitializeComponent();
        }
        void Listele()
        {
            textBox2.Clear();
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                var cevap = client.DownloadString("https://localhost:44312/api/Mesaj/2/1");
                var mesajlar = JsonConvert.DeserializeObject<List<Mesaj>>(cevap);
                foreach (var m in mesajlar)
                {
                    textBox2.AppendText(m.SendDate + "-" + m.Message + Environment.NewLine);

                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Listele();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new WebClient())
                {
                    // yapman lazım from user to usri tanimlaman lazim
                    //int id;
                    Mesaj m = new Mesaj() { FromUser = 2,/*buraya celecek*/ ToUser = 1, Message = textBox1.Text, SendDate = DateTime.Now };
                    client.Encoding = Encoding.UTF8;
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var cevap = client.UploadData("https://localhost:44312/api/Mesaj/", "POST", Encoding.Default.GetBytes(JsonConvert.SerializeObject(m)));

                }
            }
            catch (Exception ex)
            {

            }
            Listele();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Form5Profil());
            /*
            connection.Open();
            SqlCommand command = new SqlCommand("select Kayit from kayitgiris where usurname LIKE'%" + .Text + "%'", connection);
            SqlDataReader reader = command.ExecuteReader();
            int result = command.ExecuteNonQuery();
            
            command.Connection = connection;
            command.CommandText = "SELECT kitapadi FROM kitap";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
               // listBox1.Items.Add(reader["username"]);
            }
            connection.Close();
            */
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }


        private Form activeForm = null;

        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            openChildFormInPanel(new FormAyarlar());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            openChildFormInPanel(new FormMesajlar());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new FormKisiler());


        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}

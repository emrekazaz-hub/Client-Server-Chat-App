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

namespace winformdeneme
{
    public partial class FormMesajlar : Form
    {
        public FormMesajlar()
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new WebClient())
                {
                    Mesaj m = new Mesaj() { FromUser = 2, ToUser = 1, Message = textBox1.Text, SendDate = DateTime.Now };
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
    }
}

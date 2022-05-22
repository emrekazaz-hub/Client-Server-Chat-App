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
using System.Data.SqlClient;

namespace winformdeneme
{
    public partial class Form5Profil : Form
    
    {
        //private object pbImage;
        SqlConnection connection = Form1.connection;


        public Form5Profil()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String imageLocation = "";

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    pictureBox1.ImageLocation = imageLocation;
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir sorun olustu","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            SqlConnection con = new SqlConnection("Data Source.= ;Initial Catalog=kayitgiris Integrated Security=true");
            SqlCommand cmd = new SqlCommand("Insert Into TblSave (Name, Foto)Values('"+ textBox1 .Text+ "',@Pic)",con);

            MemoryStream stream = new MemoryStream();
            pbImage.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            */
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void nameTag_TextChanged(object sender, EventArgs e)
        {
            /*
            connection.Open();
            SqlCommand command = new SqlCommand("select Kayit from kayitgiris where usurname LIKE'%" + .Text + "%'", connection);
            int result = command.ExecuteNonQuery();
            connection.Close();
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {

            /*
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

            }*/

        }

        private void Form5Profil_Load(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

     
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label2.Text = Form2.epostaprofil;

        }
    }
}

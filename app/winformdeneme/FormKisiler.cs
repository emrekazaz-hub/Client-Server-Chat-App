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
using System.Configuration;



namespace winformdeneme
{
    public partial class FormKisiler : Form
    {
        //sql baglanti kismi
        SqlConnection connection = Form1.connection;
        SqlCommand cmd;
        SqlDataReader dr;

        public FormKisiler()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            cmd = new SqlCommand();
            connection.Open();
            cmd.Connection = connection;
            cmd.CommandText = "select * from Kayit";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listBox1.Items.Add(dr["username"]);
            }
            connection.Close();
            
        }
    }
}

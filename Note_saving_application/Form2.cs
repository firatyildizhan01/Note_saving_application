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

namespace Note_saving_application
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string number;
        //Data Source=FIRAT-PC\SQLEXPRESS;Initial Catalog=Db_note_saving;Integrated Security=True

        SqlConnection baglanti = new SqlConnection("@Data Source=FIRAT-PC-SQLEXPRESS;Initial Catalog=Db_note_saving;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            lblNumber.Text = number;
            SqlCommand komut = new SqlCommand("Select * From where TBL_LESSOn OGRNUMARA = @p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", number);
            SqlDataReader dr = komut.sqlD
            while(dr.Read)
            {
                lblNumber.Text = dr[2].ToString + " " + dr[3].ToString;
                lblSınav1.Text = dr[4].ToString;
                lblSınav2.Text = dr[5].ToString;
                lblSınav3.Text = dr[6].ToString;
                lblOrtalama.Text = dr[7].ToString;
                lblDurum.Text = dr[8].ToString;
                3
            }
            baglanti.Close();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}

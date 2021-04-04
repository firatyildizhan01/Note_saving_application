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
    public partial class NewTeacherForm : Form
    {
        public NewTeacherForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FIRAT-PC\SQLEXPRESS;Initial Catalog=Db_note_saving;Integrated Security=True");
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void NewTeacherForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_note_savingDataSet.TBL_LESSON' table. You can move, or remove it, as needed.
            this.tBL_LESSONTableAdapter.Fill(this.db_note_savingDataSet.TBL_LESSON);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBL_LESSON (OGRNUMARA,OGRAD,OGRSOYAD) values (@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", mskNumara.Text);
            komut.Parameters.AddWithValue("@P2", txtAd.Text);
            komut.Parameters.AddWithValue("@P3", txtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi");
            this.tBL_LESSONTableAdapter.Fill(this.db_note_savingDataSet.TBL_LESSON);




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;


            mskNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskSınav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            mskSınav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            mskSınav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama,s1,s2,s3;
            string durum;
            s1 = Convert.ToDouble(mskSınav1.Text);
            s2 = Convert.ToDouble(mskSınav2.Text);
            s3 = Convert.ToDouble(mskSınav3.Text);

            ortalama = (s1 + s2 + s3) / 3;
            lblOrtalama.Text = ortalama.ToString();

            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }


            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBL_LESSON set OGRS1=@P1,OGRS2=@P2,OGRS3=@P3,ORTALAMA=@P4,DURUM=@P5 WHERE OGRNUMARA=@P6", baglanti);
            komut.Parameters.AddWithValue("@P1", mskSınav1.Text);
            komut.Parameters.AddWithValue("@P2", mskSınav2.Text);
            komut.Parameters.AddWithValue("@P3", mskSınav3.Text);
            komut.Parameters.AddWithValue("@P4", decimal.Parse(lblOrtalama.Text));
            komut.Parameters.AddWithValue("@P5", durum);
            komut.Parameters.AddWithValue("@P6", mskNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("öğrenci notları güncellendi");
            this.tBL_LESSONTableAdapter.Fill(this.db_note_savingDataSet.TBL_LESSON);

        }
    }
}

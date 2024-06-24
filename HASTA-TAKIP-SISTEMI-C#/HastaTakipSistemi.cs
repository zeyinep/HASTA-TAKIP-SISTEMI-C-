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
using System.Net;

namespace HASTATAKIPSISTEMI___OOP
{
    public partial class HastaTakipSistemi : Form
    {
        public HastaTakipSistemi()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8PLCL96;Initial Catalog=HASTATAKIP;Integrated Security=True");
        SqlDataAdapter dr1;
        SqlCommand komut;

        public void listele()
        {
            baglanti.Open();
            string sorgu = "SELECT*FROM Hastalar";
            komut = new SqlCommand(sorgu, baglanti);
            dr1 = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            dr1.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu hasta takip programı 10.06.2024 tarihinde Zeynep Sena Yılmaz, Beyzanur Yıldız, Zilan Kavak ve Esma Çetinkaya tarafından yapılmıştır.", "HAKKIMIZDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txthId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txthAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txthSoyAd.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txthTc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txthYas.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txthCinsiyet.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txthSikayet.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txthKayitTarihi.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtTeşhis.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO Hastalar ( hAd, hSoyAd, hTc, hYas, hCinsiyet, hSikayet, hKayitTarihi, hTeşhis) VALUES (@hAd, @hSoyAd, @hTc, @hYas, @hCinsiyet, @hSikayet, @hKayitTarihi, @hTeşhis)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@hAd", txthAd.Text);
            komut.Parameters.AddWithValue("@hSoyAd", txthSoyAd.Text);
            komut.Parameters.AddWithValue("@hTc", txthTc.Text);
            komut.Parameters.AddWithValue("@hYas", txthYas.Text);
            komut.Parameters.AddWithValue("@hCinsiyet", txthCinsiyet.Text);
            komut.Parameters.AddWithValue("@hSikayet", txthSikayet.Text);
            komut.Parameters.AddWithValue("@hKayitTarihi", txthKayitTarihi.Text);
            komut.Parameters.AddWithValue("@hTeşhis", txtTeşhis.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt işlemi başarılı!", "KAYIT BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE Hastalar SET hAd=@hAd, hSoyAd=@hSoyAd, hTc=@hTc, hYas=@hYas, hCinsiyet=@hCinsiyet, hSikayet=@hSikayet, hKayitTarihi=@hKayitTarihi, hTeşhis=@hTeşhis WHERE hId=@hId";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@hId", txthId.Text);
            komut.Parameters.AddWithValue("@hAd", txthAd.Text);
            komut.Parameters.AddWithValue("@hSoyAd", txthSoyAd.Text);
            komut.Parameters.AddWithValue("@hTc", txthTc.Text);
            komut.Parameters.AddWithValue("@hYas", txthYas.Text);
            komut.Parameters.AddWithValue("@hCinsiyet", txthCinsiyet.Text);
            komut.Parameters.AddWithValue("@hSikayet", txthSikayet.Text);
            komut.Parameters.AddWithValue("@hKayitTarihi", txthKayitTarihi.Text);
            komut.Parameters.AddWithValue("@hTeşhis", txtTeşhis.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme gerçekleşirildi!", "GÜNCELLEME BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Hastalar WHERE hId=@hId";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@hId", txthId.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarıyla silindi.", "KAYIT SİLİNDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void temizle()
        {
            txthId.Text = "";
            txthAd.Text = "";
            txthSoyAd.Text = "";
            txthTc.Text = "";
            txthYas.Text = "";
            txthCinsiyet.Text = "";
            txthSikayet.Text = "";
            txthKayitTarihi.Text = "";
            txtTeşhis.Text = "";

            txthAd.Focus();

        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnGenelBilgiler_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGenel genel = new FormGenel();
            genel.Show();
        }
    }
}

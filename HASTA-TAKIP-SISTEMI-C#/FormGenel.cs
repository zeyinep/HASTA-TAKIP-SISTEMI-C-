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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace HASTATAKIPSISTEMI___OOP
{
    public partial class FormGenel : Form
    {
        public FormGenel()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8PLCL96;Initial Catalog=HASTATAKIP;Integrated Security=True");
        SqlDataAdapter dr1;
        SqlCommand komut;
        private void drsayi()
        {
            baglanti.Open();
            SqlDataAdapter dr1 = new SqlDataAdapter("SELECT COUNT(*) [Doktor Sayısı] FROM Doktorlar", baglanti);
            DataTable tablo = new DataTable();
            dr1.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btnDr_Click(object sender, EventArgs e)
        {
            drsayi();
        }
        private void hsayi()
        {
            baglanti.Open();
            SqlDataAdapter dr1 = new SqlDataAdapter("SELECT COUNT(*) [Hasta Sayısı] FROM Hastalar", baglanti);
            DataTable tablo = new DataTable();
            dr1.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void btnHasta_Click(object sender, EventArgs e)
        {
            hsayi();
        }
        private void ort()
        {
            baglanti.Open();
            SqlDataAdapter dr1 = new SqlDataAdapter("SELECT AVG(hYas) [Hastaların Yaş Ortalaması] FROM Hastalar", baglanti);
            DataTable tablo = new DataTable();
            dr1.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void btnOrt_Click(object sender, EventArgs e)
        {
            ort();
        }

        private void btnÇıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void hkadin()
        {
            baglanti.Open();
            SqlDataAdapter dr1 = new SqlDataAdapter("SELECT COUNT(*) [Kadın Hasta Sayısı] FROM Hastalar WHERE hCinsiyet='Kadın'", baglanti);
            DataTable tablo = new DataTable();
            dr1.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void btnKadın_Click(object sender, EventArgs e)
        {
            hkadin();
        }
        private void herkek()
        {
            baglanti.Open();
            SqlDataAdapter dr1 = new SqlDataAdapter("SELECT COUNT(*) [Erkek Hasta Sayısı] FROM Hastalar WHERE hCinsiyet='Erkek'", baglanti);
            DataTable tablo = new DataTable();
            dr1.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void btnErkek_Click(object sender, EventArgs e)
        {
            herkek();
        }
    }
}

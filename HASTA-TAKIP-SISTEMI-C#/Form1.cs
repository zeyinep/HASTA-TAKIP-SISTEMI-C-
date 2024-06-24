using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HASTATAKIPSISTEMI___OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8PLCL96;Initial Catalog=HASTATAKIP;Integrated Security=True");
        DateTime dtSaat = new DateTime();
        Random rnd = new Random();

        string[] kod1 = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z" };
        string[] kod2 = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "v", "y", "z" };
        string[] kod3 = { "'", "-", "_", "+", "?", "#", "/", ",", "<", "*" };

        int s1, s2, s3, s4, s5;

        private void Form1_Load(object sender, EventArgs e)
        {
            saat.Start();
            //Güvenlik Kodu
            s1 = rnd.Next(1, kod1.Length);
            s2 = rnd.Next(1, kod2.Length);
            s3 = rnd.Next(1, kod3.Length);
            s4 = rnd.Next(1, 9);
            s5 = rnd.Next(1, 9);

            lblKod.Text = kod1[s1] + s4.ToString() + kod3[s3] + s5.ToString() + kod2[s2];
        }

        private void saat_Tick(object sender, EventArgs e)
        {
            dtSaat = DateTime.Now;
            lblSaat.Text = dtSaat.Hour.ToString();
            lblDakika.Text = dtSaat.Minute.ToString();
            lblSaniye.Text = dtSaat.Second.ToString();
        }

        private void btnGiriþ_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand giris = new SqlCommand("SELECT*FROM Doktorlar WHERE kullaniciAdi = @p1 AND sifre = @p2", baglanti);
            giris.Parameters.AddWithValue("p1", txtKulAd.Text);
            giris.Parameters.AddWithValue("p2", txtÞif.Text);
            SqlDataReader dr1 = giris.ExecuteReader();
            if (txtKulAd.Text != "" && txtÞif.Text != "" && txtKod.Text != "")
            {
                if (dr1.Read() && lblKod.Text == txtKod.Text)
                {
                    MessageBox.Show("GÝRÝÞ BAÞARILI!", "BAÞARILI GÝRÝÞ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    HastaTakipSistemi formHastalar = new HastaTakipSistemi();
                    formHastalar.Show();
                }
                else
                {
                    MessageBox.Show("GÝRÝÞ BAÞARISIZ! Kullanýcý adý, þifre veya güvenlik kodunu kontrol edip tekrar deneyiniz.", "HATALI GÝRÝÞ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("GÝRÝÞ BAÞARISIZ! Kullanýcý adý, þifre veya güvenlik kodu boþ býrakýlamaz.", "BAÞARISIZ GÝRÝÞ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }

        private void btnKayýt_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kayit = new SqlCommand("INSERT INTO Doktorlar(kullaniciAdi, sifre) VALUES (@p1, @p2)", baglanti);
            kayit.Parameters.AddWithValue("p1", txtKulAd.Text);
            kayit.Parameters.AddWithValue("p2", txtÞif.Text);
            kayit.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("KAYIT BAÞARILI!", "BAÞARILI KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

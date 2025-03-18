using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Db_Proje
{
    public partial class Istatistik : Form
    {
        public Istatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-5D42MKKG;Initial Catalog=SatisVT;Integrated Security=True;");
        private void Istatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cm = new SqlCommand("Select Count(*) from TblKategori", baglanti);
            int kategoriSayisi = (int)cm.ExecuteScalar();
            label2.Text = kategoriSayisi.ToString();
            baglanti.Close();

            baglanti.Open();
            SqlCommand cm2 = new SqlCommand("Select Count(*) from TblUrunler", baglanti);
            int urunsayisi = (int)cm2.ExecuteScalar();
            label3.Text = urunsayisi.ToString();
            baglanti.Close();

            baglanti.Open();
            SqlCommand cm3 = new SqlCommand("Select Sum(Kategori) From TblUrunler where Kategori=2", baglanti);
            int beyazEsya = (int)cm3.ExecuteScalar();
            label15.Text = beyazEsya.ToString();
            baglanti.Close();

            baglanti.Open();
            SqlCommand cm4 = new SqlCommand("SELECT UrunAd FROM TblUrunler WHERE UrunSatisFiyat = (SELECT MAX(UrunSatisFiyat) FROM TblUrunler)", baglanti);
            string maxUrun = (string)cm4.ExecuteScalar();
            label11.Text = maxUrun.ToString();
            baglanti.Close();

            baglanti.Open();
            SqlCommand cm5 = new SqlCommand("select Sum(UrunStok) from TblUrunler", baglanti);
            int topStok = (int)cm5.ExecuteScalar();
            label13.Text = topStok.ToString();
            baglanti.Close();

            baglanti.Open();
            SqlCommand cm6 = new SqlCommand("SELECT UrunAd FROM TblUrunler WHERE UrunSatisFiyat = (SELECT MIN(UrunSatisFiyat) FROM TblUrunler)", baglanti);
            string minUrun = (string)cm6.ExecuteScalar();
            label9.Text = minUrun.ToString();
            baglanti.Close();

            baglanti.Open();
            SqlCommand cm7 = new SqlCommand("Select Count(*) from iller", baglanti);
            int SehirSayisi = (int)cm7.ExecuteScalar();
            label23.Text = SehirSayisi.ToString();
            baglanti.Close();

            baglanti.Open();
            SqlCommand cm9 = new SqlCommand("Select Sum(UrunSatisFiyat) from TblUrunler", baglanti);
            decimal kasa = (decimal)cm9.ExecuteScalar();
            label21.Text = kasa.ToString();
            baglanti.Close();

            baglanti.Open();
            SqlCommand cm8 = new SqlCommand("SELECT TOP 1 UrunMarka, COUNT(*) AS UrunSayisi FROM TblUrunler GROUP BY UrunMarka ORDER BY UrunSayisi DESC", baglanti);
            SqlDataReader dr = cm8.ExecuteReader();

            if (dr.Read()) // Eğer veri varsa
            {
                string markaAdi = dr["UrunMarka"].ToString();
                label19.Text = markaAdi;
            }
            dr.Close();
            baglanti.Close();

        }
    }
}

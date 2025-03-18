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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-5D42MKKG;Initial Catalog=SatisVT;Integrated Security=True;");

        private void button3_Click(object sender, EventArgs e)
        {
            FrmKategoriler fr = new FrmKategoriler();
            fr.Show();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            FrmMusteri fr = new FrmMusteri();
            fr.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ürünlerin durum seviyesi
            SqlCommand command = new SqlCommand("Execute Test4", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // grafiğe veri çekme
            baglanti.Open();
            SqlCommand command2 = new SqlCommand("Select KategoriAd, Count(*) From TblKategori INNER JOIN TblUrunler On TblKategori.KategoriId = TblUrunler.Kategori Group By KategoriAd ", baglanti);
            SqlDataReader dr = command2.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Kategoriler"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();


            // grafik 2

            baglanti.Open();
            SqlCommand command3 = new SqlCommand("Select MusteriSehir, Count(*) From TblMusteri group by MusteriSehir", baglanti);
            SqlDataReader dr3 = command3.ExecuteReader();
            while (dr3.Read())
            {
                chart2.Series["Şehirler"].Points.AddXY(dr3[0], dr3[1]);
            }
            baglanti.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kasa fr = new Kasa();
            fr.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Istatistik fr = new Istatistik();
            fr.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

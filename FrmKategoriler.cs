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

namespace SQL_Db_Proje
{
    public partial class FrmKategoriler : Form
    {
        public FrmKategoriler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-5D42MKKG;Initial Catalog=SatisVT;Integrated Security=True;");
        private void BtnList_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From TblKategori", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("insert into TblKategori (KategoriAd) values (@p1) ", baglanti);
            command.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Kaydetme işlemi başarılı");
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("Delete from TblKategori Where KategoriId=@p1", baglanti);
            command.Parameters.AddWithValue("@p1", txtKategoriId.Text);
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori silme işlemi başarılı");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKategoriId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKategoriAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("Update TblKategori set KategoriAd=@p1 where KategoriId=@p2", baglanti);
            command.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            command.Parameters.AddWithValue("@p2", txtKategoriId.Text);
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori güncelleme işlemi başarılı");

        }
    }
}
// Data Source=LAPTOP-5D42MKKG;Initial Catalog=SatisVT;Integrated Security=True;Trust Server Certificate=True
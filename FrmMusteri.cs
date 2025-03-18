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
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-5D42MKKG;Initial Catalog=SatisVT;Integrated Security=True;");

        void Listele()
        {
            SqlCommand command = new SqlCommand("Select * From TblMusteri", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            Listele();

            baglanti.Open();
            SqlCommand command = new SqlCommand("Select * From iller", baglanti);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                cmbSehir.Items.Add(dr["sehir"].ToString().ToUpper());
            }
            baglanti.Close();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("insert into TblMusteri (MusteriAd,MusteriSoyad,MusteriSehir,MusteriBakiye) values (@p1,@p2,@p3,@p4)",baglanti);
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", cmbSehir.Text);
            command.Parameters.AddWithValue("@p4",decimal.Parse( txtBakiye.Text));
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Kaydetme işlemi başarılı");
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("Delete from TblMusteri Where MusteriId=@p1", baglanti);
            command.Parameters.AddWithValue("@p1", txtId.Text);
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri silme işlemi başarılı");
            Listele();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("Update TblMusteri set MusteriAd=@p1,MusteriSoyad=@p2,MusteriSehir=@p3,MusteriBakiye=@p4 where MusteriId=@p5", baglanti);
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", cmbSehir.Text);
            command.Parameters.AddWithValue("@p4", decimal.Parse(txtBakiye.Text));
            command.Parameters.AddWithValue("@p5", txtId.Text);
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori güncelleme işlemi başarılı");
            Listele();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From TblMusteri where MusteriAd=@p1", baglanti);
            command.Parameters.AddWithValue("@p1", txtName.Text);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

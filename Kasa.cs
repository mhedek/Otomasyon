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
    public partial class Kasa : Form
    {
        public Kasa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-5D42MKKG;Initial Catalog=SatisVT;Integrated Security=True;");
        private void Kasa_Load(object sender, EventArgs e)
        {
           // baglanti.Open();
            SqlCommand command = new SqlCommand("Select * From TblKasa",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //baglanti.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Pansiyon_Kayıt_Otomasyonu
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-20F8ATP;Initial Catalog=PansiyonOtomasyonu;Integrated Security=True");
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sql = "Select * from AdminGiris where Kullanici=@Kullaniciadi AND Sifre=@Sifresi";
            SqlParameter prm1 = new SqlParameter("Kullaniciadi", TxtKullaniciAdi.Text);
            SqlParameter prm2 = new SqlParameter("Sifresi", TxtSifre.Text);
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.Add(prm1);
            komut.Parameters.Add(prm2);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
            }

            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
            baglanti.Close();
        }
    }
}

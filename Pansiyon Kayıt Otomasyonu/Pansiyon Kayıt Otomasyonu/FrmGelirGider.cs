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
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-20F8ATP;Initial Catalog=PansiyonOtomasyonu;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            int personel;
            personel = Convert.ToInt16(textBox1.Text);
            LblPersonelMaas.Text = (personel * 8500).ToString();

            int sonuc;
            int kasaToplam, personelMaas, alinanUrunler1, alinanUrunler2, alinanUrunler3, faturalar1, faturalar2, faturalar3;

            if (int.TryParse(LblKasaToplam.Text, out kasaToplam) &&
                int.TryParse(LblPersonelMaas.Text, out personelMaas) &&
                int.TryParse(LblAlinanUrunler1.Text, out alinanUrunler1) &&
                int.TryParse(LblAlinanUrunler2.Text, out alinanUrunler2) &&
                int.TryParse(LblAlinanUrunler3.Text, out alinanUrunler3) &&
                int.TryParse(LblFaturalar1.Text, out faturalar1) &&
                int.TryParse(LblFaturalar2.Text, out faturalar2) &&
                int.TryParse(LblFaturalar3.Text, out faturalar3))

            {
                sonuc = kasaToplam - personelMaas - alinanUrunler1 - alinanUrunler2 - alinanUrunler3 - faturalar1 - faturalar2 - faturalar3;
                LblSonuc.Text = sonuc.ToString();
            }
            else
            {
                // İşleme Hatası
            }

        }

        private void FrmGelirGider_Load(object sender, EventArgs e)
        {//kasadaki toplam tutar
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(Ucret) as toplam from MusteriEkle1", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                LblKasaToplam.Text = oku["toplam"].ToString();

            }
            baglanti.Close();

            //gıda giderleri

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(Gida) as toplam1 from Stoklar", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                LblAlinanUrunler1.Text = oku2["toplam1"].ToString();

            }
            baglanti.Close();

            //İçecekler

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select sum(İcecek) as toplam2 from Stoklar", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                LblAlinanUrunler2.Text = oku3["toplam2"].ToString();

            }
            baglanti.Close();

            //Atıştırmalıklar

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select sum(Cerezler) as toplam3 from Stoklar", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                LblAlinanUrunler3.Text = oku4["toplam3"].ToString();

            }
            baglanti.Close();
            //elektrik

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(Elektrik) as toplam4 from Faturalar", baglanti);
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                LblFaturalar1.Text = oku5["toplam4"].ToString();

            }
            baglanti.Close();

            //Su

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select sum(Su) as toplam5 from Faturalar", baglanti);
            SqlDataReader oku6= komut6.ExecuteReader();
            while (oku6.Read())
            {
                LblFaturalar2.Text = oku6["toplam5"].ToString();

            }
            baglanti.Close();

            //İnternet

            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("select sum(İnternet) as toplam6 from Faturalar", baglanti);
            SqlDataReader oku7 = komut7.ExecuteReader();
            while (oku7.Read())
            {
                LblFaturalar3.Text = oku7["toplam6"].ToString();

            }
            baglanti.Close();


           
        }

       
    }
}

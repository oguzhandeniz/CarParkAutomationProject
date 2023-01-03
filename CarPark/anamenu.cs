using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
namespace CarPark
{
    public partial class anamenu : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" + Application.StartupPath + "\\otoparkveri.accdb");

        public anamenu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form ekleform = new ekle();
            ekleform.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form arac = new araccikis();
            arac.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form arackonum = new konum();
            arackonum.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form aracgecmis = new gecmis();
            aracgecmis.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form kapat = new kullanicigirisi();
            kapat.Show();
            this.Hide();
        }

        private void anamenu_Load(object sender, EventArgs e)
        {
            chart1.Titles.Add("Otopark Doluluk Oranı");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from musteri where durum like (0)", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            int a = 0;
            while (okuyucu.Read())
            {
                a++;
            }
            baglanti.Close();
            double yuzde = (a * 100) / 10;
            chart1.Series["%Doluluk_Oranı"].Points.AddXY("Doluluk Oranı", yuzde);

            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("select * from gecmis where fiyat IS NOT NULL ",baglanti);
            OleDbDataReader okuyucu2 = komut2.ExecuteReader();
            double toplam = 0.0;


            while (okuyucu2.Read())
            {
              toplam = toplam + Convert.ToDouble(okuyucu2["fiyat"].ToString().Trim('T', 'L'));
            }
            baglanti.Close();
            label6.Text=Convert.ToString(toplam);
        }
    }
}

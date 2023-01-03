using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;
namespace CarPark
{
    public partial class kullanicigirisi : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" + Application.StartupPath + "\\otoparkveri.accdb");

        public kullanicigirisi()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.google.com");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Giriş Bilgisi Yapılmadı.");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Kullanıcı Adını Giriniz");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Şifrenizi Giriniz");
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("Select * from kullanici where kullaniciadi='"+textBox1.Text.ToString()+"'",baglanti);
                OleDbDataReader okuyucu = komut.ExecuteReader();
                if(okuyucu.Read()==true)
                {
                    if (textBox1.Text.ToString() == okuyucu["kullaniciadi"].ToString() && textBox2.Text.ToString() == okuyucu["sifre"].ToString())
                    {
                        Form anamenu = new anamenu();
                        anamenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullancı Adı Veya Şifre Hatalı");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Kullancı Adı Veya Şifre Hatalı");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                baglanti.Close();
            }
        }
    }
}

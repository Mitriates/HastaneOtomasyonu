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

namespace HastaneProje
{
    public partial class Frm_SekreterDetay : Form
    {
        public Frm_SekreterDetay()
        {
            InitializeComponent();
        }
        public string TCnumara;

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void Frm_SekreterDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text= TCnumara;

            // AD Soyad
            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter where SekreterTC=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",LblTC.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblAdSoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            // Branşları Datagride Aktarma 

            DataTable dt1 = new DataTable();
            SqlDataAdapter da =new SqlDataAdapter("Select * From Tbl_Branslar",bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource= dt1;

            // Doktorları Datagride Aktarma

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource= dt2;

            // Branşı Combobxa Aktarma 

            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2= komut2.ExecuteReader();
            while(dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@p1,@p2,@p3,@p4)", bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@p1", MskTarih.Text);
            komutkaydet.Parameters.AddWithValue("@p2", MskSaat.Text);
            komutkaydet.Parameters.AddWithValue("@p3", CmbBrans.Text);
            komutkaydet.Parameters.AddWithValue("@p4", CmbDoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();

            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@p1) ",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", RchDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu !");
        }

        private void BtnDoktorPaneli_Click(object sender, EventArgs e)
        {
            Frm_DoktorPaneli drp = new Frm_DoktorPaneli();
            drp.Show();
        }

        private void BtnBransPaneli_Click(object sender, EventArgs e)
        {
            Frm_BransPaneli fr = new Frm_BransPaneli();
            fr.Show();

        }

        private void BtnRandevuListe_Click(object sender, EventArgs e)
        {
            Frm_RandevuListesi fr = new Frm_RandevuListesi();
            fr.Show();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            Frm_Duyurular fr = new Frm_Duyurular();
            fr.Show();
        }
    }
}

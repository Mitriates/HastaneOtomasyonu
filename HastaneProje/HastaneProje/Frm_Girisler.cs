using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneProje
{
    public partial class Frm_Girisler : Form
    {
        public Frm_Girisler()
        {
            InitializeComponent();
        }

        private void BtnHastaGirisi_Click(object sender, EventArgs e)
        {
            Frm_HastaGiris fr = new Frm_HastaGiris();
            fr.Show();
            this.Hide();
        }

        private void BtnDoktorGirisi_Click(object sender, EventArgs e)
        {
            Frm_DoktorGiris fr = new Frm_DoktorGiris();
            fr.Show();
            this.Hide();
        }

        private void BtnSekreterGirisi_Click(object sender, EventArgs e)
        {
            Frm_SekreterGiris fr = new Frm_SekreterGiris();
            fr.Show();
            this.Hide();

        }
    }
}

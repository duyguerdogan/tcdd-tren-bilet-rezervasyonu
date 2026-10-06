using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GirisForm : Form
    {
        private readonly VeriDeposu depo = new VeriDeposu();

        public GirisForm()
        {
            InitializeComponent();
            Text = "Tren Bileti — Giriş / Kayıt";
            txtKayitParola.UseSystemPasswordChar = true;
            txtGirisParola.UseSystemPasswordChar = true;
            txtKayitParola.MaxLength = txtGirisParola.MaxLength = 128;
            txtKayitKullaniciAdi.MaxLength = txtGirisKullaniciAdi.MaxLength = 40;
            AcceptButton = btnGirisYap;
        }

        private void KayitOl_Click(object sender, EventArgs e)
        {
            ArayuzIslemi.Dene(this, () =>
            {
                depo.KayitOl(txtKayitKullaniciAdi.Text, txtKayitParola.Text);
                txtGirisKullaniciAdi.Text = txtKayitKullaniciAdi.Text.Trim();
                txtKayitParola.Clear();
                MessageBox.Show(this, "Kayıt tamamlandı. Şimdi giriş yapabilirsiniz.");
                txtGirisParola.Focus();
            });
        }

        private void GirisYap_Click(object sender, EventArgs e)
        {
            ArayuzIslemi.Dene(this, () =>
            {
                string kullanici = depo.GirisYap(txtGirisKullaniciAdi.Text, txtGirisParola.Text);
                if (kullanici == null)
                    throw new InvalidOperationException("Kullanıcı adı veya parola hatalı.");
                txtGirisParola.Clear();
                Hide();
                try { using (var menu = new AnaMenuForm(depo, kullanici)) menu.ShowDialog(); }
                finally { Show(); }
            });
        }
    }
}

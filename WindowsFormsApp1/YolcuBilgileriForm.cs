using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class YolcuBilgileriForm : Form
    {
        public string Isim { get { return txtIsim.Text.Trim(); } }
        public string Soyisim { get { return txtSoyisim.Text.Trim(); } }
        public string Telefon { get { return mskdTelefon.Text; } }
        public string Cinsiyet { get { return rdbErkek.Checked ? "ERKEK" : "KADIN"; } }

        public YolcuBilgileriForm()
        {
            InitializeComponent();
            Text = "Yolcu Bilgileri — Telefon: başında 0 olmadan";
            mskdTelefon.Mask = "(000) 000-0000";
            mskdTelefon.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtIsim.MaxLength = txtSoyisim.MaxLength = 60;
            AcceptButton = btnTamam;
            CancelButton = btnIptal;
        }

        private void Tamam_Click(object sender, EventArgs e)
        {
            if (ArayuzIslemi.Dene(this, () => BiletKurallari.YolcuDogrula(Isim, Soyisim, Telefon, Cinsiyet)))
                DialogResult = DialogResult.OK;
        }

        private void Iptal_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }
    }
}

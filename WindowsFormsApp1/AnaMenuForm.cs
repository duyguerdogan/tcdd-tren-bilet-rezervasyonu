using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AnaMenuForm : Form
    {
        private readonly VeriDeposu depo;
        private readonly string kullaniciAdi;

        public AnaMenuForm() : this(new VeriDeposu(), null) { }
        public AnaMenuForm(VeriDeposu depo, string kullaniciAdi)
        {
            InitializeComponent();
            this.depo = depo;
            this.kullaniciAdi = kullaniciAdi;
            Text = "Ana Menü — " + kullaniciAdi;
        }

        private void Hakkinda_Click(object sender, EventArgs e)
        {
            using (var form = new HakkindaForm()) form.ShowDialog(this);
        }

        private void TrenSaatleri_Click(object sender, EventArgs e)
        {
            using (var form = new TrenSaatleriForm()) form.ShowDialog(this);
        }

        private void BiletAl_Click(object sender, EventArgs e)
        {
            using (var form = new BiletAlForm(depo, kullaniciAdi)) form.ShowDialog(this);
        }
    }
}

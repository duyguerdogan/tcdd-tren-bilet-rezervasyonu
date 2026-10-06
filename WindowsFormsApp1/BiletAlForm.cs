using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class BiletAlForm : Form
    {
        private readonly VeriDeposu depo;
        private readonly string kullaniciAdi;
        private readonly List<Bilet> bekleyenler = new List<Bilet>();
        private readonly List<Button> koltuklar = new List<Button>();
        private List<Bilet> kayitliBiletler = new List<Bilet>();
        private readonly Panel koltukPaneli = new Panel();
        private Button tiklanan;

        public BiletAlForm() : this(new VeriDeposu(), null) { }
        public BiletAlForm(VeriDeposu depo, string kullaniciAdi)
        {
            InitializeComponent();
            this.depo = depo;
            this.kullaniciAdi = kullaniciAdi;
            Text = "Biletlerim — " + kullaniciAdi;
            dtpTarih.MinDate = DateTime.Today;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Tren", 110);
            listView1.Columns.Add("Durum", 110);
            koltukPaneli.SetBounds(5, 13, 250, ClientSize.Height - 26);
            koltukPaneli.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            koltukPaneli.AutoScroll = true;
            koltukPaneli.BackColor = Color.Transparent;
            Controls.Add(koltukPaneli);

            var kaldir = new Button { Text = "Bekleyen bileti kaldır", Left = button1.Left - 35,
                Top = button1.Bottom + 12, Width = 180, Height = 32 };
            kaldir.Click += BekleyenBiletiKaldir_Click;
            Controls.Add(kaldir);
            var bilgi = new Label { Text = "Sarı: kaydedilmemiş bilet\nKoltuk seç → yolcu bilgileri → KAYDET",
                Left = 263, Top = kaldir.Bottom + 15, Width = 265, Height = 65,
                ForeColor = Color.White, BackColor = Color.Transparent };
            Controls.Add(bilgi);
            Shown += (s, e) => VerileriYenile();
            FormClosing += Kapanirken;
        }

        private void TrenSecimiDegisti(object sender, EventArgs e)
        {
            tiklanan = null;
            foreach (var koltuk in koltuklar) { koltukPaneli.Controls.Remove(koltuk); koltuk.Dispose(); }
            koltuklar.Clear();
            koltukPaneli.AutoScrollPosition = Point.Empty;
            int sayi = BiletKurallari.KoltukSayisi(cmbTren.Text);
            for (int i = 0; i < sayi; i++)
            {
                int sutun = i % 3;
                var koltuk = new Button { Width = 40, Height = 40, Top = 5 + i / 3 * 45,
                    Left = 5 + (sutun == 2 ? 3 : sutun) * 45, Text = (i + 1).ToString(),
                    Tag = i + 1, ContextMenuStrip = contextMenuStrip1 };
                koltuk.MouseDown += (s, args) => tiklanan = (Button)s;
                koltuk.Click += (s, args) => { tiklanan = (Button)s; KoltukSec_Click(s, args); };
                koltukPaneli.Controls.Add(koltuk);
                koltuklar.Add(koltuk);
            }
            if (depo != null) VerileriYenile();
        }

        private void TarihDegisti(object sender, EventArgs e)
        {
            tiklanan = null;
            if (depo != null) VerileriYenile();
        }

        private bool VerileriYenile()
        {
            bool basarili = ArayuzIslemi.Dene(this, () => kayitliBiletler = depo.BiletleriOku());
            if (!basarili)
            {
                foreach (var koltuk in koltuklar) koltuk.Enabled = false;
                return false;
            }
            GorunumuYenile();
            return true;
        }

        private void GorunumuYenile()
        {
            foreach (var koltuk in koltuklar)
            {
                var aranan = new Bilet { Tren = cmbTren.Text, Tarih = dtpTarih.Value.Date, KoltukNo = (int)koltuk.Tag };
                var kayit = kayitliBiletler.FirstOrDefault(b => BiletKurallari.AyniKoltuk(b, aranan));
                bool bekliyor = bekleyenler.Any(b => BiletKurallari.AyniKoltuk(b, aranan));
                koltuk.Enabled = kayit == null && !bekliyor;
                koltuk.BackColor = kayit != null ? (kayit.Cinsiyet == "ERKEK" ? Color.PowderBlue : Color.LightCoral)
                    : bekliyor ? Color.Gold : SystemColors.Control;
            }
            listView1.Items.Clear();
            foreach (var bilet in kayitliBiletler.Where(b => b.KullaniciAdi == kullaniciAdi).Concat(bekleyenler))
            {
                bool bekliyor = bekleyenler.Contains(bilet);
                var satir = new ListViewItem(new[] { bilet.Isim + " " + bilet.Soyisim, bilet.Telefon,
                    bilet.Cinsiyet, bilet.Nereden, bilet.Nereye, bilet.KoltukNo.ToString(),
                    bilet.Tarih.ToString("dd.MM.yyyy"), bilet.Fiyat.ToString("0.00"), bilet.Tren,
                    bekliyor ? "Kaydedilmedi" : "Kaydedildi" }) { Tag = bilet };
                if (bekliyor) satir.BackColor = Color.LightGoldenrodYellow;
                listView1.Items.Add(satir);
            }
            button1.Enabled = bekleyenler.Count > 0;
        }

        private void KoltukSec_Click(object sender, EventArgs e)
        {
            ArayuzIslemi.Dene(this, () =>
            {
                if (tiklanan == null) throw new InvalidOperationException("Önce bir koltuk seçin.");
                BiletKurallari.SeferDogrula(cmbTren.Text, dtpTarih.Value, cmbNereden.Text, cmbNereye.Text, nudFiyat.Value);
                int koltukNo = (int)tiklanan.Tag;
                var bilet = new Bilet { Id = Guid.NewGuid().ToString("N"), KullaniciAdi = kullaniciAdi,
                    Tren = cmbTren.Text, Tarih = dtpTarih.Value.Date, KoltukNo = koltukNo,
                    Nereden = cmbNereden.Text, Nereye = cmbNereye.Text, Fiyat = nudFiyat.Value };
                if (!VerileriYenile()) return;
                if (kayitliBiletler.Concat(bekleyenler).Any(b => BiletKurallari.AyniKoltuk(b, bilet)))
                    throw new InvalidOperationException("Bu koltuk dolu veya zaten seçildi.");
                using (var yolcu = new YolcuBilgileriForm())
                {
                    if (yolcu.ShowDialog(this) != DialogResult.OK) return;
                    bilet.Isim = yolcu.Isim; bilet.Soyisim = yolcu.Soyisim;
                    bilet.Telefon = yolcu.Telefon; bilet.Cinsiyet = yolcu.Cinsiyet;
                }
                BiletKurallari.Dogrula(bilet);
                bekleyenler.Add(bilet);
                GorunumuYenile();
            });
        }

        private bool Kaydet()
        {
            bool basarili = ArayuzIslemi.Dene(this, () => depo.BiletleriKaydet(kullaniciAdi, bekleyenler));
            if (basarili) bekleyenler.Clear();
            VerileriYenile();
            return basarili;
        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
            if (Kaydet()) MessageBox.Show(this, "Biletler kalıcı olarak kaydedildi.");
        }

        private void BekleyenBiletiKaldir_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Listeden kaydedilmemiş bir bilet seçin.");
                return;
            }
            foreach (ListViewItem satir in listView1.SelectedItems)
                bekleyenler.Remove((Bilet)satir.Tag);
            GorunumuYenile();
        }

        private void Kapanirken(object sender, FormClosingEventArgs e)
        {
            if (bekleyenler.Count == 0) return;
            var cevap = MessageBox.Show(this, "Kaydedilmemiş biletler var. Kaydedilsin mi?",
                "Biletleri kaydet", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (cevap == DialogResult.Cancel || (cevap == DialogResult.Yes && !Kaydet())) e.Cancel = true;
        }
    }
}

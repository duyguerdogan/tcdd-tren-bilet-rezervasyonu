using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public sealed class Bilet
    {
        public string Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Tren { get; set; }
        public DateTime Tarih { get; set; }
        public int KoltukNo { get; set; }
        public string Nereden { get; set; }
        public string Nereye { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Telefon { get; set; }
        public string Cinsiyet { get; set; }
        public decimal Fiyat { get; set; }
    }

    public sealed class UygulamaVerisi
    {
        public List<Kullanici> Kullanicilar { get; set; } = new List<Kullanici>();
        public List<Bilet> Biletler { get; set; } = new List<Bilet>();
    }

    public static class BiletKurallari
    {
        public static int KoltukSayisi(string tren)
        {
            if (tren == "İZMİR MAVİ") return 45;
            if (tren == "EGE EKSPRESİ") return 36;
            return 0;
        }

        public static readonly string[] Istasyonlar =
        {
            "Ankara Gar", "Sincan", "Polatlı", "Beylikköprü", "Biçer", "Yunusemre",
            "Beylikova", "Alpu", "Eskişehir", "Kütahya", "Tavşanlı", "Balıköy",
            "Dursunbey", "Balıkesir", "Savaştepe", "Soma", "Kırkağaç", "Akhisar",
            "Saruhanlı", "Manisa", "Muradiye", "Menemen", "Çiğli", "İzmir(Basmane)"
        };

        public static void YolcuDogrula(string isim, string soyisim, string telefon, string cinsiyet)
        {
            if (string.IsNullOrWhiteSpace(isim) || string.IsNullOrWhiteSpace(soyisim))
                throw new InvalidOperationException("İsim ve soyisim alanlarını doldurun.");
            if (isim.Trim().Length > 60 || soyisim.Trim().Length > 60)
                throw new InvalidOperationException("İsim ve soyisim en fazla 60 karakter olabilir.");
            if (telefon == null || telefon.Length != 10 || telefon.Any(c => c < '0' || c > '9'))
                throw new InvalidOperationException("Telefonu başında 0 olmadan 10 rakam olarak girin.");
            if (cinsiyet != "KADIN" && cinsiyet != "ERKEK")
                throw new InvalidOperationException("Cinsiyet seçin.");
        }

        public static void SeferDogrula(string tren, DateTime tarih, string nereden, string nereye, decimal fiyat)
        {
            if (KoltukSayisi(tren) == 0 || !Istasyonlar.Contains(nereden) || !Istasyonlar.Contains(nereye))
                throw new InvalidOperationException("Tren, kalkış ve varış istasyonlarını seçin.");
            if (nereden == nereye)
                throw new InvalidOperationException("Kalkış ve varış istasyonları farklı olmalıdır.");
            if (tarih.Date < DateTime.Today)
                throw new InvalidOperationException("Geçmiş bir tarih için bilet alınamaz.");
            if (fiyat < 20 || fiyat > 10000)
                throw new InvalidOperationException("Fiyat 20 ile 10000 arasında olmalıdır.");
        }

        public static void Dogrula(Bilet bilet)
        {
            if (bilet == null) throw new InvalidOperationException("Bilet bilgisi eksik.");
            SeferDogrula(bilet.Tren, bilet.Tarih, bilet.Nereden, bilet.Nereye, bilet.Fiyat);
            YolcuDogrula(bilet.Isim, bilet.Soyisim, bilet.Telefon, bilet.Cinsiyet);
            if (bilet.KoltukNo < 1 || bilet.KoltukNo > KoltukSayisi(bilet.Tren))
                throw new InvalidOperationException("Geçerli bir koltuk seçin.");
        }

        // Simülasyonda her tren için günde tek sefer kabul edilir; koltuk tüm sefer boyunca doludur.
        public static bool AyniKoltuk(Bilet a, Bilet b)
        {
            return a.Tren == b.Tren && a.Tarih.Date == b.Tarih.Date && a.KoltukNo == b.KoltukNo;
        }
    }

    public sealed class VeriDeposu
    {
        private const int ParolaIterasyonu = 210000;
        private readonly string dosyaYolu;
        private readonly string kilitAdi;

        public VeriDeposu() : this(Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData), "TcddTrenBiletAlma", "veriler.xml")) { }

        public VeriDeposu(string dosyaYolu)
        {
            this.dosyaYolu = Path.GetFullPath(dosyaYolu);
            using (var sha = SHA256.Create())
                kilitAdi = "Local\\TcddBilet_" + Convert.ToBase64String(sha.ComputeHash(
                    Encoding.UTF8.GetBytes(this.dosyaYolu.ToUpperInvariant()))).Replace('/', '_');
        }

        public void KayitOl(string kullaniciAdi, string parola)
        {
            kullaniciAdi = (kullaniciAdi ?? "").Trim();
            if (kullaniciAdi.Length < 3 || kullaniciAdi.Length > 40)
                throw new InvalidOperationException("Kullanıcı adı 3 ile 40 karakter arasında olmalıdır.");
            if (string.IsNullOrWhiteSpace(parola) || parola.Length < 8 || parola.Length > 128)
                throw new InvalidOperationException("Parola 8 ile 128 karakter arasında olmalıdır.");
            var tuz = new byte[16];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(tuz);
            var kullanici = new Kullanici
            {
                KullaniciAdi = kullaniciAdi, Tuz = Convert.ToBase64String(tuz),
                ParolaOzeti = Convert.ToBase64String(ParolaTuret(parola, tuz, ParolaIterasyonu)),
                Iterasyon = ParolaIterasyonu
            };
            Kilitli(() =>
            {
                var veri = Oku();
                if (veri.Kullanicilar.Any(k => string.Equals(k.KullaniciAdi, kullaniciAdi, StringComparison.OrdinalIgnoreCase)))
                    throw new InvalidOperationException("Bu kullanıcı adı zaten mevcut.");
                veri.Kullanicilar.Add(kullanici);
                Yaz(veri);
                return true;
            });
        }

        public string GirisYap(string kullaniciAdi, string parola)
        {
            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrEmpty(parola) || parola.Length > 128)
                return null;
            var kullanici = Kilitli(() => Oku().Kullanicilar.FirstOrDefault(k =>
                string.Equals(k.KullaniciAdi, kullaniciAdi.Trim(), StringComparison.OrdinalIgnoreCase)));
            if (kullanici == null) return null;
            var beklenen = Convert.FromBase64String(kullanici.ParolaOzeti);
            var sonuc = ParolaTuret(parola, Convert.FromBase64String(kullanici.Tuz), kullanici.Iterasyon);
            int fark = beklenen.Length ^ sonuc.Length;
            for (int i = 0; i < Math.Min(beklenen.Length, sonuc.Length); i++) fark |= beklenen[i] ^ sonuc[i];
            return fark == 0 ? kullanici.KullaniciAdi : null;
        }

        public List<Bilet> BiletleriOku() { return Kilitli(() => Oku().Biletler); }

        public void BiletleriKaydet(string kullaniciAdi, IEnumerable<Bilet> biletler)
        {
            var yeniBiletler = biletler.ToList();
            if (yeniBiletler.Count == 0) throw new InvalidOperationException("Kaydedilecek yeni bilet yok.");
            Kilitli(() =>
            {
                var veri = Oku();
                if (!veri.Kullanicilar.Any(k => k.KullaniciAdi == kullaniciAdi))
                    throw new InvalidOperationException("Önce giriş yapın.");
                foreach (var bilet in yeniBiletler)
                {
                    BiletKurallari.Dogrula(bilet);
                    if (bilet.KullaniciAdi != kullaniciAdi)
                        throw new InvalidOperationException("Bilet başka bir kullanıcıya ait.");
                    if (string.IsNullOrWhiteSpace(bilet.Id) || veri.Biletler.Any(b => b.Id == bilet.Id))
                        throw new InvalidOperationException("Bu bilet daha önce kaydedilmiş.");
                    if (veri.Biletler.Any(b => BiletKurallari.AyniKoltuk(b, bilet)))
                        throw new InvalidOperationException(bilet.Tren + " / " + bilet.Tarih.ToString("dd.MM.yyyy") +
                            " / " + bilet.KoltukNo + " numaralı koltuk dolu. Bekleyen bileti kaldırıp başka koltuk seçin.");
                    veri.Biletler.Add(bilet);
                }
                // Tüm biletler doğrulandıktan sonra tek seferde yazılır.
                Yaz(veri);
                return true;
            });
        }

        private static byte[] ParolaTuret(string parola, byte[] tuz, int iterasyon)
        {
            using (var pbkdf = new Rfc2898DeriveBytes(parola, tuz, iterasyon, HashAlgorithmName.SHA256))
                return pbkdf.GetBytes(32);
        }

        private T Kilitli<T>(Func<T> islem)
        {
            using (var mutex = new Mutex(false, kilitAdi))
            {
                bool alindi = false;
                try
                {
                    try { alindi = mutex.WaitOne(TimeSpan.FromSeconds(10)); }
                    catch (AbandonedMutexException) { alindi = true; }
                    if (!alindi) throw new IOException("Veri dosyası meşgul. Biraz sonra yeniden deneyin.");
                    return islem();
                }
                finally { if (alindi) mutex.ReleaseMutex(); }
            }
        }

        private UygulamaVerisi Oku()
        {
            if (!File.Exists(dosyaYolu)) return new UygulamaVerisi();
            try
            {
                using (var stream = File.OpenRead(dosyaYolu))
                {
                    var veri = (UygulamaVerisi)new XmlSerializer(typeof(UygulamaVerisi)).Deserialize(stream);
                    if (veri == null || veri.Kullanicilar == null || veri.Biletler == null ||
                        veri.Kullanicilar.Any(k => k == null || string.IsNullOrWhiteSpace(k.KullaniciAdi) ||
                            k.Iterasyon < 10000 || k.Iterasyon > 2000000 ||
                            Convert.FromBase64String(k.Tuz ?? "").Length != 16 ||
                            Convert.FromBase64String(k.ParolaOzeti ?? "").Length != 32) ||
                        veri.Biletler.Any(b => b == null || string.IsNullOrWhiteSpace(b.Id)))
                        throw new InvalidOperationException("Geçersiz veri yapısı.");
                    return veri;
                }
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is FormatException)
            {
                throw new IOException("Veri dosyası okunamadı; mevcut kayıtlar değiştirilmedi. Veri dosyasını ve .bak yedeğini kontrol edin.", ex);
            }
        }

        private void Yaz(UygulamaVerisi veri)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(dosyaYolu));
            string gecici = dosyaYolu + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                using (var stream = new FileStream(gecici, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                {
                    new XmlSerializer(typeof(UygulamaVerisi)).Serialize(stream, veri);
                    stream.Flush(true);
                }
                if (File.Exists(dosyaYolu)) File.Replace(gecici, dosyaYolu, dosyaYolu + ".bak");
                else File.Move(gecici, dosyaYolu);
            }
            finally { if (File.Exists(gecici)) File.Delete(gecici); }
        }
    }
}

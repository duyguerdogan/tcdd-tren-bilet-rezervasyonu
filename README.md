# Tren Bileti Rezervasyon Simülasyonu

C# ve Windows Forms ile geliştirilmiş, kullanıcı kaydı, koltuk seçimi ve bilet rezervasyonu işlemlerini içeren masaüstü uygulaması.

Proje; olay tabanlı programlama, form yönetimi, veri doğrulama ve yerel veri saklama üzerine çalışmak amacıyla hazırlanmıştır.

> Akademik proje kapsamında hazırlanmış bir simülasyondur. TCDD ile resmî bir bağlantısı bulunmaz; gerçek bilet satışı, ödeme veya canlı sefer sorgulaması yapmaz.

## Özellikler

- Kullanıcı kaydı ve giriş doğrulaması
- İzmir Mavi ve Ege Ekspresi için dinamik koltuk oluşturma
- Yolcu bilgileri, güzergâh, tarih ve fiyat girişi
- Aynı tren, tarih ve koltuk için mükerrer rezervasyon kontrolü
- Kullanıcıya ait biletleri listeleme
- Kaydedilmemiş biletleri kaldırma ve çıkışta kaydetme uyarısı
- Örnek tarifeye göre bir sonraki trene kalan süreyi hesaplama
- Kullanıcı ve bilet kayıtlarını XML dosyasında kalıcı saklama

## Kullanılan Teknolojiler

| Teknoloji | Kullanım |
|---|---|
| C# | Uygulama mantığı |
| Windows Forms | Masaüstü arayüzü |
| .NET Framework 4.7.2 | Çalışma ortamı |
| XML | Yerel veri saklama |
| PBKDF2-SHA256 | Parola özetleme |
| LINQ | Veri sorgulama ve filtreleme |

Harici NuGet paketi veya veritabanı sunucusu gerekmez.

## Kurulum ve Çalıştırma

### Gereksinimler

- Windows
- Visual Studio ve **.NET masaüstü geliştirme** iş yükü
- .NET Framework 4.7.2 hedefleme paketi

### Adımlar

1. Depoyu klonlayın:

   ```bash
   git clone https://github.com/duyguerdogan/tcdd-tren-bilet-rezervasyonu.git
   ```

   Alternatif olarak **Code → Download ZIP** ile indirin ve arşivi bir klasöre çıkarın.

2. `WindowsFormsApp1.sln` dosyasını Visual Studio ile açın.
3. Çözümü derleyin ve **F5** ile çalıştırın.
4. En az 3 karakterlik kullanıcı adı ve en az 8 karakterlik parola ile kayıt olun.
5. Oluşturduğunuz hesapla giriş yapın.

## Kullanım

1. Ana menüden **Bilet Al** ekranını açın.
2. Tren, kalkış ve varış istasyonları, tarih ve fiyat seçin.
3. Boş bir koltuğa tıklayın veya sağ tık menüsünden **Koltuk Seç** seçeneğini kullanın.
4. Yolcu bilgilerini doldurun. Telefon numarasını başında `0` olmadan 10 rakam olarak girin.
5. **KAYDET** düğmesine basarak rezervasyonu tamamlayın.

Yeni biletler sarı renkte ve **Kaydedilmedi** durumunda gösterilir. Kaydetmeden önce listeden bir bilet seçerek **Bekleyen bileti kaldır** düğmesiyle kaldırabilirsiniz.

## Rezervasyon Kuralları

- Kalkış ve varış istasyonları farklı olmalıdır.
- Geçmiş bir tarih için rezervasyon yapılamaz.
- Her tren için günde tek sefer varsayılır.
- Koltuk doluluğu **tren + tarih + koltuk numarası** üzerinden kontrol edilir.
- Rezerve edilen koltuk, seçilen güzergâhtan bağımsız olarak o sefer boyunca dolu kabul edilir.
- Farklı tren veya tarihlerde aynı koltuk numarası kullanılabilir.
- Toplu kayıtta bir bilet için çakışma varsa hiçbir bilet kaydedilmez.
- Kullanıcılar yalnızca kendi biletlerini görür; doluluk kontrolü tüm kullanıcıların rezervasyonlarını kapsar.

## Veri Saklama

Kullanıcı ve bilet kayıtları aşağıdaki konumda saklanır:

```text
%LOCALAPPDATA%\TcddTrenBiletAlma\veriler.xml
```

- Parolalar, kullanıcıya özgü rastgele tuz ve **210.000 iterasyonlu PBKDF2-SHA256** ile özetlenir.
- Dosya güncellenirken önce geçici dosyaya yazılır, ardından mevcut dosya değiştirilir.
- Önceki kayıt dosyası `veriler.xml.bak` olarak yedeklenir.
- Eş zamanlı kayıt işlemleri dosyaya özel kilitle sıralanır.
- Bozuk veya okunamayan veri dosyalarının üzerine boş kayıt yazılmaz.

Yolcu bilgileri yerel XML dosyasında açık metin olarak tutulur. Uygulama, sunucu tabanlı bir kimlik doğrulama ve yetkilendirme sistemi içermez.

## Proje Yapısı

```text
WindowsFormsApp1.sln
WindowsFormsApp1/
├── GirisForm.cs
├── AnaMenuForm.cs
├── BiletAlForm.cs
├── YolcuBilgileriForm.cs
├── TrenSaatleriForm.cs
├── HakkindaForm.cs
├── Kullanici.cs
├── VeriDeposu.cs
├── ArayuzIslemi.cs
├── Program.cs
├── Properties/
└── Resources/
tests/
├── RegressionTests.cs
└── Run-Tests.ps1
```

Formlara ait `.Designer.cs` ve `.resx` dosyaları aynı klasörde bulunur. `VeriDeposu.cs`, kalıcı veri işlemlerinin yanında bilet modeli ve doğrulama kurallarını içerir.

# Tren Bileti Rezervasyon Simülasyonu

C# WinForms ve .NET Framework 4.7.2 ile hazırlanmış eğitim projesi. Gerçek TCDD bilet satışı, ödeme veya canlı sefer sorgulaması yapmaz. Mevcut ekran tasarımları ve örnek istasyonlar korunmuştur.

## Çalıştırma

1. Visual Studio'da `.NET masaüstü geliştirme` iş yükünün ve .NET Framework 4.7.2 hedefleme paketinin kurulu olduğundan emin olun.
2. `WindowsFormsApp1.sln` dosyasını açın, derleyin ve F5 ile çalıştırın.
3. En az 3 karakterlik kullanıcı adı ve en az 8 karakterlik parola ile kayıt olun, ardından giriş yapın.

Harici NuGet paketi veya veritabanı sunucusu gerekmez. Çözüm/proje dosya adları ve kök ad alanı mevcut Visual Studio düzenini korumak için değiştirilmedi.

## Bilet alma

Tren, farklı kalkış ve varış istasyonları, tarih ve fiyat seçin. Bir koltuğa tıklayın (sağ tık → Koltuk Seç de kullanılabilir), yolcu bilgilerini doldurun. Telefonu başında 0 olmadan 10 rakam olarak girin.

Yeni bilet sarı renkle ve **Kaydedilmedi** durumuyla görünür. **KAYDET** tüm bekleyen biletleri kalıcı saklar. Yanlış seçilen, henüz kaydedilmemiş bileti listeden seçip **Bekleyen bileti kaldır** ile kaldırabilirsiniz. Kaydedilmemiş biletler varken pencere kapatılırsa kaydetme tercihi sorulur. Kaydedilmiş biletler iptal edilmez.

Her tren için aynı tarihte tek sefer varsayılır. Aynı tren + tarih + koltuk numarası yeniden kaydedilemez; güzergâh değiştirmek koltuğu boşaltmaz. Farklı tren veya tarihte aynı koltuk kullanılabilir. İki uygulama örneği aynı anda kaydetse de dosya kilidi altında tekrar kontrol yapılır. Birden fazla biletin kaydında herhangi bir çakışma varsa grubun tamamı kaydedilmeden bırakılır.

Kullanıcı yalnızca kendi biletlerini listede görür; koltuk doluluğu tüm kullanıcıları kapsar. Mevcut istasyon seçenekleri ve elle fiyat girme davranışı korunmuştur; gerçek tren güzergâhı/fiyat doğrulaması yapılmaz. Saat ekranı sabit örnek tarifeyi gösterir.

## Kalıcı veriler

Kayıtlar Windows kullanıcısının `%LOCALAPPDATA%\TcddTrenBiletAlma\veriler.xml` dosyasında tutulur. Uygulama kapanınca kaybolmaz ve kaynak kod klasörüne yazılmaz. Parolalar rastgele tuzla PBKDF2-SHA256 (210.000 iterasyon) özeti olarak saklanır. Yolcu bilgileri yerel XML dosyasında açık metindir; bu yerel demo bir sunucu tabanlı yetkilendirme sistemi değildir.

Her başarılı güncellemede önceki dosya `veriler.xml.bak` olarak korunur. Yazma önce geçici dosyada tamamlanır, sonra mevcut dosya değiştirilir. Okunamayan/bozuk dosyanın üzerine boş veri yazılmaz; hata gösterilir. Yedekten geri almak gerekirse uygulamayı kapatın, sorunlu dosyanın ayrıca kopyasını alın ve `.bak` dosyasının bir kopyasını `veriler.xml` adıyla geri yükleyin.

Eski sürüm kullanıcıları ve biletleri yalnızca bellekte tuttuğu için taşınabilecek eski kalıcı kayıt bulunmaz.

## Kod düzeni

- `GirisForm`: kayıt, doğrulama ve oturum başlangıcı.
- `AnaMenuForm`: ekranlar arası geçiş.
- `BiletAlForm`: koltuklar, bekleyen biletler ve kaydetme akışı.
- `YolcuBilgileriForm`: yolcu bilgisi girişi.
- `TrenSaatleriForm`: örnek tarifeden bekleme süresi hesabı.
- `HakkindaForm`: mevcut hakkında ekranı.
- `VeriDeposu`: kalıcı kayıt, parola doğrulama ve kayıt kilidi.
- `BiletKurallari`: alan ve rezervasyon doğrulaması.

Boş olay metotları, çift bağlanmış koltuk menüsü olayı ve kullanılmayan üçüncü taraf paket referansları kaldırıldı. Eski `packages` önbelleği projeye bağlı değildir ve Git tarafından dışlanır.

## Testler

PowerShell'de `./tests/Run-Tests.ps1` çalıştırın. Gerekirse `-MSBuildPath` ile MSBuild konumu belirtilebilir. Altı test grubu; yeniden açılışta kalıcılığı, parola doğrulamasını, hatalı alanları, tren/tarih ayrımını, iki ayrı işlemden çift rezervasyonu, toplu kaydın bütünlüğünü, dosya hatalarını ve formların yüklenmesini denetler. Veriler ve arayüz görüntüleri `TestResults` altında oluşturulur; gerçek kullanıcı verileri kullanılmaz.

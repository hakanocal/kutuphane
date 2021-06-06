# Kütüphane
### Kütüphanedeki kitaplar, kayıtlı üyeler ve ödünç verilen kitaplar gibi kütüphane işlemlerinin web sayfası üzerinden gerçekleştirilmesi

C#, ASP.NET, MsSQL 2012 ve Visual Studio 2012 kullanılarak hazırlandı


#### Web sitesinin sorunsuz bir şekilde çalışabilmesi için:
1. MsSQL kurulu olmalı 
2. Örnek verilerin bulunduğu veritabanı için: "veritabanı örneği/kutuphane.bak" dosyası, boş verilerin bulunduğu veritabanı için: "veritabanı örneği/script.sql" çalıştırılmalı
3. Web.config dosyasındaki "connectionString="Data Source=CASPER\SQLEXPRESS;" kısmına veritabanı server name yazılmalı
4. kitap_ayrinti.aspx dosyasında bulunan gridView'e ait SqlDataSource1'in connection String data source kısmına server name yazılmalı
5. uye.aspx dosyasında bulunan gridView'e ait SqlDataSource1'in connection String data source kısmına server name yazılmalı

#### Sayfalar:
Yetkili olmayan normal üyeler sadece Profil, kitaplar ve ödünç aldıklarım sayfasına erişebilir\
· PROFİL				: Profil güncelleme ve silme işemleri\
· KİTAPLAR			: Kütüphanede bulunan tüm kitapları görüntüleme, kitap araması yapabilme, ödünç alma isteği gönderme, Kütüphane yetkisisinin kitabı ödünç vermesi \
· ÖDÜNÇ ALDIKLARIM	: Giriş yapan kullanıcının ödünç aldığı kitaplar\
· ÜYELER				: Kütüphane yetkisisinin yeni üye veya yetkili ekleme, güncelleme ve silme işlemlerini gerçekleştirmesi\
· EMANETLER			: Ödünç verilen kitaplar, kitabın kime ve hangi tarihe kadar  ödünç verildiği, kitabı geri alındı olarak işaretleme ve stoğun otomatik artırılması\
· ÖDÜNÇ İSTEKLERİ		: Giriş yapan kütüphane yetkisisinin ödünç isteğini ret veya kabul etmesi

#### Giriş bilgileri
Admin Hesabı1	: TC: 12312312311 Şifre: 123 \
Admin Hesabı2	: TC: 12312312316 Şifre: 123\
Üye Hesabı1	: TC: 12312312317 Şifre: 123\
Üye Hesabı2	: TC: 12312312313 Şifre: 123\
Üye Hesabı3	: TC: 12312312314 Şifre: 123


#### Ekran görüntüleri:
|  Giriş yap        |   
|:-------------:|
| <img src="/screenshots/giris.jpg">     |


|  Anasayfa (kitaplar)         |   
|:-------------:|
| <img src="/screenshots/anasayfa.jpg">     |



|  Kitap ayrıntı        |   
|:-------------:|
| <img src="/screenshots/kitapayrinti.jpg">     |

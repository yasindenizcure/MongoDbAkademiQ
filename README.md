🚀 Foodu Restoran: ASP.NET Core MVC, MongoDB & MailKit Projesi 🍔
-------------------------
Bu çalışmada, NoSQL veritabanı mimarisi ile modern bir web uygulamasının nasıl uçtan uca entegre edilebileceğine odaklandım.
-------------------------
🏗️ Teknik Mimari & Katmanlı Yapı
-------------------------
Sorumlulukların net bir şekilde ayrılması (Separation of Concerns) prensibiyle projeyi 4 ana katman üzerine inşa ettim:

Entities: MongoDB koleksiyonları ile birebir eşleşen POCO sınıfları.

DTOs: Katmanlar arası veri transferini güvenli ve optimize hale getiren Result, Create ve Update nesneleri.

Services (Business): Tüm iş mantığının toplandığı ve MongoDB operasyonlarının (IMongoCollection) asenkron olarak yönetildiği katman.

WebUI: Yönetim paneli (Dashboard) ve kullanıcı arayüzünü içeren dinamik MVC katmanı.

MailKit & SMTP Entegrasyonu: Bülten abonelerine (Subscribers) toplu indirim kodları gönderimi, iletişim formu üzerinden gelen mesajların yönetimi ve dijital bildirim süreçlerini hayata geçirdim.

-------------------------
🛠️ Teknolojiler & Araçlar
-------------------------
Core: .NET 8 (ASP.NET Core MVC)

Veritabanı: MongoDB (NoSQL)

Email Servisi: MailKit & MimeKit (SMTP Protokolü)

Veri Eşleme: Mapster (Yüksek performanslı Mapping)

Yetkilendirme: Cookie tabanlı Claim Authorization süreçleri.

UI/UX: Bootstrap 5, FontAwesome ve JQuery ile güçlendirilmiş, mobil uyumlu (responsive) Dashboard tasarımı.

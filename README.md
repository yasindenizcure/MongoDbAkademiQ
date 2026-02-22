🚀 Foodu Restoran: ASP.NET Core MVC, MongoDB & MailKit Projesi 🍔
-------------------------

Bu çalışmada, NoSQL veritabanı mimarisi ile modern bir web uygulamasının nasıl uçtan uca entegre edilebileceğine odaklandım.

🏗️ Teknik Mimari & Katmanlı Yapı
-------------------------
Sorumlulukların net bir şekilde ayrılması (Separation of Concerns) prensibiyle projeyi 4 ana katman üzerine inşa ettim:

Entities: MongoDB koleksiyonları ile birebir eşleşen POCO sınıfları.

DTOs: Katmanlar arası veri transferini güvenli ve optimize hale getiren Result, Create ve Update nesneleri.

Services (Business): Tüm iş mantığının toplandığı ve MongoDB operasyonlarının (IMongoCollection) asenkron olarak yönetildiği katman.

WebUI: Yönetim paneli (Dashboard) ve kullanıcı arayüzünü içeren dinamik MVC katmanı.

MailKit & SMTP Entegrasyonu: Bülten abonelerine (Subscribers) toplu indirim kodları gönderimi, iletişim formu üzerinden gelen mesajların yönetimi ve dijital bildirim süreçlerini hayata geçirdim.

🛠️ Teknolojiler & Araçlar
-------------------------
Core: .NET 8 (ASP.NET Core MVC)

Veritabanı: MongoDB (NoSQL)

Email Servisi: MailKit & MimeKit (SMTP Protokolü)

Veri Eşleme: Mapster (Yüksek performanslı Mapping)

Yetkilendirme: Cookie tabanlı Claim Authorization süreçleri.

UI/UX: Bootstrap 5, FontAwesome ve JQuery ile güçlendirilmiş, mobil uyumlu (responsive) Dashboard tasarımı.
<img width="1842" height="922" alt="Ekran görüntüsü 2026-02-22 024959" src="https://github.com/user-attachments/assets/f7885499-90cc-4728-8ff2-5bd55732962d" />
<img width="1840" height="918" alt="Ekran görüntüsü 2026-02-22 025024" src="https://github.com/user-attachments/assets/87fc81dc-6cc7-4de8-83a4-d5a7dca832fb" />
<img width="1840" height="922" alt="3" src="https://github.com/user-attachments/assets/0a97ec78-7bfc-40ad-a9c6-75953fa3762d" />
<img width="1840" height="922" alt="4" src="https://github.com/user-attachments/assets/e486aebc-c4cf-4ead-b3a7-1d1eb077d0ed" />
<img width="1837" height="925" alt="5" src="https://github.com/user-attachments/assets/ac6efe4c-4c07-4a36-9dad-b46a5d673b7e" />
<img width="1838" height="921" alt="6" src="https://github.com/user-attachments/assets/cd7fe9c1-cbc4-4dd8-b250-43da7e8262f5" />
<img width="1841" height="923" alt="7" src="https://github.com/user-attachments/assets/fd02561c-a655-4915-8e71-991b73cf6d50" />
<img width="1835" height="923" alt="8" src="https://github.com/user-attachments/assets/1ecd5dca-7f35-476d-b9d4-0742afe84dee" />
<img width="1838" height="922" alt="9" src="https://github.com/user-attachments/assets/40ee8a7b-061d-42d7-a447-a00d04c80c86" />
<img width="1840" height="923" alt="10" src="https://github.com/user-attachments/assets/5b9cc8ce-a8aa-4cb4-818f-9d528aad51a3" />
<img width="1843" height="922" alt="11" src="https://github.com/user-attachments/assets/bfc55d61-ffb7-41eb-abf1-4a67c43627f7" />
<img width="1841" height="925" alt="12" src="https://github.com/user-attachments/assets/bf7f15a0-420f-402e-b3a5-dfbd30b72a89" />
<img width="1835" height="921" alt="13" src="https://github.com/user-attachments/assets/f448b61a-86fc-4198-9917-eb4031e1998a" />
<img width="1836" height="923" alt="14" src="https://github.com/user-attachments/assets/0ee85bf6-1aa8-457f-805c-c161ebb7cba5" />
<img width="762" height="928" alt="15" src="https://github.com/user-attachments/assets/1f62486b-f88c-40ed-ad8e-9639f13a0078" />
<img width="1858" height="915" alt="16" src="https://github.com/user-attachments/assets/8e866ba5-9ec9-4f8d-98c7-cf55980db98c" />
<img width="1855" height="922" alt="17" src="https://github.com/user-attachments/assets/990189f0-d36f-4c02-a3fc-a8ebb86cb093" />
<img width="1857" height="926" alt="18" src="https://github.com/user-attachments/assets/7c49d875-1c07-405e-bbb8-595f2a52cf29" />
<img width="1860" height="926" alt="19" src="https://github.com/user-attachments/assets/f5ef6bb0-4ea7-4960-9a6c-f6fc4c4d72f0" />
<img width="1567" height="572" alt="20" src="https://github.com/user-attachments/assets/d57df199-89ee-4491-8ab5-d4f6aef36072" />

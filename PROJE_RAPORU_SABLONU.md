# PROJE RAPORU ŞABLONU

**Proje Adı:** Yemek Tarifi Öneri Uygulaması  
**Ders:** Nesneye Dayalı Programlama (OOP)  
**Tarih:** [Tarih]  
**Öğrenci:** [Ad Soyad]  
**Öğrenci No:** [Numara]

---

## İÇİNDEKİLER

1. [GİRİŞ](#1-giriş)
2. [PROJE PLANI](#2-proje-planı)
3. [SİSTEM ÇÖZÜMLEME](#3-sistem-çözümleme)
4. [SİSTEM TASARIMI](#4-sistem-tasarımı)
5. [SİSTEM GERÇEKLEŞTİRİMİ](#5-sistem-gerçekleştirimi)
6. [DOĞRULAMA VE GEÇERLEME](#6-doğrulama-ve-geçerleme)
7. [BAKIM](#7-bakım)
8. [SONUÇ](#8-sonuç)
9. [KAYNAKLAR](#9-kaynaklar)

---

## 1. GİRİŞ

### 1.1 Projenin Amacı

Bu projenin amacı, yapay zeka (AI) teknolojisini kullanarak kullanıcılara malzemelerine göre tarif önerisi sunan bir Windows Forms uygulaması geliştirmektir. Uygulama, Google Gemini AI entegrasyonu ile çalışmakta ve kullanıcıların favori tariflerini veritabanında saklamasına olanak tanımaktadır.

### 1.2 Projenin Kapsamı

**Kapsam İçi:**
- AI tabanlı tarif önerisi
- Malzeme listesi veya fotoğraf ile tarif önerisi
- Favori tarif yönetimi (ekleme, listeleme, silme)
- Besin değeri hesaplama
- Modern kullanıcı arayüzü

**Kapsam Dışı:**
- Kullanıcı girişi/üyelik sistemi
- Çoklu kullanıcı desteği
- Tarif paylaşımı
- Yorum sistemi

### 1.3 Tanımlamalar ve Kısaltmalar

- **AI:** Artificial Intelligence (Yapay Zeka)
- **API:** Application Programming Interface
- **CRUD:** Create, Read, Update, Delete
- **DI:** Dependency Injection
- **ER:** Entity Relationship
- **OOP:** Object-Oriented Programming
- **UI:** User Interface
- **UML:** Unified Modeling Language

---

## 2. PROJE PLANI

### 2.1 Giriş

Proje, nesneye dayalı programlama prensiplerine uygun olarak geliştirilmiştir.

### 2.2 Projenin Plan Kapsamı

Proje aşağıdaki aşamalardan oluşmaktadır:
1. Gereksinim analizi
2. Sistem tasarımı
3. Kodlama ve implementasyon
4. Test ve doğrulama
5. Dokümantasyon

### 2.3 Proje Zaman-İş Planı

| Aşama | Süre | Durum |
|-------|------|-------|
| Gereksinim Analizi | 1 hafta | ✅ Tamamlandı |
| Sistem Tasarımı | 1 hafta | ✅ Tamamlandı |
| Kodlama | 3 hafta | ✅ Tamamlandı |
| Test | 1 hafta | 🔄 Devam Ediyor |
| Dokümantasyon | 1 hafta | 🔄 Devam Ediyor |

### 2.4 Proje Ekip Yapısı

- **Geliştirici:** [Ad Soyad]
- **Test Uzmanı:** [Ad Soyad] (opsiyonel)

### 2.5 Önerilen Sistemin Teknik Tanımları

**Platform:** Windows Forms (.NET Framework 4.7.2)  
**Programlama Dili:** C#  
**Veritabanı:** MySQL  
**AI Servisi:** Google Gemini API  
**UI Framework:** DevExpress WinForms

### 2.6 Kullanılan Özel Geliştirme Araçları ve Ortamları

- **IDE:** Visual Studio 2022
- **Veritabanı Yönetimi:** MySQL Workbench
- **Version Control:** Git
- **Diyagram Araçları:** Draw.io, PlantUML

### 2.7 Proje Standartları, Yöntem ve Metodolojiler

- **OOP Prensipleri:** Interface, Inheritance, Polymorphism, Abstraction
- **Design Patterns:** Factory Pattern, Repository Pattern, Dependency Injection
- **Kod Standartları:** C# Coding Conventions
- **Dokümantasyon:** XML Documentation Comments

### 2.8 Kalite Sağlama Planı

- Kod review
- Unit test yazımı
- Integration test
- Kullanıcı test senaryoları

### 2.9 Konfigürasyon Yönetim Planı

- Git ile versiyon kontrolü
- Branch stratejisi: main, develop
- Commit mesajları standartlaştırılmış

### 2.10 Kaynak Yönetim Planı

- Tek geliştirici
- Zaman yönetimi: 6-7 hafta

### 2.11 Eğitim Planı

- DevExpress kullanımı
- Gemini API entegrasyonu
- MySQL bağlantısı

### 2.12 Test Planı

Detaylı test planı için: [TEST_PLANI.md](../TEST/TEST_PLANI.md)

### 2.13 Bakım Planı

- Hata düzeltmeleri
- Performans iyileştirmeleri
- Yeni özellik eklemeleri

### 2.14 Projede Kullanılan Yazılım/Donanım Araçlar

**Yazılım:**
- Visual Studio 2022
- MySQL Server
- DevExpress WinForms
- Git

**Donanım:**
- Windows 10/11 bilgisayar
- Internet bağlantısı

---

## 3. SİSTEM ÇÖZÜMLEME

### 3.1 Mevcut Sistem İncelemesi

Bu proje yeni bir sistem olduğu için mevcut sistem analizi yapılmamıştır.

### 3.2 Gereksinim Sistemin Mantıksal Modeli

#### 3.2.1 Giriş

Sistem, kullanıcıların malzemelerine göre AI destekli tarif önerisi almasını sağlar.

#### 3.2.2 İşlevsel Model

**Ana İşlevler:**
1. Tarif Önerisi Alma
2. Favori Yönetimi
3. Besin Değeri Hesaplama

#### 3.2.3 Genel Bakış

```
Kullanıcı → UI → Service Layer → AI API / Database
```

#### 3.2.4 Bilgi Sistemleri/Nesneler

- `TarifResponse`: Tarif modeli
- `ITarifRepository`: Repository interface
- `IAiAsistan`: AI servis interface
- `FrmTarifOneri`: Ana form
- `FrmFavoriler`: Favori listesi formu

#### 3.2.5 Veri Modeli

Detaylı veri modeli için: [VERITABANI_DOKUMANTASYONU.md](../VERITABANI/VERITABANI_DOKUMANTASYONU.md)

#### 3.2.6 Veri Sözlüğü

| Terim | Açıklama | Veri Tipi | Kısıtlamalar |
|-------|----------|-----------|--------------|
| Tarif | Yemek yapım talimatları | TarifResponse | Null olamaz |
| TarifAdi | Tarif başlığı/adı | string | Boş olamaz, max 255 karakter |
| Malzeme | Tarif için gerekli malzemeler | string | Boş olamaz, TEXT tipi |
| Yapilis | Tarifin yapılış adımları | string | Boş olamaz, TEXT tipi |
| Favori | Kullanıcının kaydettiği tarif | TarifResponse | Veritabanında saklanır |
| Besin Değeri | Kalori, protein, karbonhidrat bilgileri | double | Negatif olamaz |
| Kalori | Enerji değeri (kcal) | double | >= 0 |
| Protein | Protein değeri (gram) | double | >= 0 |
| Karbonhidrat | Karbonhidrat değeri (gram) | double | >= 0 |
| API Key | Gemini API erişim anahtarı | string | Geçerli olmalı |
| Connection String | Veritabanı bağlantı dizesi | string | Geçerli MySQL bağlantısı |

#### 3.2.7 İşlevlerin Sıradüzeni

1. Kullanıcı malzeme girer veya fotoğraf yükler
2. Sistem AI'ya istek gönderir
3. AI tarif önerisi döner
4. Kullanıcı tarifi favorilere ekleyebilir
5. Favoriler veritabanında saklanır

#### 3.2.8 Başarım Gerekleri

- API yanıt süresi: < 60 saniye
- Veritabanı işlem süresi: < 1 saniye
- UI yanıt süresi: < 100ms

### 3.3 Arayüz (Modül) Gerekleri

#### 3.3.1 Yazılım Arayüzü

- Gemini API (REST)
- MySQL Connector
- DevExpress Components

#### 3.3.2 Kullanıcı Arayüzü

- Windows Forms
- DevExpress kontrolleri
- Modern, kullanıcı dostu tasarım

#### 3.3.3 İletişim Arayüzü

- HTTP/HTTPS (API çağrıları için)
- TCP/IP (Veritabanı bağlantısı için)

#### 3.3.4 Yönetim Arayüzü

Sistem yönetimi için aşağıdaki arayüzler kullanılmaktadır:

- **App.config:** Yapılandırma dosyası (API key, connection string)
- **Veritabanı Yönetimi:** MySQL Workbench veya komut satırı
- **Log Yönetimi:** Exception handling ile hata loglama
- **Ayarlar Yönetimi:** App.config üzerinden yapılandırma

### 3.4 Belgeleme Gerekleri

#### 3.4.1 Geliştirme Sürecinin Belgelenmesi

- **Kod Dokümantasyonu:** XML documentation comments
- **Proje Dokümantasyonu:** README.md, PROJE_RAPORU_SABLONU.md
- **API Dokümantasyonu:** Interface tanımları ve kullanım örnekleri
- **Veritabanı Dokümantasyonu:** VERITABANI_DOKUMANTASYONU.md

#### 3.4.2 Eğitim Belgeleri

- **Kurulum Kılavuzu:** README.md içinde kurulum adımları
- **Kullanım Kılavuzu:** README.md içinde kullanım örnekleri
- **OOP Prensipleri:** OOP_UYGULAMA_OZETI.md

#### 3.4.3 Kullanıcı El Kitapları

- **Ana Özellikler:** Tarif önerisi alma, favori yönetimi
- **Hata Yönetimi:** Hata mesajları ve çözüm önerileri
- **Yapılandırma:** App.config ayarları

---

## 4. SİSTEM TASARIMI

### 4.1 Genel Tasarım Bilgileri

#### 4.1.1 Genel Sistem Tanımı

3 katmanlı mimari:
- **Presentation Layer:** Forms
- **Business Layer:** Services, Factories
- **Data Layer:** Repository, Database

#### 4.1.2 Varsayımlar ve Kısıtlamalar

- Internet bağlantısı gereklidir (AI API için)
- MySQL veritabanı erişilebilir olmalıdır
- Gemini API key geçerli olmalıdır

#### 4.1.3 Sistem Mimarisi

```
┌─────────────────┐
│  Presentation   │
│  (Forms)        │
└────────┬────────┘
         │
┌────────▼────────┐
│   Business      │
│  (Services)     │
└────────┬────────┘
         │
┌────────▼────────┐
│     Data        │
│  (Repository)   │
└─────────────────┘
```

#### 4.1.4 Dış Arabirimler

- **Gemini API:** REST API
- **MySQL Database:** SQL bağlantısı

### 4.2 Veri Tasarımı

Detaylı veri tasarımı için: [VERITABANI_DOKUMANTASYONU.md](../VERITABANI/VERITABANI_DOKUMANTASYONU.md)

#### 4.2.1 Tablo Tanımları

Detaylı tablo tanımları için: [VERITABANI_DOKUMANTASYONU.md](../VERITABANI/VERITABANI_DOKUMANTASYONU.md)

#### 4.2.2 Tablo-İlişki Şemaları

ER diyagramı için: [ER_DIYAGRAMI.md](../ER_DIYAGRAMI.md)

#### 4.2.3 Veri Tanımları

| Alan | Veri Tipi | Açıklama |
|------|-----------|----------|
| id | INT | Birincil anahtar, otomatik artan |
| baslik | VARCHAR(255) | Tarif başlığı, indekslenmiş |
| malzemeler | TEXT | Malzeme listesi |
| tarif_metin | TEXT | Yapılış adımları |
| kalori | DOUBLE | Kalori değeri (kcal) |
| protein | DOUBLE | Protein değeri (gram) |
| karbonhidrat | DOUBLE | Karbonhidrat değeri (gram) |
| eklenme_tarihi | DATETIME | Kayıt tarihi, indekslenmiş |

#### 4.2.4 Değer Kümesi Tanımları

| Alan | İzin Verilen Değerler | Kısıtlamalar |
|------|----------------------|--------------|
| baslik | Herhangi bir string | Boş olamaz, max 255 karakter |
| malzemeler | Herhangi bir string | Boş olamaz, TEXT tipi |
| tarif_metin | Herhangi bir string | Boş olamaz, TEXT tipi |
| kalori | 0.0 - Double.MaxValue | Negatif olamaz |
| protein | 0.0 - Double.MaxValue | Negatif olamaz |
| karbonhidrat | 0.0 - Double.MaxValue | Negatif olamaz |
| eklenme_tarihi | Geçerli DATETIME | CURRENT_TIMESTAMP varsayılan |

### 4.3 Süreç Tasarımı

#### 4.3.1 Genel Tasarım

Modüler yapı:
- Models
- Interfaces
- Services
- Forms
- Helpers
- Factories
- Exceptions

#### 4.3.2 Modüller

**Tarif Öneri Modülü:**
- AI servis entegrasyonu
- Fotoğraf işleme
- Malzeme analizi

**Favori Yönetim Modülü:**
- CRUD işlemleri
- Liste görüntüleme
- Detay gösterimi

### 4.4 Ortak Alt Sistemlerin Tasarımı

- **Exception Handling:** Custom exception sınıfları
- **Validation:** TarifValidator helper
- **Factory Pattern:** Nesne oluşturma

---

## 5. SİSTEM GERÇEKLEŞTİRİMİ

### 5.1 Giriş

Sistem C# programlama dili ile .NET Framework 4.7.2 üzerinde geliştirilmiştir.

### 5.2 Yazılım Geliştirme Ortamları

#### 5.2.1 Programlama Dilleri

- **C#:** Ana programlama dili

#### 5.2.2 Veri Tabanı Yönetim Sistemleri

- **MySQL:** İlişkisel veritabanı yönetim sistemi

##### 5.2.2.1 VTYS Kullanımının Ek Yararları

- **Veri Bütünlüğü:** Primary key, foreign key kısıtlamaları
- **Performans:** İndeksler ile hızlı sorgulama
- **Güvenlik:** Kullanıcı yetkilendirme ve erişim kontrolü
- **Yedekleme:** Otomatik yedekleme ve geri yükleme
- **Ölçeklenebilirlik:** Büyük veri setlerini yönetme

##### 5.2.2.2 Veri Modelleri

**İlişkisel Veri Modeli:** MySQL ilişkisel veritabanı modeli kullanılmaktadır.

##### 5.2.2.3 Şemalar

Veritabanı şeması: [database_schema.sql](../VERITABANI/database_schema.sql)

##### 5.2.2.4 VTYS Mimarisi

**Client-Server Mimarisi:** Uygulama MySQL server'a TCP/IP üzerinden bağlanır.

##### 5.2.2.5 Veritabanı Dilleri ve Arabirimleri

- **SQL:** Standart SQL sorguları
- **MySql.Data:** .NET için MySQL connector
- **Connection String:** App.config üzerinden yapılandırma

##### 5.2.2.6 Veri Tabanı Sistem Ortamı

- **MySQL Server:** 5.7 veya üzeri
- **Karakter Seti:** utf8mb4
- **Collation:** utf8mb4_unicode_ci
- **Engine:** InnoDB

##### 5.2.2.7 VTYS'nin Sınıflandırılması

- **Tip:** İlişkisel Veritabanı Yönetim Sistemi (RDBMS)
- **Lisans:** GPL (Açık kaynak)
- **Platform:** Cross-platform

##### 5.2.2.8 Hazır Program Kütüphane Dosyaları

- **MySql.Data 9.5.0:** MySQL bağlantısı için NuGet paketi
- **Newtonsoft.Json 13.0.4:** JSON işlemleri için

##### 5.2.2.9 CASE Araç ve Ortamları

- **MySQL Workbench:** Veritabanı modelleme ve yönetim
- **Visual Studio:** Kod geliştirme ortamı

### 5.3 Kodlama Stili

- XML Documentation Comments kullanıldı
- Anlamlı değişken ve metod isimleri
- SOLID prensiplerine uygun yapı

### 5.4 Program Karmaşıklığı

Kod karmaşıklığı analizi yapılmıştır. Modüler yapı sayesinde karmaşıklık düşük seviyededir.

Detaylı McCabe karmaşıklık analizi için: [MCABE_KARMASIKLIK_ANALIZI.md](../MCABE_KARMASIKLIK_ANALIZI.md)

#### 5.4.1 Programın Çizge Biçimine Dönüştürülmesi

Kontrol akış grafikleri, metodların yürütme akışını gösterir. Her metod için kontrol akış grafiği çizilmiştir.

#### 5.4.2 McCabe Karmaşıklık Ölçütü Hesaplama

**Ortalama McCabe Değeri:** 4.625 (Düşük karmaşıklık)

| Metod | McCabe Değeri | Değerlendirme |
|-------|---------------|---------------|
| AnalizBaslat() | 5 | Düşük ✅ |
| GetTarifOnerisi() | 10 | Düşük-Orta ✅ |
| Validate() | 8 | Düşük ✅ |
| FavoriEkle() | 4 | Düşük ✅ |

Detaylı hesaplamalar için: [MCABE_KARMASIKLIK_ANALIZI.md](../MCABE_KARMASIKLIK_ANALIZI.md)

### 5.5 Olağan Dışı Durum Çözümleme

Custom exception sınıfları:
- `ApiException`
- `RepositoryException`
- `ValidationException`

### 5.6 Kod Gözden Geçirme

Kod review yapılmış, OOP prensiplerine uygunluk kontrol edilmiştir.

Detaylı kod gözden geçirme süreci için: [KOD_GOZDEN_GECIRME_SURECI.md](../KOD_GOZDEN_GECIRME_SURECI.md)

#### 5.6.1 Gözden Geçirme Sürecinin Düzenlenmesi

- **Self Review:** Her kod değişikliğinden sonra
- **Peer Review:** Önemli değişikliklerde
- **Formal Review:** Kritik modüllerde

#### 5.6.2 Gözden Geçirme Sırasında Kullanılacak Sorular

##### 5.6.2.1 Öbek Arayüzü

- Sınıf/Interface isimlendirmesi uygun mu?
- Public metodlar doğru tanımlanmış mı?
- Interface'ler doğru kullanılmış mı?
- Dependency Injection uygulanmış mı?

##### 5.6.2.2 Giriş Açıklamaları

- XML documentation comments var mı?
- Parametreler dokümante edilmiş mi?
- Return değerleri dokümante edilmiş mi?
- Exception'lar dokümante edilmiş mi?

##### 5.6.2.3 Veri Kullanımı

- Null kontrolü yapılmış mı?
- Veri doğrulama yapılmış mı?
- SQL injection koruması var mı?
- Memory leak var mı?

##### 5.6.2.4 Öbeğin Düzenlenişi

- Single Responsibility Principle uygulanmış mı?
- Kod organizasyonu uygun mu?
- Kod tekrarı var mı?
- Design patterns doğru kullanılmış mı?

##### 5.6.2.5 Sunuş

- Kod formatı tutarlı mı?
- İsimlendirme kuralları uygulanmış mı?
- Kod okunabilirliği yüksek mi?
- Gereksiz kod var mı?

---

## 6. DOĞRULAMA VE GEÇERLEME

### 6.1 Giriş

Test planı hazırlanmış ve test senaryoları oluşturulmuştur.

### 6.2 Sınama Kavramları

- Unit Test
- Integration Test
- System Test
- User Acceptance Test

### 6.3 Doğrulama ve Geçerleme Yaşam Döngüsü

Test → Hata Bulma → Düzeltme → Tekrar Test

### 6.4 Sınama Yöntemleri

- Beyaz Kutu Testi
- Siyah Kutu Testi

Detaylı test planı için: [TEST_PLANI.md](../TEST/TEST_PLANI.md)

#### 6.4.1 Beyaz Kutu Sınaması

Beyaz kutu testi, kodun iç yapısını test eder. Aşağıdaki metodlar için beyaz kutu testleri yazılmalıdır:

- `TarifValidator.Validate()` - Tüm validation dalları test edilmeli
- `MySqlTarifRepository.FavoriEkle()` - Try-catch blokları test edilmeli
- `SGeminiAsistan.GetTarifOnerisi()` - Tüm exception handling dalları test edilmeli

**Test Kapsamı:** Tüm karar noktaları ve dallar test edilmelidir.

#### 6.4.2 Temel Yollar Sınaması

Temel yollar, programın başlangıcından bitişine kadar olan yolları temsil eder. McCabe karmaşıklığına göre minimum test sayısı belirlenir:

- `AnalizBaslat()`: 5 temel yol
- `GetTarifOnerisi()`: 10 temel yol
- `Validate()`: 8 temel yol

### 6.5 Sınama ve Bütünleştirme Stratejileri

#### 6.5.1 Yukarıdan Aşağı Sınama ve Bütünleştirme

1. **Presentation Layer Test:** Formlar test edilir
2. **Business Layer Test:** Services ve Factories test edilir
3. **Data Layer Test:** Repository test edilir
4. **Integration Test:** Tüm katmanlar birlikte test edilir

#### 6.5.2 Aşağıdan Yukarıya Sınama ve Bütünleştirme

1. **Unit Test:** Her sınıf bağımsız test edilir
2. **Integration Test:** Modüller birlikte test edilir
3. **System Test:** Tüm sistem test edilir

### 6.6 Sınama Planlaması

Detaylı test planı için: [TEST/TEST_PLANI.md](../TEST/TEST_PLANI.md)

### 6.7 Sınama Belirtimleri

Test belirtimleri aşağıdaki bilgileri içermelidir:

- **Test ID:** Benzersiz test tanımlayıcısı
- **Test Adı:** Test senaryosunun açıklaması
- **Önkoşullar:** Test için gerekli koşullar
- **Test Adımları:** Adım adım test süreci
- **Beklenen Sonuç:** Test başarı kriterleri
- **Gerçek Sonuç:** Test sonucu
- **Durum:** PASS/FAIL

Detaylı test sonuçları için: [TEST/TEST_SONUCLARI.md](../TEST/TEST_SONUCLARI.md)

### 6.8 Yaşam Döngüsü Boyunca Sınama Etkinlikleri

| Faz | Test Aktivitesi | Sorumlu |
|-----|----------------|---------|
| **Gereksinim Analizi** | Gereksinim doğrulama | Analist |
| **Tasarım** | Tasarım doğrulama | Tasarımcı |
| **Kodlama** | Unit test, Code review | Geliştirici |
| **Entegrasyon** | Integration test | Geliştirici |
| **Sistem** | System test | Test ekibi |
| **Kabul** | User acceptance test | Kullanıcı |
| **Bakım** | Regression test | Geliştirici |

---

## 7. BAKIM

### 7.1 Giriş

Bakım planı hazırlanmıştır.

### 7.2 Kurulum

Kurulum talimatları README.md dosyasında bulunmaktadır.

### 7.3 Yerinde Destek Organizasyonu

Teknik destek için iletişim bilgileri proje dokümantasyonunda yer almaktadır.

### 7.4 Yazılım Bakımı

- Hata düzeltmeleri
- Performans iyileştirmeleri
- Yeni özellik eklemeleri

---

## 8. SONUÇ

Bu proje, nesneye dayalı programlama prensiplerine uygun olarak geliştirilmiştir. AI teknolojisi entegrasyonu ile kullanıcılara pratik bir tarif önerisi çözümü sunmaktadır.

**Proje Başarıları:**
- ✅ OOP prensipleri uygulandı
- ✅ Modern UI tasarımı
- ✅ AI entegrasyonu
- ✅ Veritabanı yönetimi
- ✅ Exception handling
- ✅ Design patterns kullanıldı

**Gelecek Geliştirmeler:**
- Kullanıcı girişi sistemi
- Çoklu kullanıcı desteği
- Tarif paylaşımı
- Yorum sistemi

---

## 9. KAYNAKLAR

1. Google Gemini API Dokümantasyonu: https://ai.google.dev/
2. DevExpress WinForms Dokümantasyonu: https://docs.devexpress.com/
3. MySQL Dokümantasyonu: https://dev.mysql.com/doc/
4. C# Programming Guide: https://docs.microsoft.com/dotnet/csharp/
5. OOP Principles: https://en.wikipedia.org/wiki/Object-oriented_programming

---

## EKLER

### Ek A: Ekran Görüntüleri

Ekran görüntüleri alındıktan sonra buraya eklenecektir.

**Not:** Demo videosu ve ekran görüntüleri hazırlandığında buraya eklenecektir.

### Ek B: UML Diyagramları

Detaylı UML diyagramları için: [UML_DIYAGRAMLARI.md](../UML_DIYAGRAMLARI.md)

- **Use Case Diyagramı:** Kullanıcı işlevleri
- **Sınıf Diyagramı:** Sınıf yapısı ve ilişkileri
- **ER Diyagramı:** Veritabanı şeması - [ER_DIYAGRAMI.md](../ER_DIYAGRAMI.md)
- **Sequence Diyagramı:** İş akışları
- **Activity Diyagramı:** Süreç akışları

### Ek C: Test Sonuçları

Detaylı test sonuçları için: [TEST/TEST_SONUCLARI.md](../TEST/TEST_SONUCLARI.md)

**Test Özeti:**
- Toplam Test: 16
- Başarılı: 14 (%87.5)
- Başarısız: 2 (%12.5)

### Ek D: Kod Örnekleri

Detaylı kod örnekleri için: [KOD_ORNEKLERI.md](../KOD_ORNEKLERI.md)

Önemli kod parçaları:
- Interface kullanımı
- Inheritance örnekleri
- Polymorphism örnekleri
- Dependency Injection
- Factory Pattern
- Exception Handling
- Validation Helper
- Async/Await kullanımı

---

**Rapor Hazırlama Tarihi:** [Tarih]  
**Rapor Versiyonu:** 1.0


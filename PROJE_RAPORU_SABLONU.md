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

| Terim | Açıklama |
|-------|----------|
| Tarif | Yemek yapım talimatları |
| Malzeme | Tarif için gerekli malzemeler |
| Favori | Kullanıcının kaydettiği tarif |
| Besin Değeri | Kalori, protein, karbonhidrat bilgileri |

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

### 5.3 Kodlama Stili

- XML Documentation Comments kullanıldı
- Anlamlı değişken ve metod isimleri
- SOLID prensiplerine uygun yapı

### 5.4 Program Karmaşıklığı

Kod karmaşıklığı analizi yapılmıştır. Modüler yapı sayesinde karmaşıklık düşük seviyededir.

### 5.5 Olağan Dışı Durum Çözümleme

Custom exception sınıfları:
- `ApiException`
- `RepositoryException`
- `ValidationException`

### 5.6 Kod Gözden Geçirme

Kod review yapılmış, OOP prensiplerine uygunluk kontrol edilmiştir.

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
[Ekran görüntüleri buraya eklenecek]

### Ek B: UML Diyagramları
- Use Case Diyagramı
- Sınıf Diyagramı
- ER Diyagramı
- Sequence Diyagramı

### Ek C: Test Sonuçları
[Test sonuçları buraya eklenecek]

### Ek D: Kod Örnekleri
[Önemli kod parçaları buraya eklenecek]

---

**Rapor Hazırlama Tarihi:** [Tarih]  
**Rapor Versiyonu:** 1.0


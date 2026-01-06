# PROJE MALİYET KESTİRİM DOKÜMANI

**Proje Adı:** Yemek Tarifi Öneri Uygulaması  
**Tarih:** 2025-01-XX  
**Hazırlayan:** [Ad Soyad]  
**Öğrenci No:** [Numara]

---

## 1. ÖLÇÜM PARAMETRELERİ

### 1.1 Fonksiyonel Nokta Analizi

| Ölçüm Parametresi | Sayı | Ağırlık Faktörü | Toplam |
|-------------------|------|----------------|--------|
| Kullanıcı Girdi Sayısı | 3 | 4 | 12 |
| Kullanıcı Çıktı Sayısı | 4 | 5 | 20 |
| Kullanıcı Sorgu Sayısı | 3 | 4 | 12 |
| Veri Tabanındaki Tablo Sayısı | 1 | 10 | 10 |
| Arayüz Sayısı | 2 | 7 | 14 |
| **Ana İşlev Nokta Sayısı (AİN Değeri)** | - | - | **68** |

### 1.2 Parametre Açıklamaları

#### Kullanıcı Girdi Sayısı (3)
1. **Malzeme Listesi Girişi:** Kullanıcının malzeme listesini yazması
2. **Fotoğraf Seçimi:** Kullanıcının fotoğraf dosyası seçmesi
3. **Favori İşlemleri:** Favori ekleme/silme işlemleri için kullanıcı girdileri

#### Kullanıcı Çıktı Sayısı (4)
1. **Tarif Adı:** AI'dan gelen tarif başlığı
2. **Malzemeler Listesi:** Tarif için gerekli malzemeler
3. **Yapılış Adımları:** Tarifin yapılış talimatları
4. **Besin Değerleri:** Kalori, protein, karbonhidrat bilgileri (tek bir çıktı olarak sayılmıştır)

#### Kullanıcı Sorgu Sayısı (3)
1. **Tarif Önerisi Sorgusu:** AI servisine tarif önerisi için yapılan sorgu
2. **Favori Listesi Sorgusu:** Veritabanından tüm favorileri getiren sorgu
3. **Favori Detay Sorgusu:** Belirli bir favori tarifin detaylarını getiren sorgu

#### Veri Tabanındaki Tablo Sayısı (1)
- **tarif_favori:** Favori tarifleri saklayan ana tablo

#### Arayüz Sayısı (2)
1. **FrmTarifOneri:** Ana tarif öneri formu
2. **FrmFavoriler:** Favori tarifler listesi formu

---

## 2. TEKNİK KARMAŞIKLIK FAKTÖRÜ (TKF)

### 2.1 Teknik Karmaşıklık Soruları

| # | Soru | Puan | Açıklama |
|---|------|------|----------|
| 1 | Uygulama, güvenilir yedekleme ve kurtarma gerektiriyor mu? | 2 | Veritabanı yedekleme mekanizması var ama otomatik değil |
| 2 | Veri iletişimi gerekiyor mu? | 5 | Gemini API ile HTTP/HTTPS iletişimi zorunlu |
| 3 | Dağıtık işlem işlevleri var mı? | 0 | Tek bir uygulama, dağıtık değil |
| 4 | Performans kritik mi? | 2 | API yanıt süresi önemli ama kritik değil (<60 sn) |
| 5 | Sistem mevcut ve ağır yükü olan bir işletim ortamında mı çalışacak? | 1 | Windows Forms, tek kullanıcı, düşük yük |
| 6 | Sistem, çevrim içi veri girişi gerektiriyor mu? | 4 | AI API'ye çevrim içi istek gönderiliyor |
| 7 | Çevrim içi veri girişi, bir ara işlem için birden çok ekran gerektiriyor mu? | 1 | Tek ekranda işlem tamamlanıyor |
| 8 | Ana kütükler çevrim-içi olarak mı günleniyor? | 3 | Favori tarifler veritabanında çevrim içi güncelleniyor |
| 9 | Girdiler, çıktılar, kütükler ya da sorgular karmaşık mı? | 2 | AI API JSON yanıtı işleniyor, orta karmaşıklık |
| 10 | İçsel işlemler karmaşık mı? | 3 | AI entegrasyonu, fotoğraf işleme, JSON parsing |
| 11 | Tasarlanacak kod, yeniden kullanılabilir mi olacak? | 4 | Interface'ler, Factory Pattern, Repository Pattern kullanılıyor |
| 12 | Dönüştürme ve kurulum, tasarımda dikkate alınacak mı? | 2 | Basit kurulum, App.config yapılandırması |
| 13 | Sistem birden çok yerde yerleşik farklı kurumlar için mi geliştiriliyor? | 0 | Tek kullanıcı, tek kurum |
| 14 | Tasarlanan uygulama, kolay kullanılabilir ve kullanıcı tarafından kolayca değiştirilebilir mi olacak? | 3 | Modern UI, kullanıcı dostu, yapılandırma dosyası ile ayarlanabilir |
| **TOPLAM (TKF)** | - | **31** | - |

### 2.2 Puanlama Açıklamaları

- **0:** Hiçbir Etkisi Yok
- **1:** Çok Az etkisi var
- **2:** Etkisi Var
- **3:** Ortalama Etkisi Var
- **4:** Önemli Etkisi Var
- **5:** Mutlaka Olmalı, Kaçınılamaz

---

## 3. HESAPLAMALAR

### 3.1 İşlev Noktası (İN) Hesaplama

**Formül:** İN = AİN × (0.65 + 0.01 × TKF)

**Hesaplama:**
- AİN = 68
- TKF = 31
- İN = 68 × (0.65 + 0.01 × 31)
- İN = 68 × (0.65 + 0.31)
- İN = 68 × 0.96
- **İN = 65.28**

### 3.2 Tahmini Satır Sayısı

**Formül:** Satır Sayısı = İN × 30

**Hesaplama:**
- Satır Sayısı = 65.28 × 30
- **Satır Sayısı = 1,958 satır**

### 3.3 Gerçek Satır Sayısı (Kontrol)

Projede mevcut kod satır sayısı yaklaşık olarak:
- C# kaynak kod dosyaları: ~1,500-2,000 satır
- XML/Designer dosyaları: ~500 satır
- SQL dosyaları: ~50 satır
- **Toplam: ~2,000-2,500 satır**

**Not:** Hesaplanan değer (1,958 satır) gerçek değerle uyumludur.

---

## 4. PROJE BÜYÜKLÜĞÜ DEĞERLENDİRMESİ

### 4.1 Proje Kategorisi

| Kriter | Değer | Kategori |
|--------|-------|----------|
| İşlev Noktası (İN) | 65.28 | **Orta Ölçekli Proje** |
| Satır Sayısı | ~2,000 | **Küçük-Orta Ölçekli** |
| Geliştirme Süresi | 6-7 hafta | **Orta Süreli** |

### 4.2 Proje Karmaşıklığı

- **Düşük Karmaşıklık:** ✅
  - Tek kullanıcı sistemi
  - Basit veritabanı yapısı (1 tablo)
  - Standart Windows Forms uygulaması

- **Orta Karmaşıklık:** ✅
  - AI API entegrasyonu
  - Async/await programlama
  - OOP prensipleri uygulaması
  - Design patterns kullanımı

- **Yüksek Karmaşıklık:** ❌
  - Dağıtık sistem değil
  - Çoklu kullanıcı desteği yok
  - Gerçek zamanlı işlem yok

---

## 5. KAYNAK TAHMİNİ

### 5.1 Geliştirme Süresi

| Faz | Süre | Açıklama |
|-----|------|----------|
| Gereksinim Analizi | 1 hafta | İşlevsel ve işlevsel olmayan gereksinimler |
| Sistem Tasarımı | 1 hafta | UML diyagramları, veritabanı tasarımı |
| Kodlama | 3 hafta | OOP prensipleri ile kod geliştirme |
| Test | 1 hafta | Unit test, integration test, sistem testi |
| Dokümantasyon | 1 hafta | Proje raporu, kullanıcı kılavuzu |
| **TOPLAM** | **7 hafta** | - |

### 5.2 Geliştirici Sayısı

- **1 Geliştirici** (Tek kişilik proje)

### 5.3 Tahmini İş Yükü

- **Toplam İş Saati:** ~280 saat (7 hafta × 40 saat/hafta)
- **Günlük Ortalama:** ~8 saat/gün
- **Haftalık Ortalama:** ~40 saat/hafta

---

## 6. RİSK ANALİZİ

### 6.1 Teknik Riskler

| Risk | Olasılık | Etki | Önlem |
|------|----------|------|-------|
| API Key geçersizliği | Orta | Yüksek | App.config'de doğrulama |
| Veritabanı bağlantı hatası | Düşük | Orta | Exception handling |
| AI API yanıt gecikmesi | Orta | Orta | Timeout ayarları |
| Fotoğraf format uyumsuzluğu | Düşük | Düşük | Validation kontrolü |

### 6.2 Proje Riskleri

| Risk | Olasılık | Etki | Önlem |
|------|----------|------|-------|
| Zaman aşımı | Düşük | Orta | Zaman planına uyum |
| Kapsam genişlemesi | Orta | Orta | Kapsam kontrolü |
| Teknik yetersizlik | Düşük | Düşük | Dokümantasyon ve öğrenme |

---

## 7. SONUÇ

### 7.1 Özet

- **Ana İşlev Nokta Sayısı (AİN):** 68
- **Teknik Karmaşıklık Faktörü (TKF):** 31
- **İşlev Noktası (İN):** 65.28
- **Tahmini Satır Sayısı:** 1,958 satır
- **Gerçek Satır Sayısı:** ~2,000-2,500 satır
- **Proje Kategorisi:** Orta Ölçekli Proje
- **Geliştirme Süresi:** 7 hafta
- **Geliştirici Sayısı:** 1 kişi

### 7.2 Değerlendirme

Proje, **orta ölçekli** bir Windows Forms uygulamasıdır. AI entegrasyonu ve OOP prensipleri uygulaması nedeniyle teknik karmaşıklık orta seviyededir. Hesaplanan satır sayısı gerçek değerle uyumludur ve proje büyüklüğü tahmini doğrudur.

---

**Hazırlama Tarihi:** 2025-01-XX  
**Versiyon:** 1.0


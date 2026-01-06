# TEST PLANI VE DOKÜMANTASYONU

## Test Stratejisi

Bu doküman, Yemek Tarifi Öneri Uygulaması için test planını ve test senaryolarını içermektedir.

---

## 1. Test Kapsamı

### 1.1 Test Edilecek Modüller

- ✅ **UI Modülü:** Form işlevselliği, kullanıcı etkileşimleri
- ✅ **Service Modülü:** AI servisi, Repository işlemleri
- ✅ **Validation Modülü:** Veri doğrulama
- ✅ **Exception Handling:** Hata yönetimi
- ✅ **Database İşlemleri:** CRUD operasyonları

### 1.2 Test Edilmeyecek Modüller

- DevExpress framework bileşenleri (3. parti)
- MySQL connector (3. parti)
- Gemini API (harici servis)

---

## 2. Test Türleri

### 2.1 Unit Test (Birim Test)

**Amaç:** Her bir metodun ve sınıfın bağımsız olarak test edilmesi

**Test Edilecek Sınıflar:**
- `TarifValidator`
- `MySqlTarifRepository` (mock ile)
- `InMemoryTarifRepository`
- `SGeminiAsistan` (mock ile)
- `RepositoryFactory`
- `AiAsistanFactory`

**Test Framework:** NUnit veya xUnit

### 2.2 Integration Test (Entegrasyon Testi)

**Amaç:** Modüller arası etkileşimin test edilmesi

**Test Senaryoları:**
- Repository → Database entegrasyonu
- AI Service → API entegrasyonu
- Form → Service entegrasyonu

### 2.3 System Test (Sistem Testi)

**Amaç:** Tüm sistemin birlikte çalışmasının test edilmesi

**Test Senaryoları:**
- End-to-end tarif önerisi akışı
- Favori ekleme/silme/listeleme akışı
- Hata senaryoları

### 2.4 User Acceptance Test (Kullanıcı Kabul Testi)

**Amaç:** Kullanıcı gereksinimlerinin karşılandığının doğrulanması

---

## 3. Test Senaryoları

### 3.1 Fonksiyonel Test Senaryoları

#### TC-001: Tarif Önerisi - Malzeme Listesi ile

**Önkoşul:** Uygulama açık, internet bağlantısı var, API key geçerli

**Adımlar:**
1. Malzeme listesi alanına malzemeler girilir
2. "Tarif Bul (AI)" butonuna tıklanır
3. Beklenen sonuç beklenir

**Beklenen Sonuç:**
- Tarif adı görüntülenir
- Malzemeler listelenir
- Yapılış adımları gösterilir
- Besin değerleri (kalori, protein, karbonhidrat) gösterilir

**Test Verisi:**
```
Malzemeler: "domates, soğan, sarımsak, zeytinyağı"
```

---

#### TC-002: Tarif Önerisi - Fotoğraf ile

**Önkoşul:** Uygulama açık, internet bağlantısı var, API key geçerli

**Adımlar:**
1. "Fotoğraf Seç" butonuna tıklanır
2. Geçerli bir resim dosyası seçilir (.jpg, .png)
3. Otomatik analiz başlar

**Beklenen Sonuç:**
- Fotoğraf yüklenir
- AI analizi başlar
- Tarif önerisi gösterilir

**Test Verisi:**
- Geçerli resim: `test_malzemeler.jpg`
- Geçersiz format: `test.txt` (hata vermeli)

---

#### TC-003: Favori Ekleme

**Önkoşul:** Bir tarif önerisi oluşturulmuş

**Adımlar:**
1. "Favori Ekle" butonuna tıklanır

**Beklenen Sonuç:**
- Başarı mesajı gösterilir
- Tarif veritabanına kaydedilir

**Negatif Test:**
- Tarif oluşturulmadan favori eklenmeye çalışılırsa uyarı mesajı gösterilmeli

---

#### TC-004: Favori Listeleme

**Önkoşul:** En az bir favori tarif var

**Adımlar:**
1. "Favori Listesi" butonuna tıklanır
2. Favori tarifler listesi açılır

**Beklenen Sonuç:**
- Tüm favori tarifler listelenir
- Bir tarif seçildiğinde detayları gösterilir

---

#### TC-005: Favori Silme

**Önkoşul:** En az bir favori tarif var

**Adımlar:**
1. "Favori Listesi" açılır
2. Bir tarif seçilir
3. "Sil" butonuna tıklanır
4. Onay mesajında "Evet" seçilir

**Beklenen Sonuç:**
- Tarif silinir
- Listeden kaldırılır
- Başarı mesajı gösterilir

---

### 3.2 Hata Senaryoları (Error Handling)

#### TC-006: API Key Eksik

**Önkoşul:** App.config'de API key yok veya geçersiz

**Beklenen Sonuç:**
- Uygulama başlatılamaz veya hata mesajı gösterilir
- `ApiException` fırlatılır

---

#### TC-007: Veritabanı Bağlantı Hatası

**Önkoşul:** Veritabanı erişilemez durumda

**Beklenen Sonuç:**
- `RepositoryException` fırlatılır
- Kullanıcıya anlamlı hata mesajı gösterilir

---

#### TC-008: Geçersiz Veri Girişi

**Test Senaryoları:**
- Boş tarif adı
- Negatif kalori değeri
- Boş malzeme listesi

**Beklenen Sonuç:**
- `ValidationException` fırlatılır
- Kullanıcıya uyarı mesajı gösterilir

---

### 3.3 Performans Test Senaryoları

#### TC-009: API Yanıt Süresi

**Test:** AI API çağrısının süresi

**Beklenen:** 60 saniye içinde yanıt alınmalı

---

#### TC-010: Veritabanı İşlem Hızı

**Test:** Favori ekleme/silme/listeleme süreleri

**Beklenen:** Her işlem 1 saniye içinde tamamlanmalı

---

## 4. Test Ortamı

### 4.1 Gereksinimler

- **İşletim Sistemi:** Windows 10/11
- **.NET Framework:** 4.7.2 veya üzeri
- **MySQL:** 5.7 veya üzeri
- **Internet Bağlantısı:** Gemini API için
- **DevExpress:** 25.2.3

### 4.2 Test Verileri

- Test veritabanı: `yemek_tarifi_test_db`
- Test API Key: (Geçerli bir test key)
- Test resim dosyaları: `test_data/images/`

---

## 5. Test Metrikleri

### 5.1 Test Coverage Hedefi

- **Unit Test Coverage:** %70+
- **Integration Test Coverage:** %50+
- **Critical Path Coverage:** %100

### 5.2 Başarı Kriterleri

- Tüm kritik fonksiyonlar test edilmiş
- Tüm hata senaryoları test edilmiş
- Test coverage hedefleri karşılanmış
- Tüm testler geçiyor

---

## 6. Test Raporlama

### 6.1 Test Sonuçları

Her test sonucu şu bilgileri içermelidir:
- Test ID
- Test Adı
- Durum (Pass/Fail)
- Hata Mesajı (varsa)
- Test Süresi
- Test Tarihi

### 6.2 Test Raporu Formatı

```
Test ID | Test Adı | Durum | Notlar
--------|----------|-------|--------
TC-001  | Tarif Önerisi | PASS | 2.3 saniye
TC-002  | Fotoğraf ile Öneri | PASS | 3.1 saniye
TC-003  | Favori Ekleme | PASS | -
TC-004  | Favori Listeleme | PASS | -
TC-005  | Favori Silme | PASS | -
TC-006  | API Key Eksik | PASS | Hata mesajı doğru
TC-007  | DB Bağlantı Hatası | PASS | Exception yakalandı
TC-008  | Geçersiz Veri | PASS | Validation çalışıyor
```

---

## 7. Test Otomasyonu

### 7.1 Otomatik Test Araçları

- **Unit Test:** NUnit, xUnit
- **Integration Test:** NUnit
- **UI Test:** (Manuel test önerilir - DevExpress özel kontroller)

### 7.2 CI/CD Entegrasyonu

Testler CI/CD pipeline'a entegre edilebilir:
- Her commit'te unit testler çalıştırılır
- Her release'te tüm testler çalıştırılır

---

## 8. Test Takvimi

| Test Türü | Süre | Sorumlu |
|-----------|------|---------|
| Unit Test Yazımı | 2 gün | Geliştirici |
| Integration Test | 1 gün | Geliştirici |
| System Test | 1 gün | Test Ekibi |
| User Acceptance Test | 1 gün | Kullanıcı |

---

## 9. Test Sonuçları Özeti

**Test Durumu:** Hazır (Testler yazılmayı bekliyor)

**Not:** Bu test planı, testlerin yazılması ve çalıştırılması için bir rehberdir. Gerçek test sonuçları testler yazıldıktan sonra buraya eklenecektir.


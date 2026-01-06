# MCCABE KARMAŞIKLIK ÖLÇÜTÜ ANALİZİ

**Proje Adı:** Yemek Tarifi Öneri Uygulaması  
**Tarih:** 2025-01-XX

---

## 1. MCCABE KARMAŞIKLIK ÖLÇÜTÜ NEDİR?

McCabe Karmaşıklık Ölçütü (Cyclomatic Complexity), bir programın kontrol akış grafiğindeki döngüsel karmaşıklığı ölçer. Bu ölçüt, bir programın test edilebilirliği ve bakım kolaylığı hakkında bilgi verir.

### 1.1 Formül

**V(G) = E - N + 2P**

- **E:** Kenar sayısı (edges) - Kontrol akışındaki ok sayısı
- **N:** Düğüm sayısı (nodes) - Kod blokları ve karar noktaları
- **P:** Bağlı bileşen sayısı (genellikle 1)

**Alternatif Formül:** V(G) = Karar Noktaları Sayısı + 1

### 1.2 Değerlendirme Kriterleri

| Karmaşıklık Değeri | Değerlendirme | Açıklama |
|-------------------|---------------|----------|
| 1-10 | Düşük | Basit, anlaşılır kod |
| 11-20 | Orta | Karmaşıklık kabul edilebilir |
| 21-30 | Yüksek | Refactoring önerilir |
| 31+ | Çok Yüksek | Mutlaka refactoring gerekli |

---

## 2. PROGRAMIN ÇİZGE BİÇİMİNE DÖNÜŞTÜRÜLMESİ

### 2.1 Kontrol Akış Grafiği Gösterimi

Kontrol akış grafiği, programın yürütme akışını gösterir:
- **Dikdörtgen:** İşlem blokları (statements)
- **Elmas:** Karar noktaları (if, while, switch)
- **Yuvarlak:** Başlangıç/Bitiş noktaları

---

## 3. METOD BAZINDA MCCABE ANALİZİ

### 3.1 AnalizBaslat() Metodu

**Sınıf:** `FrmTarifOneri`  
**Satırlar:** 167-211

#### Kontrol Akış Grafiği

```mermaid
flowchart TD
    Start([Başla]) --> Check1{Malzeme veya<br/>Fotoğraf var mı?}
    Check1 -->|Hayır| End1([Bitiş])
    Check1 -->|Evet| Disable[Butonu devre dışı bırak]
    Disable --> Try[Try bloğu başla]
    Try --> API[AI API çağrısı]
    API --> Check2{Tarif null mı?}
    Check2 -->|Hayır| Update[UI güncelle]
    Check2 -->|Evet| Skip[Atla]
    Update --> Finally[Finally bloğu]
    Skip --> Finally
    Try --> Catch1{ApiException?}
    Catch1 -->|Evet| Error1[Hata mesajı göster]
    Catch1 -->|Hayır| Catch2{ValidationException?}
    Catch2 -->|Evet| Error2[Hata mesajı göster]
    Catch2 -->|Hayır| Catch3{Exception?}
    Catch3 -->|Evet| Error3[Hata mesajı göster]
    Error1 --> Finally
    Error2 --> Finally
    Error3 --> Finally
    Finally --> Enable[Butonu aktif et]
    Enable --> End2([Bitiş])
```

#### McCabe Hesaplama

- **Karar Noktaları:** 4 (Check1, Check2, Catch1, Catch2, Catch3)
- **V(G) = 4 + 1 = 5**

**Değerlendirme:** Düşük karmaşıklık ✅

---

### 3.2 GetTarifOnerisi() Metodu

**Sınıf:** `SGeminiAsistan`  
**Satırlar:** 49-126

#### Kontrol Akış Grafiği

```mermaid
flowchart TD
    Start([Başla]) --> Init[Prompt oluştur]
    Init --> Check1{Malzeme listesi<br/>var mı?}
    Check1 -->|Evet| Add1[Prompt'a ekle]
    Check1 -->|Hayır| Skip1[Atla]
    Add1 --> Add2[Parts listesine ekle]
    Skip1 --> Add2
    Add2 --> Check2{Fotoğraf var mı<br/>ve dosya mevcut mu?}
    Check2 -->|Evet| Read[Fotoğrafı oku]
    Read --> Base64[Base64'e çevir]
    Base64 --> Add3[Parts'e ekle]
    Check2 -->|Hayır| Skip2[Atla]
    Add3 --> Request[HTTP Request oluştur]
    Skip2 --> Request
    Request --> Try[Try bloğu]
    Try --> Post[HTTP POST]
    Post --> Check3{Status Code<br/>başarılı mı?}
    Check3 -->|Hayır| Throw1[ApiException fırlat]
    Check3 -->|Evet| Parse1[JSON parse]
    Parse1 --> Check4{Candidates<br/>var mı?}
    Check4 -->|Hayır| Throw2[ApiException fırlat]
    Check4 -->|Evet| Extract[Text çıkar]
    Extract --> Parse2[Deserialize]
    Parse2 --> Check5{Tarif null mı?}
    Check5 -->|Evet| Throw3[ApiException fırlat]
    Check5 -->|Hayır| Return[Return tarif]
    Try --> Catch1{ApiException?}
    Catch1 -->|Evet| Rethrow1[Fırlat]
    Catch1 -->|Hayır| Catch2{HttpRequestException?}
    Catch2 -->|Evet| Throw4[ApiException fırlat]
    Catch2 -->|Hayır| Catch3{JsonException?}
    Catch3 -->|Evet| Throw5[ApiException fırlat]
    Catch3 -->|Hayır| Catch4{Exception?}
    Catch4 -->|Evet| Throw6[ApiException fırlat]
    Return --> End([Bitiş])
    Throw1 --> End
    Throw2 --> End
    Throw3 --> End
    Rethrow1 --> End
    Throw4 --> End
    Throw5 --> End
    Throw6 --> End
```

#### McCabe Hesaplama

- **Karar Noktaları:** 9 (Check1, Check2, Check3, Check4, Check5, Catch1, Catch2, Catch3, Catch4)
- **V(G) = 9 + 1 = 10**

**Değerlendirme:** Düşük-Orta karmaşıklık ✅

---

### 3.3 Validate() Metodu

**Sınıf:** `TarifValidator`  
**Satırlar:** 18-40

#### Kontrol Akış Grafiği

```mermaid
flowchart TD
    Start([Başla]) --> Check1{Tarif null mı?}
    Check1 -->|Evet| Throw1[ValidationException]
    Check1 -->|Hayır| Check2{TarifAdi<br/>boş mu?}
    Check2 -->|Evet| Throw2[ValidationException]
    Check2 -->|Hayır| Check3{Malzemeler<br/>boş mu?}
    Check3 -->|Evet| Throw3[ValidationException]
    Check3 -->|Hayır| Check4{Yapilis<br/>boş mu?}
    Check4 -->|Evet| Throw4[ValidationException]
    Check4 -->|Hayır| Check5{Kalori < 0?}
    Check5 -->|Evet| Throw5[ValidationException]
    Check5 -->|Hayır| Check6{Protein < 0?}
    Check6 -->|Evet| Throw6[ValidationException]
    Check6 -->|Hayır| Check7{Karbonhidrat < 0?}
    Check7 -->|Evet| Throw7[ValidationException]
    Check7 -->|Hayır| End([Bitiş])
    Throw1 --> End
    Throw2 --> End
    Throw3 --> End
    Throw4 --> End
    Throw5 --> End
    Throw6 --> End
    Throw7 --> End
```

#### McCabe Hesaplama

- **Karar Noktaları:** 7 (Check1-7)
- **V(G) = 7 + 1 = 8**

**Değerlendirme:** Düşük karmaşıklık ✅

---

### 3.4 FavoriEkle() Metodu

**Sınıf:** `MySqlTarifRepository`  
**Satırlar:** 42-93

#### Kontrol Akış Grafiği

```mermaid
flowchart TD
    Start([Başla]) --> Validate[Validation]
    Validate --> SQL[SQL hazırla]
    SQL --> Try[Try bloğu]
    Try --> Connect[DB bağlantısı aç]
    Connect --> Execute[SQL çalıştır]
    Execute --> Check1{MySqlException?}
    Check1 -->|Evet| Check2{Error Code<br/>1062?}
    Check2 -->|Evet| Throw1[RepositoryException<br/>Duplicate]
    Check2 -->|Hayır| Throw2[RepositoryException<br/>DB Error]
    Check1 -->|Hayır| Check3{Exception?}
    Check3 -->|Evet| Throw3[RepositoryException<br/>Unexpected]
    Check3 -->|Hayır| Success[Başarılı]
    Throw1 --> End([Bitiş])
    Throw2 --> End
    Throw3 --> End
    Success --> End
```

#### McCabe Hesaplama

- **Karar Noktaları:** 3 (Check1, Check2, Check3)
- **V(G) = 3 + 1 = 4**

**Değerlendirme:** Düşük karmaşıklık ✅

---

## 4. GENEL MCCABE ANALİZİ ÖZETİ

### 4.1 Metod Karmaşıklık Tablosu

| Metod | Sınıf | McCabe Değeri | Değerlendirme |
|-------|-------|---------------|---------------|
| `AnalizBaslat()` | FrmTarifOneri | 5 | Düşük ✅ |
| `GetTarifOnerisi()` | SGeminiAsistan | 10 | Düşük-Orta ✅ |
| `Validate()` | TarifValidator | 8 | Düşük ✅ |
| `FavoriEkle()` | MySqlTarifRepository | 4 | Düşük ✅ |
| `GetTumFavoriler()` | MySqlTarifRepository | 3 | Düşük ✅ |
| `FavoriSil()` | MySqlTarifRepository | 4 | Düşük ✅ |
| `IsValidMalzemeListesi()` | TarifValidator | 1 | Düşük ✅ |
| `IsValidImageFile()` | TarifValidator | 2 | Düşük ✅ |

### 4.2 Ortalama Karmaşıklık

**Ortalama McCabe Değeri:** (5 + 10 + 8 + 4 + 3 + 4 + 1 + 2) / 8 = **4.625**

**Değerlendirme:** Proje genelinde **düşük karmaşıklık** seviyesi ✅

---

## 5. KARMAŞIKLIK DEĞERLENDİRMESİ

### 5.1 Güçlü Yönler

- ✅ Tüm metodlar düşük-orta karmaşıklık seviyesinde
- ✅ En karmaşık metod (GetTarifOnerisi) bile kabul edilebilir seviyede (10)
- ✅ Ortalama karmaşıklık çok düşük (4.625)
- ✅ Kod okunabilirliği yüksek
- ✅ Test edilebilirlik kolay

### 5.2 İyileştirme Önerileri

- `GetTarifOnerisi()` metodu 10 karmaşıklığa sahip. İyileştirme için:
  - Exception handling'i ayrı bir metoda taşınabilir
  - JSON parsing işlemi ayrı bir metoda taşınabilir
  - Bu sayede karmaşıklık 7-8 seviyesine düşürülebilir

### 5.3 Kod Kalitesi

**Genel Değerlendirme:** Proje, **düşük karmaşıklık** seviyesinde, **iyi yapılandırılmış** ve **bakımı kolay** bir kod yapısına sahiptir.

---

## 6. TEST KAPSAMI İLE İLİŞKİSİ

### 6.1 Test Senaryosu Sayısı

McCabe karmaşıklığı, bir metod için yazılması gereken minimum test sayısını gösterir:

| Metod | McCabe | Minimum Test Sayısı |
|-------|--------|---------------------|
| `AnalizBaslat()` | 5 | 5 test senaryosu |
| `GetTarifOnerisi()` | 10 | 10 test senaryosu |
| `Validate()` | 8 | 8 test senaryosu |
| `FavoriEkle()` | 4 | 4 test senaryosu |

### 6.2 Test Kapsamı Hedefi

- **Minimum Test Coverage:** McCabe değeri kadar test senaryosu
- **Hedef Test Coverage:** %80+ (tüm dallar test edilmeli)

---

## 7. SONUÇ

### 7.1 Özet

- **Toplam Analiz Edilen Metod:** 8
- **En Yüksek McCabe Değeri:** 10 (`GetTarifOnerisi`)
- **En Düşük McCabe Değeri:** 1 (`IsValidMalzemeListesi`)
- **Ortalama McCabe Değeri:** 4.625
- **Genel Değerlendirme:** Düşük karmaşıklık ✅

### 7.2 Sonuç

Proje, **McCabe karmaşıklık ölçütüne göre iyi durumdadır**. Tüm metodlar kabul edilebilir karmaşıklık seviyesindedir ve refactoring gerektirmemektedir. Kod yapısı, test edilebilirlik ve bakım kolaylığı açısından uygundur.

---

**Hazırlama Tarihi:** 2025-01-XX  
**Versiyon:** 1.0


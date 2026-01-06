# UML DİYAGRAMLARI

**Proje Adı:** Yemek Tarifi Öneri Uygulaması  
**Tarih:** 2025-01-XX

---

## 1. USE CASE DİYAGRAMI

Use Case diyagramı, sistemin kullanıcılar tarafından gerçekleştirilebilecek işlevlerini gösterir.

```mermaid
graph TB
    User[Kullanıcı]
    
    UC1[UC1: Tarif Önerisi Al<br/>Malzeme Listesi ile]
    UC2[UC2: Tarif Önerisi Al<br/>Fotoğraf ile]
    UC3[UC3: Favori Ekle]
    UC4[UC4: Favori Listele]
    UC5[UC5: Favori Sil]
    UC6[UC6: Tarif Detaylarını Görüntüle]
    
    User --> UC1
    User --> UC2
    User --> UC3
    User --> UC4
    User --> UC5
    User --> UC6
    
    UC3 -.->|extends| UC1
    UC3 -.->|extends| UC2
    UC6 -.->|includes| UC4
```

### Use Case Açıklamaları

| Use Case | Açıklama |
|----------|----------|
| **UC1: Tarif Önerisi Al (Malzeme Listesi ile)** | Kullanıcı malzeme listesini yazarak AI'dan tarif önerisi alır |
| **UC2: Tarif Önerisi Al (Fotoğraf ile)** | Kullanıcı fotoğraf yükleyerek AI'dan tarif önerisi alır |
| **UC3: Favori Ekle** | Kullanıcı bir tarifi favorilerine ekler |
| **UC4: Favori Listele** | Kullanıcı favori tariflerini listeler |
| **UC5: Favori Sil** | Kullanıcı bir favori tarifi siler |
| **UC6: Tarif Detaylarını Görüntüle** | Kullanıcı bir tarifin detaylarını görüntüler |

---

## 2. SINIF DİYAGRAMI (CLASS DIAGRAM)

Sınıf diyagramı, sistemdeki sınıfları, özelliklerini ve ilişkilerini gösterir.

```mermaid
classDiagram
    class TarifResponse {
        +string TarifAdi
        +string Malzemeler
        +string Yapilis
        +double Kalori
        +double Protein
        +double Karbonhidrat
    }
    
    class ITarifRepository {
        <<interface>>
        +void FavoriEkle(TarifResponse)
        +List~TarifResponse~ GetTumFavoriler()
        +void FavoriSil(string)
    }
    
    class IAiAsistan {
        <<interface>>
        +Task~TarifResponse~ GetTarifOnerisi(string, string)
    }
    
    class BaseRepository {
        <<abstract>>
        #abstract string ConnectionString
        +abstract void FavoriEkle(TarifResponse)
        +abstract List~TarifResponse~ GetTumFavoriler()
        +abstract void FavoriSil(string)
        #bool ValidateConnectionString(string)
        #string GetConnectionStringFromConfig(string)
    }
    
    class MySqlTarifRepository {
        -string _connectionString
        +MySqlTarifRepository()
        +void FavoriEkle(TarifResponse)
        +List~TarifResponse~ GetTumFavoriler()
        +void FavoriSil(string)
    }
    
    class InMemoryTarifRepository {
        -List~TarifResponse~ _favoriler
        +void FavoriEkle(TarifResponse)
        +List~TarifResponse~ GetTumFavoriler()
        +void FavoriSil(string)
    }
    
    class SGeminiAsistan {
        -string _apiKey
        -string _apiUrl
        -HttpClient _httpClient
        +SGeminiAsistan()
        +Task~TarifResponse~ GetTarifOnerisi(string, string)
    }
    
    class FrmTarifOneri {
        -IAiAsistan _aiAsistan
        -ITarifRepository _tarifRepository
        -TarifResponse _currentTarif
        -string _secilenFotoYolu
        +FrmTarifOneri()
        +FrmTarifOneri(IAiAsistan, ITarifRepository)
        -void ApplyModernStyling()
        +async void BtnTarifBul_Click()
        +void BtnFavoriEkle_Click()
        +void BtnFavoriListesi_Click()
    }
    
    class FrmFavoriler {
        -ITarifRepository _tarifRepository
        +FrmFavoriler()
        +FrmFavoriler(ITarifRepository)
        +void LoadFavoriler()
        +void BtnSil_Click()
    }
    
    class RepositoryFactory {
        <<factory>>
        +static ITarifRepository Create(RepositoryType)
        +static ITarifRepository CreateDefault()
    }
    
    class AiAsistanFactory {
        <<factory>>
        +static IAiAsistan Create(AiAsistanType)
        +static IAiAsistan CreateDefault()
    }
    
    class TarifValidator {
        <<utility>>
        +static void Validate(TarifResponse)
        +static bool IsValidMalzemeListesi(string)
        +static bool IsValidImageFile(string)
    }
    
    class ApiException {
        +int StatusCode
        +string ResponseContent
    }
    
    class RepositoryException {
        +string OperationType
    }
    
    class ValidationException {
        +string FieldName
    }
    
    %% İlişkiler
    ITarifRepository <|.. BaseRepository : implements
    BaseRepository <|-- MySqlTarifRepository : extends
    BaseRepository <|-- InMemoryTarifRepository : extends
    ITarifRepository <|.. MySqlTarifRepository : implements
    ITarifRepository <|.. InMemoryTarifRepository : implements
    IAiAsistan <|.. SGeminiAsistan : implements
    
    FrmTarifOneri --> IAiAsistan : uses
    FrmTarifOneri --> ITarifRepository : uses
    FrmTarifOneri --> TarifResponse : uses
    FrmFavoriler --> ITarifRepository : uses
    FrmFavoriler --> TarifResponse : uses
    
    RepositoryFactory ..> ITarifRepository : creates
    AiAsistanFactory ..> IAiAsistan : creates
    
    MySqlTarifRepository --> TarifValidator : uses
    MySqlTarifRepository --> RepositoryException : throws
    SGeminiAsistan --> ApiException : throws
    TarifValidator --> ValidationException : throws
```

### Sınıf İlişkileri Açıklaması

- **Inheritance (Kalıtım):** `BaseRepository` abstract class'ından `MySqlTarifRepository` ve `InMemoryTarifRepository` türetilmiştir.
- **Interface Implementation:** `ITarifRepository` ve `IAiAsistan` interface'leri implement edilmiştir.
- **Dependency (Bağımlılık):** Formlar interface'ler üzerinden bağımlılık kullanır (Dependency Injection).
- **Composition:** `TarifResponse` model sınıfı diğer sınıflar tarafından kullanılır.
- **Factory Pattern:** `RepositoryFactory` ve `AiAsistanFactory` nesne oluşturma için kullanılır.

---

## 3. SEQUENCE DİYAGRAMI

Sequence diyagramı, sistemdeki nesneler arasındaki etkileşimleri zaman sırasına göre gösterir.

### 3.1 Tarif Önerisi Alma (Malzeme Listesi ile)

```mermaid
sequenceDiagram
    participant User as Kullanıcı
    participant UI as FrmTarifOneri
    participant AI as SGeminiAsistan
    participant API as Gemini API
    participant Repo as MySqlTarifRepository
    participant DB as MySQL Database
    
    User->>UI: Malzeme listesi girer
    User->>UI: "Tarif Bul" butonuna tıklar
    UI->>UI: Malzeme listesini doğrula
    UI->>AI: GetTarifOnerisi(malzemeListesi)
    AI->>API: HTTP POST (JSON request)
    API-->>AI: JSON response
    AI->>AI: JSON'u parse et
    AI-->>UI: TarifResponse döner
    UI->>UI: Tarif bilgilerini göster
    UI->>UI: Besin değerlerini göster
    UI-->>User: Tarif önerisi görüntülenir
```

### 3.2 Favori Ekleme

```mermaid
sequenceDiagram
    participant User as Kullanıcı
    participant UI as FrmTarifOneri
    participant Validator as TarifValidator
    participant Repo as MySqlTarifRepository
    participant DB as MySQL Database
    
    User->>UI: "Favori Ekle" butonuna tıklar
    UI->>UI: Mevcut tarifi kontrol et
    UI->>Validator: Validate(tarif)
    Validator-->>UI: Validation başarılı
    UI->>Repo: FavoriEkle(tarif)
    Repo->>DB: INSERT INTO tarif_favori
    DB-->>Repo: Success
    Repo-->>UI: Başarılı
    UI-->>User: "Favori eklendi!" mesajı
```

### 3.3 Favori Listeleme

```mermaid
sequenceDiagram
    participant User as Kullanıcı
    participant UI as FrmFavoriler
    participant Repo as MySqlTarifRepository
    participant DB as MySQL Database
    
    User->>UI: "Favori Listesi" butonuna tıklar
    UI->>UI: FrmFavoriler formunu aç
    UI->>Repo: GetTumFavoriler()
    Repo->>DB: SELECT * FROM tarif_favori
    DB-->>Repo: ResultSet
    Repo->>Repo: ResultSet'i TarifResponse listesine çevir
    Repo-->>UI: List<TarifResponse>
    UI->>UI: Listeyi göster
    UI-->>User: Favori tarifler listelenir
```

---

## 4. ACTIVITY DİYAGRAMI

Activity diyagramı, sistemdeki iş akışlarını gösterir.

### 4.1 Tarif Önerisi Alma Akışı

```mermaid
flowchart TD
    Start([Kullanıcı tarif önerisi ister]) --> Input{Malzeme girişi<br/>veya<br/>Fotoğraf?}
    
    Input -->|Malzeme Listesi| Validate1[Malzeme listesini doğrula]
    Input -->|Fotoğraf| Validate2[Fotoğraf dosyasını doğrula]
    
    Validate1 -->|Geçersiz| Error1[Hata mesajı göster]
    Validate2 -->|Geçersiz| Error2[Hata mesajı göster]
    
    Validate1 -->|Geçerli| API1[AI API'ye istek gönder]
    Validate2 -->|Geçerli| API2[AI API'ye istek gönder<br/>Fotoğraf ile]
    
    API1 --> Wait[Yanıt bekle]
    API2 --> Wait
    
    Wait --> Response{API yanıtı<br/>başarılı mı?}
    
    Response -->|Hayır| Error3[API hatası mesajı göster]
    Response -->|Evet| Parse[JSON'u parse et]
    
    Parse --> Display[Tarif bilgilerini göster]
    Display --> End([İşlem tamamlandı])
    
    Error1 --> End
    Error2 --> End
    Error3 --> End
```

### 4.2 Favori Yönetimi Akışı

```mermaid
flowchart TD
    Start([Favori işlemi başlat]) --> Action{İşlem tipi?}
    
    Action -->|Ekle| Check1{Tarif var mı?}
    Action -->|Listele| Load[Favorileri yükle]
    Action -->|Sil| Check2{Tarif seçili mi?}
    
    Check1 -->|Hayır| Error1[Uyarı mesajı]
    Check1 -->|Evet| Validate[Tarifi doğrula]
    
    Validate -->|Geçersiz| Error2[Validation hatası]
    Validate -->|Geçerli| Insert[Veritabanına ekle]
    
    Insert --> Success1[Başarı mesajı]
    
    Load --> Display[Listeyi göster]
    Display --> Select{Kullanıcı tarif seçti mi?}
    Select -->|Evet| ShowDetail[Detayları göster]
    Select -->|Hayır| End1([İşlem tamamlandı])
    ShowDetail --> End1
    
    Check2 -->|Hayır| Error3[Uyarı mesajı]
    Check2 -->|Evet| Confirm[Onay iste]
    
    Confirm -->|Hayır| End2([İşlem iptal])
    Confirm -->|Evet| Delete[Veritabanından sil]
    
    Delete --> Success2[Başarı mesajı]
    Success1 --> End1
    Success2 --> End1
    Error1 --> End1
    Error2 --> End1
    Error3 --> End1
```

---

## 5. DİYAGRAM AÇIKLAMALARI

### 5.1 Use Case Diyagramı

- **Aktör:** Kullanıcı (tek aktör)
- **Use Case'ler:** 6 ana use case
- **İlişkiler:** Include ve Extend ilişkileri kullanılmıştır

### 5.2 Sınıf Diyagramı

- **Toplam Sınıf Sayısı:** 15+ sınıf
- **Interface Sayısı:** 2 (ITarifRepository, IAiAsistan)
- **Abstract Class:** 1 (BaseRepository)
- **Factory Pattern:** 2 factory sınıfı
- **Exception Sınıfları:** 3 custom exception

### 5.3 Sequence Diyagramı

- **3 ana akış:** Tarif önerisi alma, Favori ekleme, Favori listeleme
- **Asenkron işlemler:** AI API çağrıları async/await ile gösterilmiştir
- **Hata yönetimi:** Exception handling akışları gösterilmiştir

### 5.4 Activity Diyagramı

- **Karar noktaları:** Diamond şekilleri ile gösterilmiştir
- **Paralel işlemler:** Fork/Join gösterilmemiştir (tek akış)
- **Hata durumları:** Error handling akışları dahil edilmiştir

---

## 6. UML ARAÇLARI

Bu diyagramlar aşağıdaki araçlarla oluşturulabilir:

- **Mermaid:** Markdown içinde diyagram oluşturma
- **PlantUML:** Text-based UML diyagramları
- **Draw.io:** Görsel UML diyagram editörü
- **Visual Studio:** Class diagram özelliği
- **Enterprise Architect:** Profesyonel UML araçları

---

**Hazırlama Tarihi:** 2025-01-XX  
**Versiyon:** 1.0


# KOD ÖRNEKLERİ (EK D)

**Proje Adı:** Yemek Tarifi Öneri Uygulaması  
**Tarih:** 2025-01-XX

---

## 1. INTERFACE KULLANIMI

### 1.1 ITarifRepository Interface

```csharp
namespace YemekTarifiApp.Interfaces
{
    /// <summary>
    /// Tarif verilerinin saklanması ve yönetilmesi için repository arayüzü.
    /// Bu interface, farklı veri kaynakları (MySQL, SQL Server, InMemory vb.) için 
    /// polymorphism sağlar.
    /// </summary>
    public interface ITarifRepository
    {
        /// <summary>
        /// Yeni bir tarifi tüm besin değerleriyle favorilere ekler.
        /// </summary>
        /// <param name="tarif">Eklenecek tarif bilgileri</param>
        /// <exception cref="System.ArgumentNullException">Tarif null ise fırlatılır</exception>
        void FavoriEkle(TarifResponse tarif);

        /// <summary>
        /// Veritabanındaki tüm favori tarifleri detaylıca çeker.
        /// </summary>
        /// <returns>Favori tariflerin listesi. Liste boş olabilir ama null dönmez.</returns>
        List<TarifResponse> GetTumFavoriler();

        /// <summary>
        /// Başlığa göre favori tarifi siler.
        /// </summary>
        /// <param name="baslik">Silinecek tarifin başlığı</param>
        /// <exception cref="System.ArgumentException">Başlık boş veya null ise fırlatılır</exception>
        void FavoriSil(string baslik);
    }
}
```

**Özellikler:**
- Polymorphism sağlar
- Farklı implementasyonlar kullanılabilir
- Test edilebilirlik artar

---

## 2. INHERITANCE (KALITIM)

### 2.1 BaseRepository Abstract Class

```csharp
namespace YemekTarifiApp.Abstract
{
    /// <summary>
    /// Tüm repository sınıfları için ortak işlevleri sağlayan abstract base class.
    /// Bu sınıf, inheritance ve code reusability prensiplerini uygular.
    /// </summary>
    public abstract class BaseRepository : ITarifRepository
    {
        /// <summary>
        /// Veritabanı bağlantı dizesini döndürür.
        /// Alt sınıflar bu property'yi override ederek kendi bağlantı dizesini sağlayabilir.
        /// </summary>
        protected abstract string ConnectionString { get; }

        /// <summary>
        /// Yeni bir tarifi tüm besin değerleriyle favorilere ekler.
        /// Alt sınıflar bu metodu implement etmelidir.
        /// </summary>
        /// <param name="tarif">Eklenecek tarif bilgileri</param>
        public abstract void FavoriEkle(TarifResponse tarif);

        /// <summary>
        /// Veritabanındaki tüm favori tarifleri detaylıca çeker.
        /// Alt sınıflar bu metodu implement etmelidir.
        /// </summary>
        /// <returns>Favori tariflerin listesi</returns>
        public abstract List<TarifResponse> GetTumFavoriler();

        /// <summary>
        /// Başlığa göre favori tarifi siler.
        /// Alt sınıflar bu metodu implement etmelidir.
        /// </summary>
        /// <param name="baslik">Silinecek tarifin başlığı</param>
        public abstract void FavoriSil(string baslik);

        /// <summary>
        /// Bağlantı dizesinin geçerli olup olmadığını kontrol eder.
        /// Tüm alt sınıflar tarafından kullanılabilir ortak bir yardımcı metoddur.
        /// </summary>
        /// <param name="connectionString">Kontrol edilecek bağlantı dizesi</param>
        /// <returns>Bağlantı dizesi geçerli ise true, aksi halde false</returns>
        protected virtual bool ValidateConnectionString(string connectionString)
        {
            return !string.IsNullOrWhiteSpace(connectionString);
        }

        /// <summary>
        /// App.config'den bağlantı dizesini alır.
        /// </summary>
        /// <param name="connectionStringName">App.config'deki connection string adı</param>
        /// <returns>Bağlantı dizesi</returns>
        /// <exception cref="System.Exception">Connection string bulunamazsa fırlatılır</exception>
        protected string GetConnectionStringFromConfig(string connectionStringName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName]?.ConnectionString;
            
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception($"App.config içinde '{connectionStringName}' bulunamadı!");
            }

            return connectionString;
        }
    }
}
```

**Özellikler:**
- Abstract class ve metodlar
- Ortak işlevler tek yerde toplanmış
- Code reusability sağlanmış

---

## 3. POLYMORPHISM (ÇOK BİÇİMLİLİK)

### 3.1 MySqlTarifRepository Implementation

```csharp
namespace Modul.Service
{
    /// <summary>
    /// MySQL veritabanı kullanarak tarif verilerini yöneten repository sınıfı.
    /// BaseRepository'den türetilerek inheritance prensibini uygular.
    /// ITarifRepository interface'ini implement ederek polymorphism sağlar.
    /// </summary>
    public class MySqlTarifRepository : BaseRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// MySQL repository sınıfının constructor'ı.
        /// App.config'den bağlantı dizesini alır.
        /// </summary>
        public MySqlTarifRepository()
        {
            // Base class'ın protected metodunu kullanarak bağlantı dizesini alıyoruz
            _connectionString = GetConnectionStringFromConfig("MySqlConnectionString");
        }

        /// <summary>
        /// Base class'tan gelen abstract property'yi implement eder.
        /// </summary>
        protected override string ConnectionString => _connectionString;

        /// <summary>
        /// Yeni bir tarifi tüm besin değerleriyle favorilere ekler.
        /// BaseRepository'den gelen abstract metodu implement eder.
        /// </summary>
        /// <param name="tarif">Eklenecek tarif bilgileri</param>
        public override void FavoriEkle(TarifResponse tarif)
        {
            // Validation
            TarifValidator.Validate(tarif);

            const string sql = @"INSERT INTO tarif_favori 
                                (baslik, malzemeler, tarif_metin, kalori, protein, karbonhidrat, eklenme_tarihi)
                                 VALUES 
                                (@baslik, @malzemeler, @tarif_metin, @kalori, @protein, @karbonhidrat, NOW());";

            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@baslik", tarif.TarifAdi);
                    cmd.Parameters.AddWithValue("@malzemeler", tarif.Malzemeler);
                    cmd.Parameters.AddWithValue("@tarif_metin", tarif.Yapilis);
                    cmd.Parameters.AddWithValue("@kalori", (int)tarif.Kalori);
                    cmd.Parameters.AddWithValue("@protein", (int)tarif.Protein);
                    cmd.Parameters.AddWithValue("@karbonhidrat", (int)tarif.Karbonhidrat);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                // Duplicate key hatası kontrolü
                if (ex.Number == 1062) // MySQL duplicate entry error
                {
                    throw new RepositoryException(
                        $"'{tarif.TarifAdi}' adında bir tarif zaten mevcut!",
                        "Insert",
                        ex
                    );
                }
                throw new RepositoryException(
                    "Veritabanı hatası: Tarif eklenirken bir sorun oluştu.",
                    "Insert",
                    ex
                );
            }
            catch (Exception ex)
            {
                throw new RepositoryException(
                    "Beklenmeyen bir hata oluştu: Tarif eklenemedi.",
                    "Insert",
                    ex
                );
            }
        }
    }
}
```

**Özellikler:**
- Interface üzerinden çalışma
- Abstract class'tan türetme
- Exception handling
- SQL injection koruması

---

## 4. DEPENDENCY INJECTION

### 4.1 FrmTarifOneri Constructor Injection

```csharp
namespace YemekTarifiApp
{
    /// <summary>
    /// Ana tarif öneri formu. Kullanıcıya AI tabanlı tarif önerisi sunar.
    /// Dependency Injection pattern'ini kullanarak interface'ler üzerinden çalışır.
    /// </summary>
    public partial class FrmTarifOneri : XtraForm
    {
        private readonly IAiAsistan _aiAsistan;
        private readonly ITarifRepository _tarifRepository;
        private TarifResponse _currentTarif;
        private string _secilenFotoYolu = null;

        /// <summary>
        /// Varsayılan constructor. Factory Pattern kullanarak varsayılan implementasyonları oluşturur.
        /// Geriye dönük uyumluluk için mevcuttur.
        /// </summary>
        public FrmTarifOneri() : this(
            AiAsistanFactory.CreateDefault(),
            RepositoryFactory.CreateDefault()
        )
        {
        }

        /// <summary>
        /// Dependency Injection constructor'ı.
        /// Interface'ler üzerinden bağımlılıkları alarak polymorphism ve test edilebilirlik sağlar.
        /// </summary>
        /// <param name="aiAsistan">AI asistan servisi (IAiAsistan implementasyonu)</param>
        /// <param name="tarifRepository">Tarif repository servisi (ITarifRepository implementasyonu)</param>
        public FrmTarifOneri(IAiAsistan aiAsistan, ITarifRepository tarifRepository)
        {
            InitializeComponent();
            
            // Dependency Injection ile gelen bağımlılıkları atıyoruz
            _aiAsistan = aiAsistan ?? throw new ArgumentNullException(nameof(aiAsistan));
            _tarifRepository = tarifRepository ?? throw new ArgumentNullException(nameof(tarifRepository));
            
            // Modern DevExpress tema uygula
            try
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");
            }
            catch
            {
                // Tema bulunamazsa varsayılan tema kullanılır
            }
        }
    }
}
```

**Özellikler:**
- Constructor injection
- Interface'ler üzerinden bağımlılık
- Null kontrolü
- Factory pattern ile varsayılan değerler

---

## 5. FACTORY PATTERN

### 5.1 RepositoryFactory

```csharp
namespace YemekTarifiApp.Factory
{
    /// <summary>
    /// Repository nesnelerinin oluşturulması için factory sınıfı.
    /// Factory Pattern uygulayarak nesne oluşturma mantığını merkezileştirir.
    /// </summary>
    public static class RepositoryFactory
    {
        /// <summary>
        /// Repository tipine göre uygun repository nesnesini oluşturur.
        /// </summary>
        /// <param name="type">Repository tipi</param>
        /// <returns>ITarifRepository implementasyonu</returns>
        /// <exception cref="System.ArgumentException">Geçersiz tip için fırlatılır</exception>
        public static ITarifRepository Create(RepositoryType type)
        {
            switch (type)
            {
                case RepositoryType.MySql:
                    return new MySqlTarifRepository();
                case RepositoryType.InMemory:
                    return new InMemoryTarifRepository();
                default:
                    throw new ArgumentException($"Geçersiz repository tipi: {type}");
            }
        }

        /// <summary>
        /// Varsayılan repository tipini oluşturur (MySQL).
        /// </summary>
        /// <returns>Varsayılan ITarifRepository implementasyonu</returns>
        public static ITarifRepository CreateDefault()
        {
            return Create(RepositoryType.MySql);
        }
    }

    /// <summary>
    /// Repository tiplerini tanımlayan enum.
    /// </summary>
    public enum RepositoryType
    {
        MySql,
        InMemory
    }
}
```

**Özellikler:**
- Merkezi nesne oluşturma
- Open/Closed Principle
- Kolay genişletilebilir

---

## 6. EXCEPTION HANDLING

### 6.1 Custom Exception Sınıfları

```csharp
namespace YemekTarifiApp.Exceptions
{
    /// <summary>
    /// AI API çağrıları sırasında oluşan hatalar için özel exception sınıfı.
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// HTTP status code (varsa).
        /// </summary>
        public int? StatusCode { get; }

        /// <summary>
        /// API yanıt içeriği.
        /// </summary>
        public string ResponseContent { get; }

        /// <summary>
        /// ApiException constructor'ı.
        /// </summary>
        /// <param name="message">Hata mesajı</param>
        /// <param name="statusCode">HTTP status code (opsiyonel)</param>
        /// <param name="responseContent">API yanıt içeriği (opsiyonel)</param>
        public ApiException(string message, int? statusCode = null, string responseContent = null)
            : base(message)
        {
            StatusCode = statusCode;
            ResponseContent = responseContent;
        }

        /// <summary>
        /// ApiException constructor'ı (inner exception ile).
        /// </summary>
        /// <param name="message">Hata mesajı</param>
        /// <param name="innerException">İç exception</param>
        public ApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Veritabanı işlemleri sırasında oluşan hatalar için özel exception sınıfı.
    /// </summary>
    public class RepositoryException : Exception
    {
        /// <summary>
        /// İşlem tipi (Insert, Update, Delete, Select).
        /// </summary>
        public string OperationType { get; }

        /// <summary>
        /// RepositoryException constructor'ı.
        /// </summary>
        /// <param name="message">Hata mesajı</param>
        /// <param name="operationType">İşlem tipi</param>
        /// <param name="innerException">İç exception (opsiyonel)</param>
        public RepositoryException(string message, string operationType, Exception innerException = null)
            : base(message, innerException)
        {
            OperationType = operationType;
        }
    }

    /// <summary>
    /// Veri doğrulama hataları için özel exception sınıfı.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Hatalı alan adı.
        /// </summary>
        public string FieldName { get; }

        /// <summary>
        /// ValidationException constructor'ı.
        /// </summary>
        /// <param name="fieldName">Hatalı alan adı</param>
        /// <param name="message">Hata mesajı</param>
        public ValidationException(string fieldName, string message)
            : base(message)
        {
            FieldName = fieldName;
        }
    }
}
```

**Özellikler:**
- Spesifik exception tipleri
- Anlamlı hata mesajları
- Exception hierarchy

---

## 7. VALIDATION HELPER

### 7.1 TarifValidator

```csharp
namespace YemekTarifiApp.Helpers
{
    /// <summary>
    /// Tarif verilerinin doğrulanması için yardımcı sınıf.
    /// Single Responsibility Principle'a uygun olarak sadece validation işlemlerini yapar.
    /// </summary>
    public static class TarifValidator
    {
        /// <summary>
        /// Tarif nesnesinin geçerli olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="tarif">Kontrol edilecek tarif</param>
        /// <exception cref="ValidationException">Tarif geçersizse fırlatılır</exception>
        public static void Validate(TarifResponse tarif)
        {
            if (tarif == null)
                throw new ValidationException("Tarif", "Tarif bilgisi boş olamaz!");

            if (string.IsNullOrWhiteSpace(tarif.TarifAdi))
                throw new ValidationException("TarifAdi", "Tarif adı boş olamaz!");

            if (string.IsNullOrWhiteSpace(tarif.Malzemeler))
                throw new ValidationException("Malzemeler", "Malzemeler listesi boş olamaz!");

            if (string.IsNullOrWhiteSpace(tarif.Yapilis))
                throw new ValidationException("Yapilis", "Yapılış adımları boş olamaz!");

            if (tarif.Kalori < 0)
                throw new ValidationException("Kalori", "Kalori değeri negatif olamaz!");

            if (tarif.Protein < 0)
                throw new ValidationException("Protein", "Protein değeri negatif olamaz!");

            if (tarif.Karbonhidrat < 0)
                throw new ValidationException("Karbonhidrat", "Karbonhidrat değeri negatif olamaz!");
        }

        /// <summary>
        /// Malzeme listesinin geçerli olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="malzemeListesi">Kontrol edilecek malzeme listesi</param>
        /// <returns>Geçerli ise true, aksi halde false</returns>
        public static bool IsValidMalzemeListesi(string malzemeListesi)
        {
            return !string.IsNullOrWhiteSpace(malzemeListesi) && malzemeListesi.Trim().Length >= 3;
        }

        /// <summary>
        /// Dosya yolunun geçerli bir resim dosyası olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="filePath">Kontrol edilecek dosya yolu</param>
        /// <returns>Geçerli resim dosyası ise true, aksi halde false</returns>
        public static bool IsValidImageFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return false;

            string[] validExtensions = { ".jpg", ".jpeg", ".png" };
            string extension = System.IO.Path.GetExtension(filePath)?.ToLower();

            return Array.Exists(validExtensions, ext => ext == extension) && 
                   System.IO.File.Exists(filePath);
        }
    }
}
```

**Özellikler:**
- Single Responsibility Principle
- Static helper metodlar
- Validation logic merkezileştirilmiş

---

## 8. ASYNC/AWAIT KULLANIMI

### 8.1 AI Servis Çağrısı

```csharp
/// <summary>
/// AI kullanarak tarif analizi başlatır.
/// Interface üzerinden çalışarak polymorphism sağlar.
/// </summary>
private async Task AnalizBaslat()
{
    if (string.IsNullOrEmpty(MemoMalzemeler.Text) && string.IsNullOrEmpty(_secilenFotoYolu))
        return;

    BtnTarifBul.Enabled = false;
    BtnTarifBul.Text = "🪄 Otomatik Analiz Ediliyor...";

    try
    {
        // Interface üzerinden metod çağrısı - polymorphism
        _currentTarif = await _aiAsistan.GetTarifOnerisi(MemoMalzemeler.Text, _secilenFotoYolu);

        if (_currentTarif != null)
        {
            LblYemekAdi.Text = "🍴 " + _currentTarif.TarifAdi;
            MemoSonuc.Text = _currentTarif.Yapilis;
            
            // Besin değerlerini renkli kartlara güncelle
            LblKaloriDeger.Text = $"{(int)_currentTarif.Kalori}";
            LblProteinDeger.Text = $"{_currentTarif.Protein:0.#}";
            LblKarbonhidratDeger.Text = $"{_currentTarif.Karbonhidrat:0.#}";
        }
    }
    catch (ApiException ex)
    {
        string message = $"AI Servisi Hatası:\n{ex.Message}";
        if (ex.StatusCode.HasValue)
            message += $"\nHTTP Status: {ex.StatusCode}";
        XtraMessageBox.Show(message, "API Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    catch (ValidationException ex)
    {
        XtraMessageBox.Show($"Doğrulama Hatası:\n{ex.Message}", "Geçersiz Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    catch (Exception ex)
    {
        XtraMessageBox.Show($"Beklenmeyen Hata:\n{ex.Message}", "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    finally
    {
        BtnTarifBul.Enabled = true;
        BtnTarifBul.Text = "🪄 Tarif Bul (AI)";
    }
}
```

**Özellikler:**
- Async/await pattern
- Exception handling
- UI güncellemeleri
- Finally bloğu ile temizlik

---

## 9. XML DOCUMENTATION COMMENTS

### 9.1 Örnek XML Documentation

```csharp
/// <summary>
/// Verilen malzemelere göre Gemini AI kullanarak tarif önerisi alır.
/// IAiAsistan interface'inden gelen metodu implement eder.
/// </summary>
/// <param name="malzemeListesi">Kullanılabilir malzemelerin listesi</param>
/// <param name="imagePath">Opsiyonel: Malzeme fotoğrafının dosya yolu</param>
/// <returns>Önerilen tarif bilgileri. Null dönmez, hata durumunda exception fırlatır.</returns>
/// <exception cref="System.Exception">API hatası veya geçersiz yanıt durumunda fırlatılır</exception>
public async Task<TarifResponse> GetTarifOnerisi(string malzemeListesi, string imagePath = null)
{
    // Implementation
}
```

**Özellikler:**
- Tüm public üyelere XML comments
- Parametre dokümantasyonu
- Return değeri dokümantasyonu
- Exception dokümantasyonu

---

## 10. SONUÇ

Bu kod örnekleri, projede kullanılan önemli OOP prensiplerini ve design pattern'leri göstermektedir:

- ✅ **Interface Kullanımı:** Polymorphism sağlar
- ✅ **Inheritance:** Code reusability sağlar
- ✅ **Dependency Injection:** Test edilebilirlik artar
- ✅ **Factory Pattern:** Merkezi nesne oluşturma
- ✅ **Exception Handling:** Güvenli hata yönetimi
- ✅ **Validation:** Veri bütünlüğü sağlar
- ✅ **Async/Await:** Performanslı asenkron işlemler
- ✅ **XML Documentation:** Kod dokümantasyonu

---

**Hazırlama Tarihi:** 2025-01-XX  
**Versiyon:** 1.0


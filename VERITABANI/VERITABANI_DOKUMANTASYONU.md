# VERİTABANI TASARIM DOKÜMANTASYONU

## Genel Bilgiler

**Veritabanı Adı:** yemek_tarifi_db (opsiyonel)  
**VTYS:** MySQL  
**Karakter Seti:** utf8mb4  
**Collation:** utf8mb4_unicode_ci  
**Engine:** InnoDB

---

## Tablo Yapısı

### Tablo: `tarif_favori`

Kullanıcıların favori tariflerini saklayan ana tablo.

#### Alan Tanımları

| Alan Adı | Veri Tipi | Null | Varsayılan | Açıklama |
|----------|-----------|------|------------|----------|
| `id` | INT | NO | AUTO_INCREMENT | Birincil anahtar (Primary Key) |
| `baslik` | VARCHAR(255) | NO | - | Tarif başlığı/adı |
| `malzemeler` | TEXT | NO | - | Tarif için gerekli malzemeler listesi |
| `tarif_metin` | TEXT | NO | - | Tarifin yapılış adımları |
| `kalori` | DOUBLE | NO | 0 | Kalori değeri (kcal) |
| `protein` | DOUBLE | NO | 0 | Protein değeri (gram) |
| `karbonhidrat` | DOUBLE | NO | 0 | Karbonhidrat değeri (gram) |
| `eklenme_tarihi` | DATETIME | NO | CURRENT_TIMESTAMP | Kayıt eklenme tarihi |

#### İndeksler

- **PRIMARY KEY:** `id`
- **INDEX:** `idx_baslik` - Baslik alanı üzerinde arama performansı için
- **INDEX:** `idx_eklenme_tarihi` - Tarih sıralaması için

#### Kısıtlamalar

- `baslik` alanı benzersiz olmalı (uygulama seviyesinde kontrol edilir)
- Tüm besin değerleri (kalori, protein, karbonhidrat) negatif olamaz (uygulama seviyesinde kontrol edilir)

---

## İlişkiler

Şu an için tek tablo kullanılmaktadır. Gelecekte genişletilebilir:

- **Kullanıcı Tablosu:** Kullanıcı bazlı favori yönetimi için
- **Kategori Tablosu:** Tarif kategorileri için
- **Yorum Tablosu:** Tarif yorumları için

---

## CRUD İşlemleri

### CREATE (Ekleme)

```sql
INSERT INTO tarif_favori 
(baslik, malzemeler, tarif_metin, kalori, protein, karbonhidrat, eklenme_tarihi)
VALUES 
('Tarif Adı', 'Malzemeler', 'Yapılış', 250.5, 15.2, 5.8, NOW());
```

### READ (Okuma)

```sql
-- Tüm favorileri getir (tarihe göre sıralı)
SELECT baslik, malzemeler, tarif_metin, kalori, protein, karbonhidrat 
FROM tarif_favori 
ORDER BY eklenme_tarihi DESC;

-- Belirli bir tarifi getir
SELECT * FROM tarif_favori WHERE baslik = 'Tarif Adı';
```

### UPDATE (Güncelleme)

```sql
UPDATE tarif_favori 
SET malzemeler = 'Yeni Malzemeler', kalori = 300.0 
WHERE baslik = 'Tarif Adı';
```

### DELETE (Silme)

```sql
DELETE FROM tarif_favori WHERE baslik = 'Tarif Adı';
```

---

## Veri Modeli

```
tarif_favori
├── id (PK, Auto Increment)
├── baslik (Unique, Indexed)
├── malzemeler
├── tarif_metin
├── kalori
├── protein
├── karbonhidrat
└── eklenme_tarihi (Indexed)
```

---

## Performans Notları

1. **İndeksler:** `baslik` ve `eklenme_tarihi` alanları üzerinde indeksler mevcuttur
2. **TEXT Alanları:** `malzemeler` ve `tarif_metin` TEXT tipinde, büyük veri saklayabilir
3. **Tarih Sıralaması:** Varsayılan olarak en yeni kayıtlar önce gelir

---

## Yedekleme ve Geri Yükleme

### Yedekleme
```bash
mysqldump -u kullanici_adi -p yemek_tarifi_db > yedek.sql
```

### Geri Yükleme
```bash
mysql -u kullanici_adi -p yemek_tarifi_db < yedek.sql
```

---

## Bağlantı Dizesi

App.config dosyasında şu şekilde tanımlanmalıdır:

```xml
<connectionStrings>
  <add name="MySqlConnectionString" 
       connectionString="Server=localhost;Database=yemek_tarifi_db;Uid=kullanici;Pwd=sifre;CharSet=utf8mb4;" />
</connectionStrings>
```

---

## Gelecek Geliştirmeler

1. **Kullanıcı Tablosu:** Çoklu kullanıcı desteği
2. **Kategori Sistemi:** Tarif kategorileri
3. **Resim Saklama:** Tarif fotoğrafları için BLOB veya dosya yolu
4. **Arama Özelliği:** Full-text search için indeksler
5. **Versiyonlama:** Tarif değişiklik geçmişi


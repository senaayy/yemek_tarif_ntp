-- =============================================
-- Yemek Tarifi Öneri Uygulaması
-- Veritabanı Şema Tanımları
-- =============================================

-- Veritabanı oluşturma (opsiyonel)
-- CREATE DATABASE IF NOT EXISTS yemek_tarifi_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
-- USE yemek_tarifi_db;

-- =============================================
-- Tablo: tarif_favori
-- Açıklama: Kullanıcıların favori tariflerini saklar
-- =============================================

CREATE TABLE IF NOT EXISTS `tarif_favori` (
  `id` INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Birincil anahtar',
  `baslik` VARCHAR(255) NOT NULL COMMENT 'Tarif başlığı/adı',
  `malzemeler` TEXT NOT NULL COMMENT 'Tarif için gerekli malzemeler listesi',
  `tarif_metin` TEXT NOT NULL COMMENT 'Tarifin yapılış adımları',
  `kalori` DOUBLE NOT NULL DEFAULT 0 COMMENT 'Kalori değeri (kcal)',
  `protein` DOUBLE NOT NULL DEFAULT 0 COMMENT 'Protein değeri (gram)',
  `karbonhidrat` DOUBLE NOT NULL DEFAULT 0 COMMENT 'Karbonhidrat değeri (gram)',
  `eklenme_tarihi` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Kayıt eklenme tarihi',
  
  -- İndeksler
  INDEX `idx_baslik` (`baslik`),
  INDEX `idx_eklenme_tarihi` (`eklenme_tarihi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Favori tarifler tablosu';

-- =============================================
-- Örnek Veri Ekleme (Opsiyonel - Test için)
-- =============================================

-- INSERT INTO `tarif_favori` 
-- (`baslik`, `malzemeler`, `tarif_metin`, `kalori`, `protein`, `karbonhidrat`) 
-- VALUES 
-- (
--   'Mantarlı Omlet',
--   '2 yumurta, 100g mantar, 1 yemek kaşığı zeytinyağı, tuz, karabiber',
--   '1. Mantarları doğrayın ve tavada soteleyin\n2. Yumurtaları çırpın\n3. Mantarları yumurtalara ekleyin\n4. Tavada pişirin',
--   250.5,
--   15.2,
--   5.8
-- );

-- =============================================
-- Veritabanı Yedekleme Komutu (MySQL)
-- =============================================
-- mysqldump -u kullanici_adi -p yemek_tarifi_db > yedek.sql

-- =============================================
-- Veritabanı Geri Yükleme Komutu (MySQL)
-- =============================================
-- mysql -u kullanici_adi -p yemek_tarifi_db < yedek.sql


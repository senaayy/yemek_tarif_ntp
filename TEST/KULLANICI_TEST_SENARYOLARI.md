# KULLANICI TEST SENARYOLARI

Bu doküman, son kullanıcıların uygulamayı test etmesi için hazırlanmış test senaryolarını içermektedir.

---

## Test Öncesi Hazırlık

1. Uygulama kurulu ve çalışır durumda olmalı
2. Internet bağlantısı aktif olmalı
3. Veritabanı bağlantısı yapılandırılmış olmalı
4. Gemini API key App.config'de tanımlı olmalı

---

## Senaryo 1: İlk Kullanım - Tarif Önerisi

### Adımlar:
1. Uygulamayı başlatın
2. Ana ekranda "Malzemeler" alanına şunları yazın:
   ```
   domates, soğan, sarımsak, zeytinyağı, tuz, karabiber
   ```
3. "🪄 Tarif Bul (AI)" butonuna tıklayın
4. Bekleyin (5-10 saniye)

### Beklenen Sonuç:
- ✅ Buton metni "🪄 Otomatik Analiz Ediliyor..." olarak değişir
- ✅ Bir süre sonra tarif adı görüntülenir (örn: "Domatesli Soğan Yemeği")
- ✅ Besin değerleri kartlarında kalori, protein, karbonhidrat değerleri görünür
- ✅ "Yapılış" alanında tarif adımları görünür

### Değerlendirme:
- [ ] Tarif başarıyla oluşturuldu mu?
- [ ] Besin değerleri görüntüleniyor mu?
- [ ] Yapılış adımları okunabilir mi?

---

## Senaryo 2: Fotoğraf ile Tarif Önerisi

### Adımlar:
1. Uygulamayı başlatın
2. "Fotoğraf Seç" butonuna tıklayın
3. Bir yemek veya malzeme fotoğrafı seçin (.jpg veya .png)
4. Fotoğraf yüklendikten sonra otomatik analiz başlar

### Alternatif: Drag & Drop
1. Bir resim dosyasını sürükleyip "Resim Yükleme" alanına bırakın

### Beklenen Sonuç:
- ✅ Fotoğraf yüklenir ve görüntülenir
- ✅ Otomatik olarak AI analizi başlar
- ✅ Tarif önerisi gösterilir

### Değerlendirme:
- [ ] Fotoğraf başarıyla yüklendi mi?
- [ ] Drag & drop çalışıyor mu?
- [ ] AI analizi başarılı mı?

---

## Senaryo 3: Favori Ekleme

### Adımlar:
1. Senaryo 1 veya 2'yi tamamlayın (bir tarif oluşturun)
2. "⭐ Favori Ekle" butonuna tıklayın

### Beklenen Sonuç:
- ✅ "Tarif başarıyla favorilere eklendi!" mesajı görünür
- ✅ Tarif veritabanına kaydedilir

### Negatif Test:
1. Tarif oluşturmadan "Favori Ekle" butonuna tıklayın
2. **Beklenen:** "Önce bir tarif oluşturmalısınız!" uyarısı

### Değerlendirme:
- [ ] Favori başarıyla eklendi mi?
- [ ] Uyarı mesajı doğru mu?

---

## Senaryo 4: Favori Listeleme

### Adımlar:
1. En az bir favori tarif ekleyin (Senaryo 3)
2. "📋 Favori Listesi" butonuna tıklayın
3. Açılan pencerede listeden bir tarif seçin

### Beklenen Sonuç:
- ✅ Favori tarifler penceresi açılır
- ✅ Tüm favori tarifler listelenir
- ✅ Bir tarif seçildiğinde sağ tarafta detayları görünür:
  - Malzemeler
  - Yapılış adımları
  - Besin değerleri

### Değerlendirme:
- [ ] Favori listesi açılıyor mu?
- [ ] Tüm favoriler görünüyor mu?
- [ ] Detaylar doğru gösteriliyor mu?

---

## Senaryo 5: Favori Silme

### Adımlar:
1. Senaryo 4'ü tamamlayın (Favori listesi açık)
2. Listeden bir tarif seçin
3. "🗑️ Sil" butonuna tıklayın
4. Onay mesajında "Evet" seçin

### Beklenen Sonuç:
- ✅ Onay mesajı görünür: "[Tarif Adı] favorilerden silinsin mi?"
- ✅ "Evet" seçildiğinde tarif silinir
- ✅ "Tarif başarıyla silindi!" mesajı görünür
- ✅ Liste güncellenir (silinen tarif listeden kalkar)

### Negatif Test:
1. Onay mesajında "Hayır" seçin
2. **Beklenen:** Tarif silinmez, liste aynı kalır

### Değerlendirme:
- [ ] Silme işlemi başarılı mı?
- [ ] Onay mesajı doğru mu?
- [ ] Liste güncelleniyor mu?

---

## Senaryo 6: Tarif Kopyalama

### Adımlar:
1. Bir tarif oluşturun (Senaryo 1 veya 2)
2. "📋 Kopyala" butonuna tıklayın
3. Notepad veya Word'e yapıştırın (Ctrl+V)

### Beklenen Sonuç:
- ✅ Yapılış adımları panoya kopyalanır
- ✅ Yapıştırıldığında metin görünür

### Değerlendirme:
- [ ] Kopyalama çalışıyor mu?
- [ ] Metin doğru kopyalanıyor mu?

---

## Senaryo 7: Form Temizleme

### Adımlar:
1. Bir tarif oluşturun ve formu doldurun
2. "🗑️ Temizle" butonuna tıklayın

### Beklenen Sonuç:
- ✅ Tüm alanlar temizlenir:
  - Malzemeler alanı boşalır
  - Yapılış alanı boşalır
  - Tarif adı "Yemek Adı" olur
  - Besin değerleri sıfırlanır (0)
  - Fotoğraf kaldırılır

### Değerlendirme:
- [ ] Tüm alanlar temizlendi mi?
- [ ] Form başlangıç durumuna döndü mü?

---

## Senaryo 8: Hata Senaryoları

### 8.1 Internet Bağlantısı Yok

**Adımlar:**
1. Internet bağlantısını kesin
2. Tarif önerisi yapmayı deneyin

**Beklenen Sonuç:**
- ✅ Hata mesajı gösterilir: "API Hatası" veya "Internet bağlantısı yok"

### 8.2 Geçersiz Resim Formatı

**Adımlar:**
1. "Fotoğraf Seç" butonuna tıklayın
2. .txt veya .pdf gibi geçersiz bir dosya seçmeyi deneyin

**Beklenen Sonuç:**
- ✅ Sadece .jpg, .jpeg, .png dosyaları seçilebilir olmalı

### 8.3 Boş Malzeme Listesi

**Adımlar:**
1. Malzemeler alanını boş bırakın
2. Fotoğraf da seçmeyin
3. "Tarif Bul" butonuna tıklayın

**Beklenen Sonuç:**
- ✅ Buton çalışmaz veya uyarı mesajı gösterilir

---

## Senaryo 9: Kullanılabilirlik Testi

### 9.1 Arayüz Değerlendirmesi

**Sorular:**
- [ ] Butonlar kolay bulunabilir mi?
- [ ] Renkler uyumlu mu?
- [ ] Yazılar okunabilir mi?
- [ ] Form düzeni mantıklı mı?

### 9.2 Kullanım Kolaylığı

**Sorular:**
- [ ] İlk kullanımda ne yapacağım anlaşılıyor mu?
- [ ] Hata mesajları anlaşılır mı?
- [ ] İşlemler sezgisel mi?

### 9.3 Performans

**Sorular:**
- [ ] Uygulama hızlı açılıyor mu?
- [ ] Tarif önerisi makul sürede geliyor mu? (5-15 saniye)
- [ ] Form yanıtları hızlı mı?

---

## Test Sonuç Formu

| Senaryo | Durum | Notlar | Tarih |
|---------|-------|--------|-------|
| Senaryo 1: İlk Kullanım | ☐ PASS ☐ FAIL | | |
| Senaryo 2: Fotoğraf ile | ☐ PASS ☐ FAIL | | |
| Senaryo 3: Favori Ekleme | ☐ PASS ☐ FAIL | | |
| Senaryo 4: Favori Listeleme | ☐ PASS ☐ FAIL | | |
| Senaryo 5: Favori Silme | ☐ PASS ☐ FAIL | | |
| Senaryo 6: Kopyalama | ☐ PASS ☐ FAIL | | |
| Senaryo 7: Temizleme | ☐ PASS ☐ FAIL | | |
| Senaryo 8: Hata Senaryoları | ☐ PASS ☐ FAIL | | |
| Senaryo 9: Kullanılabilirlik | ☐ PASS ☐ FAIL | | |

---

## Genel Değerlendirme

**Test Edilen:** _________________  
**Test Tarihi:** _________________  
**Genel Not:** _________________  

**Güçlü Yönler:**
- 
- 

**İyileştirme Önerileri:**
- 
- 

---

## Notlar

- Her senaryo bağımsız test edilebilir
- Senaryolar sırayla veya rastgele çalıştırılabilir
- Hata bulunduğunda detaylı not alınmalı
- Ekran görüntüleri alınabilir (opsiyonel)


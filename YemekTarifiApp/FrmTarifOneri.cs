using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Modul.Service;
using YemekTarifiApp.Models;

namespace YemekTarifiApp
{
    public partial class FrmTarifOneri : XtraForm
    {
        private SGeminiAsistan _geminiAsistan;
        private MySqlTarifRepository _tarifRepository; // Veritabanı sınıfı
        private TarifResponse _currentTarif;
        private string _secilenFotoYolu = null;

        public FrmTarifOneri()
        {
            InitializeComponent();
            
            // Modern DevExpress tema uygula
            try
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");
            }
            catch
            {
                // Tema bulunamazsa varsayılan tema kullanılır
            }
            
            _geminiAsistan = new SGeminiAsistan();
            _tarifRepository = new MySqlTarifRepository(); // Nesneyi oluşturduk
            
            // Besin değeri kartlarını başlangıç değerleriyle başlat
            LblKaloriDeger.Text = "0";
            LblProteinDeger.Text = "0";
            LblKarbonhidratDeger.Text = "0";
            
            // Görünüm iyileştirmeleri uygula
            ApplyModernStyling();
        }
        
        private void ApplyModernStyling()
        {
            // Form arka plan rengi
            this.BackColor = Color.FromArgb(245, 245, 250);
            
            // Ana buton (Tarif Bul) - Mavi renk ve hover efekti
            BtnTarifBul.Appearance.BackColor = Color.FromArgb(0, 120, 215);
            BtnTarifBul.Appearance.ForeColor = Color.White;
            BtnTarifBul.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnTarifBul.AppearanceHovered.BackColor = Color.FromArgb(0, 100, 200);
            BtnTarifBul.AppearanceHovered.Options.UseBackColor = true;
            BtnTarifBul.AppearancePressed.BackColor = Color.FromArgb(0, 80, 180);
            BtnTarifBul.AppearancePressed.Options.UseBackColor = true;
            BtnTarifBul.LookAndFeel.UseDefaultLookAndFeel = false;
            BtnTarifBul.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            
            // Favori Ekle butonu - Altın/turuncu renk
            BtnFavoriEkle.Appearance.BackColor = Color.FromArgb(255, 193, 7);
            BtnFavoriEkle.Appearance.ForeColor = Color.White;
            BtnFavoriEkle.AppearanceHovered.BackColor = Color.FromArgb(255, 180, 0);
            BtnFavoriEkle.AppearanceHovered.Options.UseBackColor = true;
            BtnFavoriEkle.AppearancePressed.BackColor = Color.FromArgb(230, 170, 0);
            BtnFavoriEkle.AppearancePressed.Options.UseBackColor = true;
            
            // Favori Listesi butonu - Mor renk
            BtnFavoriListesi.Appearance.BackColor = Color.FromArgb(156, 39, 176);
            BtnFavoriListesi.Appearance.ForeColor = Color.White;
            BtnFavoriListesi.AppearanceHovered.BackColor = Color.FromArgb(142, 36, 170);
            BtnFavoriListesi.AppearanceHovered.Options.UseBackColor = true;
            
            // Fotoğraf Seç butonu - Yeşil renk
            BtnFotoSec.Appearance.BackColor = Color.FromArgb(76, 175, 80);
            BtnFotoSec.Appearance.ForeColor = Color.White;
            BtnFotoSec.AppearanceHovered.BackColor = Color.FromArgb(69, 160, 73);
            BtnFotoSec.AppearanceHovered.Options.UseBackColor = true;
            
            // Temizle butonu - Gri renk
            BtnTemizle.Appearance.BackColor = Color.FromArgb(158, 158, 158);
            BtnTemizle.Appearance.ForeColor = Color.White;
            BtnTemizle.AppearanceHovered.BackColor = Color.FromArgb(140, 140, 140);
            BtnTemizle.AppearanceHovered.Options.UseBackColor = true;
            
            // Kopyala butonu - Teal renk
            BtnKopyala.Appearance.BackColor = Color.FromArgb(0, 150, 136);
            BtnKopyala.Appearance.ForeColor = Color.White;
            BtnKopyala.AppearanceHovered.BackColor = Color.FromArgb(0, 130, 120);
            BtnKopyala.AppearanceHovered.Options.UseBackColor = true;
            
            // MemoEdit stilleri
            MemoMalzemeler.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            MemoMalzemeler.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            MemoMalzemeler.Properties.Appearance.BorderColor = Color.FromArgb(200, 200, 200);
            MemoMalzemeler.Properties.Appearance.BackColor = Color.White;
            
            MemoSonuc.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            MemoSonuc.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            MemoSonuc.Properties.Appearance.BorderColor = Color.FromArgb(200, 200, 200);
            MemoSonuc.Properties.Appearance.BackColor = Color.White;
            
            // Panel stilleri - Gradient ve border
            PanelKalori.Appearance.BackColor2 = Color.FromArgb(255, 120, 120);
            PanelKalori.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            PanelKalori.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            PanelKalori.Appearance.BorderColor = Color.FromArgb(220, 50, 50);
            
            PanelProtein.Appearance.BackColor2 = Color.FromArgb(100, 150, 255);
            PanelProtein.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            PanelProtein.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            PanelProtein.Appearance.BorderColor = Color.FromArgb(40, 100, 220);
            
            PanelKarbonhidrat.Appearance.BackColor2 = Color.FromArgb(100, 200, 100);
            PanelKarbonhidrat.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            PanelKarbonhidrat.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            PanelKarbonhidrat.Appearance.BorderColor = Color.FromArgb(50, 150, 50);
            
            // PictureEdit border
            PicMalzeme.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            PicMalzeme.Properties.Appearance.BorderColor = Color.FromArgb(200, 200, 200);
            
            // Label font iyileştirmesi
            LblYemekAdi.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            
            // Besin değeri label'larını siyah yap (okunabilirlik için)
            LblKaloriBaslik.Appearance.ForeColor = Color.Black;
            LblKaloriDeger.Appearance.ForeColor = Color.Black;
            LblProteinBaslik.Appearance.ForeColor = Color.Black;
            LblProteinDeger.Appearance.ForeColor = Color.Black;
            LblKarbonhidratBaslik.Appearance.ForeColor = Color.Black;
            LblKarbonhidratDeger.Appearance.ForeColor = Color.Black;
        }

        private async Task AnalizBaslat()
        {
            if (string.IsNullOrEmpty(MemoMalzemeler.Text) && string.IsNullOrEmpty(_secilenFotoYolu))
                return;

            BtnTarifBul.Enabled = false;
            BtnTarifBul.Text = "🪄 Otomatik Analiz Ediliyor...";

            try
            {
                _currentTarif = await _geminiAsistan.GetTarifOnerisi(MemoMalzemeler.Text, _secilenFotoYolu);

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
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BtnTarifBul.Enabled = true;
                BtnTarifBul.Text = "🪄 Tarif Bul (AI)";
            }
        }

        private async void BtnTarifBul_AsyncClick(object sender, EventArgs e) => await AnalizBaslat();

        private async void PicMalzeme_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files?.Length > 0)
            {
                string path = files[0];
                string ext = Path.GetExtension(path).ToLower();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                {
                    _secilenFotoYolu = path;
                    PicMalzeme.Image = Image.FromFile(_secilenFotoYolu);
                    await AnalizBaslat();
                }
            }
        }

        private void PicMalzeme_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private async void BtnFotoSec_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _secilenFotoYolu = ofd.FileName;
                    PicMalzeme.Image = Image.FromFile(_secilenFotoYolu);
                    await AnalizBaslat();
                }
            }
        }

        // --- FAVORİLERE EKLEME ---
        private void BtnFavoriEkle_Click(object sender, EventArgs e)
        {
            if (_currentTarif == null)
            {
                XtraMessageBox.Show("Önce bir tarif oluşturmalısınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _tarifRepository.FavoriEkle(_currentTarif);
                XtraMessageBox.Show("Tarif başarıyla favorilere eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            MemoMalzemeler.Text = ""; MemoSonuc.Text = "";
            _secilenFotoYolu = null; PicMalzeme.Image = null;
            LblYemekAdi.Text = "Yemek Adı";
            
            // Besin değeri kartlarını sıfırla
            LblKaloriDeger.Text = "0";
            LblProteinDeger.Text = "0";
            LblKarbonhidratDeger.Text = "0";
            
            _currentTarif = null;
        }

        private void BtnKopyala_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MemoSonuc.Text)) Clipboard.SetText(MemoSonuc.Text);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _geminiAsistan?.Dispose();
        }

        private void FrmTarifOneri_Load(object sender, EventArgs e)
        {

        }

        private void MemoSonuc_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void BtnFavoriListesi_Click(object sender, EventArgs e)
        {
            using (FrmFavoriler frm = new FrmFavoriler())
            {
                frm.ShowDialog();
            }
        }
    }
}
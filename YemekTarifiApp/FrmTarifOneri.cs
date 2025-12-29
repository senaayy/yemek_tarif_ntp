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
            _geminiAsistan = new SGeminiAsistan();
            _tarifRepository = new MySqlTarifRepository(); // Nesneyi oluşturduk
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
                    ProgKalori.Position = (int)_currentTarif.Kalori;
                    LblBilgi.Text = $"Kalori: {(int)_currentTarif.Kalori} kcal | P: {_currentTarif.Protein}g | K: {_currentTarif.Karbonhidrat}g";
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
            MemoMalzemeler.Text = ""; MemoSonuc.Text = ""; ProgKalori.Position = 0;
            _secilenFotoYolu = null; PicMalzeme.Image = null;
            LblYemekAdi.Text = "Yemek Adı"; LblBilgi.Text = "Bilgi bekleniyor...";
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
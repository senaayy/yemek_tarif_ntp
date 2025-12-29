using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Modul.Service;
using YemekTarifiApp.Models;

namespace YemekTarifiApp
{
    public partial class FrmFavoriler : XtraForm
    {
        private MySqlTarifRepository _repo = new MySqlTarifRepository();
        private List<TarifResponse> _favoriler;

        public FrmFavoriler()
        {
            InitializeComponent();
        }

        // Form açıldığında verileri yükle
        private void FrmFavoriler_Load(object sender, EventArgs e)
        {
            VerileriGuncelle();
        }

        private void VerileriGuncelle()
        {
            try
            {
                // Veritabanından tüm favorileri çek
                _favoriler = _repo.GetTumFavoriler();
                LstTarifler.DataSource = _favoriler;
                LstTarifler.DisplayMember = "TarifAdi";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        // Listeden bir tarif seçildiğinde sağ tarafta detayları göster
        private void LstTarifler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LstTarifler.SelectedItem is TarifResponse secilen)
            {
                MemoDetay.Text = $"--- MALZEMELER ---\r\n{secilen.Malzemeler}\r\n\r\n--- YAPILIŞ ---\r\n{secilen.Yapilis}";
                LblNutri.Text = $"Besin Değerleri: {secilen.Kalori} kcal | Protein: {secilen.Protein}g | Karb: {secilen.Karbonhidrat}g";
            }
        }

        // Seçili tarifi veritabanından sil
        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (LstTarifler.SelectedItem is TarifResponse secilen)
            {
                var onay = XtraMessageBox.Show($"{secilen.TarifAdi} favorilerden silinsin mi?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (onay == DialogResult.Yes)
                {
                    _repo.FavoriSil(secilen.TarifAdi);
                    VerileriGuncelle(); // Listeyi yenile
                    MemoDetay.Text = "";
                    LblNutri.Text = "Tarif silindi.";
                }
            }
        }
    }
}
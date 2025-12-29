namespace YemekTarifiApp
{
    partial class FrmTarifOneri
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.MemoMalzemeler = new DevExpress.XtraEditors.MemoEdit();
            this.BtnTarifBul = new DevExpress.XtraEditors.SimpleButton();
            this.MemoSonuc = new DevExpress.XtraEditors.MemoEdit();
            this.LblYemekAdi = new DevExpress.XtraEditors.LabelControl();
            this.ProgKalori = new DevExpress.XtraEditors.ProgressBarControl();
            this.LblBilgi = new DevExpress.XtraEditors.LabelControl();
            this.BtnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.BtnKopyala = new DevExpress.XtraEditors.SimpleButton();
            this.PicMalzeme = new DevExpress.XtraEditors.PictureEdit();
            this.BtnFotoSec = new DevExpress.XtraEditors.SimpleButton();
            this.BtnFavoriEkle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.MemoMalzemeler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoSonuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgKalori.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicMalzeme.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MemoMalzemeler
            // 
            this.MemoMalzemeler.Location = new System.Drawing.Point(12, 12);
            this.MemoMalzemeler.Name = "MemoMalzemeler";
            this.MemoMalzemeler.Properties.NullValuePrompt = "Malzemeleri yazın veya sürükleyin...";
            this.MemoMalzemeler.Size = new System.Drawing.Size(460, 80);
            this.MemoMalzemeler.TabIndex = 10;
            // 
            // BtnTarifBul
            // 
            this.BtnTarifBul.Location = new System.Drawing.Point(12, 98);
            this.BtnTarifBul.Name = "BtnTarifBul";
            this.BtnTarifBul.Size = new System.Drawing.Size(460, 40);
            this.BtnTarifBul.TabIndex = 9;
            this.BtnTarifBul.Text = "🪄 Tarif Bul (AI)";
            this.BtnTarifBul.Click += new System.EventHandler(this.BtnTarifBul_AsyncClick);
            // 
            // MemoSonuc
            // 
            this.MemoSonuc.Location = new System.Drawing.Point(12, 180);
            this.MemoSonuc.Name = "MemoSonuc";
            this.MemoSonuc.Properties.ReadOnly = true;
            this.MemoSonuc.Size = new System.Drawing.Size(460, 200);
            this.MemoSonuc.TabIndex = 7;
            this.MemoSonuc.EditValueChanged += new System.EventHandler(this.MemoSonuc_EditValueChanged);
            // 
            // LblYemekAdi
            // 
            this.LblYemekAdi.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.LblYemekAdi.Appearance.Options.UseFont = true;
            this.LblYemekAdi.Location = new System.Drawing.Point(12, 150);
            this.LblYemekAdi.Name = "LblYemekAdi";
            this.LblYemekAdi.Size = new System.Drawing.Size(90, 21);
            this.LblYemekAdi.TabIndex = 8;
            this.LblYemekAdi.Text = "Yemek Adı";
            // 
            // ProgKalori
            // 
            this.ProgKalori.Location = new System.Drawing.Point(12, 390);
            this.ProgKalori.Name = "ProgKalori";
            this.ProgKalori.Properties.Maximum = 1500;
            this.ProgKalori.Size = new System.Drawing.Size(693, 18);
            this.ProgKalori.TabIndex = 6;
            // 
            // LblBilgi
            // 
            this.LblBilgi.Location = new System.Drawing.Point(12, 415);
            this.LblBilgi.Name = "LblBilgi";
            this.LblBilgi.Size = new System.Drawing.Size(97, 16);
            this.LblBilgi.TabIndex = 5;
            this.LblBilgi.Text = "Bilgi bekleniyor...";
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.Location = new System.Drawing.Point(12, 445);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(340, 35);
            this.BtnTemizle.TabIndex = 4;
            this.BtnTemizle.Text = "Temizle";
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // BtnKopyala
            // 
            this.BtnKopyala.Location = new System.Drawing.Point(365, 445);
            this.BtnKopyala.Name = "BtnKopyala";
            this.BtnKopyala.Size = new System.Drawing.Size(340, 35);
            this.BtnKopyala.TabIndex = 3;
            this.BtnKopyala.Text = "Tarifi Kopyala";
            this.BtnKopyala.Click += new System.EventHandler(this.BtnKopyala_Click);
            // 
            // PicMalzeme
            // 
            this.PicMalzeme.AllowDrop = true;
            this.PicMalzeme.Location = new System.Drawing.Point(485, 12);
            this.PicMalzeme.Name = "PicMalzeme";
            this.PicMalzeme.Properties.NullText = "Resmi Buraya Sürükle";
            this.PicMalzeme.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.PicMalzeme.Size = new System.Drawing.Size(220, 160);
            this.PicMalzeme.TabIndex = 2;
            this.PicMalzeme.DragDrop += new System.Windows.Forms.DragEventHandler(this.PicMalzeme_DragDrop);
            this.PicMalzeme.DragEnter += new System.Windows.Forms.DragEventHandler(this.PicMalzeme_DragEnter);
            // 
            // BtnFotoSec
            // 
            this.BtnFotoSec.Location = new System.Drawing.Point(485, 180);
            this.BtnFotoSec.Name = "BtnFotoSec";
            this.BtnFotoSec.Size = new System.Drawing.Size(220, 30);
            this.BtnFotoSec.TabIndex = 1;
            this.BtnFotoSec.Text = "📷 Fotoğraf Seç";
            this.BtnFotoSec.Click += new System.EventHandler(this.BtnFotoSec_Click);
            // 
            // BtnFavoriEkle
            // 
            this.BtnFavoriEkle.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.BtnFavoriEkle.Appearance.Options.UseFont = true;
            this.BtnFavoriEkle.Location = new System.Drawing.Point(12, 490);
            this.BtnFavoriEkle.Name = "BtnFavoriEkle";
            this.BtnFavoriEkle.Size = new System.Drawing.Size(693, 40);
            this.BtnFavoriEkle.TabIndex = 0;
            this.BtnFavoriEkle.Text = "⭐ Favorilere Ekle";
            this.BtnFavoriEkle.Click += new System.EventHandler(this.BtnFavoriEkle_Click);
            // 
            // FrmTarifOneri
            // 
            this.ClientSize = new System.Drawing.Size(720, 545);
            this.Controls.Add(this.BtnFavoriEkle);
            this.Controls.Add(this.BtnFotoSec);
            this.Controls.Add(this.PicMalzeme);
            this.Controls.Add(this.BtnKopyala);
            this.Controls.Add(this.BtnTemizle);
            this.Controls.Add(this.LblBilgi);
            this.Controls.Add(this.ProgKalori);
            this.Controls.Add(this.MemoSonuc);
            this.Controls.Add(this.LblYemekAdi);
            this.Controls.Add(this.BtnTarifBul);
            this.Controls.Add(this.MemoMalzemeler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmTarifOneri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AI Yemek Tarifi Asistanı";
            this.Load += new System.EventHandler(this.FrmTarifOneri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MemoMalzemeler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoSonuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgKalori.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicMalzeme.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DevExpress.XtraEditors.MemoEdit MemoMalzemeler;
        private DevExpress.XtraEditors.SimpleButton BtnTarifBul;
        private DevExpress.XtraEditors.MemoEdit MemoSonuc;
        private DevExpress.XtraEditors.LabelControl LblYemekAdi;
        private DevExpress.XtraEditors.ProgressBarControl ProgKalori;
        private DevExpress.XtraEditors.LabelControl LblBilgi;
        private DevExpress.XtraEditors.SimpleButton BtnTemizle;
        private DevExpress.XtraEditors.SimpleButton BtnKopyala;
        private DevExpress.XtraEditors.PictureEdit PicMalzeme;
        private DevExpress.XtraEditors.SimpleButton BtnFotoSec;
        private DevExpress.XtraEditors.SimpleButton BtnFavoriEkle;
    }
}
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
            this.BtnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.BtnKopyala = new DevExpress.XtraEditors.SimpleButton();
            this.PicMalzeme = new DevExpress.XtraEditors.PictureEdit();
            this.BtnFotoSec = new DevExpress.XtraEditors.SimpleButton();
            this.BtnFavoriEkle = new DevExpress.XtraEditors.SimpleButton();
            this.BtnFavoriListesi = new DevExpress.XtraEditors.SimpleButton();
            this.PanelKalori = new DevExpress.XtraEditors.PanelControl();
            this.LblKaloriDeger = new DevExpress.XtraEditors.LabelControl();
            this.LblKaloriBaslik = new DevExpress.XtraEditors.LabelControl();
            this.PanelProtein = new DevExpress.XtraEditors.PanelControl();
            this.LblProteinDeger = new DevExpress.XtraEditors.LabelControl();
            this.LblProteinBaslik = new DevExpress.XtraEditors.LabelControl();
            this.PanelKarbonhidrat = new DevExpress.XtraEditors.PanelControl();
            this.LblKarbonhidratDeger = new DevExpress.XtraEditors.LabelControl();
            this.LblKarbonhidratBaslik = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.MemoMalzemeler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoSonuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicMalzeme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelKalori)).BeginInit();
            this.PanelKalori.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelProtein)).BeginInit();
            this.PanelProtein.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelKarbonhidrat)).BeginInit();
            this.PanelKarbonhidrat.SuspendLayout();
            this.SuspendLayout();
            // 
            // MemoMalzemeler
            // 
            this.MemoMalzemeler.Location = new System.Drawing.Point(12, 12);
            this.MemoMalzemeler.Name = "MemoMalzemeler";
            this.MemoMalzemeler.Properties.NullValuePrompt = "Malzemeleri yazın veya sürükleyin...";
            this.MemoMalzemeler.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
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
            this.MemoSonuc.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
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
            // BtnTemizle
            // 
            this.BtnTemizle.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.BtnTemizle.Appearance.Options.UseFont = true;
            this.BtnTemizle.Location = new System.Drawing.Point(12, 390);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(340, 40);
            this.BtnTemizle.TabIndex = 4;
            this.BtnTemizle.Text = "Temizle";
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // BtnKopyala
            // 
            this.BtnKopyala.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.BtnKopyala.Appearance.Options.UseFont = true;
            this.BtnKopyala.Location = new System.Drawing.Point(365, 390);
            this.BtnKopyala.Name = "BtnKopyala";
            this.BtnKopyala.Size = new System.Drawing.Size(340, 40);
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
            // BtnFavoriListesi
            // 
            this.BtnFavoriListesi.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.BtnFavoriListesi.Appearance.Options.UseFont = true;
            this.BtnFavoriListesi.Location = new System.Drawing.Point(485, 215);
            this.BtnFavoriListesi.Name = "BtnFavoriListesi";
            this.BtnFavoriListesi.Size = new System.Drawing.Size(220, 40);
            this.BtnFavoriListesi.TabIndex = 11;
            this.BtnFavoriListesi.Text = "🌟 Favori Tariflerim";
            this.BtnFavoriListesi.Click += new System.EventHandler(this.BtnFavoriListesi_Click);
            // 
            // PanelKalori
            // 
            this.PanelKalori.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.PanelKalori.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.PanelKalori.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.PanelKalori.Appearance.Options.UseBackColor = true;
            this.PanelKalori.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.PanelKalori.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PanelKalori.Controls.Add(this.LblKaloriDeger);
            this.PanelKalori.Controls.Add(this.LblKaloriBaslik);
            this.PanelKalori.Location = new System.Drawing.Point(485, 260);
            this.PanelKalori.Name = "PanelKalori";
            this.PanelKalori.Size = new System.Drawing.Size(70, 80);
            this.PanelKalori.TabIndex = 12;
            // 
            // LblKaloriDeger
            // 
            this.LblKaloriDeger.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.LblKaloriDeger.Appearance.ForeColor = System.Drawing.Color.Black;
            this.LblKaloriDeger.Appearance.Options.UseFont = true;
            this.LblKaloriDeger.Appearance.Options.UseForeColor = true;
            this.LblKaloriDeger.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LblKaloriDeger.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblKaloriDeger.Location = new System.Drawing.Point(5, 30);
            this.LblKaloriDeger.Name = "LblKaloriDeger";
            this.LblKaloriDeger.Size = new System.Drawing.Size(60, 45);
            this.LblKaloriDeger.TabIndex = 1;
            this.LblKaloriDeger.Text = "0";
            // 
            // LblKaloriBaslik
            // 
            this.LblKaloriBaslik.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LblKaloriBaslik.Appearance.ForeColor = System.Drawing.Color.Black;
            this.LblKaloriBaslik.Appearance.Options.UseFont = true;
            this.LblKaloriBaslik.Appearance.Options.UseForeColor = true;
            this.LblKaloriBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LblKaloriBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblKaloriBaslik.Location = new System.Drawing.Point(5, 5);
            this.LblKaloriBaslik.Name = "LblKaloriBaslik";
            this.LblKaloriBaslik.Size = new System.Drawing.Size(60, 20);
            this.LblKaloriBaslik.TabIndex = 0;
            this.LblKaloriBaslik.Text = "🔥 Kalori";
            // 
            // PanelProtein
            // 
            this.PanelProtein.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.PanelProtein.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.PanelProtein.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.PanelProtein.Appearance.Options.UseBackColor = true;
            this.PanelProtein.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.PanelProtein.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(100)))), ((int)(((byte)(220)))));
            this.PanelProtein.Controls.Add(this.LblProteinDeger);
            this.PanelProtein.Controls.Add(this.LblProteinBaslik);
            this.PanelProtein.Location = new System.Drawing.Point(560, 260);
            this.PanelProtein.Name = "PanelProtein";
            this.PanelProtein.Size = new System.Drawing.Size(70, 80);
            this.PanelProtein.TabIndex = 13;
            // 
            // LblProteinDeger
            // 
            this.LblProteinDeger.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.LblProteinDeger.Appearance.ForeColor = System.Drawing.Color.Black;
            this.LblProteinDeger.Appearance.Options.UseFont = true;
            this.LblProteinDeger.Appearance.Options.UseForeColor = true;
            this.LblProteinDeger.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LblProteinDeger.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblProteinDeger.Location = new System.Drawing.Point(5, 30);
            this.LblProteinDeger.Name = "LblProteinDeger";
            this.LblProteinDeger.Size = new System.Drawing.Size(60, 45);
            this.LblProteinDeger.TabIndex = 1;
            this.LblProteinDeger.Text = "0";
            // 
            // LblProteinBaslik
            // 
            this.LblProteinBaslik.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LblProteinBaslik.Appearance.ForeColor = System.Drawing.Color.Black;
            this.LblProteinBaslik.Appearance.Options.UseFont = true;
            this.LblProteinBaslik.Appearance.Options.UseForeColor = true;
            this.LblProteinBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LblProteinBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblProteinBaslik.Location = new System.Drawing.Point(5, 5);
            this.LblProteinBaslik.Name = "LblProteinBaslik";
            this.LblProteinBaslik.Size = new System.Drawing.Size(60, 20);
            this.LblProteinBaslik.TabIndex = 0;
            this.LblProteinBaslik.Text = "💪 Protein";
            // 
            // PanelKarbonhidrat
            // 
            this.PanelKarbonhidrat.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.PanelKarbonhidrat.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.PanelKarbonhidrat.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.PanelKarbonhidrat.Appearance.Options.UseBackColor = true;
            this.PanelKarbonhidrat.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.PanelKarbonhidrat.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.PanelKarbonhidrat.Controls.Add(this.LblKarbonhidratDeger);
            this.PanelKarbonhidrat.Controls.Add(this.LblKarbonhidratBaslik);
            this.PanelKarbonhidrat.Location = new System.Drawing.Point(635, 260);
            this.PanelKarbonhidrat.Name = "PanelKarbonhidrat";
            this.PanelKarbonhidrat.Size = new System.Drawing.Size(70, 80);
            this.PanelKarbonhidrat.TabIndex = 14;
            // 
            // LblKarbonhidratDeger
            // 
            this.LblKarbonhidratDeger.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.LblKarbonhidratDeger.Appearance.ForeColor = System.Drawing.Color.Black;
            this.LblKarbonhidratDeger.Appearance.Options.UseFont = true;
            this.LblKarbonhidratDeger.Appearance.Options.UseForeColor = true;
            this.LblKarbonhidratDeger.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LblKarbonhidratDeger.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblKarbonhidratDeger.Location = new System.Drawing.Point(5, 30);
            this.LblKarbonhidratDeger.Name = "LblKarbonhidratDeger";
            this.LblKarbonhidratDeger.Size = new System.Drawing.Size(60, 45);
            this.LblKarbonhidratDeger.TabIndex = 1;
            this.LblKarbonhidratDeger.Text = "0";
            // 
            // LblKarbonhidratBaslik
            // 
            this.LblKarbonhidratBaslik.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LblKarbonhidratBaslik.Appearance.ForeColor = System.Drawing.Color.Black;
            this.LblKarbonhidratBaslik.Appearance.Options.UseFont = true;
            this.LblKarbonhidratBaslik.Appearance.Options.UseForeColor = true;
            this.LblKarbonhidratBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LblKarbonhidratBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblKarbonhidratBaslik.Location = new System.Drawing.Point(5, 5);
            this.LblKarbonhidratBaslik.Name = "LblKarbonhidratBaslik";
            this.LblKarbonhidratBaslik.Size = new System.Drawing.Size(60, 20);
            this.LblKarbonhidratBaslik.TabIndex = 0;
            this.LblKarbonhidratBaslik.Text = "🌾 Karb.";
            // 
            // BtnFavoriEkle
            // 
            this.BtnFavoriEkle.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.BtnFavoriEkle.Appearance.Options.UseFont = true;
            this.BtnFavoriEkle.Location = new System.Drawing.Point(12, 440);
            this.BtnFavoriEkle.Name = "BtnFavoriEkle";
            this.BtnFavoriEkle.Size = new System.Drawing.Size(693, 45);
            this.BtnFavoriEkle.TabIndex = 0;
            this.BtnFavoriEkle.Text = "⭐ Favorilere Ekle";
            this.BtnFavoriEkle.Click += new System.EventHandler(this.BtnFavoriEkle_Click);
            // 
            // FrmTarifOneri
            // 
            this.ClientSize = new System.Drawing.Size(720, 545);
            this.Controls.Add(this.PanelKarbonhidrat);
            this.Controls.Add(this.PanelProtein);
            this.Controls.Add(this.PanelKalori);
            this.Controls.Add(this.BtnFavoriListesi);
            this.Controls.Add(this.BtnFavoriEkle);
            this.Controls.Add(this.BtnFotoSec);
            this.Controls.Add(this.PicMalzeme);
            this.Controls.Add(this.BtnKopyala);
            this.Controls.Add(this.BtnTemizle);
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
            ((System.ComponentModel.ISupportInitialize)(this.PicMalzeme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelKalori)).EndInit();
            this.PanelKalori.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelProtein)).EndInit();
            this.PanelProtein.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelKarbonhidrat)).EndInit();
            this.PanelKarbonhidrat.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DevExpress.XtraEditors.MemoEdit MemoMalzemeler;
        private DevExpress.XtraEditors.SimpleButton BtnTarifBul;
        private DevExpress.XtraEditors.MemoEdit MemoSonuc;
        private DevExpress.XtraEditors.LabelControl LblYemekAdi;
        private DevExpress.XtraEditors.SimpleButton BtnTemizle;
        private DevExpress.XtraEditors.SimpleButton BtnKopyala;
        private DevExpress.XtraEditors.PictureEdit PicMalzeme;
        private DevExpress.XtraEditors.SimpleButton BtnFotoSec;
        private DevExpress.XtraEditors.SimpleButton BtnFavoriEkle;
        private DevExpress.XtraEditors.SimpleButton BtnFavoriListesi;
        private DevExpress.XtraEditors.PanelControl PanelKalori;
        private DevExpress.XtraEditors.LabelControl LblKaloriBaslik;
        private DevExpress.XtraEditors.LabelControl LblKaloriDeger;
        private DevExpress.XtraEditors.PanelControl PanelProtein;
        private DevExpress.XtraEditors.LabelControl LblProteinBaslik;
        private DevExpress.XtraEditors.LabelControl LblProteinDeger;
        private DevExpress.XtraEditors.PanelControl PanelKarbonhidrat;
        private DevExpress.XtraEditors.LabelControl LblKarbonhidratBaslik;
        private DevExpress.XtraEditors.LabelControl LblKarbonhidratDeger;
    }
}
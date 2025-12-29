namespace YemekTarifiApp
{
    partial class FrmFavoriler
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.LstTarifler = new DevExpress.XtraEditors.ListBoxControl();
            this.MemoDetay = new DevExpress.XtraEditors.MemoEdit();
            this.BtnSil = new DevExpress.XtraEditors.SimpleButton();
            this.LblNutri = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.LstTarifler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoDetay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LstTarifler
            // 
            this.LstTarifler.Dock = System.Windows.Forms.DockStyle.Left;
            this.LstTarifler.Location = new System.Drawing.Point(0, 0);
            this.LstTarifler.Name = "LstTarifler";
            this.LstTarifler.Size = new System.Drawing.Size(220, 450);
            this.LstTarifler.TabIndex = 0;
            this.LstTarifler.SelectedIndexChanged += new System.EventHandler(this.LstTarifler_SelectedIndexChanged);
            // 
            // MemoDetay
            // 
            this.MemoDetay.Location = new System.Drawing.Point(226, 12);
            this.MemoDetay.Name = "MemoDetay";
            this.MemoDetay.Properties.ReadOnly = true;
            this.MemoDetay.Size = new System.Drawing.Size(412, 340);
            this.MemoDetay.TabIndex = 1;
            // 
            // LblNutri
            // 
            this.LblNutri.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.LblNutri.Location = new System.Drawing.Point(226, 365);
            this.LblNutri.Name = "LblNutri";
            this.LblNutri.Size = new System.Drawing.Size(147, 18);
            this.LblNutri.Text = "Detay için tarif seçin.";
            // 
            // BtnSil
            // 
            this.BtnSil.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.BtnSil.Appearance.Options.UseForeColor = true;
            this.BtnSil.Location = new System.Drawing.Point(226, 400);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(412, 38);
            this.BtnSil.TabIndex = 2;
            this.BtnSil.Text = "🗑 Seçili Tarifi Favorilerden Kaldır";
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // FrmFavoriler
            // 
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.LblNutri);
            this.Controls.Add(this.MemoDetay);
            this.Controls.Add(this.LstTarifler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmFavoriler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "🌟 Kaydedilen Favori Tarifler";
            this.Load += new System.EventHandler(this.FrmFavoriler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LstTarifler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoDetay.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DevExpress.XtraEditors.ListBoxControl LstTarifler;
        private DevExpress.XtraEditors.MemoEdit MemoDetay;
        private DevExpress.XtraEditors.SimpleButton BtnSil;
        private DevExpress.XtraEditors.LabelControl LblNutri;
    }
}
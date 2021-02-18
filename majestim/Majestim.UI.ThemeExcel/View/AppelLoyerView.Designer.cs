using Majestim.UI.ThemeExcel.Component;

namespace Majestim.UI.ThemeExcel.View
{
    partial class AppelLoyerView
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_update = new System.Windows.Forms.Button();
            this.olv_report = new BrightIdeasSoftware.ObjectListView();
            this.gb_param = new System.Windows.Forms.GroupBox();
            this.uc_periode = new Majestim.UI.ThemeExcel.Component.PeriodeSelectorComponent();
            this.uc_contrats = new Majestim.UI.ThemeExcel.Component.ContratsSelectorComponent();
            this.btn_generer_appels = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.olv_report)).BeginInit();
            this.gb_param.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_update
            // 
            this.btn_update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_update.Location = new System.Drawing.Point(282, 29);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 0;
            this.btn_update.Text = "Mettre à jour";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // olv_report
            // 
            this.olv_report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olv_report.CellEditUseWholeCell = false;
            this.olv_report.Cursor = System.Windows.Forms.Cursors.Default;
            this.olv_report.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olv_report.Location = new System.Drawing.Point(3, 3);
            this.olv_report.Name = "olv_report";
            this.olv_report.Size = new System.Drawing.Size(526, 691);
            this.olv_report.TabIndex = 5;
            this.olv_report.UseCompatibleStateImageBehavior = false;
            this.olv_report.View = System.Windows.Forms.View.Details;
            // 
            // gb_param
            // 
            this.gb_param.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_param.Controls.Add(this.uc_periode);
            this.gb_param.Controls.Add(this.uc_contrats);
            this.gb_param.Controls.Add(this.btn_generer_appels);
            this.gb_param.Controls.Add(this.btn_update);
            this.gb_param.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_param.Location = new System.Drawing.Point(535, 3);
            this.gb_param.Name = "gb_param";
            this.gb_param.Size = new System.Drawing.Size(372, 691);
            this.gb_param.TabIndex = 6;
            this.gb_param.TabStop = false;
            this.gb_param.Text = "Paramètres";
            // 
            // uc_periode
            // 
            this.uc_periode.HasDefault = false;
            this.uc_periode.Label = "Période";
            this.uc_periode.Location = new System.Drawing.Point(12, 29);
            this.uc_periode.Name = "uc_periode";
            this.uc_periode.Size = new System.Drawing.Size(259, 23);
            this.uc_periode.TabIndex = 7;
            this.uc_periode.TextDefault = null;
            // 
            // uc_contrats
            // 
            this.uc_contrats.Location = new System.Drawing.Point(6, 58);
            this.uc_contrats.Name = "uc_contrats";
            this.uc_contrats.Size = new System.Drawing.Size(269, 283);
            this.uc_contrats.TabIndex = 6;
            // 
            // btn_generer_appels
            // 
            this.btn_generer_appels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_generer_appels.Location = new System.Drawing.Point(282, 58);
            this.btn_generer_appels.Name = "btn_generer_appels";
            this.btn_generer_appels.Size = new System.Drawing.Size(75, 41);
            this.btn_generer_appels.TabIndex = 0;
            this.btn_generer_appels.Text = "Générer les appels";
            this.btn_generer_appels.UseVisualStyleBackColor = true;
            this.btn_generer_appels.Click += new System.EventHandler(this.btn_generer_appels_Click);
            // 
            // AppelLoyerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_param);
            this.Controls.Add(this.olv_report);
            this.Name = "AppelLoyerView";
            this.Size = new System.Drawing.Size(910, 697);
            this.Load += new System.EventHandler(this.AppelLoyerView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olv_report)).EndInit();
            this.gb_param.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_update;
        private BrightIdeasSoftware.ObjectListView olv_report;
        private System.Windows.Forms.GroupBox gb_param;
        private ContratsSelectorComponent uc_contrats;
        private PeriodeSelectorComponent uc_periode;
        private System.Windows.Forms.Button btn_generer_appels;
    }
}

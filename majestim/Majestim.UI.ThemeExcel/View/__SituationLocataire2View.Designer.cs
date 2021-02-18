//using Majestim.UI.ThemeExcel.Component;

//namespace Majestim.UI.ThemeExcel.View
//{
//    partial class SituationLocataire2View
//    {
//        /// <summary> 
//        /// Variable nécessaire au concepteur.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary> 
//        /// Nettoyage des ressources utilisées.
//        /// </summary>
//        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Code généré par le Concepteur de composants

//        /// <summary> 
//        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
//        /// le contenu de cette méthode avec l'éditeur de code.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.combo_nbmois = new System.Windows.Forms.ComboBox();
//            this.btn_Update = new System.Windows.Forms.Button();
//            this.label_histo = new System.Windows.Forms.Label();
//            this.olv_report = new BrightIdeasSoftware.ObjectListView();
//            this.gb_param = new System.Windows.Forms.GroupBox();
//            this.uc_contrats = new Majestim.UI.ThemeExcel.Component.ContratsSelectorComponent();
//            this.dg_report = new TenTec.Windows.iGridLib.iGrid();
//            ((System.ComponentModel.ISupportInitialize)(this.olv_report)).BeginInit();
//            this.gb_param.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dg_report)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // combo_nbmois
//            // 
//            this.combo_nbmois.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.combo_nbmois.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.combo_nbmois.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
//            this.combo_nbmois.FormattingEnabled = true;
//            this.combo_nbmois.Location = new System.Drawing.Point(123, 29);
//            this.combo_nbmois.Name = "combo_nbmois";
//            this.combo_nbmois.Size = new System.Drawing.Size(143, 21);
//            this.combo_nbmois.TabIndex = 4;
//            // 
//            // btn_Update
//            // 
//            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.btn_Update.Location = new System.Drawing.Point(282, 29);
//            this.btn_Update.Name = "btn_Update";
//            this.btn_Update.Size = new System.Drawing.Size(75, 23);
//            this.btn_Update.TabIndex = 0;
//            this.btn_Update.Text = "Mettre à jour";
//            this.btn_Update.UseVisualStyleBackColor = true;
//            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
//            // 
//            // label_histo
//            // 
//            this.label_histo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.label_histo.Location = new System.Drawing.Point(13, 29);
//            this.label_histo.Name = "label_histo";
//            this.label_histo.Size = new System.Drawing.Size(104, 21);
//            this.label_histo.TabIndex = 3;
//            this.label_histo.Text = "Historique (nb mois)";
//            // 
//            // olv_report
//            // 
//            this.olv_report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
//            | System.Windows.Forms.AnchorStyles.Left) 
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.olv_report.CellEditUseWholeCell = false;
//            this.olv_report.Cursor = System.Windows.Forms.Cursors.Default;
//            this.olv_report.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.olv_report.Location = new System.Drawing.Point(3, 3);
//            this.olv_report.Name = "olv_report";
//            this.olv_report.Size = new System.Drawing.Size(450, 696);
//            this.olv_report.TabIndex = 5;
//            this.olv_report.UseCompatibleStateImageBehavior = false;
//            this.olv_report.View = System.Windows.Forms.View.Details;
//            // 
//            // gb_param
//            // 
//            this.gb_param.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.gb_param.Controls.Add(this.dg_report);
//            this.gb_param.Controls.Add(this.uc_contrats);
//            this.gb_param.Controls.Add(this.btn_Update);
//            this.gb_param.Controls.Add(this.label_histo);
//            this.gb_param.Controls.Add(this.combo_nbmois);
//            this.gb_param.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.gb_param.Location = new System.Drawing.Point(459, 3);
//            this.gb_param.Name = "gb_param";
//            this.gb_param.Size = new System.Drawing.Size(372, 696);
//            this.gb_param.TabIndex = 6;
//            this.gb_param.TabStop = false;
//            this.gb_param.Text = "Paramètres";
//            // 
//            // uc_contrats
//            // 
//            this.uc_contrats.Location = new System.Drawing.Point(16, 56);
//            this.uc_contrats.Name = "uc_contrats";
//            this.uc_contrats.Size = new System.Drawing.Size(253, 283);
//            this.uc_contrats.TabIndex = 6;
//            // 
//            // dg_report
//            // 
//            this.dg_report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
//            | System.Windows.Forms.AnchorStyles.Left) 
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.dg_report.Appearance = TenTec.Windows.iGridLib.iGControlPaintAppearance.StyleFlat;
//            this.dg_report.Location = new System.Drawing.Point(16, 345);
//            this.dg_report.Name = "dg_report";
//            this.dg_report.Size = new System.Drawing.Size(341, 345);
//            this.dg_report.TabIndex = 7;
//            // 
//            // SituationLocataire2View
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.Controls.Add(this.gb_param);
//            this.Controls.Add(this.olv_report);
//            this.Name = "SituationLocataire2View";
//            this.Size = new System.Drawing.Size(834, 702);
//            this.Load += new System.EventHandler(this.SituationLocataireView_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.olv_report)).EndInit();
//            this.gb_param.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.dg_report)).EndInit();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.Button btn_Update;
//        private System.Windows.Forms.Label label_histo;
//        private BrightIdeasSoftware.ObjectListView olv_report;
//        private System.Windows.Forms.GroupBox gb_param;
//        private System.Windows.Forms.ComboBox combo_nbmois;
//        private ContratsSelectorComponent uc_contrats;
//        private TenTec.Windows.iGridLib.iGrid dg_report;
//    }
//}

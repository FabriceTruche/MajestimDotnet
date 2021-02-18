namespace Majestim.UI.ThemeExcel.View
{
    partial class ComptesLocataireView
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
            this.combo_contrat = new System.Windows.Forms.ComboBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.olv_report = new BrightIdeasSoftware.ObjectListView();
            this.gb_param = new System.Windows.Forms.GroupBox();
            this.panel_param = new System.Windows.Forms.Panel();
            this.uc_contrat_selector = new Majestim.UI.ThemeExcel.Component.ContratSelectorComponent();
            this.uc_periode_fin = new Majestim.UI.ThemeExcel.Component.PeriodeSelectorComponent();
            this.uc_periode_debut = new Majestim.UI.ThemeExcel.Component.PeriodeSelectorComponent();
            this.gb_contrat = new System.Windows.Forms.GroupBox();
            this.rb_tous = new System.Windows.Forms.RadioButton();
            this.rb_actif = new System.Windows.Forms.RadioButton();
            this.gb_comptes = new System.Windows.Forms.GroupBox();
            this.rb_comptes_defaut = new System.Windows.Forms.RadioButton();
            this.rb_comptes_all = new System.Windows.Forms.RadioButton();
            this.rb_comptes_aucun = new System.Windows.Forms.RadioButton();
            this.lb_operation = new System.Windows.Forms.ListBox();
            this.lb_compte = new System.Windows.Forms.ListBox();
            this.label_operation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.olv_report)).BeginInit();
            this.gb_param.SuspendLayout();
            this.panel_param.SuspendLayout();
            this.gb_contrat.SuspendLayout();
            this.gb_comptes.SuspendLayout();
            this.SuspendLayout();
            // 
            // combo_contrat
            // 
            this.combo_contrat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_contrat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combo_contrat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_contrat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.combo_contrat.Location = new System.Drawing.Point(135, 13);
            this.combo_contrat.Name = "combo_contrat";
            this.combo_contrat.Size = new System.Drawing.Size(143, 21);
            this.combo_contrat.TabIndex = 4;
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Update.Location = new System.Drawing.Point(294, 11);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 0;
            this.btn_Update.Text = "Mettre à jour";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
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
            this.olv_report.Size = new System.Drawing.Size(562, 625);
            this.olv_report.TabIndex = 5;
            this.olv_report.UseCompatibleStateImageBehavior = false;
            this.olv_report.View = System.Windows.Forms.View.Details;
            // 
            // gb_param
            // 
            this.gb_param.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_param.Controls.Add(this.panel_param);
            this.gb_param.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_param.Location = new System.Drawing.Point(571, 3);
            this.gb_param.Name = "gb_param";
            this.gb_param.Size = new System.Drawing.Size(384, 625);
            this.gb_param.TabIndex = 6;
            this.gb_param.TabStop = false;
            this.gb_param.Text = "Paramètres";
            // 
            // panel_param
            // 
            this.panel_param.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_param.AutoScroll = true;
            this.panel_param.Controls.Add(this.uc_contrat_selector);
            this.panel_param.Controls.Add(this.uc_periode_fin);
            this.panel_param.Controls.Add(this.uc_periode_debut);
            this.panel_param.Controls.Add(this.gb_contrat);
            this.panel_param.Controls.Add(this.gb_comptes);
            this.panel_param.Controls.Add(this.lb_operation);
            this.panel_param.Controls.Add(this.lb_compte);
            this.panel_param.Controls.Add(this.btn_Update);
            this.panel_param.Controls.Add(this.label_operation);
            this.panel_param.Controls.Add(this.combo_contrat);
            this.panel_param.Location = new System.Drawing.Point(6, 19);
            this.panel_param.Name = "panel_param";
            this.panel_param.Size = new System.Drawing.Size(372, 600);
            this.panel_param.TabIndex = 7;
            // 
            // uc_contrat_selector
            // 
            this.uc_contrat_selector.Location = new System.Drawing.Point(85, 471);
            this.uc_contrat_selector.Name = "uc_contrat_selector";
            this.uc_contrat_selector.Size = new System.Drawing.Size(258, 63);
            this.uc_contrat_selector.TabIndex = 11;
            // 
            // uc_periode_fin
            // 
            this.uc_periode_fin.HasDefault = false;
            this.uc_periode_fin.Label = "Période fin";
            this.uc_periode_fin.Location = new System.Drawing.Point(24, 98);
            this.uc_periode_fin.Name = "uc_periode_fin";
            this.uc_periode_fin.Size = new System.Drawing.Size(254, 23);
            this.uc_periode_fin.TabIndex = 10;
            this.uc_periode_fin.TextDefault = null;
            // 
            // uc_periode_debut
            // 
            this.uc_periode_debut.HasDefault = false;
            this.uc_periode_debut.Label = "Période début";
            this.uc_periode_debut.Location = new System.Drawing.Point(24, 71);
            this.uc_periode_debut.Name = "uc_periode_debut";
            this.uc_periode_debut.Size = new System.Drawing.Size(254, 23);
            this.uc_periode_debut.TabIndex = 9;
            this.uc_periode_debut.TextDefault = null;
            // 
            // gb_contrat
            // 
            this.gb_contrat.Controls.Add(this.rb_tous);
            this.gb_contrat.Controls.Add(this.rb_actif);
            this.gb_contrat.Location = new System.Drawing.Point(28, 13);
            this.gb_contrat.Name = "gb_contrat";
            this.gb_contrat.Size = new System.Drawing.Size(81, 57);
            this.gb_contrat.TabIndex = 8;
            this.gb_contrat.TabStop = false;
            this.gb_contrat.Text = "Contrat";
            // 
            // rb_tous
            // 
            this.rb_tous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_tous.AutoSize = true;
            this.rb_tous.Location = new System.Drawing.Point(20, 34);
            this.rb_tous.Name = "rb_tous";
            this.rb_tous.Size = new System.Drawing.Size(45, 17);
            this.rb_tous.TabIndex = 5;
            this.rb_tous.Text = "tous";
            this.rb_tous.UseVisualStyleBackColor = true;
            // 
            // rb_actif
            // 
            this.rb_actif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_actif.AutoSize = true;
            this.rb_actif.Checked = true;
            this.rb_actif.Location = new System.Drawing.Point(20, 17);
            this.rb_actif.Name = "rb_actif";
            this.rb_actif.Size = new System.Drawing.Size(50, 17);
            this.rb_actif.TabIndex = 5;
            this.rb_actif.TabStop = true;
            this.rb_actif.Text = "actifs";
            this.rb_actif.UseVisualStyleBackColor = true;
            // 
            // gb_comptes
            // 
            this.gb_comptes.Controls.Add(this.rb_comptes_defaut);
            this.gb_comptes.Controls.Add(this.rb_comptes_all);
            this.gb_comptes.Controls.Add(this.rb_comptes_aucun);
            this.gb_comptes.Location = new System.Drawing.Point(28, 127);
            this.gb_comptes.Name = "gb_comptes";
            this.gb_comptes.Size = new System.Drawing.Size(81, 86);
            this.gb_comptes.TabIndex = 7;
            this.gb_comptes.TabStop = false;
            this.gb_comptes.Text = "Comptes";
            // 
            // rb_comptes_defaut
            // 
            this.rb_comptes_defaut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_comptes_defaut.AutoSize = true;
            this.rb_comptes_defaut.Checked = true;
            this.rb_comptes_defaut.Location = new System.Drawing.Point(20, 22);
            this.rb_comptes_defaut.Name = "rb_comptes_defaut";
            this.rb_comptes_defaut.Size = new System.Drawing.Size(55, 17);
            this.rb_comptes_defaut.TabIndex = 5;
            this.rb_comptes_defaut.TabStop = true;
            this.rb_comptes_defaut.Text = "défaut";
            this.rb_comptes_defaut.UseVisualStyleBackColor = true;
            this.rb_comptes_defaut.CheckedChanged += new System.EventHandler(this.rb_comptes_defaut_CheckedChanged);
            // 
            // rb_comptes_all
            // 
            this.rb_comptes_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_comptes_all.AutoSize = true;
            this.rb_comptes_all.Location = new System.Drawing.Point(20, 57);
            this.rb_comptes_all.Name = "rb_comptes_all";
            this.rb_comptes_all.Size = new System.Drawing.Size(45, 17);
            this.rb_comptes_all.TabIndex = 5;
            this.rb_comptes_all.Text = "tous";
            this.rb_comptes_all.UseVisualStyleBackColor = true;
            this.rb_comptes_all.CheckedChanged += new System.EventHandler(this.rb_comptes_all_CheckedChanged);
            // 
            // rb_comptes_aucun
            // 
            this.rb_comptes_aucun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_comptes_aucun.AutoSize = true;
            this.rb_comptes_aucun.Location = new System.Drawing.Point(20, 39);
            this.rb_comptes_aucun.Name = "rb_comptes_aucun";
            this.rb_comptes_aucun.Size = new System.Drawing.Size(55, 17);
            this.rb_comptes_aucun.TabIndex = 5;
            this.rb_comptes_aucun.Text = "aucun";
            this.rb_comptes_aucun.UseVisualStyleBackColor = true;
            this.rb_comptes_aucun.CheckedChanged += new System.EventHandler(this.rb_comptes_aucun_CheckedChanged);
            // 
            // lb_operation
            // 
            this.lb_operation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_operation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_operation.FormattingEnabled = true;
            this.lb_operation.Location = new System.Drawing.Point(135, 405);
            this.lb_operation.Name = "lb_operation";
            this.lb_operation.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lb_operation.Size = new System.Drawing.Size(143, 182);
            this.lb_operation.TabIndex = 6;
            // 
            // lb_compte
            // 
            this.lb_compte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_compte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_compte.FormattingEnabled = true;
            this.lb_compte.Location = new System.Drawing.Point(135, 127);
            this.lb_compte.Name = "lb_compte";
            this.lb_compte.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lb_compte.Size = new System.Drawing.Size(143, 273);
            this.lb_compte.Sorted = true;
            this.lb_compte.TabIndex = 6;
            // 
            // label_operation
            // 
            this.label_operation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_operation.Location = new System.Drawing.Point(25, 405);
            this.label_operation.Name = "label_operation";
            this.label_operation.Size = new System.Drawing.Size(104, 23);
            this.label_operation.TabIndex = 2;
            this.label_operation.Text = "Opérations";
            // 
            // ComptesLocataireView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.olv_report);
            this.Controls.Add(this.gb_param);
            this.Name = "ComptesLocataireView";
            this.Size = new System.Drawing.Size(964, 631);
            this.Load += new System.EventHandler(this.ComptesLocataireView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olv_report)).EndInit();
            this.gb_param.ResumeLayout(false);
            this.panel_param.ResumeLayout(false);
            this.gb_contrat.ResumeLayout(false);
            this.gb_contrat.PerformLayout();
            this.gb_comptes.ResumeLayout(false);
            this.gb_comptes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Update;
        private BrightIdeasSoftware.ObjectListView olv_report;
        private System.Windows.Forms.GroupBox gb_param;
        private System.Windows.Forms.RadioButton rb_tous;
        private System.Windows.Forms.RadioButton rb_actif;
        private System.Windows.Forms.ComboBox combo_contrat;
        private System.Windows.Forms.ListBox lb_compte;
        private System.Windows.Forms.Panel panel_param;
        private System.Windows.Forms.ListBox lb_operation;
        private System.Windows.Forms.Label label_operation;
        private System.Windows.Forms.RadioButton rb_comptes_defaut;
        private System.Windows.Forms.RadioButton rb_comptes_aucun;
        private System.Windows.Forms.RadioButton rb_comptes_all;
        private System.Windows.Forms.GroupBox gb_comptes;
        private System.Windows.Forms.GroupBox gb_contrat;
        private Component.PeriodeSelectorComponent uc_periode_debut;
        private Component.PeriodeSelectorComponent uc_periode_fin;
        private Component.ContratSelectorComponent uc_contrat_selector;
    }
}

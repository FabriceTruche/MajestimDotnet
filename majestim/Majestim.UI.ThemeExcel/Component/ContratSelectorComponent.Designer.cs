namespace Majestim.UI.ThemeExcel.Component
{
    partial class ContratSelectorComponent
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
            this.gb_contrat = new System.Windows.Forms.GroupBox();
            this.rb_tous = new System.Windows.Forms.RadioButton();
            this.rb_actif = new System.Windows.Forms.RadioButton();
            this.combo_contrat = new System.Windows.Forms.ComboBox();
            this.gb_contrat.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_contrat
            // 
            this.gb_contrat.Controls.Add(this.rb_tous);
            this.gb_contrat.Controls.Add(this.rb_actif);
            this.gb_contrat.Location = new System.Drawing.Point(5, 3);
            this.gb_contrat.Name = "gb_contrat";
            this.gb_contrat.Size = new System.Drawing.Size(81, 57);
            this.gb_contrat.TabIndex = 10;
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
            this.rb_tous.CheckedChanged += new System.EventHandler(this.rb_tous_CheckedChanged);
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
            this.rb_actif.CheckedChanged += new System.EventHandler(this.rb_actif_CheckedChanged);
            // 
            // combo_contrat
            // 
            this.combo_contrat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_contrat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combo_contrat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_contrat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.combo_contrat.Location = new System.Drawing.Point(112, 3);
            this.combo_contrat.Name = "combo_contrat";
            this.combo_contrat.Size = new System.Drawing.Size(143, 21);
            this.combo_contrat.TabIndex = 9;
            this.combo_contrat.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.combo_contrat_DrawItem);
            // 
            // ContratSelectorComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_contrat);
            this.Controls.Add(this.combo_contrat);
            this.Name = "ContratSelectorComponent";
            this.Size = new System.Drawing.Size(258, 63);
            this.gb_contrat.ResumeLayout(false);
            this.gb_contrat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_contrat;
        private System.Windows.Forms.RadioButton rb_tous;
        private System.Windows.Forms.RadioButton rb_actif;
        private System.Windows.Forms.ComboBox combo_contrat;
    }
}

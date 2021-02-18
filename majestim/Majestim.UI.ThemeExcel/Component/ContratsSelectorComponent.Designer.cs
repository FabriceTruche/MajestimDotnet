namespace Majestim.UI.ThemeExcel.Component
{
    partial class ContratsSelectorComponent
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.rb_tous = new System.Windows.Forms.RadioButton();
            this.rb_actif = new System.Windows.Forms.RadioButton();
            this.label_contrat = new System.Windows.Forms.Label();
            this.lb_contrats = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // rb_tous
            // 
            this.rb_tous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_tous.AutoSize = true;
            this.rb_tous.Location = new System.Drawing.Point(22, 41);
            this.rb_tous.Name = "rb_tous";
            this.rb_tous.Size = new System.Drawing.Size(45, 17);
            this.rb_tous.TabIndex = 8;
            this.rb_tous.Text = "tous";
            this.rb_tous.UseVisualStyleBackColor = true;
            this.rb_tous.CheckedChanged += new System.EventHandler(this.rb_tous_CheckedChanged);
            // 
            // rb_actif
            // 
            this.rb_actif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_actif.AutoSize = true;
            this.rb_actif.Checked = true;
            this.rb_actif.Location = new System.Drawing.Point(22, 24);
            this.rb_actif.Name = "rb_actif";
            this.rb_actif.Size = new System.Drawing.Size(50, 17);
            this.rb_actif.TabIndex = 7;
            this.rb_actif.TabStop = true;
            this.rb_actif.Text = "actifs";
            this.rb_actif.UseVisualStyleBackColor = true;
            this.rb_actif.CheckedChanged += new System.EventHandler(this.rb_actif_CheckedChanged);
            // 
            // label_contrat
            // 
            this.label_contrat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_contrat.Location = new System.Drawing.Point(3, 3);
            this.label_contrat.Name = "label_contrat";
            this.label_contrat.Size = new System.Drawing.Size(69, 18);
            this.label_contrat.TabIndex = 6;
            this.label_contrat.Text = "Contrats";
            // 
            // lb_contrats
            // 
            this.lb_contrats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_contrats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_contrats.FormattingEnabled = true;
            this.lb_contrats.Location = new System.Drawing.Point(106, 3);
            this.lb_contrats.Name = "lb_contrats";
            this.lb_contrats.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_contrats.Size = new System.Drawing.Size(143, 273);
            this.lb_contrats.TabIndex = 9;
            // 
            // ContratsSelectorComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_contrats);
            this.Controls.Add(this.rb_tous);
            this.Controls.Add(this.rb_actif);
            this.Controls.Add(this.label_contrat);
            this.Name = "ContratsSelectorComponent";
            this.Size = new System.Drawing.Size(252, 279);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rb_tous;
        private System.Windows.Forms.RadioButton rb_actif;
        private System.Windows.Forms.Label label_contrat;
        private System.Windows.Forms.ListBox lb_contrats;
    }
}

namespace Majestim.UI.ThemeExcel.Component
{
    partial class PeriodeSelectorComponent
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
            this.label_periode = new System.Windows.Forms.Label();
            this.combo_periode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label_periode
            // 
            this.label_periode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_periode.Location = new System.Drawing.Point(1, 3);
            this.label_periode.Name = "label_periode";
            this.label_periode.Size = new System.Drawing.Size(104, 23);
            this.label_periode.TabIndex = 0;
            this.label_periode.Text = "<text>";
            // 
            // combo_periode
            // 
            this.combo_periode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_periode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combo_periode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_periode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.combo_periode.Location = new System.Drawing.Point(111, 0);
            this.combo_periode.Name = "combo_periode";
            this.combo_periode.Size = new System.Drawing.Size(143, 21);
            this.combo_periode.TabIndex = 0;
            this.combo_periode.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.combo_periode_DrawItem);
            // 
            // PeriodeSelectorComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_periode);
            this.Controls.Add(this.combo_periode);
            this.Name = "PeriodeSelectorComponent";
            this.Size = new System.Drawing.Size(254, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_periode;
        private System.Windows.Forms.ComboBox combo_periode;
    }
}

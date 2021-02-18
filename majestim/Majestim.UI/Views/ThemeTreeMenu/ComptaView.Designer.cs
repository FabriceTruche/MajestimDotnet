namespace Majestim.UI.Views.ThemeTreeMenu
{
    partial class ComptaView
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
            this.olvCompta = new BrightIdeasSoftware.ObjectListView();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Contrat = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.olvCompta)).BeginInit();
            this.SuspendLayout();
            // 
            // olvCompta
            // 
            this.olvCompta.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.olvCompta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvCompta.BackColor = System.Drawing.Color.Gainsboro;
            this.olvCompta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.olvCompta.CellEditUseWholeCell = false;
            this.olvCompta.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvCompta.Location = new System.Drawing.Point(7, 39);
            this.olvCompta.Name = "olvCompta";
            this.olvCompta.Size = new System.Drawing.Size(849, 470);
            this.olvCompta.TabIndex = 2;
            this.olvCompta.UseCompatibleStateImageBehavior = false;
            this.olvCompta.UseHotItem = true;
            this.olvCompta.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contrat";
            // 
            // cb_Contrat
            // 
            this.cb_Contrat.FormattingEnabled = true;
            this.cb_Contrat.Location = new System.Drawing.Point(68, 8);
            this.cb_Contrat.Name = "cb_Contrat";
            this.cb_Contrat.Size = new System.Drawing.Size(142, 21);
            this.cb_Contrat.TabIndex = 4;
            // 
            // ComptaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb_Contrat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.olvCompta);
            this.Name = "ComptaView";
            this.Size = new System.Drawing.Size(865, 515);
            this.Load += new System.EventHandler(this.ComptaControl_Load);
            this.ParentChanged += new System.EventHandler(this.ComptaView_ParentChanged);
            ((System.ComponentModel.ISupportInitialize)(this.olvCompta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BrightIdeasSoftware.ObjectListView olvCompta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Contrat;
    }
}

namespace Majestim.UI.ThemeExcel.View
{
    partial class RapproBancaireView
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
            this.cb_import_auto = new System.Windows.Forms.Button();
            this.cb_generate_compta = new System.Windows.Forms.Button();
            this.olv_banque = new BrightIdeasSoftware.ObjectListView();
            this.olv_compta = new BrightIdeasSoftware.ObjectListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cb_import_manu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.olv_banque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olv_compta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_import_auto
            // 
            this.cb_import_auto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_import_auto.Location = new System.Drawing.Point(1017, 19);
            this.cb_import_auto.Name = "cb_import_auto";
            this.cb_import_auto.Size = new System.Drawing.Size(75, 57);
            this.cb_import_auto.TabIndex = 0;
            this.cb_import_auto.Text = " Import auto";
            this.cb_import_auto.UseVisualStyleBackColor = true;
            this.cb_import_auto.Click += new System.EventHandler(this.cb_import_auto_Click);
            // 
            // cb_generate_compta
            // 
            this.cb_generate_compta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_generate_compta.Location = new System.Drawing.Point(1017, 145);
            this.cb_generate_compta.Name = "cb_generate_compta";
            this.cb_generate_compta.Size = new System.Drawing.Size(75, 57);
            this.cb_generate_compta.TabIndex = 0;
            this.cb_generate_compta.Text = "Genation Compta";
            this.cb_generate_compta.UseVisualStyleBackColor = true;
            // 
            // olv_banque
            // 
            this.olv_banque.CellEditUseWholeCell = false;
            this.olv_banque.Cursor = System.Windows.Forms.Cursors.Default;
            this.olv_banque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olv_banque.Location = new System.Drawing.Point(0, 0);
            this.olv_banque.Name = "olv_banque";
            this.olv_banque.Size = new System.Drawing.Size(997, 334);
            this.olv_banque.TabIndex = 1;
            this.olv_banque.UseCompatibleStateImageBehavior = false;
            this.olv_banque.View = System.Windows.Forms.View.Details;
            // 
            // olv_compta
            // 
            this.olv_compta.CellEditUseWholeCell = false;
            this.olv_compta.Cursor = System.Windows.Forms.Cursors.Default;
            this.olv_compta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olv_compta.Location = new System.Drawing.Point(0, 0);
            this.olv_compta.Name = "olv_compta";
            this.olv_compta.Size = new System.Drawing.Size(710, 310);
            this.olv_compta.TabIndex = 2;
            this.olv_compta.UseCompatibleStateImageBehavior = false;
            this.olv_compta.View = System.Windows.Forms.View.Details;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.olv_banque);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(999, 652);
            this.splitContainer1.SplitterDistance = 336;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.olv_compta);
            this.splitContainer2.Size = new System.Drawing.Size(997, 310);
            this.splitContainer2.SplitterDistance = 710;
            this.splitContainer2.TabIndex = 3;
            // 
            // cb_import_manu
            // 
            this.cb_import_manu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_import_manu.Location = new System.Drawing.Point(1017, 82);
            this.cb_import_manu.Name = "cb_import_manu";
            this.cb_import_manu.Size = new System.Drawing.Size(75, 57);
            this.cb_import_manu.TabIndex = 0;
            this.cb_import_manu.Text = " Import manuel";
            this.cb_import_manu.UseVisualStyleBackColor = true;
            this.cb_import_manu.Click += new System.EventHandler(this.cb_import_manu_Click);
            // 
            // RapproBancaireView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb_generate_compta);
            this.Controls.Add(this.cb_import_manu);
            this.Controls.Add(this.cb_import_auto);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RapproBancaireView";
            this.Size = new System.Drawing.Size(1099, 660);
            this.Load += new System.EventHandler(this.RapproBancaireView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olv_banque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olv_compta)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cb_import_auto;
        private System.Windows.Forms.Button cb_generate_compta;
        private BrightIdeasSoftware.ObjectListView olv_banque;
        private BrightIdeasSoftware.ObjectListView olv_compta;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button cb_import_manu;
    }
}

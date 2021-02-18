namespace testforms
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.iGrid1 = new TenTec.Windows.iGridLib.iGrid();
            this.iGrid2 = new TenTec.Windows.iGridLib.iGrid();
            this.iGrid2DefaultCellStyle = new TenTec.Windows.iGridLib.iGCellStyle(true);
            this.iGrid2DefaultColHdrStyle = new TenTec.Windows.iGridLib.iGColHdrStyle(true);
            this.iGrid2RowTextColCellStyle = new TenTec.Windows.iGridLib.iGCellStyle(true);
            ((System.ComponentModel.ISupportInitialize)(this.iGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // iGrid1
            // 
            this.iGrid1.Location = new System.Drawing.Point(87, 71);
            this.iGrid1.Name = "iGrid1";
            this.iGrid1.Size = new System.Drawing.Size(255, 254);
            this.iGrid1.TabIndex = 0;
            // 
            // iGrid2
            // 
            this.iGrid2.DefaultCol.CellStyle = this.iGrid2DefaultCellStyle;
            this.iGrid2.DefaultCol.ColHdrStyle = this.iGrid2DefaultColHdrStyle;
            this.iGrid2.Location = new System.Drawing.Point(487, 71);
            this.iGrid2.Name = "iGrid2";
            this.iGrid2.Size = new System.Drawing.Size(200, 200);
            this.iGrid2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.iGrid2);
            this.Controls.Add(this.iGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iGrid2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TenTec.Windows.iGridLib.iGrid iGrid1;
        private TenTec.Windows.iGridLib.iGrid iGrid2;
        private TenTec.Windows.iGridLib.iGCellStyle iGrid2DefaultCellStyle;
        private TenTec.Windows.iGridLib.iGColHdrStyle iGrid2DefaultColHdrStyle;
        private TenTec.Windows.iGridLib.iGCellStyle iGrid2RowTextColCellStyle;
    }
}


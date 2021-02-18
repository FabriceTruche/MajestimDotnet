namespace Majestim.UI.Views.ThemeTreeMenu
{
    partial class ContratView
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.olvContrat = new BrightIdeasSoftware.ObjectListView();
            this.olvLot = new BrightIdeasSoftware.ObjectListView();
            this.olvPreneur = new BrightIdeasSoftware.ObjectListView();
            this.sc1 = new System.Windows.Forms.SplitContainer();
            this.sc2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.olvContrat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvPreneur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).BeginInit();
            this.sc1.Panel1.SuspendLayout();
            this.sc1.Panel2.SuspendLayout();
            this.sc1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc2)).BeginInit();
            this.sc2.Panel1.SuspendLayout();
            this.sc2.Panel2.SuspendLayout();
            this.sc2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(787, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(706, 498);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // olvContrat
            // 
            this.olvContrat.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.olvContrat.BackColor = System.Drawing.Color.Gainsboro;
            this.olvContrat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.olvContrat.CellEditUseWholeCell = false;
            this.olvContrat.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvContrat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvContrat.Location = new System.Drawing.Point(0, 0);
            this.olvContrat.Name = "olvContrat";
            this.olvContrat.Size = new System.Drawing.Size(566, 489);
            this.olvContrat.TabIndex = 2;
            this.olvContrat.UseCompatibleStateImageBehavior = false;
            this.olvContrat.UseHotItem = true;
            this.olvContrat.View = System.Windows.Forms.View.Details;
            // 
            // olvLot
            // 
            this.olvLot.BackColor = System.Drawing.Color.Gainsboro;
            this.olvLot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.olvLot.CellEditUseWholeCell = false;
            this.olvLot.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvLot.Location = new System.Drawing.Point(0, 0);
            this.olvLot.Name = "olvLot";
            this.olvLot.Size = new System.Drawing.Size(289, 244);
            this.olvLot.TabIndex = 3;
            this.olvLot.UseCompatibleStateImageBehavior = false;
            this.olvLot.View = System.Windows.Forms.View.Details;
            // 
            // olvPreneur
            // 
            this.olvPreneur.BackColor = System.Drawing.Color.Gainsboro;
            this.olvPreneur.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.olvPreneur.CellEditUseWholeCell = false;
            this.olvPreneur.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvPreneur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvPreneur.Location = new System.Drawing.Point(0, 0);
            this.olvPreneur.Name = "olvPreneur";
            this.olvPreneur.Size = new System.Drawing.Size(289, 241);
            this.olvPreneur.TabIndex = 4;
            this.olvPreneur.UseCompatibleStateImageBehavior = false;
            this.olvPreneur.View = System.Windows.Forms.View.Details;
            // 
            // sc1
            // 
            this.sc1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sc1.Location = new System.Drawing.Point(3, 3);
            this.sc1.Name = "sc1";
            // 
            // sc1.Panel1
            // 
            this.sc1.Panel1.Controls.Add(this.olvContrat);
            // 
            // sc1.Panel2
            // 
            this.sc1.Panel2.Controls.Add(this.sc2);
            this.sc1.Size = new System.Drawing.Size(859, 489);
            this.sc1.SplitterDistance = 566;
            this.sc1.TabIndex = 5;
            // 
            // sc2
            // 
            this.sc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc2.Location = new System.Drawing.Point(0, 0);
            this.sc2.Name = "sc2";
            this.sc2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc2.Panel1
            // 
            this.sc2.Panel1.Controls.Add(this.olvLot);
            // 
            // sc2.Panel2
            // 
            this.sc2.Panel2.Controls.Add(this.olvPreneur);
            this.sc2.Size = new System.Drawing.Size(289, 489);
            this.sc2.SplitterDistance = 244;
            this.sc2.TabIndex = 6;
            // 
            // ContratView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sc1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ContratView";
            this.Size = new System.Drawing.Size(865, 530);
            this.Load += new System.EventHandler(this.ContratControl_Load);
            this.ParentChanged += new System.EventHandler(this.ContratView_ParentChanged);
            ((System.ComponentModel.ISupportInitialize)(this.olvContrat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvPreneur)).EndInit();
            this.sc1.Panel1.ResumeLayout(false);
            this.sc1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).EndInit();
            this.sc1.ResumeLayout(false);
            this.sc2.Panel1.ResumeLayout(false);
            this.sc2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc2)).EndInit();
            this.sc2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private BrightIdeasSoftware.ObjectListView olvContrat;
        private BrightIdeasSoftware.ObjectListView olvLot;
        private BrightIdeasSoftware.ObjectListView olvPreneur;
        private System.Windows.Forms.SplitContainer sc1;
        private System.Windows.Forms.SplitContainer sc2;
    }
}

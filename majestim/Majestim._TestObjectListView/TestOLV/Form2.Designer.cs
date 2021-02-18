namespace Majestim._TestObjectListView.TestOLV
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.olv = new BrightIdeasSoftware.ObjectListView();
            this.olv2 = new BrightIdeasSoftware.ObjectListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olv2)).BeginInit();
            this.SuspendLayout();
            // 
            // olv
            // 
            this.olv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olv.CellEditUseWholeCell = false;
            this.olv.Cursor = System.Windows.Forms.Cursors.Default;
            this.olv.Location = new System.Drawing.Point(12, 12);
            this.olv.Name = "olv";
            this.olv.Size = new System.Drawing.Size(826, 283);
            this.olv.TabIndex = 0;
            this.olv.UseCompatibleStateImageBehavior = false;
            this.olv.View = System.Windows.Forms.View.Details;
            // 
            // olv2
            // 
            this.olv2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olv2.CellEditUseWholeCell = false;
            this.olv2.Cursor = System.Windows.Forms.Cursors.Default;
            this.olv2.Location = new System.Drawing.Point(12, 303);
            this.olv2.Name = "olv2";
            this.olv2.Size = new System.Drawing.Size(826, 283);
            this.olv2.TabIndex = 0;
            this.olv2.UseCompatibleStateImageBehavior = false;
            this.olv2.View = System.Windows.Forms.View.Details;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(848, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dump";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(848, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 599);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.olv);
            this.Controls.Add(this.olv2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olv2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView olv;
        private BrightIdeasSoftware.ObjectListView olv2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
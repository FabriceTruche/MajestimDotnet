namespace Majestim._Winform
{
    partial class Form1
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
            this.iGrid1 = new TenTec.Windows.iGridLib.iGrid();
            this.iGVScrollBar1 = new TenTec.Windows.iGridLib.iGVScrollBar();
            this.iGHScrollBar1 = new TenTec.Windows.iGridLib.iGHScrollBar();
            this.iGCellStyleDesign1 = new TenTec.Windows.iGridLib.iGCellStyleDesign();
            ((System.ComponentModel.ISupportInitialize)(this.iGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // iGrid1
            // 
            this.iGrid1.Location = new System.Drawing.Point(0, 0);
            this.iGrid1.Name = "iGrid1";
            this.iGrid1.TabIndex = 0;
            // 
            // iGVScrollBar1
            // 
            this.iGVScrollBar1.CustomControlPaint = null;
            this.iGVScrollBar1.Location = new System.Drawing.Point(40, 103);
            this.iGVScrollBar1.Name = "iGVScrollBar1";
            this.iGVScrollBar1.Size = new System.Drawing.Size(26, 163);
            this.iGVScrollBar1.TabIndex = 0;
            this.iGVScrollBar1.Text = "iGVScrollBar1";
            // 
            // iGHScrollBar1
            // 
            this.iGHScrollBar1.CustomControlPaint = null;
            this.iGHScrollBar1.Location = new System.Drawing.Point(81, 278);
            this.iGHScrollBar1.Name = "iGHScrollBar1";
            this.iGHScrollBar1.Size = new System.Drawing.Size(263, 30);
            this.iGHScrollBar1.TabIndex = 1;
            this.iGHScrollBar1.Text = "iGHScrollBar1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 565);
            this.Controls.Add(this.iGHScrollBar1);
            this.Controls.Add(this.iGVScrollBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.iGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TenTec.Windows.iGridLib.iGrid iGrid1;
        private iGVScrollBar iGVScrollBar1;
        private iGHScrollBar iGHScrollBar1;
        private TenTec.Windows.iGridLib.iGCellStyleDesign iGCellStyleDesign1;
    }
}
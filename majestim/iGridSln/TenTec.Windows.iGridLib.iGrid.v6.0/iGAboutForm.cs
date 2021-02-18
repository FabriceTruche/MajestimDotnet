// Decompiled with JetBrains decompiler
// Type: TenTec.Windows.iGridLib.iGAboutForm
// Assembly: TenTec.Windows.iGridLib.iGrid.v6.0, Version=6.0.37.0, Culture=neutral, PublicKeyToken=9d47002745f2416c
// MVID: 417E314E-0FBF-4E4F-8CBF-B713726278B4
// Assembly location: C:\10Tec\iGrid.NET 6.0\Bin\TenTec.Windows.iGridLib.iGrid.v6.0.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace TenTec.Windows.iGridLib
{
  internal class iGAboutForm : Form
  {
    private PictureBox pictureBox1;
    private Panel panel1;
    private Button button1;
    private Label label1;
    private Label label2;
    private Label labelVersion;
    private Button buttonPurchase;
    private Label labelCopyright;
    public Label labelNotLicensed;
    private LinkLabel linkLabelMail;
    private LinkLabel linkLabelWWW;

    public iGAboutForm()
    {
      this.InitializeComponent();
      this.pictureBox1.Image = (Image) new Bitmap(iGrid.GetResourceStream("AboutCompanyLogo.gif"));
      this.labelNotLicensed.Text = "An unregistered copy of the component";
    }

    private void InitializeComponent()
    {
      this.pictureBox1 = new PictureBox();
      this.panel1 = new Panel();
      this.labelCopyright = new Label();
      this.linkLabelMail = new LinkLabel();
      this.linkLabelWWW = new LinkLabel();
      this.labelVersion = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.button1 = new Button();
      this.buttonPurchase = new Button();
      this.labelNotLicensed = new Label();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.pictureBox1.BackColor = SystemColors.Control;
      this.pictureBox1.Location = new Point(8, 24);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(136, 43);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel1.BackColor = SystemColors.Control;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.labelCopyright);
      this.panel1.Controls.Add((Control) this.linkLabelMail);
      this.panel1.Controls.Add((Control) this.linkLabelWWW);
      this.panel1.Controls.Add((Control) this.labelVersion);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.button1);
      this.panel1.Controls.Add((Control) this.buttonPurchase);
      this.panel1.Controls.Add((Control) this.labelNotLicensed);
      this.panel1.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.panel1.Location = new Point(32, 8);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(384, 206);
      this.panel1.TabIndex = 1;
      this.labelCopyright.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.labelCopyright.AutoSize = true;
      this.labelCopyright.Location = new Point(13, 123);
      this.labelCopyright.Name = "labelCopyright";
      this.labelCopyright.Size = new Size(239, 16);
      this.labelCopyright.TabIndex = 6;
      this.labelCopyright.Text = "Copyright © 2000-2018 10Tec Company";
      this.linkLabelMail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.linkLabelMail.AutoSize = true;
      this.linkLabelMail.Location = new Point(13, 175);
      this.linkLabelMail.Name = "linkLabelMail";
      this.linkLabelMail.Size = new Size(169, 16);
      this.linkLabelMail.TabIndex = 5;
      this.linkLabelMail.TabStop = true;
      this.linkLabelMail.Text = "e-mail: contact@10tec.com";
      this.linkLabelMail.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabelMail_LinkClicked);
      this.linkLabelWWW.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.linkLabelWWW.AutoSize = true;
      this.linkLabelWWW.Location = new Point(13, 151);
      this.linkLabelWWW.Name = "linkLabelWWW";
      this.linkLabelWWW.Size = new Size(113, 16);
      this.linkLabelWWW.TabIndex = 4;
      this.linkLabelWWW.TabStop = true;
      this.linkLabelWWW.Text = "https://10tec.com/";
      this.linkLabelWWW.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabelWWW_LinkClicked);
      this.labelVersion.Location = new Point(184, 40);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new Size(184, 23);
      this.labelVersion.TabIndex = 2;
      this.label2.Location = new Point(128, 40);
      this.label2.Name = "label2";
      this.label2.Size = new Size(100, 23);
      this.label2.TabIndex = 2;
      this.label2.Text = "Version: ";
      this.label1.Font = new Font("Arial", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.label1.Location = new Point(120, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(248, 32);
      this.label1.TabIndex = 1;
      this.label1.Text = "10Tec iGrid.NET";
      this.button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.button1.FlatStyle = FlatStyle.System;
      this.button1.Location = new Point(282, 167);
      this.button1.Name = "button1";
      this.button1.Size = new Size(88, 24);
      this.button1.TabIndex = 0;
      this.button1.Text = "OK";
      this.button1.Click += new EventHandler(this.button1_Click);
      this.buttonPurchase.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.buttonPurchase.FlatStyle = FlatStyle.System;
      this.buttonPurchase.Location = new Point(282, 135);
      this.buttonPurchase.Name = "buttonPurchase";
      this.buttonPurchase.Size = new Size(88, 24);
      this.buttonPurchase.TabIndex = 1;
      this.buttonPurchase.Text = "Purchase";
      this.buttonPurchase.Click += new EventHandler(this.buttonPurchase_Click);
      this.labelNotLicensed.BorderStyle = BorderStyle.FixedSingle;
      this.labelNotLicensed.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.labelNotLicensed.Location = new Point(16, 72);
      this.labelNotLicensed.Name = "labelNotLicensed";
      this.labelNotLicensed.Size = new Size(352, 34);
      this.labelNotLicensed.TabIndex = 9;
      this.labelNotLicensed.Text = "The component is not licensed";
      this.labelNotLicensed.TextAlign = ContentAlignment.MiddleCenter;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.LightSteelBlue;
      this.ClientSize = new Size(424, 222);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (iGAboutForm);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "About 10Tec iGrid.Net";
      this.TransparencyKey = Color.LightSteelBlue;
      this.Load += new EventHandler(this.iGAboutForm_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void iGAboutForm_Load(object sender, EventArgs e)
    {
      this.labelVersion.Text = typeof (iGrid).Assembly.GetName().Version.ToString();
      this.labelCopyright.Text = (typeof (iGrid).Assembly.GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false)[0] as AssemblyCopyrightAttribute).Copyright;
    }

    private void linkLabelWWW_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      iGHyperlinkManager.GoToLink("https://10tec.com/");
    }

    private void linkLabelMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      iGHyperlinkManager.GoToLink("mailto:contact@10tec.com?subject=iGrid.NET");
    }

    private void buttonPurchase_Click(object sender, EventArgs e)
    {
      iGHyperlinkManager.GoToLink("https://10tec.com/order/");
    }
  }
}

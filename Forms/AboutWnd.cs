// Decompiled with JetBrains decompiler
// Type: Calculator.Forms.AboutWnd
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Calculator.Properties;

namespace Calculator.Forms
{
  internal class AboutWnd : Form
  {
    private IContainer components;
    private Button button1;
    private LinkLabel linkLabel1;
    private Label label1;

    public AboutWnd()
    {
      this.InitializeComponent();
      Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
    }

    private void AboutWnd_Load(object sender, EventArgs e)
    {
      this.label1.Text += Application.ProductVersion;
      this.linkLabel1.Text += Settings.Default.homepageUrl;
    }

    private void button1_Click(object sender, EventArgs e) => this.Close();

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(this.linkLabel1.Text.Substring(e.Link.Start, e.Link.Length));

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.button1 = new Button();
      this.linkLabel1 = new LinkLabel();
      this.label1 = new Label();
      this.SuspendLayout();
      this.button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.button1.Location = new Point(308, 85);
      this.button1.Margin = new Padding(4);
      this.button1.Name = "button1";
      this.button1.Size = new Size(100, 28);
      this.button1.TabIndex = 0;
      this.button1.Text = "OK";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.LinkArea = new LinkArea(10, 42);
      this.linkLabel1.Location = new Point(17, 16);
      this.linkLabel1.Margin = new Padding(4, 0, 4, 0);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(78, 20);
      this.linkLabel1.TabIndex = 1;
      this.linkLabel1.Text = "Homepage: ";
      this.linkLabel1.UseCompatibleTextRendering = true;
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(14, 36);
      this.label1.Name = "label1";
      this.label1.Size = new Size(60, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "Version ";
      this.AcceptButton = (IButtonControl) this.button1;
      this.AutoScaleDimensions = new SizeF(120f, 120f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.ClientSize = new Size(424, 128);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.linkLabel1);
      this.Controls.Add((Control) this.button1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Margin = new Padding(4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (AboutWnd);
      this.Text = "About Calculator";
      this.Load += new EventHandler(this.AboutWnd_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

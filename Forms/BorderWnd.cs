// Decompiled with JetBrains decompiler
// Type: Calculator.Forms.BorderWnd
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using Calculator.Properties;

namespace Calculator.Forms
{
  internal class BorderWnd : Form, IWin32Window
  {
    private Color _borderColor = Color.Black;
    private int groupNumber;
    private bool showGroupNumber;
    private IContainer components;

    public Color BorderColor
    {
      get => this._borderColor;
      set
      {
        this._borderColor = value;
        this.Invalidate();
      }
    }

    public int BorderWidth { get; set; } = 5;

    public int GroupNumber
    {
      get => this.groupNumber;
      set
      {
        if (this.groupNumber == value)
          return;
        this.groupNumber = value;
        this.Invalidate();
      }
    }

    public bool ShowGroupNumber
    {
      get => this.showGroupNumber;
      set
      {
        if (this.showGroupNumber == value)
          return;
        this.showGroupNumber = value;
        this.Invalidate();
      }
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ExStyle |= 524448;
        return createParams;
      }
    }

    protected override bool ShowWithoutActivation => true;

    public BorderWnd()
    {
      this.InitializeComponent();
      this.Cursor = new Cursor((Stream) new MemoryStream(Resources.toonmono));
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, this.BorderColor, this.BorderWidth, ButtonBorderStyle.Solid, this.BorderColor, this.BorderWidth, ButtonBorderStyle.Solid, this.BorderColor, this.BorderWidth, ButtonBorderStyle.Solid, this.BorderColor, this.BorderWidth, ButtonBorderStyle.Solid);
      if (!this.ShowGroupNumber)
        return;
      e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
      e.Graphics.DrawString(this.GroupNumber.ToString(), new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Regular), Brushes.White, 5f, 5f);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(120f, 120f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.Fuchsia;
      this.ClientSize = new Size(804, 532);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Margin = new Padding(4, 4, 4, 4);
      this.Name = nameof (BorderWnd);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = nameof (BorderWnd);
      this.TransparencyKey = Color.Fuchsia;
      this.ResumeLayout(false);
    }
  }
}

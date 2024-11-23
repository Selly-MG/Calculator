// Decompiled with JetBrains decompiler
// Type: Calculator.Controls.SelectWindowCrosshair
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Calculator.Properties;

namespace Calculator.Controls
{
  public class SelectWindowCrosshair : UserControl
  {
    private IntPtr selectedWindowHandle = IntPtr.Zero;
    private Color selectedBorderColor = Color.LimeGreen;
    private bool isDragging;
    private IContainer components;
    private PictureBox pictureBox1;

    public event WindowSelectedHandler WindowSelected;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IntPtr SelectedWindowHandle
    {
      get => this.selectedWindowHandle;
      set
      {
        if (!(this.selectedWindowHandle != value))
          return;
        this.selectedWindowHandle = value;
        this.UpdateBorder();
      }
    }

    public Color SelectedBorderColor
    {
      get => this.selectedBorderColor;
      set
      {
        if (!(this.selectedBorderColor != value))
          return;
        this.selectedBorderColor = value;
        this.UpdateBorder();
      }
    }

    public SelectWindowCrosshair() => this.InitializeComponent();

    private void UpdateBorder()
    {
      try
      {
        this.InvokeIfRequired((MethodInvoker) (() => this.BackColor = this.selectedWindowHandle != IntPtr.Zero ? this.SelectedBorderColor : SystemColors.Control));
      }
      catch
      {
      }
    }

    private void SelectWindowCrosshair_MouseDown(object sender, MouseEventArgs e)
    {
      this.isDragging = true;
      this.pictureBox1.Image = (Image) Resources.findere;
      Cursor.Current = new Cursor((Stream) new MemoryStream(Resources.searchw));
    }

    private void SelectWindowCrosshair_MouseUp(object sender, MouseEventArgs e)
    {
      if (!this.isDragging)
        return;
      this.isDragging = false;
      this.pictureBox1.Image = (Image) Resources.finderf;
      IntPtr num = Win32.WindowFromPoint(Cursor.Position);
      Cursor.Current = Cursors.Default;
      if (num == this.TopLevelControl.Handle || this.TopLevelControl.Parent != null && num == this.TopLevelControl.Parent.Handle || num != Win32.GetAncestor(num, Win32.GetAncestorFlags.GetRoot))
        num = IntPtr.Zero;
      this.SelectedWindowHandle = num;
      WindowSelectedHandler windowSelected = this.WindowSelected;
      if (windowSelected == null)
        return;
      windowSelected((object) this, num);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.pictureBox1 = new PictureBox();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pictureBox1.Image = (Image) Resources.finderf;
      this.pictureBox1.Location = new Point(2, 2);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(32, 32);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.MouseDown += new MouseEventHandler(this.SelectWindowCrosshair_MouseDown);
      this.pictureBox1.MouseUp += new MouseEventHandler(this.SelectWindowCrosshair_MouseUp);
      this.AutoScaleMode = AutoScaleMode.Inherit;
      this.Controls.Add((Control) this.pictureBox1);
      this.Name = nameof (SelectWindowCrosshair);
      this.Padding = new Padding(2);
      this.Size = new Size(36, 36);
      this.MouseDown += new MouseEventHandler(this.SelectWindowCrosshair_MouseDown);
      this.MouseUp += new MouseEventHandler(this.SelectWindowCrosshair_MouseUp);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}

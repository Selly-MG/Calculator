// Decompiled with JetBrains decompiler
// Type: Calculator.Controls.ControlsPicker
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator.Controls
{
  public class ControlsPicker : UserControl
  {
    private List<KeyMapping> keyMappings = new List<KeyMapping>();
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;

    public event EventHandler KeyMappingsChanged;

    public event ControlsPicker.KeyMappingAddedHandler KeyMappingAdded;

    public event ControlsPicker.KeyMappingRemovedHandler KeyMappingRemoved;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<KeyMapping> KeyMappings
    {
      get => this.keyMappings;
      set => this.InvokeIfRequired((MethodInvoker) (() =>
      {
        while (this.tableLayoutPanel1.RowCount > 1)
          this.removeRow(1);
        foreach (KeyMapping keyMapping in value)
          this.AddMapping(keyMapping);
      }));
    }

    public ControlsPicker() => this.InitializeComponent();

    public void AddMapping(KeyMapping keyMapping) => this.InvokeIfRequired((MethodInvoker) (() =>
    {
      this.addRow(keyMapping);
      this.keyMappings.Add(keyMapping);
      ControlsPicker.KeyMappingAddedHandler keyMappingAdded = this.KeyMappingAdded;
      if (keyMappingAdded != null)
        keyMappingAdded((object) this, keyMapping);
      EventHandler keyMappingsChanged = this.KeyMappingsChanged;
      if (keyMappingsChanged != null)
        keyMappingsChanged((object) this, EventArgs.Empty);
      this.tableLayoutPanel1.ScrollControlIntoView(this.tableLayoutPanel1.Controls[this.tableLayoutPanel1.Controls.Count - 1]);
    }));

    public void RemoveMapping(int index)
    {
      this.removeRow(index + 1);
      this.keyMappings.RemoveAt(index);
      ControlsPicker.KeyMappingRemovedHandler keyMappingRemoved = this.KeyMappingRemoved;
      if (keyMappingRemoved != null)
        keyMappingRemoved((object) this, index);
      EventHandler keyMappingsChanged = this.KeyMappingsChanged;
      if (keyMappingsChanged == null)
        return;
      keyMappingsChanged((object) this, EventArgs.Empty);
    }

    private int addRow(KeyMapping keyMapping)
    {
      Point autoScrollPosition = this.AutoScrollPosition;
      Control control;
      if (keyMapping.ReadOnly)
      {
        Label label = new Label();
        label.Text = keyMapping.Title.TrimEnd(':') + ":";
        label.Dock = DockStyle.Fill;
        label.AutoSize = true;
        label.TextAlign = ContentAlignment.MiddleLeft;
        control = (Control) label;
      }
      else
      {
        TextBox textBox1 = new TextBox();
        textBox1.Text = keyMapping.Title.TrimEnd(':') + ":";
        textBox1.Dock = DockStyle.Fill;
        TextBox textBox2 = textBox1;
        textBox2.TextChanged += new EventHandler(this.BindingTitle_TextChanged);
        textBox2.Focus();
        textBox2.SelectAll();
        control = (Control) textBox2;
      }
      KeyPicker keyPicker1 = new KeyPicker();
      keyPicker1.Dock = DockStyle.Top;
      keyPicker1.ChosenKey = keyMapping.Key;
      KeyPicker keyPicker2 = keyPicker1;
      KeyPicker keyPicker3 = new KeyPicker();
      keyPicker3.Dock = DockStyle.Top;
      keyPicker3.ChosenKey = keyMapping.LeftToonKey;
      KeyPicker keyPicker4 = keyPicker3;
      KeyPicker keyPicker5 = new KeyPicker();
      keyPicker5.Dock = DockStyle.Top;
      keyPicker5.ChosenKey = keyMapping.RightToonKey;
      KeyPicker keyPicker6 = keyPicker5;
      Button button1 = new Button();
      button1.Text = "Remove";
      button1.AutoSize = true;
      button1.Enabled = !keyMapping.ReadOnly;
      Button button2 = button1;
      keyPicker2.KeyChosen += new KeyPicker.KeyChosenHandler(this.KeyChooser_KeyChosen);
      button2.Click += new EventHandler(this.RemoveBtn_Click);
      keyPicker4.KeyChosen += new KeyPicker.KeyChosenHandler(this.LeftToonKeyPicker_KeyChosen);
      keyPicker6.KeyChosen += new KeyPicker.KeyChosenHandler(this.RightToonKeyPicker_KeyChosen);
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
      ++this.tableLayoutPanel1.RowCount;
      int row = this.tableLayoutPanel1.RowCount - 1;
      this.tableLayoutPanel1.Controls.Add(control, 0, row);
      this.tableLayoutPanel1.Controls.Add((Control) keyPicker2, 1, row);
      this.tableLayoutPanel1.Controls.Add((Control) keyPicker4, 2, row);
      this.tableLayoutPanel1.Controls.Add((Control) keyPicker6, 3, row);
      this.tableLayoutPanel1.Controls.Add((Control) button2, 4, row);
      this.tableLayoutPanel1.ResumeLayout();
      this.AutoScrollPosition = new Point(Math.Abs(autoScrollPosition.X), Math.Abs(autoScrollPosition.Y));
      return row;
    }

    private void removeRow(int rowNum)
    {
      Point autoScrollPosition = this.AutoScrollPosition;
      this.tableLayoutPanel1.SuspendLayout();
      for (int column = 0; column < this.tableLayoutPanel1.ColumnCount; ++column)
      {
        Control controlFromPosition = this.tableLayoutPanel1.GetControlFromPosition(column, rowNum);
        if (controlFromPosition != null)
          this.tableLayoutPanel1.Controls.Remove(controlFromPosition);
      }
      for (int row = rowNum + 1; row < this.tableLayoutPanel1.RowCount; ++row)
      {
        for (int column = 0; column < this.tableLayoutPanel1.ColumnCount; ++column)
        {
          Control controlFromPosition = this.tableLayoutPanel1.GetControlFromPosition(column, row);
          if (controlFromPosition != null)
            this.tableLayoutPanel1.SetRow(controlFromPosition, row - 1);
        }
      }
      this.tableLayoutPanel1.RowStyles.RemoveAt(rowNum);
      --this.tableLayoutPanel1.RowCount;
      this.tableLayoutPanel1.ResumeLayout();
      this.AutoScrollPosition = new Point(Math.Abs(autoScrollPosition.X), Math.Abs(autoScrollPosition.Y));
    }

    private void ControlsPicker_Load(object sender, EventArgs e)
    {
      if (!this.DesignMode)
        return;
      this.KeyMappings = new List<KeyMapping>()
      {
        new KeyMapping("Test", Keys.None, Keys.None, Keys.None, true),
        new KeyMapping("Test", Keys.None, Keys.None, Keys.None, true),
        new KeyMapping("Test", Keys.A, Keys.None, Keys.D, true),
        new KeyMapping("Test", Keys.None, Keys.None, Keys.None, true),
        new KeyMapping("Test", Keys.None, Keys.B, Keys.None, true),
        new KeyMapping("Test", Keys.None, Keys.None, Keys.None, true),
        new KeyMapping("Test", Keys.None, Keys.None, Keys.C, true),
        new KeyMapping("Test", Keys.None, Keys.None, Keys.None, true)
      };
    }

    private void KeyChooser_KeyChosen(KeyPicker keyChooser, Keys keyChosen)
    {
      this.keyMappings[this.tableLayoutPanel1.GetRow((Control) keyChooser) - 1].Key = keyChosen;
      EventHandler keyMappingsChanged = this.KeyMappingsChanged;
      if (keyMappingsChanged == null)
        return;
      keyMappingsChanged((object) this, EventArgs.Empty);
    }

    private void LeftToonKeyPicker_KeyChosen(KeyPicker keyChooser, Keys keyChosen)
    {
      this.keyMappings[this.tableLayoutPanel1.GetRow((Control) keyChooser) - 1].LeftToonKey = keyChosen;
      EventHandler keyMappingsChanged = this.KeyMappingsChanged;
      if (keyMappingsChanged == null)
        return;
      keyMappingsChanged((object) this, EventArgs.Empty);
    }

    private void RightToonKeyPicker_KeyChosen(KeyPicker keyChooser, Keys keyChosen)
    {
      this.keyMappings[this.tableLayoutPanel1.GetRow((Control) keyChooser) - 1].RightToonKey = keyChosen;
      EventHandler keyMappingsChanged = this.KeyMappingsChanged;
      if (keyMappingsChanged == null)
        return;
      keyMappingsChanged((object) this, EventArgs.Empty);
    }

    private void BindingTitle_TextChanged(object sender, EventArgs e)
    {
      this.keyMappings[this.tableLayoutPanel1.GetRow((Control) sender) - 1].Title = (sender as Control).Text.Trim(':');
      EventHandler keyMappingsChanged = this.KeyMappingsChanged;
      if (keyMappingsChanged == null)
        return;
      keyMappingsChanged((object) this, EventArgs.Empty);
    }

    private void RemoveBtn_Click(object sender, EventArgs e) => this.RemoveMapping(this.tableLayoutPanel1.GetPositionFromControl((Control) sender).Row - 1);

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel1.ColumnCount = 5;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 79f));
      this.tableLayoutPanel1.Controls.Add((Control) this.label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.label2, 1, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.label3, 2, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.label4, 3, 0);
      this.tableLayoutPanel1.Dock = DockStyle.Top;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Margin = new Padding(2);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.Padding = new Padding(2, 2, 5, 2);
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel1.Size = new Size(394, 30);
      this.tableLayoutPanel1.TabIndex = 24;
      this.label1.AutoSize = true;
      this.label1.Dock = DockStyle.Fill;
      this.label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(5, 2);
      this.label1.Name = "label1";
      this.label1.Size = new Size(39, 26);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name";
      this.label2.AutoSize = true;
      this.label2.Dock = DockStyle.Fill;
      this.label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(50, 2);
      this.label2.Name = "label2";
      this.label2.Size = new Size(81, 26);
      this.label2.TabIndex = 1;
      this.label2.Text = "Toontown Key";
      this.label3.AutoSize = true;
      this.label3.Dock = DockStyle.Fill;
      this.label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(137, 2);
      this.label3.Name = "label3";
      this.label3.Size = new Size(81, 26);
      this.label3.TabIndex = 2;
      this.label3.Text = "Left Toon";
      this.label4.AutoSize = true;
      this.label4.Dock = DockStyle.Fill;
      this.label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(224, 2);
      this.label4.Name = "label4";
      this.label4.Size = new Size(81, 26);
      this.label4.TabIndex = 3;
      this.label4.Text = "Right Toon";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Margin = new Padding(2);
      this.Name = nameof (ControlsPicker);
      this.Size = new Size(394, 34);
      this.Load += new EventHandler(this.ControlsPicker_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public delegate void KeyMappingAddedHandler(object sender, KeyMapping keyMapping);

    public delegate void KeyMappingRemovedHandler(object sender, int row);
  }
}

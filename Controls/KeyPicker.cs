// Decompiled with JetBrains decompiler
// Type: Calculator.Controls.KeyPicker
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
  public class KeyPicker : UserControl
  {
    private const string DISABLED_FOCUSED_TEXT = "Disabled - press a key";
    private const string DISABLED_UNFOCUSED_TEXT = "Disabled - click here";
    private Keys _key;
    private bool isActive;
    private static Dictionary<Keys, string> alternateKeyTexts = new Dictionary<Keys, string>()
    {
      {
        Keys.Oemcomma,
        "Comma"
      },
      {
        Keys.OemPeriod,
        "Period"
      },
      {
        Keys.OemOpenBrackets,
        "Open Brackets"
      },
      {
        Keys.OemCloseBrackets,
        "Close Brackets"
      },
      {
        Keys.OemBackslash,
        "Backslash"
      },
      {
        Keys.OemQuotes,
        "Quote"
      },
      {
        Keys.OemSemicolon,
        "Semicolon"
      },
      {
        Keys.OemQuestion,
        "Forward Slash"
      },
      {
        Keys.OemMinus,
        "Minus"
      },
      {
        Keys.Oemplus,
        "Equals"
      },
      {
        Keys.Oemtilde,
        "Tilde"
      },
      {
        Keys.Menu,
        "Alt"
      },
      {
        Keys.ShiftKey,
        "Shift"
      },
      {
        Keys.ControlKey,
        "Control"
      },
      {
        Keys.D1,
        "1"
      },
      {
        Keys.D2,
        "2"
      },
      {
        Keys.D3,
        "3"
      },
      {
        Keys.D4,
        "4"
      },
      {
        Keys.D5,
        "5"
      },
      {
        Keys.D6,
        "6"
      },
      {
        Keys.D7,
        "7"
      },
      {
        Keys.D8,
        "8"
      },
      {
        Keys.D9,
        "9"
      },
      {
        Keys.D0,
        "0"
      },
      {
        Keys.Left,
        "LeftArrow"
      },
      {
        Keys.Right,
        "RightArrow"
      },
      {
        Keys.Down,
        "DownArrow"
      },
      {
        Keys.Up,
        "UpArrow"
      },
      {
        Keys.Back,
        "Backspace"
      },
      {
        Keys.Capital,
        "CapsLock"
      },
      {
        Keys.Next,
        "PageDown"
      }
    };
    private IContainer components;
    private TextBox textBox1;

    public event KeyPicker.KeyChosenHandler KeyChosen;

    static KeyPicker()
    {
      KeyPicker.alternateKeyTexts[Keys.OemPipe] = KeyPicker.alternateKeyTexts[Keys.OemBackslash];
      KeyPicker.alternateKeyTexts[Keys.OemCloseBrackets] = KeyPicker.alternateKeyTexts[Keys.OemCloseBrackets];
      KeyPicker.alternateKeyTexts[Keys.OemSemicolon] = KeyPicker.alternateKeyTexts[Keys.OemSemicolon];
      KeyPicker.alternateKeyTexts[Keys.OemQuotes] = KeyPicker.alternateKeyTexts[Keys.OemQuotes];
    }

    [Browsable(true)]
    public Keys ChosenKey
    {
      get => this._key;
      set
      {
        this._key = value;
        this.InvokeIfRequired((MethodInvoker) (() =>
        {
          string str = this._key.ToString();
          if (KeyPicker.alternateKeyTexts.ContainsKey(this._key))
            str = KeyPicker.alternateKeyTexts[this._key];
          else if (this._key == Keys.None)
            str = this.isActive ? "Disabled - press a key" : "Disabled - click here";
          this.textBox1.Text = str;
          if (this._key == Keys.None)
            this.textBox1.Font = new Font(this.textBox1.Font, FontStyle.Italic);
          else
            this.textBox1.Font = new Font(this.textBox1.Font, FontStyle.Regular);
        }));
      }
    }

    [Browsable(true)]
    public int ChosenKeyCode
    {
      get => (int) this._key;
      set => this.ChosenKey = (Keys) value;
    }

    public KeyPicker()
    {
      this.InitializeComponent();
      this.textBox1.Text = this._key.ToString();
      this.textBox1.Enter += new EventHandler(this.TextBox1_Enter);
      this.textBox1.Leave += new EventHandler(this.TextBox1_Leave);
    }

    private void TextBox1_Leave(object sender, EventArgs e)
    {
      this.isActive = false;
      if (this.ChosenKey != Keys.None)
        return;
      this.textBox1.Text = "Disabled - click here";
    }

    private void TextBox1_Enter(object sender, EventArgs e)
    {
      this.isActive = true;
      if (this.ChosenKey != Keys.None)
        return;
      this.textBox1.Text = "Disabled - press a key";
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData != Keys.Tab && keyData != Keys.Return && keyData != Keys.Escape)
        return base.ProcessCmdKey(ref msg, keyData);
      this.keyDown(keyData);
      return true;
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
      this.keyDown(e.KeyCode);
      e.SuppressKeyPress = true;
    }

    private void keyDown(Keys key)
    {
      this.ChosenKey = key;
      KeyPicker.KeyChosenHandler keyChosen = this.KeyChosen;
      if (keyChosen == null)
        return;
      keyChosen(this, this.ChosenKey);
    }

    private void textBox1_DoubleClick(object sender, EventArgs e) => this.keyDown(Keys.None);

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.textBox1 = new TextBox();
      this.SuspendLayout();
      this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox1.Location = new Point(0, 0);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(68, 20);
      this.textBox1.TabIndex = 2;
      this.textBox1.DoubleClick += new EventHandler(this.textBox1_DoubleClick);
      this.textBox1.KeyDown += new KeyEventHandler(this.textBox1_KeyDown);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.Controls.Add((Control) this.textBox1);
      this.MinimumSize = new Size(38, 20);
      this.Name = nameof (KeyPicker);
      this.Size = new Size(68, 20);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public delegate void KeyChosenHandler(KeyPicker chooser, Keys keyChosen);
  }
}

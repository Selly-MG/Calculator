// Decompiled with JetBrains decompiler
// Type: Calculator.Forms.AddKeyMappingDlg
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Calculator.Controls;

namespace Calculator.Forms
{
  internal class AddKeyMappingDlg : Form
  {
    private IContainer components;
    private GroupBox groupBox1;
    private KeyPicker bindingKeyPicker;
    private GroupBox groupBox2;
    private KeyPicker leftToonKeyPicker;
    private GroupBox groupBox3;
    private KeyPicker rightToonKeyPicker;
    private Button okBtn;
    private Button cancelBtn;
    private TextBox nameTxt;
    private GroupBox groupBox4;
    private Label label2;
    private Label label3;
    private Label label1;
    private Label label4;

    internal string BindingName => this.nameTxt.Text;

    internal Keys BindingKey => this.bindingKeyPicker.ChosenKey;

    internal Keys LeftToonKey => this.leftToonKeyPicker.ChosenKey;

    internal Keys RightToonKey => this.rightToonKeyPicker.ChosenKey;

    public AddKeyMappingDlg() => this.InitializeComponent();

    private void AddKeyMappingDlg_Load(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.groupBox1 = new GroupBox();
      this.label2 = new Label();
      this.bindingKeyPicker = new KeyPicker();
      this.groupBox2 = new GroupBox();
      this.label3 = new Label();
      this.leftToonKeyPicker = new KeyPicker();
      this.groupBox3 = new GroupBox();
      this.label4 = new Label();
      this.rightToonKeyPicker = new KeyPicker();
      this.okBtn = new Button();
      this.cancelBtn = new Button();
      this.nameTxt = new TextBox();
      this.groupBox4 = new GroupBox();
      this.label1 = new Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.SuspendLayout();
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.bindingKeyPicker);
      this.groupBox1.Location = new Point(12, 75);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(309, 58);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Key in Toontown:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(6, 16);
      this.label2.Name = "label2";
      this.label2.Size = new Size(195, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "What keyboard key is set in Toontown?";
      this.bindingKeyPicker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.bindingKeyPicker.ChosenKey = Keys.None;
      this.bindingKeyPicker.ChosenKeyCode = 0;
      this.bindingKeyPicker.Location = new Point(6, 32);
      this.bindingKeyPicker.MinimumSize = new Size(38, 20);
      this.bindingKeyPicker.Name = "bindingKeyPicker";
      this.bindingKeyPicker.Size = new Size(297, 20);
      this.bindingKeyPicker.TabIndex = 1;
      this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox2.Controls.Add((Control) this.label3);
      this.groupBox2.Controls.Add((Control) this.leftToonKeyPicker);
      this.groupBox2.Location = new Point(12, 139);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(309, 72);
      this.groupBox2.TabIndex = 2;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Left Toon Key:";
      this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label3.Location = new Point(6, 16);
      this.label3.Name = "label3";
      this.label3.Size = new Size(297, 28);
      this.label3.TabIndex = 3;
      this.label3.Text = "In multi-mode, what key do you want to press to activate this on the left toon?";
      this.leftToonKeyPicker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.leftToonKeyPicker.ChosenKey = Keys.None;
      this.leftToonKeyPicker.ChosenKeyCode = 0;
      this.leftToonKeyPicker.Location = new Point(6, 45);
      this.leftToonKeyPicker.MinimumSize = new Size(38, 20);
      this.leftToonKeyPicker.Name = "leftToonKeyPicker";
      this.leftToonKeyPicker.Size = new Size(297, 20);
      this.leftToonKeyPicker.TabIndex = 2;
      this.groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox3.Controls.Add((Control) this.label4);
      this.groupBox3.Controls.Add((Control) this.rightToonKeyPicker);
      this.groupBox3.Location = new Point(12, 218);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(309, 71);
      this.groupBox3.TabIndex = 3;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Right Toon Key:";
      this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label4.Location = new Point(6, 16);
      this.label4.Name = "label4";
      this.label4.Size = new Size(297, 28);
      this.label4.TabIndex = 3;
      this.label4.Text = "In multi-mode, what key do you want to press to activate this on the right toon?";
      this.rightToonKeyPicker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.rightToonKeyPicker.ChosenKey = Keys.None;
      this.rightToonKeyPicker.ChosenKeyCode = 0;
      this.rightToonKeyPicker.Location = new Point(6, 45);
      this.rightToonKeyPicker.MinimumSize = new Size(38, 20);
      this.rightToonKeyPicker.Name = "rightToonKeyPicker";
      this.rightToonKeyPicker.Size = new Size(297, 20);
      this.rightToonKeyPicker.TabIndex = 3;
      this.okBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.okBtn.DialogResult = DialogResult.OK;
      this.okBtn.Location = new Point(165, 299);
      this.okBtn.Name = "okBtn";
      this.okBtn.Size = new Size(75, 23);
      this.okBtn.TabIndex = 4;
      this.okBtn.Text = "Add";
      this.okBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cancelBtn.DialogResult = DialogResult.Cancel;
      this.cancelBtn.Location = new Point(246, 299);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new Size(75, 23);
      this.cancelBtn.TabIndex = 5;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.nameTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.nameTxt.Location = new Point(6, 32);
      this.nameTxt.Name = "nameTxt";
      this.nameTxt.Size = new Size(297, 20);
      this.nameTxt.TabIndex = 0;
      this.groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox4.Controls.Add((Control) this.label1);
      this.groupBox4.Controls.Add((Control) this.nameTxt);
      this.groupBox4.Location = new Point(12, 12);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(309, 57);
      this.groupBox4.TabIndex = 0;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Name:";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(6, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(156, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "What does this key binding do?";
      this.AcceptButton = (IButtonControl) this.okBtn;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.CancelButton = (IButtonControl) this.cancelBtn;
      this.ClientSize = new Size(333, 334);
      this.Controls.Add((Control) this.groupBox4);
      this.Controls.Add((Control) this.cancelBtn);
      this.Controls.Add((Control) this.okBtn);
      this.Controls.Add((Control) this.groupBox3);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (AddKeyMappingDlg);
      this.Text = "Add Custom Key Binding";
      this.Load += new EventHandler(this.AddKeyMappingDlg_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}

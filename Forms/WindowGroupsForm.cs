// Decompiled with JetBrains decompiler
// Type: Calculator.Forms.WindowGroupsForm
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Calculator.Controls;
using Calculator.Properties;

namespace Calculator.Forms
{
  public class WindowGroupsForm : Form
  {
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel1;
    private GroupBox groupBox1;
    private SelectWindowCrosshair rightToonCrosshair;
    private SelectWindowCrosshair leftToonCrosshair;
    private Label rightToonLbl;
    private Label leftToonLbl;
    private Button addGroupBtn;
    private Button removeGroupBtn;
    private Label label1;
    private Button okBtn;

    public WindowGroupsForm()
    {
      this.InitializeComponent();
      Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.groupBox1.Tag = (object) Multicontroller.Instance.ControllerGroups[0];
      for (int index = 1; index < Settings.Default.numberOfGroups; ++index)
        this.addGroup();
      for (int index = 0; index < Multicontroller.Instance.ControllerGroups.Count; ++index)
      {
        ControllerGroup controllerGroup = Multicontroller.Instance.ControllerGroups[index];
        List<SelectWindowCrosshair> list = this.tableLayoutPanel1.Controls[index].Controls.OfType<SelectWindowCrosshair>().ToList<SelectWindowCrosshair>();
        list.First<SelectWindowCrosshair>((Func<SelectWindowCrosshair, bool>) (c => (string) c.Tag == "left")).SelectedWindowHandle = controllerGroup.LeftController.TTWindowHandle;
        list.First<SelectWindowCrosshair>((Func<SelectWindowCrosshair, bool>) (c => (string) c.Tag == "right")).SelectedWindowHandle = controllerGroup.RightController.TTWindowHandle;
      }
    }

    private void addGroup()
    {
      this.tableLayoutPanel1.Controls.Add((Control) this.createGroupBox());
      this.addGroupBtn.Enabled = this.tableLayoutPanel1.Controls.Count < 10;
      this.removeGroupBtn.Enabled = true;
    }

    private GroupBox createGroupBox()
    {
      int count = this.tableLayoutPanel1.Controls.Count;
      ControllerGroup controllerGroup = Multicontroller.Instance.ControllerGroups.Count <= count ? Multicontroller.Instance.AddControllerGroup() : Multicontroller.Instance.ControllerGroups[count];
      GroupBox groupBox1 = new GroupBox();
      groupBox1.Width = this.groupBox1.Width;
      groupBox1.Height = this.groupBox1.Height;
      groupBox1.Text = "Group " + (object) (count + 1);
      groupBox1.Tag = (object) controllerGroup;
      GroupBox groupBox2 = groupBox1;
      Label label1 = new Label();
      label1.Location = this.leftToonLbl.Location;
      label1.Text = this.leftToonLbl.Text;
      label1.AutoSize = this.leftToonLbl.AutoSize;
      Label label2 = label1;
      Label label3 = new Label();
      label3.Location = this.rightToonLbl.Location;
      label3.Text = this.rightToonLbl.Text;
      label3.AutoSize = this.rightToonLbl.AutoSize;
      Label label4 = label3;
      SelectWindowCrosshair selectWindowCrosshair1 = new SelectWindowCrosshair();
      selectWindowCrosshair1.Location = this.leftToonCrosshair.Location;
      selectWindowCrosshair1.Size = this.leftToonCrosshair.Size;
      selectWindowCrosshair1.Tag = this.leftToonCrosshair.Tag;
      selectWindowCrosshair1.SelectedBorderColor = this.leftToonCrosshair.SelectedBorderColor;
      SelectWindowCrosshair selectWindowCrosshair2 = selectWindowCrosshair1;
      selectWindowCrosshair2.WindowSelected += new WindowSelectedHandler(this.crosshair_WindowSelected);
      SelectWindowCrosshair selectWindowCrosshair3 = new SelectWindowCrosshair();
      selectWindowCrosshair3.Location = this.rightToonCrosshair.Location;
      selectWindowCrosshair3.Size = this.rightToonCrosshair.Size;
      selectWindowCrosshair3.Tag = this.rightToonCrosshair.Tag;
      selectWindowCrosshair3.SelectedBorderColor = this.rightToonCrosshair.SelectedBorderColor;
      SelectWindowCrosshair selectWindowCrosshair4 = selectWindowCrosshair3;
      selectWindowCrosshair4.WindowSelected += new WindowSelectedHandler(this.crosshair_WindowSelected);
      groupBox2.Controls.AddRange(new Control[4]
      {
        (Control) label2,
        (Control) label4,
        (Control) selectWindowCrosshair2,
        (Control) selectWindowCrosshair4
      });
      return groupBox2;
    }

    private void WindowGroupsForm_FormClosing(object sender, FormClosingEventArgs e) => Settings.Default.Save();

    private void crosshair_WindowSelected(object sender, IntPtr handle)
    {
      SelectWindowCrosshair selectWindowCrosshair = (SelectWindowCrosshair) sender;
      ControllerGroup tag = (ControllerGroup) selectWindowCrosshair.Parent.Tag;
      (selectWindowCrosshair.Tag == this.leftToonCrosshair.Tag ? tag.LeftController : tag.RightController).TTWindowHandle = handle;
    }

    private void addGroupBtn_Click(object sender, EventArgs e)
    {
      if (this.tableLayoutPanel1.Controls.Count >= 10)
        return;
      this.addGroup();
      ++Settings.Default.numberOfGroups;
    }

    private void removeGroupBtn_Click(object sender, EventArgs e)
    {
      if (this.tableLayoutPanel1.Controls.Count <= 1)
        return;
      this.tableLayoutPanel1.Controls.RemoveAt(this.tableLayoutPanel1.Controls.Count - 1);
      this.addGroupBtn.Enabled = this.tableLayoutPanel1.Controls.Count < 10;
      this.removeGroupBtn.Enabled = this.tableLayoutPanel1.Controls.Count > 1;
      Multicontroller.Instance.RemoveControllerGroup(Multicontroller.Instance.ControllerGroups.Count - 1);
      --Settings.Default.numberOfGroups;
    }

    private void okBtn_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.groupBox1 = new GroupBox();
      this.rightToonLbl = new Label();
      this.leftToonLbl = new Label();
      this.rightToonCrosshair = new SelectWindowCrosshair();
      this.leftToonCrosshair = new SelectWindowCrosshair();
      this.addGroupBtn = new Button();
      this.removeGroupBtn = new Button();
      this.label1 = new Label();
      this.okBtn = new Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Controls.Add((Control) this.groupBox1, 0, 0);
      this.tableLayoutPanel1.Location = new Point(4, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel1.Size = new Size(178, 78);
      this.tableLayoutPanel1.TabIndex = 0;
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.rightToonLbl);
      this.groupBox1.Controls.Add((Control) this.leftToonLbl);
      this.groupBox1.Controls.Add((Control) this.rightToonCrosshair);
      this.groupBox1.Controls.Add((Control) this.leftToonCrosshair);
      this.groupBox1.Location = new Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(172, 72);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Group 1";
      this.rightToonLbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.rightToonLbl.AutoSize = true;
      this.rightToonLbl.Location = new Point(106, 16);
      this.rightToonLbl.Name = "rightToonLbl";
      this.rightToonLbl.Size = new Size(60, 13);
      this.rightToonLbl.TabIndex = 3;
      this.rightToonLbl.Text = "Right Toon";
      this.leftToonLbl.AutoSize = true;
      this.leftToonLbl.Location = new Point(6, 16);
      this.leftToonLbl.Name = "leftToonLbl";
      this.leftToonLbl.Size = new Size(53, 13);
      this.leftToonLbl.TabIndex = 2;
      this.leftToonLbl.Text = "Left Toon";
      this.rightToonCrosshair.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.rightToonCrosshair.BackColor = SystemColors.Control;
      this.rightToonCrosshair.Location = new Point(118, 32);
      this.rightToonCrosshair.Name = "rightToonCrosshair";
      this.rightToonCrosshair.SelectedBorderColor = Color.DarkGreen;
      this.rightToonCrosshair.Size = new Size(36, 36);
      this.rightToonCrosshair.TabIndex = 1;
      this.rightToonCrosshair.Tag = (object) "right";
      this.rightToonCrosshair.WindowSelected += new WindowSelectedHandler(this.crosshair_WindowSelected);
      this.leftToonCrosshair.BackColor = SystemColors.Control;
      this.leftToonCrosshair.Location = new Point(14, 32);
      this.leftToonCrosshair.Name = "leftToonCrosshair";
      this.leftToonCrosshair.Padding = new Padding(2);
      this.leftToonCrosshair.SelectedBorderColor = Color.LimeGreen;
      this.leftToonCrosshair.Size = new Size(36, 36);
      this.leftToonCrosshair.TabIndex = 0;
      this.leftToonCrosshair.Tag = (object) "left";
      this.leftToonCrosshair.WindowSelected += new WindowSelectedHandler(this.crosshair_WindowSelected);
      this.addGroupBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.addGroupBtn.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.addGroupBtn.Location = new Point(188, 12);
      this.addGroupBtn.Name = "addGroupBtn";
      this.addGroupBtn.Size = new Size(32, 32);
      this.addGroupBtn.TabIndex = 1;
      this.addGroupBtn.Text = "+";
      this.addGroupBtn.UseVisualStyleBackColor = true;
      this.addGroupBtn.Click += new EventHandler(this.addGroupBtn_Click);
      this.removeGroupBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.removeGroupBtn.Enabled = false;
      this.removeGroupBtn.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.removeGroupBtn.Location = new Point(188, 50);
      this.removeGroupBtn.Name = "removeGroupBtn";
      this.removeGroupBtn.Size = new Size(32, 32);
      this.removeGroupBtn.TabIndex = 2;
      this.removeGroupBtn.Text = "-";
      this.removeGroupBtn.UseVisualStyleBackColor = true;
      this.removeGroupBtn.Click += new EventHandler(this.removeGroupBtn_Click);
      this.label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.label1.Location = new Point(7, 98);
      this.label1.Name = "label1";
      this.label1.Size = new Size(213, 44);
      this.label1.TabIndex = 3;
      this.label1.Text = "Use the number keys to switch between groups in Multi-Mode. Mirror Mode will control all groups at the same time.";
      this.okBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.okBtn.Location = new Point(63, 145);
      this.okBtn.Margin = new Padding(2, 2, 2, 2);
      this.okBtn.Name = "okBtn";
      this.okBtn.Size = new Size(100, 27);
      this.okBtn.TabIndex = 4;
      this.okBtn.Text = "OK";
      this.okBtn.UseVisualStyleBackColor = true;
      this.okBtn.Click += new EventHandler(this.okBtn_Click);
      this.AcceptButton = (IButtonControl) this.okBtn;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.AutoSize = true;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.ClientSize = new Size(226, 180);
      this.Controls.Add((Control) this.okBtn);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.removeGroupBtn);
      this.Controls.Add((Control) this.addGroupBtn);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (WindowGroupsForm);
      this.Padding = new Padding(0, 0, 0, 85);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Window Groups";
      this.FormClosing += new FormClosingEventHandler(this.WindowGroupsForm_FormClosing);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

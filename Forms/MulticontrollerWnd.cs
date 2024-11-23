// Decompiled with JetBrains decompiler
// Type: Calculator.Forms.MulticontrollerWnd
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Calculator.Controls;
using Calculator.Properties;

namespace Calculator.Forms
{
  internal class MulticontrollerWnd : Form, IMessageFilter
  {
    private bool ignoreMessages;
    private Thread activationThread;
    private Multicontroller controller;
    private bool hotkeyRegistered;
    private bool userPromptedForAdminRights;
    private IContainer components;
    private OpenFileDialog openFileDialog1;
    private SaveFileDialog saveFileDialog1;
    private Button optionsBtn;
    private Button windowGroupsBtn;
    public SelectWindowCrosshair leftToonCrosshair;
    public SelectWindowCrosshair rightToonCrosshair;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel leftStatusLbl;
    private ToolStripStatusLabel toolStripStatusLabel2;
    private ToolStripStatusLabel rightStatusLbl;
    private RadioButton mirrorModeRadio;
    private RadioButton multiModeRadio;
    private Panel panel1;
    private ToolTip toolTip1;

    internal MulticontrollerWnd()
    {
      this.InitializeComponent();
      Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
    }

    internal void TryActivate()
    {
      if (this.activationThread != null && this.activationThread.ThreadState == System.Threading.ThreadState.Running)
        return;
      this.activationThread = new Thread(new ThreadStart(this.activationThreadFunc))
      {
        IsBackground = true
      };
      this.activationThread.Start();
    }

    private void activationThreadFunc()
    {
      IntPtr hWnd = IntPtr.Zero;
      this.InvokeIfRequired((MethodInvoker) (() => hWnd = this.Handle));
      Stopwatch stopwatch = Stopwatch.StartNew();
      while (!this.IsDisposed)
      {
        if (stopwatch.ElapsedMilliseconds < 100L)
        {
          this.InvokeIfRequired((MethodInvoker) (() => this.Activate()));
        }
        else
        {
          this.InvokeIfRequired((MethodInvoker) (() => this.TopMost = true));
          int num1 = this.DisplayRectangle.Width / 2;
          Point point = this.Location;
          int x = point.X;
          int num2 = num1 + x;
          point = this.Location;
          int num3 = point.Y + SystemInformation.CaptionHeight / 2;
          Rectangle virtualScreen = SystemInformation.VirtualScreen;
          int num4 = (num2 - virtualScreen.Left) * 65536 / virtualScreen.Width;
          int num5 = (num3 - virtualScreen.Top) * 65536 / virtualScreen.Height;
          point = Control.MousePosition;
          int num6 = (int) Math.Ceiling((double) (point.X - virtualScreen.Left) * 65536.0 / (double) virtualScreen.Width);
          point = Control.MousePosition;
          int num7 = (int) Math.Ceiling((double) (point.Y - virtualScreen.Top) * 65536.0 / (double) virtualScreen.Height);
          Win32.INPUT[] inputArray = new Win32.INPUT[3];
          Win32.INPUT input = new Win32.INPUT();
          input.type = 0U;
          ref Win32.INPUT local1 = ref input;
          Win32.InputUnion inputUnion1 = new Win32.InputUnion();
          ref Win32.InputUnion local2 = ref inputUnion1;
          Win32.MOUSEINPUT mouseinput1 = new Win32.MOUSEINPUT();
          mouseinput1.dx = num4;
          mouseinput1.dy = num5;
          mouseinput1.dwFlags = Win32.MOUSEEVENTF.ABSOLUTE | Win32.MOUSEEVENTF.MOVE | Win32.MOUSEEVENTF.LEFTDOWN | Win32.MOUSEEVENTF.VIRTUALDESK;
          Win32.MOUSEINPUT mouseinput2 = mouseinput1;
          local2.mi = mouseinput2;
          Win32.InputUnion inputUnion2 = inputUnion1;
          local1.U = inputUnion2;
          inputArray[0] = input;
          input = new Win32.INPUT();
          input.type = 0U;
          ref Win32.INPUT local3 = ref input;
          Win32.InputUnion inputUnion3 = new Win32.InputUnion();
          ref Win32.InputUnion local4 = ref inputUnion3;
          mouseinput1 = new Win32.MOUSEINPUT();
          mouseinput1.dx = 0;
          mouseinput1.dy = 0;
          mouseinput1.dwFlags = Win32.MOUSEEVENTF.LEFTUP;
          Win32.MOUSEINPUT mouseinput3 = mouseinput1;
          local4.mi = mouseinput3;
          Win32.InputUnion inputUnion4 = inputUnion3;
          local3.U = inputUnion4;
          inputArray[1] = input;
          input = new Win32.INPUT();
          input.type = 0U;
          ref Win32.INPUT local5 = ref input;
          Win32.InputUnion inputUnion5 = new Win32.InputUnion();
          ref Win32.InputUnion local6 = ref inputUnion5;
          mouseinput1 = new Win32.MOUSEINPUT();
          mouseinput1.dx = num6;
          mouseinput1.dy = num7;
          mouseinput1.dwFlags = Win32.MOUSEEVENTF.ABSOLUTE | Win32.MOUSEEVENTF.MOVE | Win32.MOUSEEVENTF.VIRTUALDESK;
          Win32.MOUSEINPUT mouseinput4 = mouseinput1;
          local6.mi = mouseinput4;
          Win32.InputUnion inputUnion6 = inputUnion5;
          local5.U = inputUnion6;
          inputArray[2] = input;
          Win32.INPUT[] pInputs = inputArray;
          int num8 = (int) Win32.SendInput((uint) pInputs.Length, pInputs, Win32.INPUT.Size);
        }
        Thread.Sleep(10);
        if (Win32.GetForegroundWindow() == hWnd)
          this.InvokeIfRequired((MethodInvoker) (() => this.TopMost = Settings.Default.onTopWhenInactive));
        else if (stopwatch.Elapsed.TotalSeconds < 5.0)
          continue;
        stopwatch.Stop();
        break;
      }
    }

    internal void UpdateWindowStatus()
    {
      this.leftToonCrosshair.SelectedWindowHandle = this.controller.LeftController.TTWindowHandle;
      this.rightToonCrosshair.SelectedWindowHandle = this.controller.RightController.TTWindowHandle;
      this.leftStatusLbl.Text = "Group " + (object) (this.controller.CurrentGroupIndex + 1) + " active.";
      this.rightStatusLbl.Text = this.controller.ControllerGroups.Count.ToString() + " groups.";
      if (!this.statusStrip1.Visible && this.controller.ControllerGroups.Count > 1 && !Settings.Default.controlAllGroupsAtOnce)
      {
        this.statusStrip1.Visible = true;
        Padding padding = this.Padding;
        int left = padding.Left;
        padding = this.Padding;
        int top = padding.Top;
        padding = this.Padding;
        int right = padding.Right;
        padding = this.Padding;
        int bottom = padding.Bottom + this.statusStrip1.Height;
        this.Padding = new Padding(left, top, right, bottom);
      }
      else
      {
        if (!this.statusStrip1.Visible || this.controller.ControllerGroups.Count != 1 && !Settings.Default.controlAllGroupsAtOnce)
          return;
        int left = this.Padding.Left;
        Padding padding = this.Padding;
        int top = padding.Top;
        padding = this.Padding;
        int right = padding.Right;
        padding = this.Padding;
        int bottom = padding.Bottom - this.statusStrip1.Height;
        this.Padding = new Padding(left, top, right, bottom);
        this.statusStrip1.Visible = false;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch (keyData)
      {
        case Keys.Tab:
        case Keys.Left:
        case Keys.Up:
        case Keys.Right:
        case Keys.Down:
        case Keys.Alt:
          return true;
        default:
          return base.ProcessCmdKey(ref msg, keyData);
      }
    }

    public bool PreFilterMessage(ref Message m)
    {
      if (this.ignoreMessages)
        return false;
      bool flag = false;
      switch ((Win32.WM) m.Msg)
      {
        case Win32.WM.KEYDOWN:
        case Win32.WM.KEYUP:
        case Win32.WM.SYSKEYDOWN:
        case Win32.WM.SYSKEYUP:
        case Win32.WM.SYSCOMMAND:
        case Win32.WM.HOTKEY:
          flag = this.controller.ProcessKey((Keys) m.WParam.ToInt32(), (uint) m.Msg, m.LParam);
          break;
      }
      this.CheckControllerErrors();
      return flag;
    }

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == 786)
      {
        this.controller.ProcessKey((Keys) Settings.Default.modeKeyCode, (uint) m.Msg, IntPtr.Zero);
        this.CheckControllerErrors();
      }
      base.WndProc(ref m);
    }

    internal void CheckControllerErrors()
    {
      if (this.userPromptedForAdminRights || !this.controller.ErrorOccurredPostingMessage)
        return;
      this.userPromptedForAdminRights = true;
      if (MessageBox.Show("There was an error controlling a Toontown window. You may need to run the multicontroller as administrator.\n\nDo you want to re-launch as administrator?", "Error", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      Settings.Default.runAsAdministrator = true;
      Settings.Default.Save();
      if (Program.TryRunAsAdmin())
      {
        Application.Exit();
      }
      else
      {
        int num = (int) MessageBox.Show("Failed to re-launch as administrator.", "Error");
      }
    }

    internal void SaveWindowPosition()
    {
      Settings.Default.lastLocation = this.Location;
      Settings.Default.Save();
    }

    private void ReloadOptions()
    {
      this.TopMost = Settings.Default.onTopWhenInactive;
      this.panel1.Visible = !Settings.Default.compactUI;
      this.controller.UpdateKeys();
      this.UnregisterHotkey();
    }

    private bool RegisterHotkey()
    {
      if (!this.hotkeyRegistered)
        this.hotkeyRegistered = Win32.RegisterHotKey(this.Handle, 0, Win32.KeyModifiers.None, (Keys) Settings.Default.modeKeyCode);
      return this.hotkeyRegistered;
    }

    private void UnregisterHotkey()
    {
      Win32.UnregisterHotKey(this.Handle, 0);
      this.hotkeyRegistered = false;
    }

    private void MulticontrollerWnd_Load(object sender, EventArgs e)
    {
      this.controller = Multicontroller.Instance;
      this.controller.ModeChanged += new EventHandler(this.Controller_ModeChanged);
      this.controller.GroupsChanged += new EventHandler(this.Controller_GroupsChanged);
      this.controller.ShouldActivate += new EventHandler(this.Controller_ShouldActivate);
      this.controller.TTWindowActivated += new EventHandler(this.Controller_TTWindowActivated);
      this.controller.AllTTWindowsInactive += new EventHandler(this.Controller_AllTTWindowsInactive);
      StatusStrip statusStrip1 = this.statusStrip1;
      Padding padding1 = this.statusStrip1.Padding;
      int left1 = padding1.Left;
      padding1 = this.statusStrip1.Padding;
      int top = padding1.Top;
      padding1 = this.statusStrip1.Padding;
      int left2 = padding1.Left;
      padding1 = this.statusStrip1.Padding;
      int bottom = padding1.Bottom;
      Padding padding2 = new Padding(left1, top, left2, bottom);
      statusStrip1.Padding = padding2;
      Application.AddMessageFilter((IMessageFilter) this);
      if (Settings.Default.lastLocation != Point.Empty)
      {
        Point lastLocation = Settings.Default.lastLocation;
        bool flag = false;
        foreach (Screen allScreen in Screen.AllScreens)
        {
          if (allScreen.Bounds.Contains(lastLocation))
          {
            flag = true;
            break;
          }
        }
        if (flag)
          this.Location = Settings.Default.lastLocation;
      }
      this.ReloadOptions();
      this.UpdateWindowStatus();
    }

    private void Controller_AllTTWindowsInactive(object sender, EventArgs e)
    {
      try
      {
        this.InvokeIfRequired((MethodInvoker) (() => this.UnregisterHotkey()));
      }
      catch
      {
      }
    }

    private void Controller_TTWindowActivated(object sender, EventArgs e)
    {
      try
      {
        this.InvokeIfRequired((MethodInvoker) (() => this.RegisterHotkey()));
      }
      catch
      {
      }
    }

        private void MainWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.activationThread != null)
                {
                    this.activationThread.Abort();
                }
            }
            catch
            {
            }
            this.SaveWindowPosition();
        }

    private void Controller_GroupsChanged(object sender, EventArgs e) => this.UpdateWindowStatus();

    private void Controller_ShouldActivate(object sender, EventArgs e) => this.TryActivate();

    private void Controller_ModeChanged(object sender, EventArgs e) => this.InvokeIfRequired((MethodInvoker) (() =>
    {
      switch (this.controller.CurrentMode)
      {
        case Multicontroller.ControllerMode.Multi:
          this.multiModeRadio.Checked = true;
          break;
        case Multicontroller.ControllerMode.Mirror:
          this.mirrorModeRadio.Checked = true;
          break;
      }
    }));

    private void optionsBtn_Click(object sender, EventArgs e)
    {
      OptionsDlg optionsDlg = new OptionsDlg();
      this.ignoreMessages = true;
      if (optionsDlg.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.ReloadOptions();
      this.ignoreMessages = false;
      this.UpdateWindowStatus();
    }

    private void windowGroupsBtn_Click(object sender, EventArgs e)
    {
      this.controller.ShowAllBorders = true;
      this.ignoreMessages = true;
      int num = (int) new WindowGroupsForm().ShowDialog((IWin32Window) this);
      this.ignoreMessages = false;
      this.controller.ShowAllBorders = false;
      this.UpdateWindowStatus();
    }

    private void leftToonCrosshair_WindowSelected(object sender, IntPtr handle) => Multicontroller.Instance.LeftController.TTWindowHandle = handle;

    private void rightToonCrosshair_WindowSelected(object sender, IntPtr handle) => Multicontroller.Instance.RightController.TTWindowHandle = handle;

    private void multiModeRadio_Click(object sender, EventArgs e) => this.controller.CurrentMode = Multicontroller.ControllerMode.Multi;

    private void mirrorModeRadio_Clicked(object sender, EventArgs e) => this.controller.CurrentMode = Multicontroller.ControllerMode.Mirror;

    private void MulticontrollerWnd_Activated(object sender, EventArgs e) => this.controller.IsActive = true;

    private void MulticontrollerWnd_Deactivate(object sender, EventArgs e)
    {
      if (this.ignoreMessages)
        return;
      this.controller.IsActive = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.mirrorModeRadio = new RadioButton();
      this.multiModeRadio = new RadioButton();
      this.openFileDialog1 = new OpenFileDialog();
      this.saveFileDialog1 = new SaveFileDialog();
      this.optionsBtn = new Button();
      this.windowGroupsBtn = new Button();
      this.statusStrip1 = new StatusStrip();
      this.leftStatusLbl = new ToolStripStatusLabel();
      this.toolStripStatusLabel2 = new ToolStripStatusLabel();
      this.rightStatusLbl = new ToolStripStatusLabel();
      this.rightToonCrosshair = new SelectWindowCrosshair();
      this.leftToonCrosshair = new SelectWindowCrosshair();
      this.panel1 = new Panel();
      this.toolTip1 = new ToolTip(this.components);
      this.statusStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.mirrorModeRadio.Appearance = Appearance.Button;
      this.mirrorModeRadio.FlatAppearance.BorderColor = Color.Violet;
      this.mirrorModeRadio.FlatAppearance.BorderSize = 3;
      this.mirrorModeRadio.FlatAppearance.CheckedBackColor = Color.Violet;
      this.mirrorModeRadio.FlatStyle = FlatStyle.Flat;
      this.mirrorModeRadio.Location = new Point(109, 0);
      this.mirrorModeRadio.Name = "mirrorModeRadio";
      this.mirrorModeRadio.Size = new Size(104, 27);
      this.mirrorModeRadio.TabIndex = 3;
      this.mirrorModeRadio.Text = "Mirror Mode";
      this.mirrorModeRadio.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.mirrorModeRadio, "Control all toons at the same time");
      this.mirrorModeRadio.UseVisualStyleBackColor = true;
      this.mirrorModeRadio.Click += new EventHandler(this.mirrorModeRadio_Clicked);
      this.multiModeRadio.Appearance = Appearance.Button;
      this.multiModeRadio.Checked = true;
      this.multiModeRadio.FlatAppearance.BorderColor = Color.LimeGreen;
      this.multiModeRadio.FlatAppearance.BorderSize = 3;
      this.multiModeRadio.FlatAppearance.CheckedBackColor = Color.LimeGreen;
      this.multiModeRadio.FlatStyle = FlatStyle.Flat;
      this.multiModeRadio.Location = new Point(0, 0);
      this.multiModeRadio.Name = "multiModeRadio";
      this.multiModeRadio.Size = new Size(104, 27);
      this.multiModeRadio.TabIndex = 6;
      this.multiModeRadio.TabStop = true;
      this.multiModeRadio.Text = "Multi-Mode";
      this.multiModeRadio.TextAlign = ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip((Control) this.multiModeRadio, "Control left and right toon independently");
      this.multiModeRadio.UseVisualStyleBackColor = true;
      this.multiModeRadio.Click += new EventHandler(this.multiModeRadio_Click);
      this.openFileDialog1.FileName = "openFileDialog1";
      this.openFileDialog1.Filter = "Key Sequence|*.keyseq";
      this.saveFileDialog1.Filter = "Key Sequence|*.keyseq";
      this.optionsBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.optionsBtn.FlatStyle = FlatStyle.System;
      this.optionsBtn.Location = new Point(54, 30);
      this.optionsBtn.Name = "optionsBtn";
      this.optionsBtn.Size = new Size(122, 20);
      this.optionsBtn.TabIndex = 8;
      this.optionsBtn.Text = "Options";
      this.optionsBtn.TextAlign = ContentAlignment.TopCenter;
      this.optionsBtn.UseVisualStyleBackColor = true;
      this.optionsBtn.Click += new EventHandler(this.optionsBtn_Click);
      this.windowGroupsBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.windowGroupsBtn.FlatStyle = FlatStyle.System;
      this.windowGroupsBtn.Location = new Point(54, 6);
      this.windowGroupsBtn.Name = "windowGroupsBtn";
      this.windowGroupsBtn.Size = new Size(122, 20);
      this.windowGroupsBtn.TabIndex = 12;
      this.windowGroupsBtn.Text = "Window Groups";
      this.windowGroupsBtn.TextAlign = ContentAlignment.TopCenter;
      this.windowGroupsBtn.UseVisualStyleBackColor = true;
      this.windowGroupsBtn.Click += new EventHandler(this.windowGroupsBtn_Click);
      this.statusStrip1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.statusStrip1.AutoSize = false;
      this.statusStrip1.Dock = DockStyle.None;
      this.statusStrip1.ImageScalingSize = new Size(20, 20);
      this.statusStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.leftStatusLbl,
        (ToolStripItem) this.toolStripStatusLabel2,
        (ToolStripItem) this.rightStatusLbl
      });
      this.statusStrip1.Location = new Point(0, 90);
      this.statusStrip1.Margin = new Padding(0, 25, 0, 0);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Padding = new Padding(1, 0, 15, 0);
      this.statusStrip1.Size = new Size(230, 22);
      this.statusStrip1.SizingGrip = false;
      this.statusStrip1.TabIndex = 15;
      this.statusStrip1.Text = "statusStrip1";
      this.leftStatusLbl.Name = "leftStatusLbl";
      this.leftStatusLbl.Size = new Size(0, 17);
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      this.toolStripStatusLabel2.Size = new Size(214, 17);
      this.toolStripStatusLabel2.Spring = true;
      this.toolStripStatusLabel2.TextAlign = ContentAlignment.MiddleRight;
      this.rightStatusLbl.Name = "rightStatusLbl";
      this.rightStatusLbl.Size = new Size(0, 17);
      this.rightToonCrosshair.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.rightToonCrosshair.BackColor = SystemColors.Control;
      this.rightToonCrosshair.Location = new Point(186, 10);
      this.rightToonCrosshair.Name = "rightToonCrosshair";
      this.rightToonCrosshair.Padding = new Padding(2);
      this.rightToonCrosshair.SelectedBorderColor = Color.DarkGreen;
      this.rightToonCrosshair.Size = new Size(36, 36);
      this.rightToonCrosshair.TabIndex = 14;
      this.rightToonCrosshair.WindowSelected += new WindowSelectedHandler(this.rightToonCrosshair_WindowSelected);
      this.leftToonCrosshair.BackColor = SystemColors.Control;
      this.leftToonCrosshair.Location = new Point(9, 10);
      this.leftToonCrosshair.Name = "leftToonCrosshair";
      this.leftToonCrosshair.Padding = new Padding(2);
      this.leftToonCrosshair.SelectedBorderColor = Color.LimeGreen;
      this.leftToonCrosshair.Size = new Size(36, 36);
      this.leftToonCrosshair.TabIndex = 13;
      this.leftToonCrosshair.WindowSelected += new WindowSelectedHandler(this.leftToonCrosshair_WindowSelected);
      this.panel1.Controls.Add((Control) this.mirrorModeRadio);
      this.panel1.Controls.Add((Control) this.multiModeRadio);
      this.panel1.Location = new Point(9, 56);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(213, 27);
      this.panel1.TabIndex = 7;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.AutoSize = true;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.ClientSize = new Size(228, 112);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.statusStrip1);
      this.Controls.Add((Control) this.rightToonCrosshair);
      this.Controls.Add((Control) this.leftToonCrosshair);
      this.Controls.Add((Control) this.windowGroupsBtn);
      this.Controls.Add((Control) this.optionsBtn);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (MulticontrollerWnd);
      this.Padding = new Padding(6, 6, 3, 26);
      this.Text = "Calculator";
      this.Activated += new EventHandler(this.MulticontrollerWnd_Activated);
      this.Deactivate += new EventHandler(this.MulticontrollerWnd_Deactivate);
      this.FormClosing += new FormClosingEventHandler(this.MainWnd_FormClosing);
      this.Load += new EventHandler(this.MulticontrollerWnd_Load);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}

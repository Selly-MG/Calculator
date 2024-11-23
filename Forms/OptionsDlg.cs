// Decompiled with JetBrains decompiler
// Type: Calculator.Forms.OptionsDlg
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Calculator.Controls;
using Calculator.Properties;

namespace Calculator.Forms
{
  public class OptionsDlg : Form
  {
    private bool loaded;
    private IContainer components;
    private Button okBtn;
    private Button cancelBtn;
    private Button aboutBtn;
    private Button checkUpdateBtn;
    private TabControl tabControl1;
    private TabPage tabPage3;
    private KeyPicker keyPicker1;
    private TabPage tabPage2;
    private CheckBox checkBox2;
    private ToolTip toolTip1;
    private CheckBox checkBox3;
    private TabPage tabPage5;
    private CheckBox checkBox4;
    private Label label2;
    private KeyPicker keyPicker2;
    private TabPage tabPage6;
    private Label label3;
    private ControlsPicker controlsPicker;
    private Button addBindingBtn;
    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel3;
    private Label label6;
    private GroupBox groupBox1;
    private Label label4;
    private CheckBox controlAllGroupsChk;
    private TableLayoutPanel tableLayoutPanel2;
    private GroupBox groupBox2;
    private Label label1;
    private KeyPicker keyPicker3;

    public OptionsDlg()
    {
      this.InitializeComponent();
      Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.toolTip1.SetToolTip((Control) this.checkBox2, "If checked, the Multicontroller window will stay on top of everything else. Otherwise, it will go to the background when it's deactivated by clicking on another window.");
      this.toolTip1.SetToolTip((Control) this.checkBox3, "If checked, some of the UI elements will be hidden to make the Multicontroller window smaller.");
    }

    private void checkUpdates_ClickOnce()
    {
      ApplicationDeployment currentDeployment = ApplicationDeployment.CurrentDeployment;
      UpdateCheckInfo updateCheckInfo;
      try
      {
        updateCheckInfo = currentDeployment.CheckForDetailedUpdate();
      }
      catch (DeploymentDownloadException ex)
      {
        int num = (int) MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + ex.Message);
        return;
      }
      catch (InvalidDeploymentException ex)
      {
        int num = (int) MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ex.Message);
        return;
      }
      catch (InvalidOperationException ex)
      {
        int num = (int) MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ex.Message);
        return;
      }
      if (updateCheckInfo.UpdateAvailable)
      {
        bool flag = true;
        if (!updateCheckInfo.IsUpdateRequired)
        {
          if (DialogResult.OK != MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel))
            flag = false;
        }
        else
        {
          int num1 = (int) MessageBox.Show("This application has detected a mandatory update from your current version to version " + updateCheckInfo.MinimumRequiredVersion.ToString() + ". The application will now install the update and restart.", "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        if (!flag)
          return;
        try
        {
          currentDeployment.Update();
          int num2 = (int) MessageBox.Show("The application has been upgraded, and will now restart.");
          System.Windows.Forms.Application.Restart();
        }
        catch (DeploymentDownloadException ex)
        {
          int num2 = (int) MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + (object) ex);
        }
      }
      else
      {
        int num3 = (int) MessageBox.Show("There are no updates available at the moment.", "No Update Available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void checkUpdates_Standalone()
    {
      string latestVersion = (string) null;
      Thread thread = new Thread((ThreadStart) (() =>
      {
        try
        {
          using (HttpWebResponse response = (HttpWebResponse) WebRequest.Create(Settings.Default.homepageUrl + "/version.txt").GetResponse())
          {
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
              latestVersion = streamReader.ReadToEnd();
          }
        }
        catch
        {
        }
      }))
      {
        IsBackground = true
      };
      thread.Start();
      this.Enabled = false;
      this.UseWaitCursor = true;
      Stopwatch stopwatch = Stopwatch.StartNew();
      while (thread.IsAlive && stopwatch.ElapsedMilliseconds < 5000L)
      {
        System.Windows.Forms.Application.DoEvents();
        Thread.Sleep(10);
      }
      if (thread.IsAlive)
      {
        thread.Abort();
        latestVersion = (string) null;
      }
      if (!string.IsNullOrEmpty(latestVersion))
      {
        if (System.Windows.Forms.Application.ProductVersion != latestVersion)
        {
          int num1 = (int) MessageBox.Show(string.Format("An update is available to version {0}. Click the About button to view the homepage.", (object) latestVersion), "Update available");
        }
        else
        {
          int num2 = (int) MessageBox.Show("No updates available.");
        }
      }
      else
      {
        int num3 = (int) MessageBox.Show("Could not check for a new version of the application.", "Error");
      }
      this.UseWaitCursor = false;
      this.Enabled = true;
    }

        private void OptionsDlg_Load(object sender, EventArgs e)
        {
            this.controlsPicker.KeyMappings = SerializedSettings.Default.Bindings;
            this.loaded = true;
            // Use the 'loaded' field to perform any additional actions if needed
            if (this.loaded)
            {
                // Perform actions that depend on the form being fully loaded
            }
        }

    private void okBtn_Click(object sender, EventArgs e)
    {
      SerializedSettings.Default.Bindings = this.controlsPicker.KeyMappings;
      Settings.Default.Save();
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void cancelBtn_Click(object sender, EventArgs e)
    {
      Settings.Default.Reload();
      this.DialogResult = DialogResult.Cancel;
    }

    private void aboutBtn_Click(object sender, EventArgs e)
    {
      int num = (int) new AboutWnd().ShowDialog((IWin32Window) this);
    }

    private void checkUpdateBtn_Click(object sender, EventArgs e)
    {
      if (ApplicationDeployment.IsNetworkDeployed)
        this.checkUpdates_ClickOnce();
      else
        this.checkUpdates_Standalone();
    }

    private void addBindingBtn_Click(object sender, EventArgs e)
    {
      AddKeyMappingDlg addKeyMappingDlg = new AddKeyMappingDlg();
      while (addKeyMappingDlg.ShowDialog() == DialogResult.OK)
      {
        List<KeyMapping> keyMappings = this.controlsPicker.KeyMappings;
        if (string.IsNullOrEmpty(addKeyMappingDlg.BindingName.Trim()))
        {
          int num1 = (int) MessageBox.Show("Please enter a name for the binding.");
        }
        else
        {
          if (addKeyMappingDlg.LeftToonKey >= Keys.D0 && addKeyMappingDlg.LeftToonKey <= Keys.D9 || addKeyMappingDlg.LeftToonKey >= Keys.NumPad0 && addKeyMappingDlg.LeftToonKey <= Keys.NumPad9 || (addKeyMappingDlg.RightToonKey >= Keys.D0 && addKeyMappingDlg.RightToonKey <= Keys.D9 || addKeyMappingDlg.RightToonKey >= Keys.NumPad0 && addKeyMappingDlg.RightToonKey <= Keys.NumPad9))
          {
            int num2 = (int) MessageBox.Show("Note: the number keys (0-9) and number pad keys are reserved for switching groups if there is more than 1 group.");
          }
          this.controlsPicker.AddMapping(new KeyMapping(addKeyMappingDlg.BindingName, addKeyMappingDlg.BindingKey, addKeyMappingDlg.LeftToonKey, addKeyMappingDlg.RightToonKey, false));
          break;
        }
      }
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (OptionsDlg));
      this.okBtn = new Button();
      this.cancelBtn = new Button();
      this.aboutBtn = new Button();
      this.checkUpdateBtn = new Button();
      this.tabControl1 = new TabControl();
      this.tabPage6 = new TabPage();
      this.tableLayoutPanel3 = new TableLayoutPanel();
      this.label6 = new Label();
      this.label3 = new Label();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.controlsPicker = new ControlsPicker();
      this.addBindingBtn = new Button();
      this.tabPage3 = new TabPage();
      this.groupBox1 = new GroupBox();
      this.label4 = new Label();
      this.keyPicker1 = new KeyPicker();
      this.tabPage5 = new TabPage();
      this.label2 = new Label();
      this.checkBox4 = new CheckBox();
      this.keyPicker2 = new KeyPicker();
      this.tabPage2 = new TabPage();
      this.controlAllGroupsChk = new CheckBox();
      this.checkBox3 = new CheckBox();
      this.checkBox2 = new CheckBox();
      this.toolTip1 = new ToolTip(this.components);
      this.tableLayoutPanel2 = new TableLayoutPanel();
      this.groupBox2 = new GroupBox();
      this.label1 = new Label();
      this.keyPicker3 = new KeyPicker();
      this.tabControl1.SuspendLayout();
      this.tabPage6.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabPage5.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.okBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.okBtn.Location = new Point(554, 494);
      this.okBtn.Margin = new Padding(4, 4, 4, 4);
      this.okBtn.Name = "okBtn";
      this.okBtn.Size = new Size(100, 28);
      this.okBtn.TabIndex = 0;
      this.okBtn.Text = "OK";
      this.okBtn.UseVisualStyleBackColor = true;
      this.okBtn.Click += new EventHandler(this.okBtn_Click);
      this.cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cancelBtn.DialogResult = DialogResult.Cancel;
      this.cancelBtn.Location = new Point(665, 494);
      this.cancelBtn.Margin = new Padding(4, 4, 4, 4);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new Size(100, 28);
      this.cancelBtn.TabIndex = 1;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new EventHandler(this.cancelBtn_Click);
      this.aboutBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.aboutBtn.Location = new Point(15, 494);
      this.aboutBtn.Margin = new Padding(4, 4, 4, 4);
      this.aboutBtn.Name = "aboutBtn";
      this.aboutBtn.Size = new Size(100, 28);
      this.aboutBtn.TabIndex = 12;
      this.aboutBtn.Text = "About...";
      this.aboutBtn.UseVisualStyleBackColor = true;
      this.aboutBtn.Click += new EventHandler(this.aboutBtn_Click);
      this.checkUpdateBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.checkUpdateBtn.Location = new Point(122, 494);
      this.checkUpdateBtn.Margin = new Padding(4, 4, 4, 4);
      this.checkUpdateBtn.Name = "checkUpdateBtn";
      this.checkUpdateBtn.Size = new Size(139, 28);
      this.checkUpdateBtn.TabIndex = 13;
      this.checkUpdateBtn.Text = "Check for Updates";
      this.checkUpdateBtn.UseVisualStyleBackColor = true;
      this.checkUpdateBtn.Click += new EventHandler(this.checkUpdateBtn_Click);
      this.tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tabControl1.Controls.Add((Control) this.tabPage6);
      this.tabControl1.Controls.Add((Control) this.tabPage3);
      this.tabControl1.Controls.Add((Control) this.tabPage5);
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Location = new Point(16, 15);
      this.tabControl1.Margin = new Padding(4, 4, 4, 4);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(750, 472);
      this.tabControl1.TabIndex = 14;
      this.tabPage6.Controls.Add((Control) this.tableLayoutPanel3);
      this.tabPage6.Location = new Point(4, 25);
      this.tabPage6.Margin = new Padding(2);
      this.tabPage6.Name = "tabPage6";
      this.tabPage6.Padding = new Padding(2);
      this.tabPage6.Size = new Size(742, 443);
      this.tabPage6.TabIndex = 6;
      this.tabPage6.Text = "Multi-Mode Key Bindings";
      this.tabPage6.UseVisualStyleBackColor = true;
      this.tableLayoutPanel3.ColumnCount = 1;
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel3.Controls.Add((Control) this.label6, 0, 3);
      this.tableLayoutPanel3.Controls.Add((Control) this.label3, 0, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.tableLayoutPanel1, 0, 1);
      this.tableLayoutPanel3.Dock = DockStyle.Fill;
      this.tableLayoutPanel3.Location = new Point(2, 2);
      this.tableLayoutPanel3.Margin = new Padding(4, 4, 4, 4);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 4;
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel3.Size = new Size(738, 439);
      this.tableLayoutPanel3.TabIndex = 24;
      this.label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.label6.Location = new Point(4, 365);
      this.label6.Margin = new Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new Size(730, 74);
      this.label6.TabIndex = 24;
      this.label6.Text = componentResourceManager.GetString("label6.Text");
      this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label3.Location = new Point(4, 0);
      this.label3.Margin = new Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(730, 38);
      this.label3.TabIndex = 21;
      this.label3.Text = "These are the keys that the multicontroller will send to Toontown while in multi-mode. Make sure the Toontown keys match your key bindings in your game options.";
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.controlsPicker, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.addBindingBtn, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(4, 42);
      this.tableLayoutPanel1.Margin = new Padding(4, 4, 4, 4);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel1.Size = new Size(730, 319);
      this.tableLayoutPanel1.TabIndex = 23;
      this.controlsPicker.AutoScroll = true;
      this.controlsPicker.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.controlsPicker.Dock = DockStyle.Fill;
      this.controlsPicker.Location = new Point(2, 2);
      this.controlsPicker.Margin = new Padding(2);
      this.controlsPicker.Name = "controlsPicker";
      this.controlsPicker.Size = new Size(726, 278);
      this.controlsPicker.TabIndex = 20;
      this.addBindingBtn.Dock = DockStyle.Fill;
      this.addBindingBtn.Location = new Point(4, 286);
      this.addBindingBtn.Margin = new Padding(4, 4, 4, 4);
      this.addBindingBtn.Name = "addBindingBtn";
      this.addBindingBtn.Size = new Size(722, 29);
      this.addBindingBtn.TabIndex = 22;
      this.addBindingBtn.Text = "+ Add Custom Key Binding";
      this.toolTip1.SetToolTip((Control) this.addBindingBtn, "Add a custom binding for any extra controls you want in multi-mode");
      this.addBindingBtn.UseVisualStyleBackColor = true;
      this.addBindingBtn.Click += new EventHandler(this.addBindingBtn_Click);
      this.tabPage3.Controls.Add((Control) this.tableLayoutPanel2);
      this.tabPage3.Location = new Point(4, 25);
      this.tabPage3.Margin = new Padding(4, 4, 4, 4);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new Padding(4, 4, 4, 4);
      this.tabPage3.Size = new Size(742, 443);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Hotkeys";
      this.tabPage3.UseVisualStyleBackColor = true;
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.keyPicker1);
      this.groupBox1.Dock = DockStyle.Top;
      this.groupBox1.Location = new Point(4, 4);
      this.groupBox1.Margin = new Padding(4, 4, 4, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new Padding(4, 4, 4, 4);
      this.groupBox1.Size = new Size(726, 94);
      this.groupBox1.TabIndex = 14;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Mode/Activate Hotkey:";
      this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label4.Location = new Point(8, 20);
      this.label4.Margin = new Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(712, 35);
      this.label4.TabIndex = 13;
      this.label4.Text = "This key is used to change from multi-mode to mirror-mode and back. It also activates the multicontroller when you have a Toontown window active. ";
      this.keyPicker1.ChosenKey = Keys.Oemtilde;
      this.keyPicker1.ChosenKeyCode = Settings.Default.modeKeyCode;
      this.keyPicker1.DataBindings.Add(new Binding("ChosenKeyCode", (object) Settings.Default, "modeKeyCode", true, DataSourceUpdateMode.OnPropertyChanged));
      this.keyPicker1.Location = new Point(9, 60);
      this.keyPicker1.Margin = new Padding(5, 5, 5, 5);
      this.keyPicker1.MinimumSize = new Size(50, 25);
      this.keyPicker1.Name = "keyPicker1";
      this.keyPicker1.Size = new Size(188, 25);
      this.keyPicker1.TabIndex = 12;
      this.tabPage5.Controls.Add((Control) this.label2);
      this.tabPage5.Controls.Add((Control) this.checkBox4);
      this.tabPage5.Controls.Add((Control) this.keyPicker2);
      this.tabPage5.Location = new Point(4, 25);
      this.tabPage5.Margin = new Padding(2);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Padding = new Padding(4, 4, 4, 4);
      this.tabPage5.Size = new Size(742, 443);
      this.tabPage5.TabIndex = 5;
      this.tabPage5.Text = "Keep-Alive";
      this.tabPage5.UseVisualStyleBackColor = true;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(8, 38);
      this.label2.Margin = new Padding(2, 0, 2, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(108, 17);
      this.label2.TabIndex = 14;
      this.label2.Text = "Keep-Alive Key:";
      this.checkBox4.AutoSize = true;
      this.checkBox4.Checked = Settings.Default.disableKeepAlive;
      this.checkBox4.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "disableKeepAlive", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox4.Location = new Point(8, 8);
      this.checkBox4.Margin = new Padding(4, 4, 4, 4);
      this.checkBox4.Name = "checkBox4";
      this.checkBox4.Size = new Size(149, 21);
      this.checkBox4.TabIndex = 3;
      this.checkBox4.Text = "Disable Keep-Alive";
      this.toolTip1.SetToolTip((Control) this.checkBox4, "If checked, your toons will no longer be kept awake automatically.");
      this.checkBox4.UseVisualStyleBackColor = true;
      this.keyPicker2.ChosenKey = Keys.Home;
      this.keyPicker2.ChosenKeyCode = Settings.Default.keepAliveKeyCode;
      this.keyPicker2.DataBindings.Add(new Binding("ChosenKeyCode", (object) Settings.Default, "keepAliveKeyCode", true, DataSourceUpdateMode.OnPropertyChanged));
      this.keyPicker2.Location = new Point(124, 36);
      this.keyPicker2.Margin = new Padding(5, 5, 5, 5);
      this.keyPicker2.MinimumSize = new Size(50, 25);
      this.keyPicker2.Name = "keyPicker2";
      this.keyPicker2.Size = new Size(188, 25);
      this.keyPicker2.TabIndex = 13;
      this.toolTip1.SetToolTip((Control) this.keyPicker2, "This is the key that will be pressed periodically to keep your toons awake.");
      this.tabPage2.Controls.Add((Control) this.controlAllGroupsChk);
      this.tabPage2.Controls.Add((Control) this.checkBox3);
      this.tabPage2.Controls.Add((Control) this.checkBox2);
      this.tabPage2.Location = new Point(4, 25);
      this.tabPage2.Margin = new Padding(4, 4, 4, 4);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(4, 4, 4, 4);
      this.tabPage2.Size = new Size(742, 443);
      this.tabPage2.TabIndex = 3;
      this.tabPage2.Text = "Other";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.controlAllGroupsChk.AutoSize = true;
      this.controlAllGroupsChk.Checked = Settings.Default.controlAllGroupsAtOnce;
      this.controlAllGroupsChk.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "controlAllGroupsAtOnce", true, DataSourceUpdateMode.OnPropertyChanged));
      this.controlAllGroupsChk.Location = new Point(8, 68);
      this.controlAllGroupsChk.Margin = new Padding(2);
      this.controlAllGroupsChk.Name = "controlAllGroupsChk";
      this.controlAllGroupsChk.Size = new Size(280, 21);
      this.controlAllGroupsChk.TabIndex = 2;
      this.controlAllGroupsChk.Text = "Control all groups at once in multi-mode";
      this.toolTip1.SetToolTip((Control) this.controlAllGroupsChk, "If checked, every left toon will move at once, and every right toon will move at once while in multi-mode. Otherwise, you can only control one group at a time.");
      this.controlAllGroupsChk.UseVisualStyleBackColor = true;
      this.checkBox3.AutoSize = true;
      this.checkBox3.Checked = Settings.Default.compactUI;
      this.checkBox3.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "compactUI", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox3.Location = new Point(8, 38);
      this.checkBox3.Margin = new Padding(4, 4, 4, 4);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(144, 21);
      this.checkBox3.TabIndex = 1;
      this.checkBox3.Text = "Compact interface";
      this.toolTip1.SetToolTip((Control) this.checkBox3, "If checked, the size of the multicontroller window will be smaller.");
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox2.AutoSize = true;
      this.checkBox2.Checked = Settings.Default.onTopWhenInactive;
      this.checkBox2.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "onTopWhenInactive", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox2.Location = new Point(8, 8);
      this.checkBox2.Margin = new Padding(4, 4, 4, 4);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(196, 21);
      this.checkBox2.TabIndex = 0;
      this.checkBox2.Text = "Keep on top when inactive";
      this.toolTip1.SetToolTip((Control) this.checkBox2, "If checked, the multicontroller window will always stay visible over everything else on your screen.");
      this.checkBox2.UseVisualStyleBackColor = true;
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel2.Controls.Add((Control) this.groupBox2, 0, 1);
      this.tableLayoutPanel2.Controls.Add((Control) this.groupBox1, 0, 0);
      this.tableLayoutPanel2.Dock = DockStyle.Fill;
      this.tableLayoutPanel2.Location = new Point(4, 4);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel2.Size = new Size(734, 435);
      this.tableLayoutPanel2.TabIndex = 15;
      this.groupBox2.Controls.Add((Control) this.label1);
      this.groupBox2.Controls.Add((Control) this.keyPicker3);
      this.groupBox2.Dock = DockStyle.Top;
      this.groupBox2.Location = new Point(4, 106);
      this.groupBox2.Margin = new Padding(4);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new Padding(4);
      this.groupBox2.Size = new Size(726, 77);
      this.groupBox2.TabIndex = 15;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Control All Groups Hotkey:";
      this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label1.Location = new Point(8, 20);
      this.label1.Margin = new Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(712, 22);
      this.label1.TabIndex = 13;
      this.label1.Text = "This key will toggle the option to 'Control all groups at once in multi-mode', found in the Other tab.";
      this.keyPicker3.ChosenKey = Keys.None;
      this.keyPicker3.ChosenKeyCode = Settings.Default.controlAllGroupsKeyCode;
      this.keyPicker3.DataBindings.Add(new Binding("ChosenKeyCode", (object) Settings.Default, "controlAllGroupsKeyCode", true, DataSourceUpdateMode.OnPropertyChanged));
      this.keyPicker3.Location = new Point(9, 44);
      this.keyPicker3.Margin = new Padding(5);
      this.keyPicker3.MinimumSize = new Size(50, 25);
      this.keyPicker3.Name = "keyPicker3";
      this.keyPicker3.Size = new Size(188, 25);
      this.keyPicker3.TabIndex = 12;
      this.AcceptButton = (IButtonControl) this.okBtn;
      this.AutoScaleDimensions = new SizeF(120f, 120f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.CancelButton = (IButtonControl) this.cancelBtn;
      this.ClientSize = new Size(781, 538);
      this.Controls.Add((Control) this.tabControl1);
      this.Controls.Add((Control) this.checkUpdateBtn);
      this.Controls.Add((Control) this.aboutBtn);
      this.Controls.Add((Control) this.cancelBtn);
      this.Controls.Add((Control) this.okBtn);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Margin = new Padding(4, 4, 4, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (OptionsDlg);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Options";
      this.Load += new EventHandler(this.OptionsDlg_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage6.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tabPage3.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.tabPage5.ResumeLayout(false);
      this.tabPage5.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}

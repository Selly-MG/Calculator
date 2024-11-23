// Decompiled with JetBrains decompiler
// Type: Calculator.Properties.Settings
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Calculator.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.0.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default => Settings.defaultInstance;

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool sendDeleteToRightOnly
    {
      get => (bool) this[nameof (sendDeleteToRightOnly)];
      set => this[nameof (sendDeleteToRightOnly)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0, 0")]
    public Point lastLocation
    {
      get => (Point) this[nameof (lastLocation)];
      set => this[nameof (lastLocation)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool onTopWhenInactive
    {
      get => (bool) this[nameof (onTopWhenInactive)];
      set => this[nameof (onTopWhenInactive)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool compactUI
    {
      get => (bool) this[nameof (compactUI)];
      set => this[nameof (compactUI)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("1")]
    public int numberOfGroups
    {
      get => (int) this[nameof (numberOfGroups)];
      set => this[nameof (numberOfGroups)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool disableKeepAlive
    {
      get => (bool) this[nameof (disableKeepAlive)];
      set => this[nameof (disableKeepAlive)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("192")]
    public int modeKeyCode
    {
      get => (int) this[nameof (modeKeyCode)];
      set => this[nameof (modeKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("16")]
    public int leftJumpKeyCode
    {
      get => (int) this[nameof (leftJumpKeyCode)];
      set => this[nameof (leftJumpKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("46")]
    public int leftThrowKeyCode
    {
      get => (int) this[nameof (leftThrowKeyCode)];
      set => this[nameof (leftThrowKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("27")]
    public int leftEscapeKeyCode
    {
      get => (int) this[nameof (leftEscapeKeyCode)];
      set => this[nameof (leftEscapeKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("87")]
    public int leftForwardKeyCode
    {
      get => (int) this[nameof (leftForwardKeyCode)];
      set => this[nameof (leftForwardKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("65")]
    public int leftLeftKeyCode
    {
      get => (int) this[nameof (leftLeftKeyCode)];
      set => this[nameof (leftLeftKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("83")]
    public int leftBackKeyCode
    {
      get => (int) this[nameof (leftBackKeyCode)];
      set => this[nameof (leftBackKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("68")]
    public int leftRightKeyCode
    {
      get => (int) this[nameof (leftRightKeyCode)];
      set => this[nameof (leftRightKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("17")]
    public int rightJumpKeyCode
    {
      get => (int) this[nameof (rightJumpKeyCode)];
      set => this[nameof (rightJumpKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("46")]
    public int rightThrowKeyCode
    {
      get => (int) this[nameof (rightThrowKeyCode)];
      set => this[nameof (rightThrowKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("27")]
    public int rightEscapeKeyCode
    {
      get => (int) this[nameof (rightEscapeKeyCode)];
      set => this[nameof (rightEscapeKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("38")]
    public int rightForwardKeyCode
    {
      get => (int) this[nameof (rightForwardKeyCode)];
      set => this[nameof (rightForwardKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("37")]
    public int rightLeftKeyCode
    {
      get => (int) this[nameof (rightLeftKeyCode)];
      set => this[nameof (rightLeftKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("40")]
    public int rightBackKeyCode
    {
      get => (int) this[nameof (rightBackKeyCode)];
      set => this[nameof (rightBackKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("39")]
    public int rightRightKeyCode
    {
      get => (int) this[nameof (rightRightKeyCode)];
      set => this[nameof (rightRightKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("36")]
    public int keepAliveKeyCode
    {
      get => (int) this[nameof (keepAliveKeyCode)];
      set => this[nameof (keepAliveKeyCode)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string keyBindings
    {
      get => (string) this[nameof (keyBindings)];
      set => this[nameof (keyBindings)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string leftKeys
    {
      get => (string) this[nameof (leftKeys)];
      set => this[nameof (leftKeys)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string rightKeys
    {
      get => (string) this[nameof (rightKeys)];
      set => this[nameof (rightKeys)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool controlAllGroupsAtOnce
    {
      get => (bool) this[nameof (controlAllGroupsAtOnce)];
      set => this[nameof (controlAllGroupsAtOnce)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool UpgradeRequired
    {
      get => (bool) this[nameof (UpgradeRequired)];
      set => this[nameof (UpgradeRequired)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool runAsAdministrator
    {
      get => (bool) this[nameof (runAsAdministrator)];
      set => this[nameof (runAsAdministrator)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int controlAllGroupsKeyCode
    {
      get => (int) this[nameof (controlAllGroupsKeyCode)];
      set => this[nameof (controlAllGroupsKeyCode)] = (object) value;
    }

    [ApplicationScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("https://danfresneda.com/tt/multicontroller")]
    public string homepageUrl => (string) this[nameof (homepageUrl)];
  }
}

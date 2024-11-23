// Decompiled with JetBrains decompiler
// Type: Calculator.Program
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Calculator.Forms;
using Calculator.Properties;

namespace Calculator
{
  internal static class Program
  {
    [STAThread]
    private static void Main(string[] args)
    {
      if (Environment.OSVersion.Version.Major >= 6)
        Program.SetProcessDPIAware();
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      if (Settings.Default.UpgradeRequired)
      {
        Settings.Default.Upgrade();
        Settings.Default.UpgradeRequired = false;
        Settings.Default.Save();
      }
      if (Settings.Default.runAsAdministrator && (args.Length == 0 || args[0] != "--runasadmin") && Program.TryRunAsAdmin())
        return;
      Application.Run((Form) new MulticontrollerWnd());
    }

    internal static bool TryRunAsAdmin()
    {
      ProcessStartInfo startInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase);
      startInfo.Arguments = "--runasadmin";
      startInfo.UseShellExecute = true;
      startInfo.Verb = "runas";
      try
      {
        Process.Start(startInfo);
        return true;
      }
      catch
      {
        Settings.Default.runAsAdministrator = false;
        Settings.Default.Save();
        return false;
      }
    }

    [DllImport("user32.dll")]
    private static extern bool SetProcessDPIAware();
  }
}

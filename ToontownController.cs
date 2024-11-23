// Decompiled with JetBrains decompiler
// Type: Calculator.ToontownController
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Calculator.Forms;
using Calculator.Properties;

namespace Calculator
{
  internal class ToontownController : IMessageFilter
  {
    private IntPtr _ttWindowHandle;
    private bool _showBorder = true;
    private bool ttWindowActive;
    private BorderWnd _borderWnd;
    private Thread bgThread;

    public event TTWindowActivatedHandler TTWindowActivated;

    public event TTWindowActivatedHandler TTWindowDeactivated;

    public event TTWindowClosedHandler TTWindowClosed;

    public IntPtr TTWindowHandle
    {
      get => this._ttWindowHandle;
      set => this._ttWindowHandle = value;
    }

    public Color BorderColor { get; set; }

    public bool ShowBorder
    {
      get => this._showBorder;
      set => this._showBorder = value;
    }

    public int GroupNumber { get; set; }

    public bool ShowGroupNumber { get; set; }

        public bool TTWindowActive
        {
            get => this.ttWindowActive;
            private set
            {
                if (this.ttWindowActive == value)
                    return;
                this.ttWindowActive = value;
                if (this.ttWindowActive)
                {
                    this.TTWindowActivated?.Invoke(this, this._ttWindowHandle);
                }
                else
                {
                    this.TTWindowDeactivated?.Invoke(this, this._ttWindowHandle);
                }
            }
        }

    public bool ErrorOccurredPostingMessage { get; private set; }

        public ToontownController()
        {
            this.bgThread = new Thread((ThreadStart)(() =>
            {
                this._borderWnd = new BorderWnd();
                DateTime dateTime = DateTime.MinValue;
                Application.AddMessageFilter((IMessageFilter)this);
                while (true)
                {
                    if (this._borderWnd.BorderColor != this.BorderColor)
                        this._borderWnd.BorderColor = this.BorderColor;
                    if (this._borderWnd.GroupNumber != this.GroupNumber)
                        this._borderWnd.GroupNumber = this.GroupNumber;
                    if (this._borderWnd.ShowGroupNumber != this.ShowGroupNumber)
                        this._borderWnd.ShowGroupNumber = this.ShowGroupNumber;
                    try
                    {
                        if (this.TTWindowHandle != IntPtr.Zero && !Win32.IsWindow(this.TTWindowHandle))
                        {
                            this.TTWindowHandle = IntPtr.Zero;
                            this.TTWindowClosed?.Invoke(this);
                        }
                        if (this.TTWindowHandle == IntPtr.Zero && this._borderWnd.Visible)
                            this._borderWnd.Hide();
                        else if (this.TTWindowHandle != IntPtr.Zero)
                        {
                            this.TTWindowActive = Win32.GetForegroundWindow() == this.TTWindowHandle;
                            Win32.RECT lpRect;
                            Win32.GetClientRect(this.TTWindowHandle, out lpRect);
                            Win32.WINDOWPLACEMENT lpwndpl = new Win32.WINDOWPLACEMENT();
                            lpwndpl.Length = Marshal.SizeOf((object)lpwndpl);
                            Win32.GetWindowPlacement(this.TTWindowHandle, ref lpwndpl);
                            Point lpPoint = new Point(0, 0);
                            Win32.ClientToScreen(this.TTWindowHandle, ref lpPoint);
                            this._borderWnd.Location = lpPoint;
                            if (lpwndpl.ShowCmd == Win32.ShowWindowCommands.ShowMinimized)
                            {
                                this._borderWnd.Hide();
                            }
                            else
                            {
                                this._borderWnd.Size = new Size(lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top);
                                if (!this._borderWnd.Visible && this.ShowBorder)
                                    this._borderWnd.Show();
                                else if (this._borderWnd.Visible && !this.ShowBorder)
                                    this._borderWnd.Hide();
                                this._borderWnd.WindowState = FormWindowState.Normal;
                                bool flag = false;
                                IntPtr hWnd = this.TTWindowHandle;
                                do
                                {
                                    hWnd = Win32.GetWindow(hWnd, Win32.GetWindow_Cmd.GW_HWNDPREV);
                                    if (hWnd == this._borderWnd.Handle)
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                while (hWnd != IntPtr.Zero);
                                if (!flag)
                                {
                                    Win32.SetWindowPos(this._borderWnd.Handle, this.TTWindowHandle, 0, 0, 0, 0, Win32.SetWindowPosFlags.DoNotActivate | Win32.SetWindowPosFlags.IgnoreMove | Win32.SetWindowPosFlags.IgnoreResize);
                                    Win32.SetWindowPos(this.TTWindowHandle, this._borderWnd.Handle, 0, 0, 0, 0, Win32.SetWindowPosFlags.DoNotActivate | Win32.SetWindowPosFlags.IgnoreMove | Win32.SetWindowPosFlags.IgnoreResize);
                                }
                            }
                        }
                        if (!Settings.Default.disableKeepAlive && ((DateTime.Now - dateTime).TotalMinutes >= 1.0 && this.TTWindowHandle != IntPtr.Zero && Settings.Default.keepAliveKeyCode != 0))
                        {
                            this.PostMessage(256U, (IntPtr)Settings.Default.keepAliveKeyCode, IntPtr.Zero);
                            Thread.Sleep(50);
                            this.PostMessage(257U, (IntPtr)Settings.Default.keepAliveKeyCode, IntPtr.Zero);
                            dateTime = DateTime.Now;
                        }
                        Application.DoEvents();
                        Thread.Sleep(5);
                    }
                    catch (ThreadInterruptedException)
                    {
                        break;
                    }
                }
            }))
            {
                IsBackground = true
            };
            this.bgThread.Start();
        }

    public void PostMessage(uint msg, IntPtr wParam, IntPtr lParam)
    {
      if (!(this.TTWindowHandle != IntPtr.Zero) || Win32.PostMessage(this.TTWindowHandle, msg, wParam, lParam))
        return;
      this.ErrorOccurredPostingMessage = true;
    }

    public bool PreFilterMessage(ref Message m)
    {
      if (m.HWnd != this._borderWnd.Handle)
        return false;
      switch ((Win32.WM) m.Msg)
      {
        case Win32.WM.SETCURSOR:
          this.PostMessage((uint) m.Msg, this.TTWindowHandle, m.LParam);
          break;
        case Win32.WM.KEYDOWN:
        case Win32.WM.KEYUP:
        case Win32.WM.MOUSEFIRST:
        case Win32.WM.LBUTTONDOWN:
        case Win32.WM.LBUTTONUP:
        case Win32.WM.RBUTTONDOWN:
        case Win32.WM.RBUTTONUP:
          this.PostMessage((uint) m.Msg, m.WParam, m.LParam);
          break;
        default:
          return false;
      }
      return false;
    }

    public void Shutdown()
    {
      this._borderWnd.InvokeIfRequired((MethodInvoker) (() => this._borderWnd.Close()));
      this.bgThread.Interrupt();
      while (this.bgThread.IsAlive)
        Thread.Sleep(1);
      int num = this.TTWindowHandle != IntPtr.Zero ? 1 : 0;
    }
  }
}

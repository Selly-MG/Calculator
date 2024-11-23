// Decompiled with JetBrains decompiler
// Type: Calculator.Win32
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Calculator
{
  internal class Win32
  {
    internal const int WS_EX_LAYERED = 524288;
    internal const int WS_EX_TRANSPARENT = 32;
    internal const int WS_EX_TOOLWINDOW = 128;
    internal const int WH_MOUSE_LL = 14;
    internal const int WH_KEYBOARD_LL = 13;
    internal const int GWL_HWNDPARENT = -8;
    internal const int GWL_STYLE = -16;
    internal const int GWL_EXSTYLE = -20;
    internal const int AC_SRC_OVER = 0;
    internal const int AC_SRC_ALPHA = 1;
    internal const int ULW_ALPHA = 2;

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    internal static extern IntPtr WindowFromPoint(Point Point);

    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool GetWindowRect(IntPtr hwnd, out Win32.RECT lpRect);

    [DllImport("user32.dll")]
    internal static extern bool GetClientRect(IntPtr hWnd, out Win32.RECT lpRect);

    [DllImport("user32.dll")]
    internal static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

    [DllImport("user32.dll")]
    internal static extern IntPtr SetCapture(IntPtr hWnd);

    [DllImport("user32.dll")]
    internal static extern bool ReleaseCapture();

    [DllImport("user32.dll")]
    internal static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool GetWindowPlacement(IntPtr hWnd, ref Win32.WINDOWPLACEMENT lpwndpl);

    [DllImport("user32.dll")]
    internal static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("gdi32.dll", SetLastError = true)]
    internal static extern IntPtr CreateCompatibleDC([In] IntPtr hdc);

    [DllImport("gdi32.dll")]
    internal static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);

    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool UpdateLayeredWindow(
      IntPtr hwnd,
      IntPtr hdcDst,
      ref Point pptDst,
      ref Size psize,
      IntPtr hdcSrc,
      ref Point pptSrc,
      uint crKey,
      [In] ref Win32.BLENDFUNCTION pblend,
      uint dwFlags);

    [DllImport("user32.dll")]
    internal static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("gdi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool DeleteObject([In] IntPtr hObject);

    [DllImport("gdi32.dll")]
    internal static extern bool DeleteDC([In] IntPtr hdc);

    [DllImport("user32.dll", SetLastError = true)]
    internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll")]
    internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool IsWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    internal static extern short GetAsyncKeyState(Keys vKey);

    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool SetWindowPos(
      IntPtr hWnd,
      IntPtr hWndInsertAfter,
      int X,
      int Y,
      int cx,
      int cy,
      Win32.SetWindowPosFlags uFlags);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

    [DllImport("user32.dll")]
    internal static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", SetLastError = true)]
    internal static extern IntPtr GetWindow(IntPtr hWnd, Win32.GetWindow_Cmd uCmd);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool ShowWindow(IntPtr hWnd, Win32.ShowWindowCommands nCmdShow);

    [DllImport("user32.dll")]
    internal static extern bool BlockInput(bool fBlockIt);

    [DllImport("user32.dll")]
    internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] Win32.INPUT[] pInputs, int cbSize);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern bool RegisterHotKey(
      IntPtr hWnd,
      int id,
      Win32.KeyModifiers fsModifiers,
      Keys vk);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    internal static extern IntPtr SetWindowsHookEx(
      int hookType,
      Win32.HookProc lpfn,
      IntPtr hMod,
      uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern IntPtr CallNextHookEx(
      IntPtr hhk,
      int nCode,
      IntPtr wParam,
      IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("user32.dll")]
    internal static extern IntPtr GetAncestor(IntPtr hwnd, Win32.GetAncestorFlags flags);

    [Flags]
    public enum KeyModifiers
    {
      None = 0,
      Alt = 1,
      Control = 2,
      Shift = 4,
      Windows = 8,
      NoRepeat = 16384, // 0x00004000
    }

    internal struct INPUT
    {
      internal uint type;
      internal Win32.InputUnion U;

      internal static int Size => Marshal.SizeOf(typeof (Win32.INPUT));
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct InputUnion
    {
      [FieldOffset(0)]
      internal Win32.MOUSEINPUT mi;
      [FieldOffset(0)]
      internal Win32.KEYBDINPUT ki;
      [FieldOffset(0)]
      internal Win32.HARDWAREINPUT hi;
    }

    internal struct MOUSEINPUT
    {
      internal int dx;
      internal int dy;
      internal int mouseData;
      internal Win32.MOUSEEVENTF dwFlags;
      internal uint time;
      internal UIntPtr dwExtraInfo;
    }

    internal struct KEYBDINPUT
    {
      internal Win32.VirtualKeyShort wVk;
      internal Win32.ScanCodeShort wScan;
      internal Win32.KEYEVENTF dwFlags;
      internal int time;
      internal UIntPtr dwExtraInfo;
    }

    internal struct HARDWAREINPUT
    {
      internal int uMsg;
      internal short wParamL;
      internal short wParamH;
    }

    [Flags]
    internal enum KEYEVENTF : uint
    {
      EXTENDEDKEY = 1,
      KEYUP = 2,
      SCANCODE = 8,
      UNICODE = 4,
    }

    internal enum VirtualKeyShort : short
    {
      LBUTTON = 1,
      RBUTTON = 2,
      CANCEL = 3,
      MBUTTON = 4,
      XBUTTON1 = 5,
      XBUTTON2 = 6,
      BACK = 8,
      TAB = 9,
      CLEAR = 12, // 0x000C
      RETURN = 13, // 0x000D
      SHIFT = 16, // 0x0010
      CONTROL = 17, // 0x0011
      MENU = 18, // 0x0012
      PAUSE = 19, // 0x0013
      CAPITAL = 20, // 0x0014
      HANGUL = 21, // 0x0015
      KANA = 21, // 0x0015
      JUNJA = 23, // 0x0017
      FINAL = 24, // 0x0018
      HANJA = 25, // 0x0019
      KANJI = 25, // 0x0019
      ESCAPE = 27, // 0x001B
      CONVERT = 28, // 0x001C
      NONCONVERT = 29, // 0x001D
      ACCEPT = 30, // 0x001E
      MODECHANGE = 31, // 0x001F
      SPACE = 32, // 0x0020
      PRIOR = 33, // 0x0021
      NEXT = 34, // 0x0022
      END = 35, // 0x0023
      HOME = 36, // 0x0024
      LEFT = 37, // 0x0025
      UP = 38, // 0x0026
      RIGHT = 39, // 0x0027
      DOWN = 40, // 0x0028
      SELECT = 41, // 0x0029
      PRINT = 42, // 0x002A
      EXECUTE = 43, // 0x002B
      SNAPSHOT = 44, // 0x002C
      INSERT = 45, // 0x002D
      DELETE = 46, // 0x002E
      HELP = 47, // 0x002F
      KEY_0 = 48, // 0x0030
      KEY_1 = 49, // 0x0031
      KEY_2 = 50, // 0x0032
      KEY_3 = 51, // 0x0033
      KEY_4 = 52, // 0x0034
      KEY_5 = 53, // 0x0035
      KEY_6 = 54, // 0x0036
      KEY_7 = 55, // 0x0037
      KEY_8 = 56, // 0x0038
      KEY_9 = 57, // 0x0039
      KEY_A = 65, // 0x0041
      KEY_B = 66, // 0x0042
      KEY_C = 67, // 0x0043
      KEY_D = 68, // 0x0044
      KEY_E = 69, // 0x0045
      KEY_F = 70, // 0x0046
      KEY_G = 71, // 0x0047
      KEY_H = 72, // 0x0048
      KEY_I = 73, // 0x0049
      KEY_J = 74, // 0x004A
      KEY_K = 75, // 0x004B
      KEY_L = 76, // 0x004C
      KEY_M = 77, // 0x004D
      KEY_N = 78, // 0x004E
      KEY_O = 79, // 0x004F
      KEY_P = 80, // 0x0050
      KEY_Q = 81, // 0x0051
      KEY_R = 82, // 0x0052
      KEY_S = 83, // 0x0053
      KEY_T = 84, // 0x0054
      KEY_U = 85, // 0x0055
      KEY_V = 86, // 0x0056
      KEY_W = 87, // 0x0057
      KEY_X = 88, // 0x0058
      KEY_Y = 89, // 0x0059
      KEY_Z = 90, // 0x005A
      LWIN = 91, // 0x005B
      RWIN = 92, // 0x005C
      APPS = 93, // 0x005D
      SLEEP = 95, // 0x005F
      NUMPAD0 = 96, // 0x0060
      NUMPAD1 = 97, // 0x0061
      NUMPAD2 = 98, // 0x0062
      NUMPAD3 = 99, // 0x0063
      NUMPAD4 = 100, // 0x0064
      NUMPAD5 = 101, // 0x0065
      NUMPAD6 = 102, // 0x0066
      NUMPAD7 = 103, // 0x0067
      NUMPAD8 = 104, // 0x0068
      NUMPAD9 = 105, // 0x0069
      MULTIPLY = 106, // 0x006A
      ADD = 107, // 0x006B
      SEPARATOR = 108, // 0x006C
      SUBTRACT = 109, // 0x006D
      DECIMAL = 110, // 0x006E
      DIVIDE = 111, // 0x006F
      F1 = 112, // 0x0070
      F2 = 113, // 0x0071
      F3 = 114, // 0x0072
      F4 = 115, // 0x0073
      F5 = 116, // 0x0074
      F6 = 117, // 0x0075
      F7 = 118, // 0x0076
      F8 = 119, // 0x0077
      F9 = 120, // 0x0078
      F10 = 121, // 0x0079
      F11 = 122, // 0x007A
      F12 = 123, // 0x007B
      F13 = 124, // 0x007C
      F14 = 125, // 0x007D
      F15 = 126, // 0x007E
      F16 = 127, // 0x007F
      F17 = 128, // 0x0080
      F18 = 129, // 0x0081
      F19 = 130, // 0x0082
      F20 = 131, // 0x0083
      F21 = 132, // 0x0084
      F22 = 133, // 0x0085
      F23 = 134, // 0x0086
      F24 = 135, // 0x0087
      NUMLOCK = 144, // 0x0090
      SCROLL = 145, // 0x0091
      LSHIFT = 160, // 0x00A0
      RSHIFT = 161, // 0x00A1
      LCONTROL = 162, // 0x00A2
      RCONTROL = 163, // 0x00A3
      LMENU = 164, // 0x00A4
      RMENU = 165, // 0x00A5
      BROWSER_BACK = 166, // 0x00A6
      BROWSER_FORWARD = 167, // 0x00A7
      BROWSER_REFRESH = 168, // 0x00A8
      BROWSER_STOP = 169, // 0x00A9
      BROWSER_SEARCH = 170, // 0x00AA
      BROWSER_FAVORITES = 171, // 0x00AB
      BROWSER_HOME = 172, // 0x00AC
      VOLUME_MUTE = 173, // 0x00AD
      VOLUME_DOWN = 174, // 0x00AE
      VOLUME_UP = 175, // 0x00AF
      MEDIA_NEXT_TRACK = 176, // 0x00B0
      MEDIA_PREV_TRACK = 177, // 0x00B1
      MEDIA_STOP = 178, // 0x00B2
      MEDIA_PLAY_PAUSE = 179, // 0x00B3
      LAUNCH_MAIL = 180, // 0x00B4
      LAUNCH_MEDIA_SELECT = 181, // 0x00B5
      LAUNCH_APP1 = 182, // 0x00B6
      LAUNCH_APP2 = 183, // 0x00B7
      OEM_1 = 186, // 0x00BA
      OEM_PLUS = 187, // 0x00BB
      OEM_COMMA = 188, // 0x00BC
      OEM_MINUS = 189, // 0x00BD
      OEM_PERIOD = 190, // 0x00BE
      OEM_2 = 191, // 0x00BF
      OEM_3 = 192, // 0x00C0
      OEM_4 = 219, // 0x00DB
      OEM_5 = 220, // 0x00DC
      OEM_6 = 221, // 0x00DD
      OEM_7 = 222, // 0x00DE
      OEM_8 = 223, // 0x00DF
      OEM_102 = 226, // 0x00E2
      PROCESSKEY = 229, // 0x00E5
      PACKET = 231, // 0x00E7
      ATTN = 246, // 0x00F6
      CRSEL = 247, // 0x00F7
      EXSEL = 248, // 0x00F8
      EREOF = 249, // 0x00F9
      PLAY = 250, // 0x00FA
      ZOOM = 251, // 0x00FB
      NONAME = 252, // 0x00FC
      PA1 = 253, // 0x00FD
      OEM_CLEAR = 254, // 0x00FE
    }

    internal enum ScanCodeShort : short
    {
      ACCEPT = 0,
      ATTN = 0,
      CONVERT = 0,
      CRSEL = 0,
      EXECUTE = 0,
      EXSEL = 0,
      FINAL = 0,
      HANGUL = 0,
      HANJA = 0,
      JUNJA = 0,
      KANA = 0,
      KANJI = 0,
      LBUTTON = 0,
      MBUTTON = 0,
      MODECHANGE = 0,
      NONAME = 0,
      NONCONVERT = 0,
      OEM_8 = 0,
      OEM_CLEAR = 0,
      PA1 = 0,
      PACKET = 0,
      PAUSE = 0,
      PLAY = 0,
      PRINT = 0,
      PROCESSKEY = 0,
      RBUTTON = 0,
      SELECT = 0,
      SEPARATOR = 0,
      XBUTTON1 = 0,
      XBUTTON2 = 0,
      ESCAPE = 1,
      KEY_1 = 2,
      KEY_2 = 3,
      KEY_3 = 4,
      KEY_4 = 5,
      KEY_5 = 6,
      KEY_6 = 7,
      KEY_7 = 8,
      KEY_8 = 9,
      KEY_9 = 10, // 0x000A
      KEY_0 = 11, // 0x000B
      OEM_MINUS = 12, // 0x000C
      OEM_PLUS = 13, // 0x000D
      BACK = 14, // 0x000E
      TAB = 15, // 0x000F
      KEY_Q = 16, // 0x0010
      MEDIA_PREV_TRACK = 16, // 0x0010
      KEY_W = 17, // 0x0011
      KEY_E = 18, // 0x0012
      KEY_R = 19, // 0x0013
      KEY_T = 20, // 0x0014
      KEY_Y = 21, // 0x0015
      KEY_U = 22, // 0x0016
      KEY_I = 23, // 0x0017
      KEY_O = 24, // 0x0018
      KEY_P = 25, // 0x0019
      MEDIA_NEXT_TRACK = 25, // 0x0019
      OEM_4 = 26, // 0x001A
      OEM_6 = 27, // 0x001B
      RETURN = 28, // 0x001C
      CONTROL = 29, // 0x001D
      LCONTROL = 29, // 0x001D
      RCONTROL = 29, // 0x001D
      KEY_A = 30, // 0x001E
      KEY_S = 31, // 0x001F
      KEY_D = 32, // 0x0020
      VOLUME_MUTE = 32, // 0x0020
      KEY_F = 33, // 0x0021
      LAUNCH_APP2 = 33, // 0x0021
      KEY_G = 34, // 0x0022
      MEDIA_PLAY_PAUSE = 34, // 0x0022
      KEY_H = 35, // 0x0023
      KEY_J = 36, // 0x0024
      MEDIA_STOP = 36, // 0x0024
      KEY_K = 37, // 0x0025
      KEY_L = 38, // 0x0026
      OEM_1 = 39, // 0x0027
      OEM_7 = 40, // 0x0028
      OEM_3 = 41, // 0x0029
      LSHIFT = 42, // 0x002A
      SHIFT = 42, // 0x002A
      OEM_5 = 43, // 0x002B
      KEY_Z = 44, // 0x002C
      KEY_X = 45, // 0x002D
      KEY_C = 46, // 0x002E
      VOLUME_DOWN = 46, // 0x002E
      KEY_V = 47, // 0x002F
      KEY_B = 48, // 0x0030
      VOLUME_UP = 48, // 0x0030
      KEY_N = 49, // 0x0031
      BROWSER_HOME = 50, // 0x0032
      KEY_M = 50, // 0x0032
      OEM_COMMA = 51, // 0x0033
      OEM_PERIOD = 52, // 0x0034
      DIVIDE = 53, // 0x0035
      OEM_2 = 53, // 0x0035
      RSHIFT = 54, // 0x0036
      MULTIPLY = 55, // 0x0037
      LMENU = 56, // 0x0038
      MENU = 56, // 0x0038
      RMENU = 56, // 0x0038
      SPACE = 57, // 0x0039
      CAPITAL = 58, // 0x003A
      F1 = 59, // 0x003B
      F2 = 60, // 0x003C
      F3 = 61, // 0x003D
      F4 = 62, // 0x003E
      F5 = 63, // 0x003F
      F6 = 64, // 0x0040
      F7 = 65, // 0x0041
      F8 = 66, // 0x0042
      F9 = 67, // 0x0043
      F10 = 68, // 0x0044
      NUMLOCK = 69, // 0x0045
      CANCEL = 70, // 0x0046
      SCROLL = 70, // 0x0046
      HOME = 71, // 0x0047
      NUMPAD7 = 71, // 0x0047
      NUMPAD8 = 72, // 0x0048
      UP = 72, // 0x0048
      NUMPAD9 = 73, // 0x0049
      PRIOR = 73, // 0x0049
      SUBTRACT = 74, // 0x004A
      LEFT = 75, // 0x004B
      NUMPAD4 = 75, // 0x004B
      CLEAR = 76, // 0x004C
      NUMPAD5 = 76, // 0x004C
      NUMPAD6 = 77, // 0x004D
      RIGHT = 77, // 0x004D
      ADD = 78, // 0x004E
      END = 79, // 0x004F
      NUMPAD1 = 79, // 0x004F
      DOWN = 80, // 0x0050
      NUMPAD2 = 80, // 0x0050
      NEXT = 81, // 0x0051
      NUMPAD3 = 81, // 0x0051
      INSERT = 82, // 0x0052
      NUMPAD0 = 82, // 0x0052
      DECIMAL = 83, // 0x0053
      DELETE = 83, // 0x0053
      SNAPSHOT = 84, // 0x0054
      OEM_102 = 86, // 0x0056
      F11 = 87, // 0x0057
      F12 = 88, // 0x0058
      LWIN = 91, // 0x005B
      RWIN = 92, // 0x005C
      APPS = 93, // 0x005D
      EREOF = 93, // 0x005D
      SLEEP = 95, // 0x005F
      ZOOM = 98, // 0x0062
      HELP = 99, // 0x0063
      F13 = 100, // 0x0064
      BROWSER_SEARCH = 101, // 0x0065
      F14 = 101, // 0x0065
      BROWSER_FAVORITES = 102, // 0x0066
      F15 = 102, // 0x0066
      BROWSER_REFRESH = 103, // 0x0067
      F16 = 103, // 0x0067
      BROWSER_STOP = 104, // 0x0068
      F17 = 104, // 0x0068
      BROWSER_FORWARD = 105, // 0x0069
      F18 = 105, // 0x0069
      BROWSER_BACK = 106, // 0x006A
      F19 = 106, // 0x006A
      F20 = 107, // 0x006B
      LAUNCH_APP1 = 107, // 0x006B
      F21 = 108, // 0x006C
      LAUNCH_MAIL = 108, // 0x006C
      F22 = 109, // 0x006D
      LAUNCH_MEDIA_SELECT = 109, // 0x006D
      F23 = 110, // 0x006E
      F24 = 118, // 0x0076
    }

    [Flags]
    internal enum MOUSEEVENTF : uint
    {
      ABSOLUTE = 32768, // 0x00008000
      HWHEEL = 4096, // 0x00001000
      MOVE = 1,
      MOVE_NOCOALESCE = 8192, // 0x00002000
      LEFTDOWN = 2,
      LEFTUP = 4,
      RIGHTDOWN = 8,
      RIGHTUP = 16, // 0x00000010
      MIDDLEDOWN = 32, // 0x00000020
      MIDDLEUP = 64, // 0x00000040
      VIRTUALDESK = 16384, // 0x00004000
      WHEEL = 2048, // 0x00000800
      XDOWN = 128, // 0x00000080
      XUP = 256, // 0x00000100
    }

    internal delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);

        internal struct MSLLHOOKSTRUCT
        {
            internal Point pt;
            internal uint mouseData;
            internal uint flags;
            internal uint time;
            internal IntPtr dwExtraInfo;

            public MSLLHOOKSTRUCT(Point pt, uint mouseData, uint flags, uint time, IntPtr dwExtraInfo)
            {
                this.pt = pt;
                this.mouseData = mouseData;
                this.flags = flags;
                this.time = time;
                this.dwExtraInfo = dwExtraInfo;
            }
        }

    internal enum GetAncestorFlags
    {
      GetParent = 1,
      GetRoot = 2,
      GetRootOwner = 3,
    }

    internal enum GetWindow_Cmd : uint
    {
      GW_HWNDFIRST,
      GW_HWNDLAST,
      GW_HWNDNEXT,
      GW_HWNDPREV,
      GW_OWNER,
      GW_CHILD,
      GW_ENABLEDPOPUP,
    }

    [Flags]
    internal enum SetWindowPosFlags : uint
    {
      AsynchronousWindowPosition = 16384, // 0x00004000
      DeferErase = 8192, // 0x00002000
      DrawFrame = 32, // 0x00000020
      FrameChanged = DrawFrame, // 0x00000020
      HideWindow = 128, // 0x00000080
      DoNotActivate = 16, // 0x00000010
      DoNotCopyBits = 256, // 0x00000100
      IgnoreMove = 2,
      DoNotChangeOwnerZOrder = 512, // 0x00000200
      DoNotRedraw = 8,
      DoNotReposition = DoNotChangeOwnerZOrder, // 0x00000200
      DoNotSendChangingEvent = 1024, // 0x00000400
      IgnoreResize = 1,
      IgnoreZOrder = 4,
      ShowWindow = 64, // 0x00000040
    }

    internal struct BLENDFUNCTION
    {
      internal byte BlendOp;
      internal byte BlendFlags;
      internal byte SourceConstantAlpha;
      internal byte AlphaFormat;

      internal BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
      {
        this.BlendOp = op;
        this.BlendFlags = flags;
        this.SourceConstantAlpha = alpha;
        this.AlphaFormat = format;
      }
    }

    internal struct RECT
    {
      internal int Left;
      internal int Top;
      internal int Right;
      internal int Bottom;
    }

    [Serializable]
    internal struct WINDOWPLACEMENT
    {
      internal int Length;
      internal int Flags;
      internal Win32.ShowWindowCommands ShowCmd;
      internal Point MinPosition;
      internal Point MaxPosition;
      internal Win32.RECT NormalPosition;

      internal static Win32.WINDOWPLACEMENT Default
      {
        get
        {
          Win32.WINDOWPLACEMENT windowplacement = new Win32.WINDOWPLACEMENT();
          windowplacement.Length = Marshal.SizeOf((object) windowplacement);
          return windowplacement;
        }
      }
    }

    internal enum ShowWindowCommands
    {
      Hide = 0,
      Normal = 1,
      ShowMinimized = 2,
      Maximize = 3,
      ShowMaximized = 3,
      ShowNoActivate = 4,
      Show = 5,
      Minimize = 6,
      ShowMinNoActive = 7,
      ShowNA = 8,
      Restore = 9,
      ShowDefault = 10, // 0x0000000A
      ForceMinimize = 11, // 0x0000000B
    }

    internal enum WM : uint
    {
      NULL = 0,
      CREATE = 1,
      HSHELL_WINDOWCREATED = 1,
      DESTROY = 2,
      HSHELL_WINDOWDESTROYED = 2,
      HSHELL_ACTIVATESHELLWINDOW = 3,
      MOVE = 3,
      HSHELL_WINDOWACTIVATED = 4,
      HSHELL_GETMINRECT = 5,
      SIZE = 5,
      ACTIVATE = 6,
      HSHELL_REDRAW = 6,
      HSHELL_TASKMAN = 7,
      SETFOCUS = 7,
      HSHELL_LANGUAGE = 8,
      KILLFOCUS = 8,
      ENABLE = 10, // 0x0000000A
      HSHELL_ACCESSIBILITYSTATE = 11, // 0x0000000B
      SETREDRAW = 11, // 0x0000000B
      HSHELL_APPCOMMAND = 12, // 0x0000000C
      SETTEXT = 12, // 0x0000000C
      GETTEXT = 13, // 0x0000000D
      HSHELL_WINDOWREPLACED = 13, // 0x0000000D
      GETTEXTLENGTH = 14, // 0x0000000E
      PAINT = 15, // 0x0000000F
      CLOSE = 16, // 0x00000010
      QUERYENDSESSION = 17, // 0x00000011
      QUIT = 18, // 0x00000012
      QUERYOPEN = 19, // 0x00000013
      ERASEBKGND = 20, // 0x00000014
      SYSCOLORCHANGE = 21, // 0x00000015
      ENDSESSION = 22, // 0x00000016
      SHOWWINDOW = 24, // 0x00000018
      SETTINGCHANGE = 26, // 0x0000001A
      WININICHANGE = 26, // 0x0000001A
      DEVMODECHANGE = 27, // 0x0000001B
      ACTIVATEAPP = 28, // 0x0000001C
      FONTCHANGE = 29, // 0x0000001D
      TIMECHANGE = 30, // 0x0000001E
      CANCELMODE = 31, // 0x0000001F
      SETCURSOR = 32, // 0x00000020
      MOUSEACTIVATE = 33, // 0x00000021
      CHILDACTIVATE = 34, // 0x00000022
      QUEUESYNC = 35, // 0x00000023
      GETMINMAXINFO = 36, // 0x00000024
      PAINTICON = 38, // 0x00000026
      ICONERASEBKGND = 39, // 0x00000027
      NEXTDLGCTL = 40, // 0x00000028
      SPOOLERSTATUS = 42, // 0x0000002A
      DRAWITEM = 43, // 0x0000002B
      MEASUREITEM = 44, // 0x0000002C
      DELETEITEM = 45, // 0x0000002D
      VKEYTOITEM = 46, // 0x0000002E
      CHARTOITEM = 47, // 0x0000002F
      SETFONT = 48, // 0x00000030
      GETFONT = 49, // 0x00000031
      SETHOTKEY = 50, // 0x00000032
      GETHOTKEY = 51, // 0x00000033
      QUERYDRAGICON = 55, // 0x00000037
      COMPAREITEM = 57, // 0x00000039
      GETOBJECT = 61, // 0x0000003D
      COMPACTING = 65, // 0x00000041
      [Obsolete] COMMNOTIFY = 68, // 0x00000044
      WINDOWPOSCHANGING = 70, // 0x00000046
      WINDOWPOSCHANGED = 71, // 0x00000047
      [Obsolete] POWER = 72, // 0x00000048
      COPYDATA = 74, // 0x0000004A
      CANCELJOURNAL = 75, // 0x0000004B
      NOTIFY = 78, // 0x0000004E
      INPUTLANGCHANGEREQUEST = 80, // 0x00000050
      INPUTLANGCHANGE = 81, // 0x00000051
      TCARD = 82, // 0x00000052
      HELP = 83, // 0x00000053
      USERCHANGED = 84, // 0x00000054
      NOTIFYFORMAT = 85, // 0x00000055
      CONTEXTMENU = 123, // 0x0000007B
      STYLECHANGING = 124, // 0x0000007C
      STYLECHANGED = 125, // 0x0000007D
      DISPLAYCHANGE = 126, // 0x0000007E
      GETICON = 127, // 0x0000007F
      SETICON = 128, // 0x00000080
      NCCREATE = 129, // 0x00000081
      NCDESTROY = 130, // 0x00000082
      NCCALCSIZE = 131, // 0x00000083
      NCHITTEST = 132, // 0x00000084
      NCPAINT = 133, // 0x00000085
      NCACTIVATE = 134, // 0x00000086
      GETDLGCODE = 135, // 0x00000087
      SYNCPAINT = 136, // 0x00000088
      NCMOUSEMOVE = 160, // 0x000000A0
      NCLBUTTONDOWN = 161, // 0x000000A1
      NCLBUTTONUP = 162, // 0x000000A2
      NCLBUTTONDBLCLK = 163, // 0x000000A3
      NCRBUTTONDOWN = 164, // 0x000000A4
      NCRBUTTONUP = 165, // 0x000000A5
      NCRBUTTONDBLCLK = 166, // 0x000000A6
      NCMBUTTONDOWN = 167, // 0x000000A7
      NCMBUTTONUP = 168, // 0x000000A8
      NCMBUTTONDBLCLK = 169, // 0x000000A9
      NCXBUTTONDOWN = 171, // 0x000000AB
      NCXBUTTONUP = 172, // 0x000000AC
      NCXBUTTONDBLCLK = 173, // 0x000000AD
      INPUT_DEVICE_CHANGE = 254, // 0x000000FE
      INPUT = 255, // 0x000000FF
      KEYDOWN = 256, // 0x00000100
      KEYUP = 257, // 0x00000101
      CHAR = 258, // 0x00000102
      DEADCHAR = 259, // 0x00000103
      SYSKEYDOWN = 260, // 0x00000104
      SYSKEYUP = 261, // 0x00000105
      SYSCHAR = 262, // 0x00000106
      SYSDEADCHAR = 263, // 0x00000107
      KEYLAST = 265, // 0x00000109
      UNICHAR = 265, // 0x00000109
      IME_STARTCOMPOSITION = 269, // 0x0000010D
      IME_ENDCOMPOSITION = 270, // 0x0000010E
      IME_COMPOSITION = 271, // 0x0000010F
      IME_KEYLAST = 271, // 0x0000010F
      INITDIALOG = 272, // 0x00000110
      COMMAND = 273, // 0x00000111
      SYSCOMMAND = 274, // 0x00000112
      TIMER = 275, // 0x00000113
      HSCROLL = 276, // 0x00000114
      VSCROLL = 277, // 0x00000115
      INITMENU = 278, // 0x00000116
      INITMENUPOPUP = 279, // 0x00000117
      SYSTIMER = 280, // 0x00000118
      MENUSELECT = 287, // 0x0000011F
      MENUCHAR = 288, // 0x00000120
      ENTERIDLE = 289, // 0x00000121
      MENURBUTTONUP = 290, // 0x00000122
      MENUDRAG = 291, // 0x00000123
      MENUGETOBJECT = 292, // 0x00000124
      UNINITMENUPOPUP = 293, // 0x00000125
      MENUCOMMAND = 294, // 0x00000126
      CHANGEUISTATE = 295, // 0x00000127
      UPDATEUISTATE = 296, // 0x00000128
      QUERYUISTATE = 297, // 0x00000129
      CTLCOLORMSGBOX = 306, // 0x00000132
      CTLCOLOREDIT = 307, // 0x00000133
      CTLCOLORLISTBOX = 308, // 0x00000134
      CTLCOLORBTN = 309, // 0x00000135
      CTLCOLORDLG = 310, // 0x00000136
      CTLCOLORSCROLLBAR = 311, // 0x00000137
      CTLCOLORSTATIC = 312, // 0x00000138
      MOUSEFIRST = 512, // 0x00000200
      MOUSEMOVE = 512, // 0x00000200
      LBUTTONDOWN = 513, // 0x00000201
      LBUTTONUP = 514, // 0x00000202
      LBUTTONDBLCLK = 515, // 0x00000203
      RBUTTONDOWN = 516, // 0x00000204
      RBUTTONUP = 517, // 0x00000205
      RBUTTONDBLCLK = 518, // 0x00000206
      MBUTTONDOWN = 519, // 0x00000207
      MBUTTONUP = 520, // 0x00000208
      MBUTTONDBLCLK = 521, // 0x00000209
      MOUSEWHEEL = 522, // 0x0000020A
      XBUTTONDOWN = 523, // 0x0000020B
      XBUTTONUP = 524, // 0x0000020C
      XBUTTONDBLCLK = 525, // 0x0000020D
      MOUSEHWHEEL = 526, // 0x0000020E
      MOUSELAST = 526, // 0x0000020E
      PARENTNOTIFY = 528, // 0x00000210
      ENTERMENULOOP = 529, // 0x00000211
      EXITMENULOOP = 530, // 0x00000212
      NEXTMENU = 531, // 0x00000213
      SIZING = 532, // 0x00000214
      CAPTURECHANGED = 533, // 0x00000215
      MOVING = 534, // 0x00000216
      POWERBROADCAST = 536, // 0x00000218
      DEVICECHANGE = 537, // 0x00000219
      MDICREATE = 544, // 0x00000220
      MDIDESTROY = 545, // 0x00000221
      MDIACTIVATE = 546, // 0x00000222
      MDIRESTORE = 547, // 0x00000223
      MDINEXT = 548, // 0x00000224
      MDIMAXIMIZE = 549, // 0x00000225
      MDITILE = 550, // 0x00000226
      MDICASCADE = 551, // 0x00000227
      MDIICONARRANGE = 552, // 0x00000228
      MDIGETACTIVE = 553, // 0x00000229
      MDISETMENU = 560, // 0x00000230
      ENTERSIZEMOVE = 561, // 0x00000231
      EXITSIZEMOVE = 562, // 0x00000232
      DROPFILES = 563, // 0x00000233
      MDIREFRESHMENU = 564, // 0x00000234
      IME_SETCONTEXT = 641, // 0x00000281
      IME_NOTIFY = 642, // 0x00000282
      IME_CONTROL = 643, // 0x00000283
      IME_COMPOSITIONFULL = 644, // 0x00000284
      IME_SELECT = 645, // 0x00000285
      IME_CHAR = 646, // 0x00000286
      IME_REQUEST = 648, // 0x00000288
      IME_KEYDOWN = 656, // 0x00000290
      IME_KEYUP = 657, // 0x00000291
      NCMOUSEHOVER = 672, // 0x000002A0
      MOUSEHOVER = 673, // 0x000002A1
      NCMOUSELEAVE = 674, // 0x000002A2
      MOUSELEAVE = 675, // 0x000002A3
      WTSSESSION_CHANGE = 689, // 0x000002B1
      TABLET_FIRST = 704, // 0x000002C0
      TABLET_LAST = 735, // 0x000002DF
      CUT = 768, // 0x00000300
      COPY = 769, // 0x00000301
      PASTE = 770, // 0x00000302
      CLEAR = 771, // 0x00000303
      UNDO = 772, // 0x00000304
      RENDERFORMAT = 773, // 0x00000305
      RENDERALLFORMATS = 774, // 0x00000306
      DESTROYCLIPBOARD = 775, // 0x00000307
      DRAWCLIPBOARD = 776, // 0x00000308
      PAINTCLIPBOARD = 777, // 0x00000309
      VSCROLLCLIPBOARD = 778, // 0x0000030A
      SIZECLIPBOARD = 779, // 0x0000030B
      ASKCBFORMATNAME = 780, // 0x0000030C
      CHANGECBCHAIN = 781, // 0x0000030D
      HSCROLLCLIPBOARD = 782, // 0x0000030E
      QUERYNEWPALETTE = 783, // 0x0000030F
      PALETTEISCHANGING = 784, // 0x00000310
      PALETTECHANGED = 785, // 0x00000311
      HOTKEY = 786, // 0x00000312
      PRINT = 791, // 0x00000317
      PRINTCLIENT = 792, // 0x00000318
      APPCOMMAND = 793, // 0x00000319
      THEMECHANGED = 794, // 0x0000031A
      CLIPBOARDUPDATE = 797, // 0x0000031D
      DWMCOMPOSITIONCHANGED = 798, // 0x0000031E
      DWMNCRENDERINGCHANGED = 799, // 0x0000031F
      DWMCOLORIZATIONCOLORCHANGED = 800, // 0x00000320
      DWMWINDOWMAXIMIZEDCHANGE = 801, // 0x00000321
      GETTITLEBARINFOEX = 831, // 0x0000033F
      HANDHELDFIRST = 856, // 0x00000358
      HANDHELDLAST = 863, // 0x0000035F
      AFXFIRST = 864, // 0x00000360
      AFXLAST = 895, // 0x0000037F
      PENWINFIRST = 896, // 0x00000380
      PENWINLAST = 911, // 0x0000038F
      USER = 1024, // 0x00000400
      CPL_LAUNCH = 5120, // 0x00001400
      CPL_LAUNCHED = 5121, // 0x00001401
      APP = 32768, // 0x00008000
    }
  }
}

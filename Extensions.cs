﻿// Decompiled with JetBrains decompiler
// Type: Calculator.Extensions
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System;
using System.Windows.Forms;

namespace Calculator
{
  public static class Extensions
  {
    public static void InvokeIfRequired(this Control control, MethodInvoker action)
    {
      if (control.InvokeRequired)
        control.Invoke((Delegate) action);
      else
        action();
    }
  }
}

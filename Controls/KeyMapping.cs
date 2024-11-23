// Decompiled with JetBrains decompiler
// Type: Calculator.Controls.KeyMapping
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System;
using System.Windows.Forms;

namespace Calculator.Controls
{
  [Serializable]
  public class KeyMapping
  {
    public string Title { get; set; }

    public Keys Key { get; set; }

    public Keys LeftToonKey { get; set; }

    public Keys RightToonKey { get; set; }

    public bool ReadOnly { get; set; }

    public KeyMapping()
    {
    }

    public KeyMapping(string title, Keys key, Keys leftToonKey, Keys rightToonKey, bool readOnly)
    {
      this.Title = title;
      this.Key = key;
      this.LeftToonKey = leftToonKey;
      this.RightToonKey = rightToonKey;
      this.ReadOnly = readOnly;
    }
  }
}

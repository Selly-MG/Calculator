// Decompiled with JetBrains decompiler
// Type: Calculator.Properties.Resources
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Calculator.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Calculator.Properties.Resources.resourceMan == null)
          Calculator.Properties.Resources.resourceMan = new ResourceManager("Calculator.Properties.Resources", typeof (Calculator.Properties.Resources).Assembly);
        return Calculator.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Calculator.Properties.Resources.resourceCulture;
      set => Calculator.Properties.Resources.resourceCulture = value;
    }

    internal static Bitmap findere => (Bitmap) Calculator.Properties.Resources.ResourceManager.GetObject(nameof (findere), Calculator.Properties.Resources.resourceCulture);

    internal static Bitmap finderf => (Bitmap) Calculator.Properties.Resources.ResourceManager.GetObject(nameof (finderf), Calculator.Properties.Resources.resourceCulture);

    internal static Icon icon => (Icon) Calculator.Properties.Resources.ResourceManager.GetObject(nameof (icon), Calculator.Properties.Resources.resourceCulture);

    internal static byte[] searchw => (byte[]) Calculator.Properties.Resources.ResourceManager.GetObject(nameof (searchw), Calculator.Properties.Resources.resourceCulture);

    internal static byte[] toonmono => (byte[]) Calculator.Properties.Resources.ResourceManager.GetObject(nameof (toonmono), Calculator.Properties.Resources.resourceCulture);
  }
}

// Decompiled with JetBrains decompiler
// Type: Calculator.Properties.SerializedSettings
// Assembly: ToontownMulticontroller, Version=1.2.1.0, Culture=neutral, PublicKeyToken=null
// MVID: CF31A606-3059-4965-9E58-C8E615756A73
// Assembly location: C:\Users\Spenc\AppData\Local\Apps\2.0\3M63EJL2.NQD\NBW5C819.HK9\toon..tion_4512a1ef8d1e4b25_0001.0002_ff712502cfebbe13\ToontownMulticontroller.exe

using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Calculator.Controls;

namespace Calculator.Properties
{
  internal class SerializedSettings
  {
    private XmlSerializer keyMappingSerializer = new XmlSerializer(typeof (List<KeyMapping>));

    public static SerializedSettings Default { get; } = new SerializedSettings();

    public List<KeyMapping> Bindings
    {
      get
      {
        using (StringReader stringReader = new StringReader(Settings.Default.keyBindings))
        {
          try
          {
            return this.keyMappingSerializer.Deserialize((TextReader) stringReader) as List<KeyMapping>;
          }
          catch
          {
            return new List<KeyMapping>()
            {
              new KeyMapping("Forward", Keys.Up, (Keys) Settings.Default.leftForwardKeyCode, (Keys) Settings.Default.rightForwardKeyCode, true),
              new KeyMapping("Left", Keys.Left, (Keys) Settings.Default.leftLeftKeyCode, (Keys) Settings.Default.rightLeftKeyCode, true),
              new KeyMapping("Backward", Keys.Down, (Keys) Settings.Default.leftBackKeyCode, (Keys) Settings.Default.rightBackKeyCode, true),
              new KeyMapping("Right", Keys.Right, (Keys) Settings.Default.leftRightKeyCode, (Keys) Settings.Default.rightRightKeyCode, true),
              new KeyMapping("Jump", Keys.ControlKey, (Keys) Settings.Default.leftJumpKeyCode, (Keys) Settings.Default.rightJumpKeyCode, true),
              new KeyMapping("Throw", Keys.Delete, (Keys) Settings.Default.leftThrowKeyCode, (Keys) Settings.Default.rightThrowKeyCode, true),
              new KeyMapping("Open Book", Keys.Escape, (Keys) Settings.Default.leftEscapeKeyCode, (Keys) Settings.Default.rightEscapeKeyCode, true)
            };
          }
        }
      }
      set
      {
        using (StringWriter stringWriter = new StringWriter())
        {
          this.keyMappingSerializer.Serialize((TextWriter) stringWriter, (object) value);
          Settings.Default.keyBindings = stringWriter.ToString();
        }
      }
    }
  }
}

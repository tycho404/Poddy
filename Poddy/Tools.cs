using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Diagnostics;

namespace Poddy
{
  public class Tools
  {
    public static string CreateFilenameFromUrl(string webUrl)
    {
      int indexOfSlash = webUrl.LastIndexOf("/");
      string filename = webUrl.Substring(indexOfSlash + 1, webUrl.Length - indexOfSlash - 1);
      return filename;
    }

    public static String SerializeObject(Object pObject, Type type)
    {
      try
      {
        String XmlizedString = null;
        MemoryStream memoryStream = new MemoryStream();
        XmlSerializer xs = new XmlSerializer(type);
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        xs.Serialize(xmlTextWriter, pObject);
        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
        XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());

        return XmlizedString;
      }

      catch (Exception e)
      {
        System.Console.WriteLine(e);
        return null;
      }
    }

    public static Object DeserializeObject(String pXmlizedString, Type type)
    {
      XmlSerializer xs = new XmlSerializer(type);
      MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
      XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

      return xs.Deserialize(memoryStream);
    }

    private static String UTF8ByteArrayToString(Byte[] characters)
    {
      UTF8Encoding encoding = new UTF8Encoding();
      String constructedString = encoding.GetString(characters);
      return (constructedString);
    }

    private static Byte[] StringToUTF8ByteArray(String pXmlString)
    {
      UTF8Encoding encoding = new UTF8Encoding();
      Byte[] byteArray = encoding.GetBytes(pXmlString);
      return byteArray;
    }

    public static void OpenWindowsExplorer(string folderName)
    {
      ProcessStartInfo psi = new ProcessStartInfo(folderName);
      psi.UseShellExecute = true;
      Process process = new Process();
      process.StartInfo = psi;
      process.Start();
    }

    public static bool CheckFolderExists(string folderName)
    {
      if (string.IsNullOrEmpty(folderName))
      {
        System.Windows.Forms.MessageBox.Show(Properties.Resources.TargetFolderNotSpecified);
        return false;
      }

      if (!Directory.Exists(folderName))
      {
        System.Windows.Forms.MessageBox.Show(Properties.Resources.TargetFolderNotExist);
        return false;
      }

      return true;
    }
  }
}

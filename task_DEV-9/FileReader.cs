using System;
using System.IO;
using System.Text;

namespace task_DEV_9
{
  // Read info from the file helper
  public class FileReader
  {
    // Returns the array of splited strings readed from the custom file located in a project directory.
    // By default this file is InputDataFile.txt.
    public string[] GetStringsFromCustomFile()
    {
      StringBuilder filePath = new StringBuilder();
      string customFileName = "InputDataFile.txt";
      // Get builded project path dir.
      string buildPath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

      // Get the project full path name and finally set up the filePath name.
      filePath.Append(buildPath.Replace(@"bin\Debug", string.Empty));
      filePath.Append(customFileName);

      // Read, split and return data from file.
      TextReader textReader = new StreamReader(filePath.ToString());
      string fileData = textReader.ReadToEnd();
      char[] delimiters = null;
      return fileData.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
    }

  }
}

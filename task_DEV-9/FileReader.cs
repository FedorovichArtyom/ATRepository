using System;
using System.IO;
using System.Text;

namespace task_DEV_9
{
  // Read info from the file helper.
  public class FileReader
  {
    // Returns the array of splited strings readed from the custom file located in a project directory.
    // By default this file is InputDataFile.txt. 
    // Use command line args to change the filepaths.
    //
    // System.NotSupportedException,
    // System.IndexOutOfRangeException.
    // System.ArgumentException,
    // System.IO.FileNotFoundException,
    // System.IO.DirectoryNotFoundException,
    // System.IO.IOException,
    public string[] GetStringsFromCustomFile()
    {
      // Get the filepath.
      string[] args = Environment.GetCommandLineArgs();
      string filePath = args[1];

      // Read, split and return data from file.
      string[] dataFromFile = null;
      using (TextReader textReader = new StreamReader(filePath))
      {
        char[] delimiters = null;
        dataFromFile = textReader.ReadToEnd()
          .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
      }
      
      return dataFromFile;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_DEV_10
{
  class Program
  {
    static void Main(string[] args)
    {
      List<double[]> arrays = null;
      try
      {
        arrays = new FileReader().GetArraysOfDoubleFromCustomFile();
      }
      catch (ArgumentException ex)
      {
        Console.WriteLine();
        return;
      }
      catch (FormatException ex)
      {
        Console.WriteLine(AssemblyInfo.invalidDataFromFileMessage);
        return;
      }
      catch (IndexOutOfRangeException ex)
      {
        Console.WriteLine(AssemblyInfo.emptyFilePathMessage);
        return;
      }
      catch (System.IO.FileNotFoundException ex)
      {
        Console.WriteLine(AssemblyInfo.incorrectFilePathMessage);
        return;
      }
      catch (System.IO.DirectoryNotFoundException ex)
      {
        Console.WriteLine(AssemblyInfo.directoryNotFoundMessage);
        return;
      }
      catch (System.IO.IOException ex)
      {
        Console.WriteLine(AssemblyInfo.dataReadFromFileErrorMessage);
        return;
      }

      foreach (var array in arrays)
      {
        foreach (var element in array)
        {
          Console.Write(element + " ");
        }
        Console.WriteLine();
      }
    }
  }
}

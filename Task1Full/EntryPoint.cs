using System;
using System.IO;

namespace Task1Full
{
  // Validate file path to the object in OS Windows.
  class EntryPoint
  {
    static void Main(string[] args)
    {
      FilePathValidator validator = new FilePathValidator(args[0]);

      Console.WriteLine(validator.IsValid());
    }
  }
}

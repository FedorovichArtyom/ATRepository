﻿using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Globalization;

namespace task_DEV_10
{
  // Reading info from the file helper.
  public class FileReader
  {
    // Returns the list of arrays of doubles readed from the custom file located in a project directory.
    // By default this file is InputDataFile.txt. 
    // Use command line args to change the filepaths.
    // To set up the arrays use [] brackets to divide array instances, and spaces to divide elements in 
    // the array. To set up values for arrays use 'en-US' culture format.
    //
    // System.ArgumentException - incorrect filePath,
    // System.FormatException - wrong format of inputed numbers,
    // System.IndexOutOfRangeException - empty filePath,
    // System.IO.FileNotFoundException - not found file with current name from filePath,
    // System.IO.DirectoryNotFoundException - not found directory from filePath,
    // System.IO.IOException - got error while reading data from file,
    // System.NotSupportedException - current platform has no realisation of one of the using methods,
    // System.OverflowException - one or more of inputed numbers are out of range of the double.
    public List<double[]> GetArraysOfDoubleFromCustomFile()
    {
      // Get the filepath.
      string[] args = Environment.GetCommandLineArgs();
      string filePath = args[1];

      // Read and split arrays.
      string[] dataFromFile = null;
      using (TextReader textReader = new StreamReader(filePath))
      {
        char[] delimiters = { '[', ']', '\r', '\n' };
        dataFromFile = textReader.ReadToEnd()
          .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
      }

      // Split and try to covert to double each member of each array from the input data.
      List<double[]> convertedDataFromFile = new List<double[]>();
      foreach (var array in dataFromFile)
      { 
        char[] delimiters = { ' ' };
        string[] arrayInstances = array.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        double[] convertedArrayInstances = new double[arrayInstances.Length];

        for (int i = 0; i < arrayInstances.Length; i++)
        {
          CultureInfo cultureInfo = new CultureInfo(AssemblyInfo.inputDataCultureFormat);
          convertedArrayInstances[i] = Convert.ToDouble(arrayInstances[i], cultureInfo);
        }

        // If the conversion of each member of each individual array is successful,
        // add the array to the list of arrays.
        convertedDataFromFile.Add(convertedArrayInstances);
      }

      return convertedDataFromFile;
    }
  }
}

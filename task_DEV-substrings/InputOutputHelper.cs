using System;
using System.Collections.Generic;

namespace task_DEV_substrings
{
    public class InputOutputHelper
    {
        // Get all words from the entered string as parameter.
        public string[] GetAllWords(string enteredString)
        { 
            char[] delimiters = { ' ', '.', ',', '?', '!', '/', '\\', '|', '(', ')', '{','}',
                                '[', ']', '@', '#', '$', '%', '^', '&', '*', '+', '-', '`', 
                                '<', '>', '\'', '\"' };

            return enteredString.Split(delimiters);
        }

        public void PrintAllSubstrings(Dictionary<string, int> pairs)
        {
            foreach (var pair in pairs)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
    }
}

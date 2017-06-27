using System;

namespace task_DEV_substrings
{
    class EntryPoint
    {
        // Program that prints the number of substrings 
        // with two nearby symbols.
        static void Main(string[] args)
        {
            InputOutputHelper ioHelper = new InputOutputHelper();
            SubstringHandler substringHandler = new SubstringHandler(ioHelper.GetAllWords(args[0]));
            substringHandler.FindAllPairSubstrings();
            ioHelper.PrintAllSubstrings(substringHandler.GetPairs);
        }
    }
}

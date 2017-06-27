using System;
using System.Collections.Generic;
using System.Linq;

namespace task_DEV_substrings
{
    public class SubstringHandler
    {
        private string[] definedSubstrings;
        private Dictionary<string, int> pairSubstrings;

        public SubstringHandler(string[] substrings)
        {
            definedSubstrings = substrings;
            pairSubstrings = new Dictionary<string, int>();
        }

        public Dictionary<string, int> GetPairs
        {
            get
            {
                return pairSubstrings;
            }
        }
        
        // Combine all pairs of nearby sumbols in each word of 'definedSubstrings'
        // into the list of strings 'pairSubstrings'.
        public void FindAllPairSubstrings()
        {
            foreach (string word in definedSubstrings)
            {
                for (int i = 0; i < word.Length - 1; i++)
                {
                    string currentPair = word.Substring(i, 2);
                    if (pairSubstrings.ContainsKey(currentPair))
                    {
                        pairSubstrings[currentPair]++;
                    }
                    else
                    {
                        pairSubstrings.Add(currentPair, 1);
                    }
                }
            }

            // Sort the collection.
            pairSubstrings = pairSubstrings.OrderByDescending(pairs => pairs.Value)
                .ToDictionary(pairs => pairs.Key, pairs => pairs.Value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_DEV_2
{
    // Class that performs the function of a counter.
    public class Counter
    {
        // Perform count from 0 to 100 and print numbers to the console.
        // Numbers that are multiples of 3 are replaced by "Tutti".
        // Numbers that are multiples of 5 are replaced by "Frutti".
        // Numbers that are multiples of 15 are replaced by "Tutti-Frutti".
        public void Count()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (i % 15 != 0)
                {
                    if (i % 3 == 0)
                    {
                        Console.WriteLine("Tutti");
                        continue;
                    }
                    if (i % 5 == 0)
                    {
                        Console.WriteLine("Frutti");
                        continue;
                    }

                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine("Tutti-Frutti");
                }
            }
        }
    }

    static class Program
    {
        static void Main()
        {
            Counter counter = new Counter();
            counter.Count();
        }
    }
}

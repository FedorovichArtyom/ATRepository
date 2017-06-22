using System;

namespace task_DEV_1
{
    static class Program
    {
        static void Main()
        {
            // Perform count from 0 to 100 and 
            // print numbers to the console.
            // Numbers that are multiples of 3 are output in 3 * N format.
            for (int i = 0; i <= 100; i++)
            {
                string output = (i % 3 != 0) ? i.ToString() : "3*" + (i / 3).ToString();
                Console.WriteLine(output);
            }
        }
    }
}
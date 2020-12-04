using System;

namespace Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // With the values 1-10, use code to generate a multiplication table.
            // Use a multidimensional array to store all values.
            int [,,] multiplicationTable = new int [10, 1, 10];
            for (int y = 1; y <= 10; y++)
            {
                for (int x = 1; x <= 10 ; x++)
                {
                    if (y-1 == 0)
                    {
                        multiplicationTable[y-1, 0, x-1] = x;
                    }
                    else
                    {
                        multiplicationTable[y-1, 0, x-1] = x * y;
                    }
                    Console.WriteLine(multiplicationTable[y-1, 0, x-1]);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Create an empty List of type object
            List<object> box = new List<object>();

            // Add the following values to the list: 7, 28, -1, true, "chair"
            box.Add(7);
            box.Add(28);
            box.Add(-1);
            box.Add(true);
            box.Add("chair");
            // Console.WriteLine(box);

            // Loop through the list and print all values (Hint: Type Inference might help here!)

            foreach (var item in box)
            {
                Console.WriteLine(item);
            }

            // Add all values that are Int type together and output the sum
            int sum = 0;
            foreach (var item in box)
            {
                if( item is int)
                {
                    int number = (int)item;
                    sum += number;
                }
                else
                {
                    Console.WriteLine("Cannot add a Non-integer type.");
                }
            }
            Console.WriteLine(sum);
        }
    }
}
using System;
using System.Collections.Generic;

namespace Collections_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Three Basic Arrays:
            // Create an array to hold integer values 0 through 9
            int[] basicArray1 = {0,1,2,3,4,5,6,7,8,9};
            Console.WriteLine(basicArray1);
            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] basicArray2 = {"Tim", "Martin", "Nikki", "Sara"};
            Console.WriteLine(basicArray2);
            // Create an array of length 10 that alternates between true and false values, starting with true
            bool[] basicArray3 = {true, false, true, false, true, false, true, false, true, false};
            Console.WriteLine(basicArray3);

            // List of Flavors:
            // Create a list of ice cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
            List<string> iceCreamFlavors = new List<string>();
            iceCreamFlavors.Add("Vanilla");
            iceCreamFlavors.Add("Strawberry");
            iceCreamFlavors.Add("Chocolate");
            iceCreamFlavors.Add("Butter Pecan");
            iceCreamFlavors.Add("Moose Tracks");
            // Output the length of this list after building it
            Console.WriteLine(iceCreamFlavors.Count);
            // Output the third flavor in the list, then remove this value
            Console.WriteLine(iceCreamFlavors[2]);
            iceCreamFlavors.Remove(iceCreamFlavors[2]);
            // Output the new length of the list (It should just be one fewer!)
            Console.WriteLine(iceCreamFlavors.Count);

            // User Info Dictionary:
            // Create a dictionary that will store both string keys as well as string values
            Dictionary<string, string> favoriteIceCream = new Dictionary<string, string>();
            // Add key/value pairs to this dictionary where:
                // each key is a name from your names array
                // each value is a randomly select a flavor from your flavors list.
            favoriteIceCream.Add(basicArray2[0], iceCreamFlavors[0]);
            favoriteIceCream.Add(basicArray2[1], iceCreamFlavors[1]);
            favoriteIceCream.Add(basicArray2[2], iceCreamFlavors[2]);
            favoriteIceCream.Add(basicArray2[3], iceCreamFlavors[3]);
            // Loop through the dictionary and print out each user's name and their associated ice cream flavor
            foreach (KeyValuePair<string,string> person in favoriteIceCream)
            {
                Console.WriteLine(person.Key + "'s favorite icecream - " + person.Value);
            }
        }
    }
}
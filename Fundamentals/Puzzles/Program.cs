using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {

        // 1) Create a function called RandomArray() that returns an integer array
        public static void RandomArray()
        {
        // Place 10 random integer values between 5-25 into the array
            int[] randomArray = new int[10];
            Random rand = new Random();
                for (int value = 0; value < 10; value++)
                {
                    randomArray[value] = rand.Next(5, 25);
                }
        // Print the min and max values of the array
        // Print the sum of all the values
            int max = randomArray[0];
            int min = randomArray[0];
            int sum = 0;
            for (int i = 0; i < randomArray.Length; i++)
            {
                sum += randomArray[i];
                if (max < randomArray[i])
                {
                    max = randomArray[i];
                }
                else if (min > randomArray[i])
                {
                    min = randomArray[i];
                }
            }
            Console.WriteLine($"max: {max}, min: {min}, sum: {sum}");
        }
        
        // 2) Create a function called TossCoin() that returns a string
        public static string TossCoin()
        {
        // Have the function print "Tossing a Coin!"
            Console.Write("Tossing a Coin!");
        // Randomize a coin toss with a result signaling either side of the coin 
            Random rand = new Random();
            string result = " ";
            int coin = rand.Next(1, 3);
        // Have the function print either "Heads" or "Tails"
            if (coin == 1)
            {
                result = " Heads";
                Console.WriteLine("Heads");
            }
            if (coin == 2)
            {
                result = " Tails";
                Console.WriteLine("Tails");
            }
        // Finally, return the result
            return result;
        }

        // Create another function called TossMultipleCoins(int num) that returns a Double
        public static double TossMultipleCoins(int num)
        {
        // Have the function call the tossCoin function multiple times based on num value
            Random rand = new Random();
            int heads = 0;
            int total = 0;
            for (int toss = 0; toss < num; toss++){
                int coin = rand.Next(1, 3);
                if (coin == 1)
                {
                    heads++;
                    total++;
                }
                else
                {
                    total++;
                }
            }
            double results = (double)heads / (double)total;
        // Have the function return a Double that reflects the ratio of head toss to total toss
            return results;
        }

        // 3) Build a function Names that returns a list of strings.  In this function:
        public static List<string> Names()
        {
        // Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
            List<string> listOfNames = new List<string>{"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
        // Shuffle the list and print the values in the new order
            Random rand = new Random();
            string nameSwap = "";
            for (int name = 0; name < listOfNames.Count; name++)
            {
                if (listOfNames[name].Length <= 5)
                {
                    listOfNames.Remove(listOfNames[name]);
                    name--;
                }
                else
                {
                    int randomIdx = rand.Next(0, listOfNames.Count);
                    nameSwap = listOfNames[name];
                    listOfNames[name] = listOfNames[randomIdx];
                    listOfNames[randomIdx] = nameSwap;
                }
                // listOfNames.FindAll(n => n.Length < 5);
            }
            Console.WriteLine(listOfNames);
        // Return a list that only includes names longer than 5 characters
            return listOfNames;
        }
        static void Main(string[] args)
        {
            RandomArray();
            string tossResult = TossCoin();
            Console.WriteLine($"The coin flipped to be {tossResult}");

            double multipleTosses = TossMultipleCoins(7);
            Console.WriteLine($"The average chance of heads was: {multipleTosses}");

            List<string> listofNames = Names();
            Console.WriteLine(listofNames);
        }
    }
}
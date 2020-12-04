using System;

namespace Basic_13
{
    class Program
    {
        public static void PrintNumbers()
            {
                for (int i = 1; i <= 255; i++)
                {
                    Console.WriteLine(i);
                }
            }

        public static void PrintOdds()
        {
            for (int i = 1; i <= 255; i+=2)
            {
                Console.WriteLine(i);
            }
        }

        public static void PrintSum()
        {
            int sum = 0;
            for (int i = 0; i <= 255; i++)
            {
                sum += i;
                Console.WriteLine($"New number: {i} Sum: {sum}");
            }
        }

        public static void LoopArray(int[] numbers)
        {
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        public static int FindMax(int[] numbers)
        {
            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (max < number)
                {
                    max = number;
                }
            }
            Console.WriteLine(max);
            return max;
        }

        public static void GetAverage(int[] numbers)
        {
            int sum = 0;
            int count = 0;
            foreach (int number in numbers)
            {
                sum+= number;
                count+=1;
            }
            float average = (float)sum / (float)count;
            Console.WriteLine(average);
        }

        public static int[] OddArray()
        {
            int[] array = new int[256/2];
            // int index = 0;
            for (int i = 1; i <= 255; i+= 2)
            {
                array[(i-1)/2] = i;
                // array[index] = i;
                // index++;
            }

            return array;
        }

        public static int GreaterThanY(int[] numbers, int y)
        {
            int count = 0;
            foreach (int number in numbers)
            {
                if (number > y)
                {
                    count++;
                }
            }
            return count;
        }

        public static void SquareArrayValues(int[] numbers)
        {
            int length = numbers.Length;
            for (int i = 0; i < length; i++)
            {
                numbers[i] = numbers[i] * numbers[i];
            }
            Console.WriteLine(numbers);
        }

        public static void EliminateNegatives(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = 0;
                }
            }
            Console.WriteLine(numbers);
        }

        public static void MinMaxAverage(int[] numbers)
        {
            int max = numbers[0];
            int min = numbers[0];
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
                if (max < numbers[i])
                {
                    max = numbers[i];
                }
                else if (min > numbers[i])
                {
                    min = numbers[i];
                }
            }
            float average = (float)sum / (float)numbers.Length;
            Console.WriteLine($"max: {max}, min: {min}, average: {average}");
        }

        public static void ShiftValues(int[] numbers)
            {
                int swap;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (i == 0)
                    {
                        numbers[i] = numbers[i+1];
                    }
                    else if (i+1 == numbers.Length)
                    {
                        numbers[i] = 0;
                    }
                    else
                    {
                        swap = numbers[i];
                        numbers[i] = numbers[i+1];
                        numbers[i-1] = swap;
                    }
                }
                Console.WriteLine(numbers);
            }

            public static object[] NumToString(int[] numbers)
            {
                object[] updatedArray = new object[numbers.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] < 0)
                    {
                        updatedArray[i] = "'Dojo'";
                    }
                    else
                    {
                        updatedArray[i] = numbers[i];
                    }
                }
                return updatedArray;
            }

        static void Main(string[] args)
        {
            // PrintNumbers();
            // PrintOdds();
            // PrintSum();
            // LoopArray(new int[]{1,2,3,4,5});

            // int max1 = FindMax(new int[]{-9,7,0,12,1});
            // int max2 = FindMax(new int[]{-1,-5,-10, 0});
            // Console.WriteLine($"First max: {max1} Second max: {max2}");

            // GetAverage(new int[]{1,2,3,4});

            // int[] myArray = OddArray();
            // Console.WriteLine(myArray);

            // int biggerThanY = GreaterThanY(new int[]{4, -2, 5, 0, 13}, 4);
            // Console.WriteLine(biggerThanY);

            // SquareArrayValues(new int[]{-1, 2, 9, 10});

            // EliminateNegatives(new int[]{-1, 70, -2, -13});

            // MinMaxAverage(new int[]{-2, -9, 0, 2, 13});

            // ShiftValues(new int[]{-1, -3, 5, 7});

            object[] updatedArray = NumToString(new int[]{-1, 2, -13, 99, 0});
            Console.WriteLine(updatedArray);
        }
    }
}
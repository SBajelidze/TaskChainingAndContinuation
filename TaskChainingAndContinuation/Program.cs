#pragma warning disable CS1998
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChainExample
{
    public static class Program
    {
        private static int mult;

        public static async Task Main(string[] args)
        {
            try
            {
                int[] array = await Task1();
                int[] multipliedArray = await Task2(array);
                int[] sortedArray = await Task3(multipliedArray);
                double average = await Task4(sortedArray);

                Console.WriteLine($"Average value: {average}");
            }
            catch (AggregateException ex)
            {
                foreach (var innerEx in ex.InnerExceptions)
                {
                    Console.WriteLine($"An error occurred: {innerEx.Message}");
                }
            }
        }

        public static async Task<int[]> Task1()
        {
            Console.WriteLine("Task 1: Creating an array of 10 random integers.");
            Random random = new Random();
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 101); // Generate random integers between 1 and 100
            }
            PrintArray(array);
            return array;
        }

        public static async Task<int[]> Task2(int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException(nameof(inputArray), "Input array cannot be null.");
            }

            Console.WriteLine("Task 2: Multiplying the array by a random number.");
            Random random = new Random();
            int multiplier = random.Next(2, 6); // Generate a random multiplier between 2 and 5
            mult = multiplier;
            int[] multipliedArray = inputArray.Select(x => x * multiplier).ToArray();
            PrintArray(multipliedArray);
            return multipliedArray;
        }

        public static async Task<int[]> Task3(int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException(nameof(inputArray), "Input array cannot be null.");
            }

            Console.WriteLine("Task 3: Sorting the array in ascending order.");
            int[] sortedArray = inputArray.OrderBy(x => x).ToArray();
            PrintArray(sortedArray);
            return sortedArray;
        }

        public static async Task<double> Task4(int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException(nameof(inputArray), "Input array cannot be null.");
            }

            Console.WriteLine("Task 4: Calculating the average value.");
            double average = inputArray.Average();
            return average;
        }

        public static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        public static int GetRandomMultiplier()
        {
            return mult;
        }
    }
}
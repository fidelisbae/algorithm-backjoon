using System;

namespace _12865
{
    public class Item
    {
        public int Value
        {
            get; set;
        }

        public int Weight { get; set; }

        public Item(int weight, int value)
        {
            Value = value;
            Weight = weight;
        }

        public Item()
        {
            Value = 0;
            Weight = 0;
        }
    }

    internal class Program

    {
        private static void GetInput(out int totalNumber, out int maxWeight, out Item[] items)
        {
            string? firstLine = Console.ReadLine();
            totalNumber = int.Parse(firstLine!.Split(" ")[0]);
            maxWeight = int.Parse(firstLine.Split(" ")[1]);

            items = new Item[totalNumber];

            for (int i = 0; i < totalNumber; i++)
            {
                string? input = Console.ReadLine();
                items[i] = new Item(int.Parse(input!.Split(" ")[0]), int.Parse(input.Split(" ")[1]));
            }
        }

        private static void Main(string[] args)
        {
            GetInput(out int totalNumber, out int maxWeight, out Item[] items);

            var dp = new int[maxWeight + 1];
            dp[0] = 0;

            Console.WriteLine(dp[3]);

            for (int i = 0; i < totalNumber; i++)
            {
                for (int j = maxWeight; j >= items[i].Weight; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j - items[i].Weight] + items[i].Value);
                }
            }

            Console.WriteLine(dp[maxWeight]);
        }
    }
}
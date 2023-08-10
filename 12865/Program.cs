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
            string firstLine = Console.ReadLine();
            totalNumber = int.Parse(firstLine.Split(" ")[0]);
            maxWeight = int.Parse(firstLine.Split(" ")[1]);

            items = new Item[totalNumber];

            for (int i = 0; i < totalNumber; i++)
            {
                string input = Console.ReadLine();
                items[i] = new Item(int.Parse(input.Split(" ")[0]), int.Parse(input.Split(" ")[1]));
            }
        }

        private static void Main(string[] args)
        {
            GetInput(out int totalNumber, out int maxWeight, out Item[] items);

            Item[] dp = new Item[totalNumber + 1];
            Array.Fill(dp, new Item());

            for (int i = 1; i <= totalNumber; i++)
            {
                for (int j = 0; j < totalNumber; j++)
                {
                    if (items[j].Value + dp[i - 1].Value > dp[i].Value && items[j].Weight + dp[i - 1].Weight <= maxWeight)
                    {
                        dp[i].Value = items[j].Value + dp[i - 1].Value;
                        dp[i].Weight = items[j].Weight + dp[i - 1].Weight;
                    }
                }
            }

            foreach (Item item in dp)
            {
                Console.WriteLine(item.Value);
                Console.WriteLine(item.Weight);
            }
        }
    }
}
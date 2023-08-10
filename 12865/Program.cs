using System;

namespace _12865
{
    public class Item
    {
        public int Value
        {
            get; private set;
        }

        public int Weight { get; private set; }

        public Item(int value, int weight)
        {
            Value = value;
            Weight = weight;
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

            int totalValue = 0;

            foreach (Item item in items)
            {
            }
        }
    }
}
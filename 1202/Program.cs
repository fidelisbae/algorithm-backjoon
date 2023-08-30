namespace _1202
{
    internal class Program
    {
        private static ((int weight, int value)[], int[]) GetInput()
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            string[] firstInput = sr.ReadLine()!.Split(" ");
            int N = int.Parse(firstInput[0]);
            int K = int.Parse(firstInput[1]);
            var jewels = new (int weight, int value)[N];
            var bags = new int[K];

            for (int i = 0; i < N; i++)
            {
                string[] input = sr.ReadLine()!.Split(" ");
                int weight = int.Parse(input[0]);
                int value = int.Parse(input[1]);
                jewels[i] = (weight, value);
            }

            for (int i = 0; i < K; i++)
            {
                int input = int.Parse(sr.ReadLine()!);
                bags[i] = input;
            }

            return (jewels, bags);
        }

        private static void Main(string[] args)
        {
            (var jewels, var bags) = GetInput();
            Array.Sort(bags, (a, b) => (a - b));
            Array.Sort(jewels, (a, b) =>
            {
                if (a.weight == b.weight)
                {
                    return b.value - a.value;
                }
                else
                {
                    return a.weight - b.weight;
                }
            });
            var priorityQueue = new PriorityQueue<(int weight, int value), int>();
            long totalValue = 0;
            int jewelIndex = 0;

            for (int i = 0; i < bags.Length; i++)
            {
                while (jewelIndex < jewels.Length && jewels[jewelIndex].weight <= bags[i])
                {
                    priorityQueue.Enqueue(jewels[jewelIndex], jewels[jewelIndex].value * -1);
                    jewelIndex++;
                }

                if (priorityQueue.Count > 0)
                {
                    var current = priorityQueue.Dequeue();
                    totalValue += current.value;
                }
            }

            Console.WriteLine(totalValue);
        }
    }
}
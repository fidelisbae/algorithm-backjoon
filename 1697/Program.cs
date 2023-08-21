namespace _1697
{
    internal class Program
    {
        private static bool IsValidRange(int i)
        {
            return i >= 0 && i <= 100000;
        }

        private static int BFS(int start, int end)
        {
            var distances = new int[100001];
            Array.Fill(distances, -1);

            var queue = new Queue<int>();
            queue.Enqueue(start);
            distances[start] = 0;

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                if (current == end)
                {
                    return distances[current];
                }

                if (IsValidRange(current - 1) && distances[current - 1] == -1)
                {
                    queue.Enqueue(current - 1);
                    distances[current - 1] = distances[current] + 1;
                }
                if (IsValidRange(current + 1) && distances[current + 1] == -1)
                {
                    queue.Enqueue(current + 1);
                    distances[current + 1] = distances[current] + 1;
                }
                if (IsValidRange(current * 2) && distances[current * 2] == -1)
                {
                    queue.Enqueue(current * 2);
                    distances[current * 2] = distances[current] + 1;
                }
            }

            return distances[end];
        }

        private static void Main(string[] args)
        {
            string[] input = Console.ReadLine()!.Split(' ');
            int start = int.Parse(input[0]);
            int end = int.Parse(input[1]);

            int answer = BFS(start, end);

            Console.WriteLine(answer);
        }
    }
}
using System.Text;

namespace _14940
{
    public class Graph
    {
        private readonly int[,] map;
        private readonly int[,] distance;
        private readonly int[] dr = new int[4] { 1, -1, 0, 0 };
        private readonly int[] dc = new int[4] { 0, 0, 1, -1 };
        private readonly StringBuilder sb;

        public Graph(int[,] map)
        {
            this.map = map;
            distance = new int[map.GetLength(0), map.GetLength(1)];
            sb = new StringBuilder();
        }

        private bool IsValid((int r, int c) dot)
        {
            return dot.r >= 0 && dot.c >= 0 && dot.r < map.GetLength(0) && dot.c < map.GetLength(1) && map[dot.r, dot.c] == 1 && distance[dot.r, dot.c] == 0;
        }

        public void BFS((int r, int c) target)
        {
            var queue = new Queue<(int r, int c)>();
            queue.Enqueue(target);

            while (queue.Count > 0)
            {
                (int r, int c) current = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    (int r, int c) next = (current.r + dr[i], current.c + dc[i]);

                    if (IsValid(next))
                    {
                        queue.Enqueue(next);
                        distance[next.r, next.c] = distance[current.r, current.c] + 1;
                    }
                }
            }
        }

        public void CompareMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 1 && distance[i, j] == 0)
                    {
                        distance[i, j] = -1;
                    }
                }
            }
        }

        public void PrintDistance()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (j == map.GetLength(1) - 1)
                    {
                        sb.AppendLine(distance[i, j].ToString());
                    }
                    else
                    {
                        sb.Append($"{distance[i, j]} ");
                    }
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            string[] firstInput = sr.ReadLine()!.Split(" ");
            int row = int.Parse(firstInput[0]);
            int column = int.Parse(firstInput[1]);
            var map = new int[row, column];
            (int r, int c) target = (0, 0);

            for (int i = 0; i < row; i++)
            {
                string[] input = sr.ReadLine()!.Split(" ");

                for (int j = 0; j < column; j++)
                {
                    map[i, j] = int.Parse(input[j]);
                    if (map[i, j] == 2)
                    {
                        target = (i, j);
                    }
                }
            }

            var graph = new Graph(map);
            graph.BFS(target);
            graph.CompareMap();
            graph.PrintDistance();
        }
    }
}
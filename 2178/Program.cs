using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _2178
{
    internal class Program
    {
        private static int MAX_ROW;
        private static int MAX_COLUMN;
        private static int[,] maze;
        private static int[,] distance;

        public class Node
        {
            public int Row { get; private set; }
            public int Column { get; private set; }

            public Node(int r, int c)
            {
                Row = r;
                Column = c;
            }
        }

        private static int BFS()
        {
            var dr = new int[] { 1, -1, 0, 0 };
            var dc = new int[] { 0, 0, 1, -1 };

            var queue = new Queue<Node>();
            queue.Enqueue(new Node(0, 0));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int row = current.Row + dr[i];
                    int column = current.Column + dc[i];

                    // 각각 유효범위, 벽이아닌지여부, 방문여부
                    if (IsValid(row, column) && maze[row, column] == 1 && distance[row, column] == 0)
                    {
                        distance[row, column] = distance[current.Row, current.Column] + 1;
                        queue.Enqueue(new Node(row, column));
                    }
                }
            }

            return distance[MAX_ROW - 1, MAX_COLUMN - 1];
        }

        private static bool IsValid(int r, int c)
        {
            return r >= 0 && c >= 0 && r < MAX_ROW && c < MAX_COLUMN;
        }

        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            string input = sr.ReadLine()!;
            MAX_ROW = int.Parse(input.Split(" ")[0]);
            MAX_COLUMN = int.Parse(input.Split(" ")[1]);

            maze = new int[MAX_ROW, MAX_COLUMN];
            distance = new int[MAX_ROW, MAX_COLUMN];
            distance[0, 0] = 1;

            for (int i = 0; i < MAX_ROW; i++)
            {
                string line = sr.ReadLine()!;

                for (int j = 0; j < MAX_COLUMN; j++)
                {
                    maze[i, j] = line[j] - '0';
                }
            }
            int answer = BFS();

            sb.AppendLine(answer.ToString());
            Console.WriteLine(sb.ToString());
        }
    }
}
using System.Text;

namespace _1012
{
    public class BFS_Solution
    {
        private readonly int MAX_ROW;
        private readonly int MAX_COLUMN;
        private readonly int[] dr = new int[4] { 1, -1, 0, 0 };
        private readonly int[] dc = new int[4] { 0, 0, 1, -1 };
        public int[,] map;
        public int count = 0;

        private bool IsValid(int r, int c)
        {
            return r >= 0 && c >= 0 && r < MAX_ROW && c < MAX_COLUMN;
        }

        public BFS_Solution(int r, int c)
        {
            MAX_ROW = r;
            MAX_COLUMN = c;
            map = new int[MAX_ROW, MAX_COLUMN];
        }

        public void BFS(int r, int c)
        {
            var queue = new Queue<ValueTuple<int, int>>();
            queue.Enqueue((r, c));
            map[r, c] = 0;

            while (queue.Count > 0)
            {
                (int currentRow, int currentColumn) = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int nextRow = currentRow + dr[i];
                    int nextColumn = currentColumn + dc[i];

                    if (IsValid(nextRow, nextColumn) && map[nextRow, nextColumn] == 1)
                    {
                        queue.Enqueue((nextRow, nextColumn));
                        map[nextRow, nextColumn] = 0;
                    }
                }
            }
            count++;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            int T = int.Parse(sr.ReadLine()!);

            for (int i = 0; i < T; i++)
            {
                string[] firstInput = sr.ReadLine()!.Split(" ");
                int column = int.Parse(firstInput[0]);
                int row = int.Parse(firstInput[1]);
                int targets = int.Parse(firstInput[2]);

                var solution = new BFS_Solution(row, column);

                for (int j = 0; j < targets; j++)
                {
                    string[] target = sr.ReadLine()!.Split(" ");
                    int targetRow = int.Parse(target[1]);
                    int targetColumn = int.Parse(target[0]);

                    solution.map[targetRow, targetColumn] = 1;
                }

                for (int j = 0; j < row; j++)
                {
                    for (int k = 0; k < column; k++)
                    {
                        if (solution.map[j, k] == 1)
                        {
                            solution.BFS(j, k);
                        }
                    }
                }
                sb.AppendLine(solution.count.ToString());
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
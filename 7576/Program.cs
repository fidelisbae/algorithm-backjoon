namespace _7576
{
    internal class Program
    {
        private static int row;
        private static int column;
        private static int[,] map;
        private static int[] rowDirection = new int[4] { 1, -1, 0, 0 };
        private static int[] columnDirection = new int[4] { 0, 0, 1, -1 };
        private static int count = 0;
        private static (int r, int c) last = (-1, -1);

        private static bool IsValid(int r, int c)
        {
            return r >= 0 && c >= 0 && r < row && c < column && map[r, c] == 0;
        }

        private static void BFS(Queue<(int, int)> queue)
        {
            bool isDequeue = false;
            while (queue.Count > 0)
            {
                (int r, int c) current = queue.Dequeue();

                if (current == last)
                {
                    if (isDequeue)
                    {
                        count++;
                        isDequeue = false;
                    }
                    if (queue.Count > 0)
                    {
                        queue.Enqueue(last);
                    }
                    else
                    {
                        break;
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    (int r, int c) near = (current.r + rowDirection[i], current.c + columnDirection[i]);

                    if (IsValid(near.r, near.c))
                    {
                        isDequeue = true;
                        queue.Enqueue(near);
                        map[near.r, near.c] = 1;
                    }
                }
            }
        }

        private static void GetInput()
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            string[] firstInput = sr.ReadLine()!.Split(" ");
            row = int.Parse(firstInput[1]);
            column = int.Parse(firstInput[0]);
            map = new int[row, column];

            for (int i = 0; i < row; i++)
            {
                string[] input = sr.ReadLine()!.Split(" ");

                for (int j = 0; j < column; j++)
                {
                    map[i, j] = int.Parse(input[j]);
                }
            }
        }

        private static void Main(string[] args)
        {
            GetInput();

            var queue = new Queue<(int, int)>();
            bool isFindZero = false;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (map[i, j] == 1)
                    {
                        queue.Enqueue((i, j));
                    }
                }
            }

            queue.Enqueue(last);
            BFS(queue);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (map[i, j] == 0)
                    {
                        isFindZero = true;
                    }
                }
            }

            if (isFindZero)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(count);
            }
        }
    }
}
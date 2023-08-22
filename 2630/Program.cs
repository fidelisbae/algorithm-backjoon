namespace _2630
{
    internal class Program
    {
        private static int[,] map;
        private static int white = 0;
        private static int blue = 0;

        private static int DevideAndConquer(int n, int r, int c)
        {
            int first = map[r, c];
            int half = n / 2;
            bool isSame = true;

            if (n == 0)
            {
                if (first == 1)
                {
                    blue++;
                }
                else
                {
                    white++;
                }

                return 0;
            }

            for (int i = r; i < r + n; i++)
            {
                for (int j = c; j < c + n; j++)
                {
                    if (map[i, j] != first)
                    {
                        isSame = false;
                        break;
                    }
                }
            }

            if (isSame)
            {
                if (first == 1)
                {
                    blue++;
                }
                else
                {
                    white++;
                }

                return 0;
            }
            else
            {
                DevideAndConquer(half, r, c);
                DevideAndConquer(half, r + half, c);
                DevideAndConquer(half, r, c + half);
                DevideAndConquer(half, r + half, c + half);
            }

            return 0;
        }

        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());

            int N = int.Parse(sr.ReadLine()!);

            map = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                string[] input = sr.ReadLine()!.Split(" ");

                for (int j = 0; j < N; j++)
                {
                    map[i, j] = int.Parse(input[j]);
                }
            }

            DevideAndConquer(N, 0, 0);

            Console.WriteLine(white);
            Console.WriteLine(blue);
        }
    }
}
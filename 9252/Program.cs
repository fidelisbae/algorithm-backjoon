namespace _9252
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string first = Console.ReadLine()!;
            string second = Console.ReadLine()!;
            var dp = new int[first.Length + 1, second.Length + 1];

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            var stack = new Stack<Char>();
            string lcs = "";
            int x = first.Length;
            int y = second.Length;

            while (x > 0 && y > 0)
            {
                if (first[x - 1] == second[y - 1])
                {
                    stack.Push(first[x - 1]);
                    x--;
                    y--;
                }
                else
                {
                    if (dp[x - 1, y] > dp[x, y - 1])
                    {
                        x--;
                    }
                    else
                    {
                        y--;
                    }
                }
            }

            while (stack.Count > 0)
            {
                lcs += stack.Pop();
            }

            Console.WriteLine(dp[first.Length, second.Length]);
            Console.WriteLine(lcs);
        }
    }
}
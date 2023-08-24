namespace _11726
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);
            var dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                dp[i] = (dp[i - 1] + dp[i - 2]) % 10007;
            }

            Console.WriteLine(dp[n]);
        }
    }
}
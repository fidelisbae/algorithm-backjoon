using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace _9095
{
    internal class Program
    {
        private static int[] dp = new int[11];

        private static int Recursion(int n)
        {
            if (n > 10)
            {
                return 0;
            }

            dp[n] = dp[n] + 1;

            Recursion(n + 1);
            Recursion(n + 2);
            Recursion(n + 3);

            return 0;
        }

        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            int N = int.Parse(sr.ReadLine()!);

            Recursion(0);

            for (int i = 0; i < N; i++)
            {
                int number = int.Parse(sr.ReadLine()!);

                sb.AppendLine(dp[number].ToString());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
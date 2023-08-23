using System.Text;

namespace _9095
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            int N = int.Parse(sr.ReadLine()!);

            for (int i = 0; i < N; i++)
            {
                int number = int.Parse(sr.ReadLine()!);
                var dp = new int[number + 1];
                dp[0] = 0;
                dp[1] = 1;
                dp[2] = 2;
                dp[3] = 4;
            }
        }
    }
}
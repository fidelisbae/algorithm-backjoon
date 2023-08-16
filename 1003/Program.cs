using System.Reflection;
using System.Text;

namespace _1003
{
    internal class Program
    {
        public class Fibo
        {
            public int One { get; set; }

            public int Zero { get; set; }

            public Fibo()
            {
                Zero = 0;
                One = 0;
            }
        }

        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            int T = int.Parse(sr.ReadLine()!);

            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(sr.ReadLine()!);

                var dp = new Fibo[N + 1];

                for (int j = 0; j < dp.Length; j++)
                {
                    dp[j] = new Fibo();
                }

                if (N == 0)
                {
                    sb.AppendLine("1 0");
                    continue;
                }

                if (N == 1)
                {
                    sb.AppendLine("0 1");
                    continue;
                }

                dp[0].Zero = 1;
                dp[0].One = 0;

                dp[1].Zero = 0;
                dp[1].One = 1;

                for (int j = 2; j <= N; j++)
                {
                    dp[j].Zero = dp[j - 2].Zero + dp[j - 1].Zero;
                    dp[j].One = dp[j - 2].One + dp[j - 1].One;
                }

                sb.AppendLine($"{dp[N].Zero} {dp[N].One}");
            }
            Console.Write(sb.ToString());
        }
    }
}
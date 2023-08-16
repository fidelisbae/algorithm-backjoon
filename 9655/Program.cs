using System.Threading.Channels;

namespace _9655
{
    internal class Program
    {
        private static int GetInput()
        {
            int input = int.Parse(Console.ReadLine()!);

            return input;
        }

        private static void Main(string[] args)
        {
            int stones = GetInput();

            var dp = new bool[stones + 1];
            Array.Fill(dp, false);

            if (stones >= 1)
            {
                dp[1] = true;
            }

            if (stones >= 3)
            {
                dp[3] = true;
            }

            for (int i = 0; i <= stones - 3; i++)
            {
                dp[i + 1] = dp[i] ? false : true;
                dp[i + 3] = dp[i] ? true : false;
            }

            string answer = dp[stones] ? "SK" : "CY";
            Console.WriteLine(answer);
        }
    }
}
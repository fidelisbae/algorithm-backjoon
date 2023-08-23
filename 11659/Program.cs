using System.Text;

namespace _11659
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            string[] firstInput = sr.ReadLine()!.Split(" ");
            string[] secondInput = sr.ReadLine()!.Split(" ");
            int N = int.Parse(firstInput[0]);
            int M = int.Parse(firstInput[1]);
            var numbers = new int[N];
            var accumulation = new int[N];

            accumulation[0] = int.Parse(secondInput[0]);

            for (int i = 1; i < N; i++)
            {
                numbers[i] = int.Parse(secondInput[i]);
                accumulation[i] = accumulation[i - 1] + numbers[i];
            }

            for (int i = 0; i < M; i++)
            {
                string[] input = sr.ReadLine()!.Split(" ");
                int first = int.Parse(input[0]);
                int second = int.Parse(input[1]);

                int answer;

                if (first == 1)
                {
                    answer = accumulation[second - 1];
                }
                else
                {
                    answer = accumulation[second - 1] - accumulation[first - 2];
                }

                sb.AppendLine(answer.ToString());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
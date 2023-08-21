using System.Text;

namespace _1074
{
    internal class Program
    {
        private static int DevideAndConQuer(int n, int r, int c)
        {
            if (n == 0)
            {
                return 0;
            }

            int half = (int)Math.Pow(2, n - 1);

            if (r < half && c < half) // 왼쪽위
            {
                return DevideAndConQuer(n - 1, r, c);
            }
            else if (r < half && c >= half)
            {
                return half * half + DevideAndConQuer(n - 1, r, c - half); // 오른쪽위
            }
            else if (r >= half && c < half)
            {
                return 2 * half * half + DevideAndConQuer(n - 1, r - half, c); // 왼쪽아래
            }
            else
            {
                return 3 * half * half + DevideAndConQuer(n - 1, r - half, c - half); // 오른쪽아래
            }
        }

        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            string[] input = sr.ReadLine()!.Split(' ');

            int power = int.Parse(input[0]);
            int row = int.Parse(input[1]);
            int column = int.Parse(input[2]);

            int answer = DevideAndConQuer(power, row, column);

            Console.WriteLine(answer);
        }
    }
}
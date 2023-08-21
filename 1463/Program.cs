using System.Text;

namespace _1463
{
    internal class Program
    {
        private static int MakeOne(int number)
        {
            var dpArray = new int[number + 1];
            Array.Fill(dpArray, int.MaxValue);
            dpArray[1] = 0;

            for (int i = 1; i < number; i++)
            {
                dpArray[i + 1] = Math.Min(dpArray[i + 1], dpArray[i] + 1);
                if (i * 2 <= number)
                {
                    dpArray[i * 2] = Math.Min(dpArray[i * 2], dpArray[i] + 1);
                }
                if (i * 3 <= number)
                {
                    dpArray[i * 3] = Math.Min(dpArray[i * 3], dpArray[i] + 1);
                }
            }

            return dpArray[number];
        }

        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());

            int numbeer = int.Parse(sr.ReadLine()!);

            int answer = MakeOne(numbeer);

            Console.WriteLine(answer);
        }
    }
}
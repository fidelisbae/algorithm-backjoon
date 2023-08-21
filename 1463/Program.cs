using System.Text;

namespace _1463
{
    internal class Program
    {
        private static int MakeOne(int number)
        {
            // index 범위를 벗어나는것을 방지하기 위해 넉넉하게 number * 3 + 1 인덱스까지 배열을 초기화
            // 불필요하게 메모리가 낭비되고 시간을 소요함
            // 개선필요
            var dpArray = new int[number * 3 + 1];
            Array.Fill(dpArray, int.MaxValue);
            dpArray[1] = 0;

            for (int i = 1; i <= number; i++)
            {
                dpArray[i + 1] = Math.Min(dpArray[i + 1], dpArray[i] + 1);
                dpArray[i * 2] = Math.Min(dpArray[i * 2], dpArray[i] + 1);
                dpArray[i * 3] = Math.Min(dpArray[i * 3], dpArray[i] + 1);
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
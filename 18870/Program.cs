using System.Text;

namespace _18870
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sb = new StringBuilder();
            int N = int.Parse(Console.ReadLine()!);
            string[] input = Console.ReadLine()!.Split(" ");
            var dic = new Dictionary<int, int>();
            var array = new int[N];
            var sortedArray = new int[N];
            var compression = new int[N];

            for (int i = 0; i < N; i++)
            {
                array[i] = int.Parse(input[i]);
                sortedArray[i] = int.Parse(input[i]);
            }

            Array.Sort(sortedArray);
            var set = new HashSet<int>(sortedArray);
            var distinctArray = set.ToArray();

            for (int i = 0; i < distinctArray.Length; i++)
            {
                dic[distinctArray[i]] = i;
            }

            for (int i = 0; i < N; i++)
            {
                compression[i] = dic[array[i]];
            }

            for (int i = 0; i < N; i++)
            {
                if (i == N - 1)
                {
                    sb.Append($"{compression[i]}");
                }
                else
                {
                    sb.Append($"{compression[i]} ");
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
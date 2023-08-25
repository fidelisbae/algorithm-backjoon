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
            var origin = new int[N];
            var set = new HashSet<int>();
            var dic = new Dictionary<int, int>();
            var compression = new int[N];

            for (int i = 0; i < N; i++)
            {
                origin[i] = int.Parse(input[i]);
                set.Add(origin[i]);
            }

            var list = new List<int>(set);
            list.Sort();

            for (int i = 0; i < list.Count; i++)
            {
                dic[list[i]] = i;
            }

            for (int i = 0; i < N; i++)
            {
                if (i == N - 1)
                {
                    sb.AppendLine($"{dic[origin[i]]}");
                }
                else
                {
                    sb.Append($"{dic[origin[i]]} ");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
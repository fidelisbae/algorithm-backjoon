using System.Text;

namespace _1931
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            int N = int.Parse(sr.ReadLine()!);

            var meetings = new (int start, int end)[N];

            for (int i = 0; i < N; i++)
            {
                string[] input = sr.ReadLine()!.Split(" ");

                meetings[i] = (start: int.Parse(input[0]), end: int.Parse(input[1]));
            }

            Array.Sort(meetings, (x, y) =>
            {
                int result = (x.end).CompareTo(y.end);
                if (result == 0)
                {
                    return (x.start).CompareTo(y.start);
                }
                else
                {
                    return result;
                }
            });

            var list = new List<(int start, int end)> { meetings[0] };

            for (int i = 1; i < N; i++)
            {
                if (list[list.Count - 1].end <= meetings[i].start)
                {
                    list.Add(meetings[i]);
                }
            }

            Console.WriteLine(list.Count);
        }
    }
}
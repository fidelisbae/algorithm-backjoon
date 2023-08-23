namespace _11399
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine()!);
            string[] input = Console.ReadLine()!.Split(" ");
            var times = new (int index, int time)[N];

            for (int i = 0; i < N; i++)
            {
                times[i] = (i + 1, int.Parse(input[i]));
            }

            Array.Sort(times, (x, y) => x.time.CompareTo(y.time));

            int answer = 0;

            for (int i = 0; i < times.Length; i++)
            {
                answer = answer + times[i].time * (times.Length - i);
            }

            Console.WriteLine(answer);
        }
    }
}
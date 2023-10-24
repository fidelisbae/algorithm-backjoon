namespace _2473
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            long N = long.Parse(Console.ReadLine()!);
            long[] numbers = new long[N];
            string[] input = Console.ReadLine()!.Split(' ');

            for (long i = 0; i < N; i++)
            {
                numbers[i] = long.Parse(input[i]);
            }

            Array.Sort(numbers);

            long min = long.MaxValue;
            long temp;
            long negative = 0;
            long positive = 0;
            long first = 0;

            for (long i = 0; i < N; i++)
            {
                long low = i + 1;
                long high = N - 1;

                while (low < high)
                {
                    temp = Math.Abs(numbers[i] + numbers[low] + numbers[high]);

                    if (temp < min)
                    {
                        min = temp;
                        negative = numbers[low];
                        positive = numbers[high];
                        first = numbers[i];
                    }

                    if (numbers[i] + numbers[low] + numbers[high] < 0)
                    {
                        low++;
                    }
                    else
                    {
                        high--;
                    }
                }
            }
            Console.WriteLine($"{first} {negative} {positive}");
        }
    }
}
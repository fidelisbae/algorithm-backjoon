namespace _2467
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine()!);
            int[] numbers = new int[N];
            string[] input = Console.ReadLine()!.Split(' ');

            for (int i = 0; i < N; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }

            Array.Sort(numbers);

            int low = 0;
            int high = N - 1;
            int min = int.MaxValue;
            int temp;
            int negative = 0;
            int positive = 0;

            while (low < high)
            {
                temp = Math.Abs(numbers[low] + numbers[high]);

                if (temp < min)
                {
                    min = temp;
                    negative = numbers[low];
                    positive = numbers[high];
                }

                if (numbers[low] + numbers[high] < 0)
                {
                    low++;
                }
                else
                {
                    high--;
                }
            }

            Console.WriteLine($"{negative} {positive}");
        }
    }
}
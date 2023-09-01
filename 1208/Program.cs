namespace _1208
{
    internal class Program
    {
        private static long count = 0;
        private static long N;
        private static long S;
        private static long[] numbers;
        private static List<long> list1;
        private static List<long> list2;

        private static void GetInput()
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            string[] firstInput = sr.ReadLine()!.Split(" ");
            string[] secondInput = sr.ReadLine()!.Split(" ");
            N = long.Parse(firstInput[0]);
            S = long.Parse(firstInput[1]);
            numbers = new long[N];
            list1 = new List<long>();
            list2 = new List<long>();

            for (long i = 0; i < N; i++)
            {
                numbers[i] = long.Parse(secondInput[i]);
            }
        }

        private static long Recursion1(long index, long sum)
        {
            if (index == N / 2)
            {
                list1.Add(sum);
                return 0;
            }

            Recursion1(index + 1, sum + numbers[index]);
            Recursion1(index + 1, sum);

            return 0;
        }

        private static long Recursion2(long index, long sum)
        {
            if (index == N)
            {
                list2.Add(sum);
                return 0;
            }

            Recursion2(index + 1, sum + numbers[index]);
            Recursion2(index + 1, sum);

            return 0;
        }

        private static long FindLow(long target)
        {
            long left = 0;
            long right = list2.Count - 1;

            while (left <= right)
            {
                long mid = (left + right) / 2;

                if (list2[(int)mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }

        private static long FindHigh(long target)
        {
            long left = 0;
            long right = list2.Count - 1;

            while (left <= right)
            {
                long mid = (left + right) / 2;

                if (list2[(int)mid] <= target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }

        private static void Main(string[] args)
        {
            GetInput();
            Recursion1(0, 0);
            Recursion2(N / 2, 0);
            list2.Sort();

            for (int i = 0; i < list1.Count; i++)
            {
                long target = S - list1[i];
                long left = FindLow(target);
                long right = FindHigh(target);

                count = count + (right - left);
            }

            if (S == 0)
            {
                count--;
            }

            Console.WriteLine(count);
        }
    }
}
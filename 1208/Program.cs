namespace _1208
{
    internal class Program
    {
        private static int count = 0;
        private static int N;
        private static int S;
        private static int[] numbers;
        private static int[] halfArray_1;
        private static int[] halfArray_2;
        private static List<int> list1;
        private static List<int> list2;

        private static int Recursion1(int index, int sum)
        {
            if (index == halfArray_1.Length)
            {
                return 0;
            }

            list1.Add(sum);
            Recursion1(index + 1, sum + numbers[index]);
            Recursion1(index + 1, sum);

            return 0;
        }

        private static int Recursion2(int index, int sum)
        {
            if (index == halfArray_2.Length)
            {
                return 0;
            }

            list2.Add(sum);
            Recursion2(index + 1, sum + numbers[index]);
            Recursion2(index + 1, sum);

            return 0;
        }

        private static void GetInput()
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            string[] firstInput = sr.ReadLine()!.Split(" ");
            string[] secondInput = sr.ReadLine()!.Split(" ");
            N = int.Parse(firstInput[0]);
            S = int.Parse(firstInput[1]);
            numbers = new int[N];
            int mid = N / 2;
            halfArray_1 = new int[mid];
            halfArray_2 = new int[numbers.Length - mid];
            Array.Copy(numbers, 0, halfArray_1, 0, mid);
            Array.Copy(numbers, mid, halfArray_2, 0, numbers.Length - mid);
            list1 = new List<int>();
            list2 = new List<int>();

            for (int i = 0; i < N; i++)
            {
                numbers[i] = int.Parse(secondInput[i]);
            }
        }

        private static void Main(string[] args)
        {
            GetInput();
            Recursion1(0, halfArray_1[0]);
            Recursion2(0, halfArray_2[0]);

            foreach (var sum1 in list1)
            {
                foreach (var sum2 in list2)
                {
                    if (sum1 + sum2 == S)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
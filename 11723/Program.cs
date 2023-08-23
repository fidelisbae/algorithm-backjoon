using System.Diagnostics.Tracing;

namespace _11723
{
    public class BitSet
    {
        private long set;

        public BitSet()
        {
            set = 0;
        }

        public void Add(long x)
        {
            long mask = x - 1;
            mask = 1L << mask;
            set |= 1L << x - 1L;
        }

        public void Remove(long x)
        {
            long mask = 1L << x - 1L;
            mask = ~mask;
            set &= mask;
        }

        public void Check(long x)
        {
            long mask = 1 << x - 1;
            long check = set | mask;

            if (set == check)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        public void Toggle(long x)
        {
            long mask = 1 << x - 1;
            set ^= mask;
        }

        public void All()
        {
            set = 0;
            set = ~set;
        }

        public void Empty()
        {
            set = 0;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            long M = long.Parse(Console.ReadLine()!);

            var set = new BitSet();

            for (int i = 0; i < M; i++)
            {
                string[] input = Console.ReadLine()!.Split(" ");
                string word = input[0];
                long value = 0;

                if (input.Length > 1)
                {
                    value = long.Parse(input[1]);
                }

                switch (word)
                {
                    case "add":
                        set.Add(value);
                        break;

                    case "remove":
                        set.Remove(value);
                        break;

                    case "check":
                        set.Check(value);
                        break;

                    case "toggle":
                        set.Toggle(value);
                        break;

                    case "all":
                        set.All();
                        break;

                    case "empty":
                        set.Empty();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
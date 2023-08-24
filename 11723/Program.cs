using System.Diagnostics.Tracing;
using System.Text;

namespace _11723
{
    public class BitSet
    {
        private int set;
        public StringBuilder sb;

        public BitSet()
        {
            set = 0;
            sb = new StringBuilder();
        }

        public void Add(int x)
        {
            int mask = 1 << x - 1;
            set |= mask;
        }

        public void Remove(int x)
        {
            int mask = 1 << x - 1;
            mask = ~mask;
            set &= mask;
        }

        public void Check(int x)
        {
            int mask = 1 << x - 1;

            if ((set & mask) == mask)
            {
                sb.AppendLine("1");
            }
            else
            {
                sb.AppendLine("0");
            }
        }

        public void Toggle(int x)
        {
            int mask = 1 << x - 1;
            set ^= mask;
        }

        public void All()
        {
            set = 0b11111111111111111111;
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
            var sr = new StreamReader(Console.OpenStandardInput());
            int M = int.Parse(sr.ReadLine()!);
            var set = new BitSet();

            for (int i = 0; i < M; i++)
            {
                string[] input = sr.ReadLine()!.Split(" ");
                string word = input[0];
                int value = 0;

                if (input.Length > 1)
                {
                    value = int.Parse(input[1]);
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
            Console.WriteLine(set.sb.ToString());
        }
    }
}
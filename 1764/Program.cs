using System.Text;
using System.Xml.Linq;

namespace _1764
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            string[] firstInput = sr.ReadLine()!.Split(" ");
            int N = int.Parse(firstInput[0]);
            int M = int.Parse(firstInput[1]);

            var N_dictionary = new Dictionary<string, bool>();

            var list = new List<string>();

            for (int i = 0; i < N; i++)
            {
                string name = sr.ReadLine()!;

                N_dictionary[name] = true;
            }

            for (int i = 0; i < M; i++)
            {
                string name = sr.ReadLine()!;

                if (N_dictionary.ContainsKey(name))
                {
                    list.Add(name);
                }
            }

            list.Sort();

            sb.AppendLine(list.Count.ToString());

            foreach (var item in list)
            {
                sb.AppendLine(item);
            }

            Console.WriteLine(sb);
        }
    }
}
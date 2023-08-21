using System.Text;

namespace _1620
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            string[] firstInput = sr.ReadLine()!.Split(' ');
            int pokemons = int.Parse(firstInput[0]);
            int questions = int.Parse(firstInput[1]);

            var numberNameDic = new Dictionary<int, string>();
            var nameNumberDic = new Dictionary<string, int>();

            for (int i = 1; i <= pokemons; i++)
            {
                string pokemonName = sr.ReadLine()!;
                numberNameDic[i] = pokemonName;
                nameNumberDic[pokemonName] = i;
            }

            for (int i = 0; i < questions; i++)
            {
                string answer;
                string input = sr.ReadLine()!;
                if (input[0] <= 57)
                {
                    answer = numberNameDic[int.Parse(input)];
                }
                else
                {
                    answer = nameNumberDic[input].ToString();
                }

                sb.AppendLine(answer);
            }
            Console.WriteLine(sb);
        }
    }
}
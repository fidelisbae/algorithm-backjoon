using System.Text;

namespace _2606
{
    public class Graph
    {
        private readonly int vertices;
        private readonly List<int>[] adjacency;

        public Graph(int vertices)
        {
            this.vertices = vertices;
            adjacency = new List<int>[vertices + 1];

            for (int i = 1; i <= vertices; i++)
            {
                adjacency[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            if (!adjacency[v].Contains(w))
            {
                adjacency[v].Add(w);
                adjacency[w].Add(v);
            }
        }

        public int DFS()
        {
            int count = 0;
            var visited = new bool[vertices + 1];
            var stack = new Stack<int>();
            stack.Push(1);
            visited[1] = true;

            while (stack.Count > 0)
            {
                int current = stack.Pop();

                foreach (int w in adjacency[current])
                {
                    if (visited[w] == false)
                    {
                        stack.Push(w);
                        visited[w] = true;
                        count++;
                    }
                }
            }

            return count;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());

            int vertices = int.Parse(sr.ReadLine()!);
            int edges = int.Parse(sr.ReadLine()!);

            var graph = new Graph(vertices);

            for (int i = 0; i < edges; i++)
            {
                string[] input = sr.ReadLine()!.Split(" ");
                int v = int.Parse(input[0]);
                int w = int.Parse(input[1]);

                graph.AddEdge(v, w);
            }

            int answer = graph.DFS();

            Console.WriteLine(answer);
        }
    }
}
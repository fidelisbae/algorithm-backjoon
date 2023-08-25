using System.Text;

namespace _1005
{
    public class Graph
    {
        private readonly int vertices;
        private readonly List<int>[] adjacencyList;
        private readonly int[] times;
        private readonly int[] totalTimes;

        public Graph(int n, int[] times)
        {
            vertices = n;
            adjacencyList = new List<int>[vertices + 1];
            this.times = times;
            totalTimes = new int[vertices + 1];

            for (int i = 1; i <= vertices; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            adjacencyList[v].Add(w);
        }

        public void TopologicalSort()
        {
            var indegree = new int[vertices + 1];
            var queue = new Queue<int>();

            for (int i = 1; i <= vertices; i++)
            {
                foreach (int w in adjacencyList[i])
                {
                    indegree[w]++;
                }
            }

            for (int i = 1; i <= vertices; i++)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                    totalTimes[i] = times[i];
                }
            }

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                for (int i = 0; i < adjacencyList[current].Count; i++)
                {
                    int next = adjacencyList[current][i];

                    indegree[next]--;
                    if (indegree[next] == 0)
                    {
                        queue.Enqueue(next);
                    }

                    totalTimes[next] = Math.Max(totalTimes[next], totalTimes[current] + times[next]);
                }
            }
        }

        public int[] GetTotalTimes()
        {
            return totalTimes;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            int T = int.Parse(sr.ReadLine()!);

            for (int i = 0; i < T; i++)
            {
                string[] firstInput = sr.ReadLine()!.Split(" ");
                int N = int.Parse(firstInput[0]);
                int K = int.Parse(firstInput[1]);
                string[] secondInput = sr.ReadLine()!.Split(" ");
                var times = new int[N + 1];

                for (int j = 1; j <= N; j++)
                {
                    times[j] = int.Parse(secondInput[j - 1]);
                }

                var graph = new Graph(N, times);

                for (int j = 0; j < K; j++)
                {
                    string[] input = sr.ReadLine()!.Split(" ");
                    int v = int.Parse(input[0]);
                    int k = int.Parse(input[1]);

                    graph.AddEdge(v, k);
                }

                graph.TopologicalSort();
                int target = int.Parse(sr.ReadLine()!);
                var totalTimes = graph.GetTotalTimes();

                sb.AppendLine(totalTimes[target].ToString());
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
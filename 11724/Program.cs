namespace _11724
{
    public class Graph
    {
        private readonly int vertices;
        private readonly List<int>[] adjacencyList;
        private readonly bool[] visited;
        private int count;

        public Graph(int size)
        {
            count = 0;
            vertices = size;
            adjacencyList = new List<int>[vertices + 1];
            visited = new bool[vertices + 1];
            for (int i = 1; i <= vertices; i++)
            {
                adjacencyList[i] = new List<int> { };
            }
        }

        public int GetCount()
        { return count; }

        public void AddEdge(int v, int w)
        {
            if (!adjacencyList[v].Contains(w))
            {
                adjacencyList[v].Add(w);
                adjacencyList[w].Add(v);
            }
        }

        private void BFS(int v)
        {
            var queue = new Queue<int>();

            if (!visited[v])
            {
                queue.Enqueue(v);
                visited[v] = true;
                count++;
            }

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                for (int i = 0; i < adjacencyList[current].Count; i++)
                {
                    int next = adjacencyList[current][i];

                    if (!visited[next])
                    {
                        queue.Enqueue(next);
                        visited[next] = true;
                    }
                }
            }
        }

        public void BFSLoop()
        {
            for (int i = 1; i <= vertices; i++)
            {
                BFS(i);
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            string[] firstInput = sr.ReadLine()!.Split(" ");
            int vertices = int.Parse(firstInput[0]);
            int edges = int.Parse(firstInput[1]);
            var graph = new Graph(vertices);

            for (int i = 0; i < edges; i++)
            {
                string[] input = sr.ReadLine()!.Split(" ");
                int v = int.Parse(input[0]);
                int w = int.Parse(input[1]);
                graph.AddEdge(v, w);
            }

            graph.BFSLoop();
            Console.WriteLine(graph.GetCount());
        }
    }
}
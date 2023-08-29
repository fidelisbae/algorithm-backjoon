namespace _1197
{
    public class Graph
    {
        private readonly int vertices;
        private readonly List<(int w, int weight)>[] adjacencyList;
        private readonly PriorityQueue<(int w, int weight), int> queue;
        private readonly List<int> mst;

        public Graph(int vertices)
        {
            this.vertices = vertices;
            adjacencyList = new List<(int w, int weight)>[vertices + 1];
            queue = new PriorityQueue<(int w, int weight), int>();
            mst = new List<int>();

            for (int i = 1; i <= vertices; i++)
            {
                adjacencyList[i] = new List<(int w, int weight)>();
            }
        }

        public void AddEdge(int v, int w, int weight)
        {
            adjacencyList[v].Add((w, weight));
            adjacencyList[w].Add((v, weight));
        }

        public int MakeMST()
        {
            int totalWeight = 0;
            mst.Add(1);

            foreach (var item in adjacencyList[1])
            {
                queue.Enqueue((item.w, item.weight), item.weight);
            }

            while (mst.Count < vertices)
            {
                var current = queue.Dequeue();

                if (!mst.Contains(current.w))
                {
                    mst.Add(current.w);
                    totalWeight += current.weight;

                    foreach (var item in adjacencyList[current.w])
                    {
                        if (!mst.Contains(item.w))
                        {
                            queue.Enqueue((item.w, item.weight), item.weight);
                        }
                    }
                }
            }

            return totalWeight;
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
                int weight = int.Parse(input[2]);
                graph.AddEdge(v, w, weight);
            }

            int totalWeight = graph.MakeMST();

            Console.WriteLine(totalWeight);
        }
    }
}
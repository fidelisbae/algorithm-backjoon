using System.Text;

namespace _1927
{
    internal class Program
    {
        private static void AddToHeap(List<int> heap, int input)
        {
            heap.Add(input);
            int currentIndex = heap.Count - 1;

            while (currentIndex > 1)
            {
                if (heap[currentIndex] < heap[currentIndex / 2])
                {
                    (heap[currentIndex], heap[currentIndex / 2]) = (heap[currentIndex / 2], heap[currentIndex]);
                    currentIndex /= 2;
                }
                else
                {
                    break;
                }
            }
        }

        private static int PopFromHeap(List<int> heap)
        {
            int pop = heap[1];
            (heap[1], heap[heap.Count - 1]) = (heap[heap.Count - 1], heap[1]);
            heap.RemoveAt(heap.Count - 1);
            int currentIndex = 1;

            while (currentIndex * 2 < heap.Count)
            {
                int smallerChild = currentIndex * 2;

                if (smallerChild + 1 < heap.Count && heap[smallerChild] > heap[smallerChild + 1])
                {
                    smallerChild++;
                }

                if (heap[currentIndex] > heap[smallerChild])
                {
                    (heap[currentIndex], heap[smallerChild]) = (heap[smallerChild], heap[currentIndex]);
                    currentIndex = smallerChild;
                }
                else
                {
                    break;
                }
            }

            return pop;
        }

        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            int N = int.Parse(sr.ReadLine()!);
            var heap = new List<int> { 0 };

            for (int i = 0; i < N; i++)
            {
                int input = int.Parse(sr.ReadLine()!);

                if (input == 0)
                {
                    if (heap.Count <= 1)
                    {
                        sb.AppendLine("0");
                        continue;
                    }

                    int output = PopFromHeap(heap);
                    sb.AppendLine(output.ToString());
                }
                else
                {
                    AddToHeap(heap, input);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
using System.Text;

namespace _1655
{
    internal class Program
    {
        private static void MaxHeapAdd(List<int> maxHeap, int input)
        {
            maxHeap.Add(input);
            int currentIndex = maxHeap.Count - 1;

            while (currentIndex > 1 && maxHeap[currentIndex] > maxHeap[currentIndex / 2])
            {
                (maxHeap[currentIndex], maxHeap[currentIndex / 2]) = (maxHeap[currentIndex / 2], maxHeap[currentIndex]);
                currentIndex /= 2;
            }
        }

        private static void MinHeapAdd(List<int> minHeap, int input)
        {
            minHeap.Add(input);
            int currentIndex = minHeap.Count - 1;

            while (currentIndex > 1 && minHeap[currentIndex] < minHeap[currentIndex / 2])
            {
                (minHeap[currentIndex], minHeap[currentIndex / 2]) = (minHeap[currentIndex / 2], minHeap[currentIndex]);
                currentIndex /= 2;
            }
        }

        private static void MaxHeapRemove(List<int> maxHeap)
        {
            (maxHeap[1], maxHeap[maxHeap.Count - 1]) = (maxHeap[maxHeap.Count - 1], maxHeap[1]);
            maxHeap.RemoveAt(maxHeap.Count - 1);

            int currentIndex = 1;

            while (currentIndex * 2 < maxHeap.Count)
            {
                int biggerChildIndex = currentIndex * 2;

                // 오른쪽 자식도 있고, 오른쪽 자식의 값이 더 큰 경우
                if (currentIndex * 2 + 1 < maxHeap.Count && maxHeap[currentIndex * 2 + 1] > maxHeap[biggerChildIndex])
                {
                    biggerChildIndex = currentIndex * 2 + 1;
                }

                if (maxHeap[currentIndex] >= maxHeap[biggerChildIndex]) break;

                (maxHeap[currentIndex], maxHeap[biggerChildIndex]) = (maxHeap[biggerChildIndex], maxHeap[currentIndex]);
                currentIndex = biggerChildIndex;
            }
        }

        private static void MinHeapRemove(List<int> minHeap)
        {
            (minHeap[1], minHeap[minHeap.Count - 1]) = (minHeap[minHeap.Count - 1], minHeap[1]);
            minHeap.RemoveAt(minHeap.Count - 1);

            int currentIndex = 1;

            while (currentIndex * 2 < minHeap.Count)
            {
                int smallerChildIndex = currentIndex * 2;

                // 오른쪽 자식도 있고, 오른쪽 자식의 값이 더 작은 경우
                if (currentIndex * 2 + 1 < minHeap.Count && minHeap[currentIndex * 2 + 1] < minHeap[smallerChildIndex])
                {
                    smallerChildIndex = currentIndex * 2 + 1;
                }

                if (minHeap[currentIndex] <= minHeap[smallerChildIndex]) break;

                (minHeap[currentIndex], minHeap[smallerChildIndex]) = (minHeap[smallerChildIndex], minHeap[currentIndex]);
                currentIndex = smallerChildIndex;
            }
        }

        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            int N = int.Parse(sr.ReadLine()!);

            int middle = int.MaxValue;

            var maxHeap = new List<int> { int.MaxValue };
            var minHeap = new List<int> { int.MinValue };

            for (int i = 0; i < N; i++)
            {
                int input = int.Parse(sr.ReadLine()!);

                // 1. input > middle ? minHeap Add : maxHeap Add
                // 2. heap 에 input 들어오면 sort

                if (input > middle)
                {
                    MinHeapAdd(minHeap, input);
                }
                else
                {
                    MaxHeapAdd(maxHeap, input);
                }

                // 3. 두 heap 의 길이 비교
                // 4. 길이가 2 이상 차이나면 balancing

                if (maxHeap.Count - minHeap.Count > 1)
                {
                    int temp = maxHeap[1];
                    MaxHeapRemove(maxHeap);
                    MinHeapAdd(minHeap, temp);
                }

                while (minHeap.Count > maxHeap.Count)
                {
                    int temp = minHeap[1];
                    MinHeapRemove(minHeap);
                    MaxHeapAdd(maxHeap, temp);
                }

                // 5. maxHeap 의 최대값 (1번 인덱스) 가 중앙값

                middle = maxHeap[1];

                sb.AppendLine(middle.ToString());
            }
            Console.Write(sb.ToString());
        }
    }
}
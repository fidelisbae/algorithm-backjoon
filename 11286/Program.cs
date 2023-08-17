using System.Reflection;
using System.Text;

namespace _11286
{
    internal class Program
    {
        private static void AddPosMinHeap(List<int> posMinHeap, int input)
        {
            posMinHeap.Add(input);
            int currentIndex = posMinHeap.Count - 1;

            while (currentIndex > 1)
            {
                if (posMinHeap[currentIndex] < posMinHeap[currentIndex / 2])
                {
                    (posMinHeap[currentIndex], posMinHeap[currentIndex / 2]) = (posMinHeap[currentIndex / 2], posMinHeap[currentIndex]);
                }
                currentIndex /= 2;
            }
        }

        private static void AddNegMaxHeap(List<int> negMaxHeap, int input)
        {
            negMaxHeap.Add(input);
            int currentIndex = negMaxHeap.Count - 1;

            while (currentIndex > 1)
            {
                if (negMaxHeap[currentIndex] > negMaxHeap[currentIndex / 2])
                {
                    (negMaxHeap[currentIndex], negMaxHeap[currentIndex / 2]) = (negMaxHeap[currentIndex / 2], negMaxHeap[currentIndex]);
                }
                currentIndex /= 2;
            }
        }

        private static void RemovePosMinHeap(List<int> posMinHeap)
        {
            if (posMinHeap.Count <= 1) return;

            posMinHeap[1] = posMinHeap[posMinHeap.Count - 1];
            posMinHeap.RemoveAt(posMinHeap.Count - 1);

            int currentIndex = 1;

            while (currentIndex * 2 < posMinHeap.Count)
            {
                int smallerChildIndex = currentIndex * 2;

                if (smallerChildIndex + 1 < posMinHeap.Count && posMinHeap[smallerChildIndex + 1] < posMinHeap[smallerChildIndex])
                {
                    smallerChildIndex++;
                }

                if (posMinHeap[currentIndex] <= posMinHeap[smallerChildIndex])
                {
                    break;
                }

                (posMinHeap[currentIndex], posMinHeap[smallerChildIndex]) = (posMinHeap[smallerChildIndex], posMinHeap[currentIndex]);
                currentIndex = smallerChildIndex;
            }
        }

        private static void RemoveNegMaxHeap(List<int> negMaxHeap)
        {
            if (negMaxHeap.Count <= 1) return;

            negMaxHeap[1] = negMaxHeap[negMaxHeap.Count - 1];
            negMaxHeap.RemoveAt(negMaxHeap.Count - 1);

            int currentIndex = 1;

            while (currentIndex * 2 < negMaxHeap.Count)
            {
                int largerChildIndex = currentIndex * 2;

                if (largerChildIndex + 1 < negMaxHeap.Count && negMaxHeap[largerChildIndex + 1] > negMaxHeap[largerChildIndex])
                {
                    largerChildIndex++;
                }

                if (negMaxHeap[currentIndex] >= negMaxHeap[largerChildIndex])
                {
                    break;
                }

                (negMaxHeap[currentIndex], negMaxHeap[largerChildIndex]) = (negMaxHeap[largerChildIndex], negMaxHeap[currentIndex]);
                currentIndex = largerChildIndex;
            }
        }

        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sb = new StringBuilder();

            int N = int.Parse(sr.ReadLine()!);

            var posMinHeap = new List<int> { 0 };
            var negMaxHeap = new List<int> { 0 };

            for (int i = 0; i < N; i++)
            {
                int input = int.Parse(sr.ReadLine()!);
                if (input > 0)
                {
                    AddPosMinHeap(posMinHeap, input);
                }
                else if (input < 0)
                {
                    AddNegMaxHeap(negMaxHeap, input);
                }
                else
                {
                    if (posMinHeap.Count <= 1 && negMaxHeap.Count <= 1)
                    {
                        sb.AppendLine("0");
                    }
                    else if (posMinHeap.Count <= 1 || (negMaxHeap.Count > 1 && Math.Abs(negMaxHeap[1]) <= posMinHeap[1]))
                    {
                        sb.AppendLine(negMaxHeap[1].ToString());
                        RemoveNegMaxHeap(negMaxHeap);
                    }
                    else
                    {
                        sb.AppendLine(posMinHeap[1].ToString());
                        RemovePosMinHeap(posMinHeap);
                    }
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1966
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int testCase = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < testCase; i++)
            {
                string firstInput = Console.ReadLine()!;
                string secondInput = Console.ReadLine()!;

                int numbers = int.Parse(firstInput.Split(" ")[0]);
                int target = int.Parse(firstInput.Split(' ')[1]);

                var list = new LinkedList<int[]>();
                int count = 0;

                for (int j = 0; j < numbers; j++)
                {
                    if (j == target)
                    {
                        list.AddLast(new int[] { int.Parse(secondInput.Split(" ")[j]), 1 });
                    }
                    else
                    {
                        list.AddLast(new int[] { int.Parse(secondInput.Split(" ")[j]), 0 });
                    }
                }

                while (list.Count > 0)
                {
                    var temp = list.First;
                    bool isTarget = false;
                    bool back = false;

                    if (temp.Value[1] == 1)
                    {
                        isTarget = true;
                    }

                    var current = temp.Next;

                    while (current != null)
                    {
                        if (temp.Value[0] < current.Value[0])
                        {
                            back = true;
                            break;
                        }
                        current = current.Next;
                    }

                    if (back)
                    {
                        list.RemoveFirst();
                        list.AddLast(temp);
                    }
                    else
                    {
                        if (isTarget)
                        {
                            Console.WriteLine(count + 1);
                            list.RemoveFirst();
                            break;
                        }
                        else
                        {
                            list.RemoveFirst();
                            count++;
                        }
                    }
                }
            }
        }
    }
}
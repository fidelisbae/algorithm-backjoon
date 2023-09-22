using System;
using System.Numerics;

namespace _2166
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            int N = int.Parse(sr.ReadLine()!);
            var points = new (long x, long y)[N];

            for (int i = 0; i < N; i++)
            {
                string[] input = sr.ReadLine()!.Split(" ");
                points[i] = (long.Parse(input[0]), long.Parse(input[1]));
            }

            double width = 0;

            for (int i = 0; i < N - 1; i++)
            {
                width += points[i].x * points[i + 1].y - points[i].y * points[i + 1].x;
            }
            width += points[N - 1].x * points[0].y - points[N - 1].y * points[0].x;

            double result = Math.Abs(width) / 2;
            result = Math.Round(result, 1);

            Console.Write("{0:F1}", result);
        }
    }
}
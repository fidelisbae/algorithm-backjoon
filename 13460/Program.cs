namespace _13460
{
    public class Ball
    {
        private readonly char[,] map;
        public readonly (int r, int c) red;
        public readonly (int r, int c) blue;
        public readonly (int r, int c) hole;

        public Ball(char[,] map)
        {
            this.map = map;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 'R')
                    {
                        red = (i, j);
                    }
                    if (map[i, j] == 'B')
                    {
                        blue = (i, j);
                    }
                    if (map[i, j] == 'O')
                    {
                        hole = (i, j);
                    }
                }
            }
        }

        public struct State
        {
            public (int r, int c) Red { get; set; }
            public (int r, int c) Blue { get; set; }
            public int Moves { get; set; }
        }

        public ((int r, int c), (int r, int c)) Up((int r, int c) red, (int r, int c) blue)
        {
            bool isRedFront = red.r < blue.r;
            (int r, int c) = isRedFront ? red : blue;

            while (r >= 1)
            {
                r--;

                if (map[r, c] == 'O')
                {
                    return isRedFront ? ((0, 0), (0, 0)) : ((-1, -1), (-1, -1));
                }

                if (map[r, c] == '#')
                {
                    return isRedFront ? ((r + 1, c), (r + 2, c)) : ((r + 2, c), (r + 1, c));
                }
            }

            return ((-1, -1), (-1, -1));
        }

        public ((int r, int c), (int r, int c)) Down((int r, int c) red, (int r, int c) blue)
        {
            bool isRedFront = red.r > blue.r;
            (int r, int c) = isRedFront ? red : blue;

            while (r <= map.GetLength(0) - 2)
            {
                r++;

                if (map[r, c] == 'O')
                {
                    return isRedFront ? ((0, 0), (0, 0)) : ((-1, -1), (-1, -1));
                }

                if (map[r, c] == '#')
                {
                    return isRedFront ? ((r - 1, c), (r - 2, c)) : ((r - 2, c), (r - 1, c));
                }
            }

            return ((-1, -1), (-1, -1));
        }

        public ((int r, int c), (int r, int c)) Left((int r, int c) red, (int r, int c) blue)
        {
            bool isRedFront = red.c < blue.c;
            (int r, int c) = isRedFront ? red : blue;

            while (c >= 1)
            {
                c--;

                if (map[r, c] == 'O')
                {
                    return isRedFront ? ((0, 0), (0, 0)) : ((-1, -1), (-1, -1));
                }

                if (map[r, c] == '#')
                {
                    return isRedFront ? ((r, c + 1), (r, c + 2)) : ((r, c + 2), (r, c + 1));
                }
            }

            return ((-1, -1), (-1, -1));
        }

        public ((int r, int c), (int r, int c)) Right((int r, int c) red, (int r, int c) blue)
        {
            bool isRedFront = red.c > blue.c;
            (int r, int c) = isRedFront ? red : blue;

            while (c <= map.GetLength(1) - 2)
            {
                c++;

                if (map[r, c] == 'O')
                {
                    return isRedFront ? ((0, 0), (0, 0)) : ((-1, -1), (-1, -1));
                }

                if (map[r, c] == '#')
                {
                    return isRedFront ? ((r, c - 1), (r, c - 2)) : ((r, c - 2), (r, c - 1));
                }
            }

            return ((-1, -1), (-1, -1));
        }

        public int BFS()
        {
            int count = int.MaxValue;
            var queue = new Queue<State>();
            queue.Enqueue(new State
            {
                Red = red,
                Blue = blue,
                Moves = 0
            });

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Red == (-1, -1))
                {
                    continue;
                }

                if (current.Red == (0, 0) && current.Moves < count)
                {
                    count = current.Moves;
                }

                if (current.Moves < 10)
                {
                    queue.Enqueue(new State
                    {
                        Red = Up(current.Red, current.Blue).Item1,
                        Blue = Up(current.Red, current.Blue).Item2,
                        Moves = current.Moves + 1
                    });
                    queue.Enqueue(new State
                    {
                        Red = Down(current.Red, current.Blue).Item1,
                        Blue = Down(current.Red, current.Blue).Item2,
                        Moves = current.Moves + 1
                    });
                    queue.Enqueue(new State
                    {
                        Red = Left(current.Red, current.Blue).Item1,
                        Blue = Left(current.Red, current.Blue).Item2,
                        Moves = current.Moves + 1
                    });
                    queue.Enqueue(new State
                    {
                        Red = Right(current.Red, current.Blue).Item1,
                        Blue = Right(current.Red, current.Blue).Item2,
                        Moves = current.Moves + 1
                    });
                }
            }

            return count;
        }
    }

    internal class Program
    {
        private static char[,] GetInput()
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            string[] firstInput = sr.ReadLine()!.Split(" ");
            int row = int.Parse(firstInput[0]);
            int column = int.Parse(firstInput[1]);
            var map = new char[row, column];

            for (int i = 0; i < row; i++)
            {
                string input = sr.ReadLine()!;

                for (int j = 0; j < column; j++)
                {
                    map[i, j] = input[j];
                }
            }

            return map;
        }

        private static void Main(string[] args)
        {
            var map = GetInput();
            var ball = new Ball(map);
            Console.WriteLine(ball.BFS());
        }
    }
}
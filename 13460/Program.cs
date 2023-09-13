namespace _13460
{
    public class Ball
    {
        private readonly char[,] map;
        private readonly (int r, int c) red;
        private readonly (int r, int c) blue;

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
                }
            }
        }

        private struct State
        {
            public (int r, int c) Red { get; set; }
            public (int r, int c) Blue { get; set; }
            public int Moves { get; set; }

            // 1: 성공 0: 일반 -1: 실패
            public int Out { get; set; }
        }

        private State Up(State current)
        {
            var red = current.Red;
            var blue = current.Blue;
            var nextRed = red;
            var nextBlue = blue;

            while (nextRed.r >= 1)
            {
                if (map[nextRed.r - 1, nextRed.c] == '#')
                {
                    current.Red = nextRed;
                    break;
                }
                if (map[nextRed.r - 1, nextRed.c] == 'O')
                {
                    current.Out = 1;
                    current.Red = (nextRed.r - 1, nextRed.c);
                    break;
                }
                nextRed.r--;
            }

            while (nextBlue.r >= 1)
            {
                if (map[nextBlue.r - 1, nextBlue.c] == '#')
                {
                    current.Blue = nextBlue;
                    break;
                }
                if (map[nextBlue.r - 1, nextBlue.c] == 'O')
                {
                    current.Out = -1;
                    current.Blue = (nextBlue.r - 1, nextBlue.c);
                    break;
                }
                nextBlue.r--;
            }

            if (current.Red == current.Blue && current.Out != -1)
            {
                if (red.r > blue.r)
                    current.Red = (current.Red.r + 1, current.Red.c);
                else
                    current.Blue = (current.Blue.r + 1, current.Blue.c);
            }

            current.Moves++;
            return current;
        }

        private State Down(State current)
        {
            var red = current.Red;
            var blue = current.Blue;
            var nextRed = red;
            var nextBlue = blue;

            while (nextRed.r < map.GetLength(0) - 1)
            {
                if (map[nextRed.r + 1, nextRed.c] == '#')
                {
                    current.Red = nextRed;
                    break;
                }
                if (map[nextRed.r + 1, nextRed.c] == 'O')
                {
                    current.Out = 1;
                    current.Red = (nextRed.r + 1, nextRed.c);
                    break;
                }
                nextRed.r++;
            }

            while (nextBlue.r < map.GetLength(0) - 1)
            {
                if (map[nextBlue.r + 1, nextBlue.c] == '#')
                {
                    current.Blue = nextBlue;
                    break;
                }
                if (map[nextBlue.r + 1, nextBlue.c] == 'O')
                {
                    current.Out = -1;
                    current.Blue = (nextBlue.r + 1, nextBlue.c);
                    break;
                }
                nextBlue.r++;
            }

            if (current.Red == current.Blue && current.Out != -1)
            {
                if (red.r < blue.r)
                    current.Red = (current.Red.r - 1, current.Red.c);
                else
                    current.Blue = (current.Blue.r - 1, current.Blue.c);
            }

            current.Moves++;
            return current;
        }

        private State Left(State current)
        {
            var red = current.Red;
            var blue = current.Blue;
            var nextRed = red;
            var nextBlue = blue;

            while (nextRed.c >= 1)
            {
                if (map[nextRed.r, nextRed.c - 1] == '#')
                {
                    current.Red = nextRed;
                    break;
                }
                if (map[nextRed.r, nextRed.c - 1] == 'O')
                {
                    current.Out = 1;
                    current.Red = (nextRed.r, nextRed.c - 1);
                    break;
                }
                nextRed.c--;
            }

            while (nextBlue.c >= 1)
            {
                if (map[nextBlue.r, nextBlue.c - 1] == '#')
                {
                    current.Blue = nextBlue;
                    break;
                }
                if (map[nextBlue.r, nextBlue.c - 1] == 'O')
                {
                    current.Out = -1;
                    current.Blue = (nextBlue.r, nextBlue.c - 1);
                    break;
                }
                nextBlue.c--;
            }

            if (current.Red == current.Blue && current.Out != -1)
            {
                if (red.c > blue.c)
                    current.Red = (current.Red.r, current.Red.c + 1);
                else
                    current.Blue = (current.Blue.r, current.Blue.c + 1);
            }

            current.Moves++;
            return current;
        }

        private State Right(State current)
        {
            var red = current.Red;
            var blue = current.Blue;
            var nextRed = red;
            var nextBlue = blue;

            while (nextRed.c < map.GetLength(1) - 1)
            {
                if (map[nextRed.r, nextRed.c + 1] == '#')
                {
                    current.Red = nextRed;
                    break;
                }
                if (map[nextRed.r, nextRed.c + 1] == 'O')
                {
                    current.Out = 1;
                    current.Red = (nextRed.r, nextRed.c + 1);
                    break;
                }
                nextRed.c++;
            }

            while (nextBlue.c < map.GetLength(1) - 1)
            {
                if (map[nextBlue.r, nextBlue.c + 1] == '#')
                {
                    current.Blue = nextBlue;
                    break;
                }
                if (map[nextBlue.r, nextBlue.c + 1] == 'O')
                {
                    current.Out = -1;
                    current.Blue = (nextBlue.r, nextBlue.c + 1);
                    break;
                }
                nextBlue.c++;
            }

            if (current.Red == current.Blue && current.Out != -1)
            {
                if (red.c < blue.c)
                    current.Red = (current.Red.r, current.Red.c - 1);
                else
                    current.Blue = (current.Blue.r, current.Blue.c - 1);
            }

            current.Moves++;
            return current;
        }

        public int BFS()
        {
            var queue = new Queue<State>();
            var visited = new HashSet<((int r, int c), (int r, int c))>();
            var current = new State
            {
                Red = red,
                Blue = blue,
                Moves = 0,
                Out = 0
            };
            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();

                if (visited.Contains((current.Red, current.Blue)))
                {
                    continue;
                }
                else
                {
                    visited.Add((current.Red, current.Blue));
                }

                if (current.Moves > 10)
                {
                    continue;
                }
                if (current.Out == 1)
                {
                    return current.Moves;
                }
                if (current.Out == -1)
                {
                    continue;
                }

                queue.Enqueue(Up(current));
                queue.Enqueue(Down(current));
                queue.Enqueue(Left(current));
                queue.Enqueue(Right(current));
            }

            return -1;
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
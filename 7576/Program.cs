namespace _7576
{
    internal class Program
    {
        private static int row;
        private static int column;
        private static int[,] map;

        private static void GetInput()
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            string[] firstInput = sr.ReadLine()!.Split(" ");
            row = int.Parse(firstInput[1]);
            column = int.Parse(firstInput[0]);
            map = new int[row, column];

            for (int i = 0; i < row; i++)
            {
                string[] input = sr.ReadLine()!.Split(" ");

                for (int j = 0; j < column; j++)
                {
                    map[i, j] = int.Parse(input[j]);
                }
            }
        }

        private static void Main(string[] args)
        {
            GetInput();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                }
            }
        }

        // 1. map 전체를 순회하면서 익은 토마토를 발견하면 큐를 만들어서 저장하고 큐를 리스트에 저장
        // 2. 순회가 끝나면 리스트에서 큐를 꺼내면서 큐에서 요소를 꺼내서 bfs 진행
        // 3. count++
        // 4. bfs 가 종료될때까지 진행하고 count return
    }
}
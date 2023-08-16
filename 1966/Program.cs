using System.Threading.Channels;

namespace _9655
{
    internal class Program
    {
        private static int GetInput()
        {
            int input = int.Parse(Console.ReadLine()!);

            return input;
        }

        private static void Main(string[] args)
        {
            int stones = GetInput();

            // dp 배열 돌갯수 + 1
            var dp = new bool[stones + 1];
            // false 로 초기화
            // false : 선공이 지는 경우
            // true : 선공이 이기는 경우
            Array.Fill(dp, false);

            // 돌 갯수 적을때 예외처리
            if (stones >= 1)
            {
                dp[1] = true;
            }

            // 돌 갯수 적을때 예외처리
            if (stones >= 3)
            {
                dp[3] = true;
            }

            // 메인 로직
            // 0 index 부터 시작해서 돌 갯수를 +1, +3 햇을때 현재 index 의 value 가 false 면 true 로 바꿔줌, true 면 false 로 바꿔줌
            for (int i = 0; i <= stones - 3; i++)
            {
                if (dp[i])
                {
                    dp[i + 1] = false;
                    dp[i + 3] = false;
                }
                else
                {
                    dp[i + 1] = true;
                    dp[i + 3] = true;
                }
            }

            string answer = dp[stones] ? "SK" : "CY";
            Console.WriteLine(answer);
        }
    }
}
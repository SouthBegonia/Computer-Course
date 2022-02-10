namespace CsharpExam
{
    // https://leetcode-cn.com/problems/qing-wa-tiao-tai-jie-wen-ti-lcof/
    // 10 跳台阶问题
    public class Offer_20220210_10
    {
        public int NumWays(int n)
        {
            if (n == 0)
                return 1;

            int[] arr = new int[n+1];
            arr[0] = 1;
            arr[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                arr[i] = (arr[i - 1] + arr[i - 2]) % 1000000007;
                if (i == n)
                    break;
            }

            return arr[n];
        }
    }
}
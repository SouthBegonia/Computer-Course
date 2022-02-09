namespace CsharpExam
{
    // https://leetcode-cn.com/problems/fei-bo-na-qi-shu-lie-lcof/
    // 10-1 斐波那契数列
    public class Offer_20220209_10
    {
        public int Fib(int n)
        {
            if (n <= 1)
                return n;

            int a = 0;
            int b = 1;
            int sum = 0;

            for (int i = 2; i <= n; i++)
            {
                sum = (a + b) % 1000000007;
                a = b;
                b = sum;
            }

            return sum;
        }
    }
}
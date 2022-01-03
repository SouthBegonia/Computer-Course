using System.Collections.Generic;

namespace CsharpExam
{
    public class _20220103_爬楼梯
    {
        public int ClimbStairs(int n)
        {
            if (n <= 1)
                return 1;

            int[] result = new int[n + 1];
            result[1] = 1;
            result[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                result[i] = result[i - 1] + result[i - 2];
            }

            return result[n];
        }
    }
}
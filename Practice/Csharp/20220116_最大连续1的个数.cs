using System;

namespace CsharpExam
{
    //https://leetcode-cn.com/leetbook/read/array-and-string/cd71t/
    public class _20220116_最大连续1的个数
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int len = nums.Length;
            int ans = 0;
            int zeroIndex = -1;

            for (int i = 0; i < len; i++)
            {
                if (nums[i] == 0)
                {
                    zeroIndex = i;

                }
                else
                {
                    //[1,1,0,1,1,1]
                    ans = Math.Max(ans, i - zeroIndex);
                }
            }

            return ans;
        }
    }
}
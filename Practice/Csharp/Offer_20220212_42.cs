using System;

namespace CsharpExam
{
    // https://leetcode-cn.com/problems/lian-xu-zi-shu-zu-de-zui-da-he-lcof/
    // 42 连续子数组的最大和
    public class Offer_20220212_42
    {
        public int MaxSubArray(int[] nums)
        {
            int curSum = nums[0];
            int maxSum = curSum;

            for (int i = 1; i < nums.Length; i++)
            {
                if (curSum <= 0)
                    curSum = nums[i];
                else
                    curSum += nums[i];

                maxSum = Math.Max(maxSum, curSum);
            }

            return maxSum;
        }
    }
}
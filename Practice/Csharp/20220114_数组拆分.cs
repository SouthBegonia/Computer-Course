using System;

namespace CsharpExam
{
    //https://leetcode-cn.com/leetbook/read/array-and-string/c24he/
    public class _20220114_数组拆分
    {
        public int ArrayPairSum(int[] nums)
        {
            //排列
            Array.Sort(nums, (a, b) => b.CompareTo(a));

            int result = 0;
            for (int i = 1; i <= nums.Length-1; i=i+2)
                result += nums[i];

            return result;
        }
    }
}
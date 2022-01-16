using System;

namespace CsharpExam
{
    //https://leetcode-cn.com/leetbook/read/array-and-string/c0w4r/
    public class _20220116_长度最小的子数组
    {
        // static void Main()
        // {
        //     _20220116_长度最小的子数组 test = new _20220116_长度最小的子数组();
        //
        //     int[] arr = {2, 3, 1, 2, 4, 3};
        //     int target = 7;
        //     Console.WriteLine(test.MinSubArrayLen(target,arr));
        // }

        public int MinSubArrayLen(int target, int[] nums)
        {
            //滑动窗口
            int minLen = nums.Length + 1;
            int left = 0;
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                while (sum >= target)
                {
                    minLen = Math.Min(minLen, i - left + 1);
                    sum -= nums[left];
                    left++;
                }
            }

            return minLen <= nums.Length ? minLen : 0;
        }
    }
}
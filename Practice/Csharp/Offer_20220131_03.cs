using System.Collections.Generic;

namespace CsharpExam
{
    //https://leetcode-cn.com/problems/shu-zu-zhong-zhong-fu-de-shu-zi-lcof/
    // 03 数组中重复的数字
    public class Offer_20220131_03
    {
        public int FindRepeatNumber(int[] nums)
        {
            HashSet<int> table = new HashSet<int>();
            ;
            foreach (int num in nums)
            {
                if (table.Contains(num))
                    return num;
                else
                    table.Add(num);
            }

            return -1;
        }
    }
}
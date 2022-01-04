using System.Collections.Generic;

namespace CsharpExam
{
    public class _20220102_两数之和
    {
        //字典
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                    return new int[] {dic[target - nums[i]], i};

                if (!dic.ContainsKey(nums[i]))
                    dic.Add(nums[i], i);
            }

            return new[] {-1, -1};
        }

        //暴力遍历
        // public int[] TwoSum(int[] nums, int target)
        // {
        //     for(int i=0;i<nums.Length;i++)
        //     {
        //         for(int j=i+1;j<nums.Length;j++)
        //         {
        //             if(nums[i] + nums[j] == target)
        //                 return new [] {i,j};
        //         }
        //     }

        //     return new [] {-1,-1};
        // }
    }
}
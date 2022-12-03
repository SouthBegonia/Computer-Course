using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 二分查找  https://www.nowcoder.com/practice/d3df40bd23594118b57554129cadf47b?tpId=295&tqId=1499549&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221203_search
    {
        public int search(List<int> nums, int target)
        {
            int len = nums.Count;
            if (len == 0)
                return -1;

            int centerIndex = 0;
            int leftIndex = 0;
            int rightIndex = len - 1;

            while (leftIndex <= rightIndex)
            {
                centerIndex = (rightIndex + leftIndex) / 2;
                if (nums[centerIndex] == target)
                    return centerIndex;
                else if (nums[centerIndex] > target)
                    rightIndex = centerIndex - 1;
                else
                    leftIndex = centerIndex + 1;
            }

            return -1;
        }
    }
}
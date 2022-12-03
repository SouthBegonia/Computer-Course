using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 寻找峰值  https://www.nowcoder.com/practice/fcf87540c4f347bcb4cf720b5b350c76?tpId=295&tqId=2227748&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221203_findPeakElement
    {
        public int findPeakElement (List<int> nums)
        {
            int left = 0;
            int right = nums.Count - 1;

            while(left < right)
            {
                int mid = (left+right)/2;
                if (nums[mid] > nums[mid+1])
                    right = mid;
                else
                    left = mid + 1;
            }

            return right;
        }
    }
}
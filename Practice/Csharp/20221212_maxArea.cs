using System;
using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 盛水最多的容器  https://www.nowcoder.com/practice/3d8d6a8e516e4633a2244d2934e5aa47?tpId=295&tqId=2284579&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221212_maxArea
    {
        public int maxArea(List<int> height)
        {
            if (height == null || height.Count <= 1)
                return 0;

            int ret = 0;
            int left = 0;
            int right = height.Count - 1;

            //贪心
            while (left < right)
            {
                int capacity = Math.Min(height[left], height[right]) * (right - left);
                ret = Math.Max(ret, capacity);

                //优先舍弃短边
                if (height[left] < height[right])
                    ++left;
                else
                    --right;
            }

            return ret;
        }
    }
}
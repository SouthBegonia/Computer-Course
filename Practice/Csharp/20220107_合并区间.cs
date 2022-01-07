using System;
using System.Collections.Generic;

namespace CsharpExam
{
    //https://leetcode-cn.com/leetbook/read/array-and-string/c5tv3/
    public class _20220107_合并区间
    {
        public int[][] Merge(int[][] intervals)
        {
            //第0列升序排列
            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            List<int[]> list = new List<int[]>();
            int[] term = intervals[0];

            for (int i = 1; i < intervals.Length; i++)
            {
                if (term[1] >= intervals[i][0])
                {
                    //左边的右值 大于等于 右边的左值
                    //即 当前区间与其左侧区间有交集，则左区间阔范围至包含这两个区间
                    term[1] = Math.Max(term[1], intervals[i][1]);
                }
                else
                {
                    //两区间无交集，左区间入表
                    list.Add(term);
                    term = intervals[i];
                }
            }
            list.Add(term);

            return list.ToArray();
        }
    }
}
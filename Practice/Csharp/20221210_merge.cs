using System;
using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 合并区间  https://www.nowcoder.com/practice/69f4e5b7ad284a478777cb2a17fb5e6a?tpId=295&tqId=691&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221210_merge
    {
        public List<Interval> merge(List<Interval> intervals)
        {
            if (intervals == null || intervals.Count == 0)
                return intervals;

            //排序+贪心

            List<Interval> ret = new List<Interval>();

            //start升序重排
            intervals.Sort((Interval a, Interval b) => a.start.CompareTo(b.start));
            ret.Add(intervals[0]);
            for (int i = 1; i < intervals.Count; i++)
            {
                if (intervals[i].start <= ret[ret.Count - 1].end)
                {
                    //有区间重叠，则更新结果区间
                    ret[ret.Count - 1].end = Math.Max(ret[ret.Count - 1].end, intervals[i].end);
                }
                else
                {
                    //没有区间重叠，则直接插入
                    ret.Add(intervals[i]);
                }
            }

            return ret;
        }

        public class Interval
        {
            public int start;
            public int end;

            public Interval()
            {
                start = 0;
                end = 0;
            }

            public Interval(int s, int e)
            {
                start = s;
                end = e;
            }
        }
    }
}
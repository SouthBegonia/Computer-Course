using System;
using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 最小花费爬楼梯  https://www.nowcoder.com/practice/6fe0302a058a4e4a834ee44af88435c7?tpId=295&tqId=2366451&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221128_minCostClimbingStairs
    {
        public int minCostClimbingStairs(List<int> cost)
        {
            int count = cost.Count;
            List<int> dp = new List<int>(count + 1);
            for (int i = 0; i <= count; i++)
                dp.Add(0);

            for (int i = 2; i <= count; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
            }

            //注意是跨过 下标=count-1的台阶，即抵达下标为count的台阶
            return dp[count];
        }
    }
}
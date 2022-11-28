using System;
using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 最长上升子序列  https://www.nowcoder.com/practice/5164f38b67f846fb8699e9352695cd2f?tpId=295&tqId=2281434&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221128_LIS
    {
        public int LIS(List<int> arr)
        {
            int count = arr.Count;
            if (count <= 1)
                return count;

            List<int> dp = new List<int>(count);
            for (int i = 0; i < count; i++)
                dp.Add(1);

            int res = 0;
            for (int i = 1; i < count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j] && dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;
                        res = Math.Max(res, dp[i]);
                        //Console.WriteLine($"dp[{i}]={dp[i]}  res={res}");
                    }
                }
            }

            return res;
        }
    }
}
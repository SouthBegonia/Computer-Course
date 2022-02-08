using System;
using System.Collections.Generic;

namespace CsharpExam
{
    // https://leetcode-cn.com/problems/zui-xiao-de-kge-shu-lcof/
    // 40 最小的K个数
    public class Offer_20220208_40
    {
        public int[] GetLeastNumbers(int[] arr, int k)
        {
            Array.Sort(arr, (a, b) => { return a.CompareTo(b); });

            List<int> list = new List<int>(arr.Length);
            for (int i = 0; i < k; i++)
                list.Add(arr[i]);

            return list.ToArray();
        }
    }
}
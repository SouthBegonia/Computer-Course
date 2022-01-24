using System;
using System.Collections.Generic;

namespace CsharpExam
{
    //https://leetcode-cn.com/problems/smallest-k-lcci/
    public class _20220124_SmallestK
    {
        //方法1：快排全排序
        public int[] SmallestK(int[] arr, int k)
        {
            List<int> list = new List<int>(k);

            //升序排列
            Array.Sort(arr, (a, b) => a.CompareTo(b));

            for (int i = 0; i < k; i++)
                list.Add(arr[i]);

            return list.ToArray();
        }

        // //方法2：冒泡局部排序 O(N*k)超时
        // public int[] SmallestK(int[] arr, int k)
        // {
        //     List<int> list = new List<int>(k);

        //     for (int i = 0; i < k; i++)
        //     {
        //         for (int j = arr.Length - 1; j > 0; j--)
        //         {
        //             if (arr[j] < arr[j - 1])
        //             {
        //                 int temp = arr[j - 1];
        //                 arr[j - 1] = arr[j];
        //                 arr[j] = temp;
        //             }
        //         }

        //         list.Add(arr[i]);
        //     }

        //     return list.ToArray();
        // }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;

//题目：给定无序数组arr，求在arr有序后，相邻两数的最大差值。
//    不可采用基数排序，要求时间复杂度O(N)
//思路：类似桶排，但是桶数目为元素个数+1，而非最大元素值的个数；
//     单个桶的信息包含 桶内是否非空标记、桶内最大元素值、桶内最小元素值；
//     全部元素入桶后，进行 前一非空桶内最小值与后一非空桶内内最大值之差 的运算，一趟遍历后的最值即为所求。
//问题：
//   1. 为什么最大差值不可能存在于同一个桶内，而是两个非空桶？
//        一个桶内部的最大差值 <= 一个桶的范围，而两个非空桶的min-max >= 一个桶的范围；
//      因此不用关心桶内部，而是两个非空桶
           
namespace GapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //原始数组
            int[] arr = new int[] { 1, 24, 20, 56, 78, 54, 90, 102, 120, 12 };
            int[] arr2 = new int[] { 9, 10, 10, 56, 89, 100, 120, 33, 68, 99 };
            foreach (int i in arr)
                Console.Write(i + " ");
            Console.WriteLine();

            //排序后的数组(仅提参照，不参与解题核心)
            List<int> arrList = new List<int>(arr);
            arrList.Sort();
            foreach (int i in arrList)
                Console.Write(i + " ");
            Console.WriteLine();

            Console.WriteLine("有序数组内相邻两数最大差值为 :" + maxGap(arr));
            Console.ReadKey();
        }

        public static int maxGap(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return 0;

            int len = nums.Length;
            int min = nums[0];
            int max = nums[0];

            //取得数组内的最值
            for (int i = 0; i < len; i++)
            {
                min = Math.Min(min, nums[i]);
                max = Math.Max(max, nums[i]);
            }
            if (min == max)
                return 0;

            //创建标记：某桶内是否装入了元素；某桶内的最值
            bool[] hasNum = new bool[len + 1];
            int[] maxs = new int[len + 1];
            int[] mins = new int[len + 1];
            int bid = 0;

            for (int i = 0; i < len; i++)
            {
                //数组元素逐一入桶
                bid = bucket(nums[i], len, min, max);
                //获取对应桶内的最值信息
                mins[bid] = hasNum[bid] ? Math.Min(mins[bid], nums[i]) : nums[i];
                maxs[bid] = hasNum[bid] ? Math.Max(maxs[bid], nums[i]) : nums[i];
                hasNum[bid] = true;
            }

            int res = 0;
            int lastMax = maxs[0];
            for (int k = 1; k < len; k++)
            {
                //遍历所有桶，更新 当前非空桶内的最小值-前一个非空桶内的最大值
                if (hasNum[k])
                {
                    res = Math.Max(res, mins[k] - lastMax);
                    lastMax = maxs[k];
                }
            }
            return res;
        }

        //元素入桶，返回元素所在桶的标记
        public static int bucket(long num, long len, long min, long max)
        {
            return (int)((num - min) * len / (max - min));
        }
    }
}
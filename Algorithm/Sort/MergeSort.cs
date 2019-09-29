using System;
using System.Collections;
using System.Collections.Generic;

namespace Sorting
{
    class MergeSort
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 9,8,7,6,5,4,3,2,1 };
            MergeSortFunction(arr, 0, arr.Length - 1);

            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }

        //归并排序（目标数组，子表的起始位置，子表的终止位置）
        private static void MergeSortFunction(int[] array, int first, int last)
        {
            if (first < last)   //子表的长度大于1，则进入下面的递归处理
            {
                int mid = (first + last) / 2;
                MergeSortFunction(array, first, mid);       //对左子表进行递归划分
                MergeSortFunction(array, mid + 1, last);    //对右子表进行递归划分
                MergeSortCore(array, first, mid, last);     //对左右子表进行有序的整合
            }
        }

        //归并排序的核心部分：将两个有序的左右子表（以mid区分），合并成一个有序的表
        private static void MergeSortCore(int[] array, int first, int mid, int last)
        {

            int indexA = first;             //左侧子表的起始位置
            int indexB = mid + 1;           //右侧子表的起始位置

            int[] temp = new int[last + 1]; //临时数组：暂存左右子表的所有有序数列
            int tempIndex = 0;

            while (indexA <= mid && indexB <= last) //进行左右子表的遍历，如果其中有一个子表遍历完，则跳出循环
            {
                if (array[indexA] <= array[indexB])
                {
                    temp[tempIndex++] = array[indexA++];
                }
                else//此时左子表的数 > 右子表的数
                {
                    temp[tempIndex++] = array[indexB++];
                }
            }

            //有一侧子表遍历完后，跳出循环，将另外一侧子表剩下的数一次放入暂存数组中
            while (indexA <= mid)
            {
                temp[tempIndex++] = array[indexA++];
            }
            while (indexB <= last)
            {
                temp[tempIndex++] = array[indexB++];
            }

            //将暂存数组中有序的数列写入目标数组的制定位置
            tempIndex = 0;
            for (int i = first; i <= last; i++)
            {
                array[i] = temp[tempIndex++];
            }
        }
    }
}
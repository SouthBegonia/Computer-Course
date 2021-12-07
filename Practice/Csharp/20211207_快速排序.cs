using System;

namespace CsharpExam
{
    public class _20211207_快速排序
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        static void Main(string[] args)
        {
            int[] arr = {9, 7, 6, 5, 4, 3, 2, -1, -3, -5};

            int[] arr2 = QuickSort(arr, 0, arr.Length - 1);
            foreach (int i in arr2)
                Console.Write(i + " ");
            Console.WriteLine();

            int[] arr3 = QuickSort2(arr, 0, arr.Length - 1);
            foreach (int i in arr3)
                Console.Write(i + " ");
            Console.WriteLine();

            Console.ReadKey();
        }

        #region 快速排序1

        static int[] QuickSort(int[] arr, int left, int right)
        {
            int len = arr.Length;
            int partitionIndex;

            if (left < right)
            {
                partitionIndex = Partition(arr, left, right);
                QuickSort(arr, left, partitionIndex - 1);
                QuickSort(arr, partitionIndex + 1, right);
            }

            return arr;
        }

        /// <summary>
        /// 将该数组以left基准值分区（大于left的在右，小于left的在左边）
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        static int Partition(int[] arr, int left, int right)
        {
            int privot = left;    // 基准值
            int index = privot + 1;

            for (int i = index; i <= right; i++)
            {
                if (arr[i] < arr[privot])
                {
                    Swap(ref arr[i], ref arr[index]);
                    index++;
                }
            }

            Swap(ref arr[privot], ref arr[index - 1]);
            return index - 1;
        }
        #endregion

        #region 快速排序2
        static int[] QuickSort2(int[] arr, int left, int right)
        {
            int partition;

            if (left < right)
            {
                partition = Partition2(arr, left, right);
                QuickSort2(arr, left, partition - 1);
                QuickSort2(arr, partition + 1, right);
            }

            return arr;
        }

        static int Partition2(int[] arr, int left, int right)
        {
            int center = left;
            int curIndex = left + 1;

            for (int i = curIndex; i <= right; i++)
            {
                if (arr[curIndex] < arr[center])
                {
                    if (curIndex != i)
                    {
                        arr[i] ^= arr[curIndex];
                        arr[curIndex] ^= arr[i];
                        arr[i] ^= arr[curIndex];
                    }

                    curIndex++;
                }
            }

            if (arr[center] != arr[curIndex - 1])
            {
                arr[center] ^= arr[curIndex - 1];
                arr[curIndex - 1] ^= arr[center];
                arr[center] ^= arr[curIndex - 1];
            }

            return curIndex - 1;
        }
        #endregion
    }
}
using System;
using System.Text;

namespace CsharpExam
{
    public class _20220113_排序练习
    {
        // static void Main()
        // {
        //     int[] tempArr = {8, 5, 3, 2, 1, 0, 8, 9, 5, 3};
        //     int[] testArr = new int[tempArr.Length];
        //
        //     tempArr.CopyTo(testArr, 0);
        //     SelectionSort(tempArr);
        //     PrintArr(tempArr, "选择排序 : ");
        //
        //     tempArr.CopyTo(testArr, 0);
        //     InsertSort(tempArr);
        //     PrintArr(tempArr, "直插排序 : ");
        //
        //     tempArr.CopyTo(testArr, 0);
        //     BubbleSort(tempArr);
        //     PrintArr(tempArr, "冒泡排序 : ");
        //
        //     tempArr.CopyTo(testArr, 0);
        //     QuickSort(tempArr, 0, testArr.Length - 1);
        //     PrintArr(tempArr, "快速排序 : ");
        // }

        static void Swap(ref int a, ref int b)
        {
            if (a != b)
            {
                a ^= b;
                b ^= a;
                a ^= b;
            }
        }

        static void PrintArr(int[] arr, string tag)
        {
            StringBuilder sb = new StringBuilder(tag);
            foreach (int i in arr)
            {
                sb.Append(i).Append(" ");
            }

            Console.WriteLine(sb);
        }

        #region 选择排序

        static void SelectionSort(int[] arr)
        {
            int minIndex = 0;
            int len = arr.Length;

            for (int i = 0; i < len; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < len; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                Swap(ref arr[minIndex], ref arr[i]);
            }
        }

        #endregion

        #region 直插排序

        static void InsertSort(int[] arr)
        {
            int len = arr.Length;
            for (int i = 1; i < len; i++)
            {
                int preIndex = i - 1;
                int curNum = arr[i];

                while (preIndex >= 0 && arr[preIndex] > curNum)
                {
                    arr[preIndex + 1] = arr[preIndex];
                    preIndex--;
                }

                arr[preIndex + 1] = curNum;
            }
        }

        #endregion

        #region 冒泡排序

        static void BubbleSort(int[] arr)
        {
            int len = arr.Length;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                        Swap(ref arr[j], ref arr[j + 1]);
                }
            }
        }

        #endregion

        #region 快速排序

        static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int partition = Partition(arr, left, right);
                QuickSort(arr, left, partition - 1);
                QuickSort(arr, partition + 1, right);
            }
        }

        static int Partition(int[] arr, int left, int right)
        {
            int privot = left;
            int index = left + 1;

            for (int i = index; i <= right; i++)
            {
                if (arr[i] < arr[privot])
                {
                    Swap(ref arr[index], ref arr[i]);
                    index++;
                }
            }

            Swap(ref arr[privot], ref arr[index - 1]);
            return index - 1;
        }

        #endregion

    }
}
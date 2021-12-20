using System;

namespace CsharpExam
{
    public class _20211220_排序练习
    {
        static void Main()
        {
            int[] arr = {-1, 2, 3, 7, 3, 2, -6, 9, 0, 1};
            int[] testArr = new int[arr.Length];

            arr.CopyTo(testArr, 0);
            SelectionSort(testArr);
            PrintArr(testArr, "选择排序1");

            arr.CopyTo(testArr, 0);
            InsertSort(testArr);
            PrintArr(testArr, "直插排序1");

            arr.CopyTo(testArr, 0);
            BubbleSort(testArr);
            PrintArr(testArr, "冒泡排序1");

            arr.CopyTo(testArr, 0);
            QuickSort(testArr, 0, testArr.Length - 1);
            PrintArr(testArr, "快速排序1");
        }

        static void Swap(int[] arr, int i, int j)
        {
            if (arr[i] != arr[j])
            {
                arr[i] ^= arr[j];
                arr[j] ^= arr[i];
                arr[i] ^= arr[j];
            }
        }

        static void PrintArr(int[] arr, string msg)
        {
            Console.Write(msg + " : ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }

        #region ROund_1

        #region 选择排序

        static void SelectionSort(int[] arr)
        {
            int len = arr.Length;

            int minIndex = 0;

            for (int i = 0; i < len; i++)
            {
                minIndex = i;

                for (int j = minIndex+1; j < len; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                Swap(arr, minIndex, i);
            }
        }


        #endregion

        #region 直插排序

        static void InsertSort(int[] arr)
        {
            int len = arr.Length;

            int preIndex;
            int curNum;

            for (int i = 1; i < len; i++)
            {
                curNum = arr[i];
                preIndex = i - 1;

                while (preIndex >=0 && curNum < arr[preIndex])
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
                for (int j = 0; j < len-1-i; j++)
                {
                    if (arr[j] > arr[j + 1])
                        Swap(arr, j, j + 1);
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
                if (arr[privot] > arr[i])
                {
                    Swap(arr, i, index);
                    index++;
                }
            }

            Swap(arr, index - 1, privot);
            return index - 1;
        }


        #endregion
        #endregion
    }
}
using System;

namespace CsharpExam
{
    public class _20211215_排序练习
    {
        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
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

        static void Main()
        {
            int[] arr = {-1, 2, 3, 7, 3, 2, -6, 9, 0, 1};
            int[] testArr = new int[arr.Length];

            #region Round_1

            arr.CopyTo(testArr, 0);
            SelectionSort1(testArr);
            PrintArr(testArr, "选择排序1");

            arr.CopyTo(testArr, 0);
            InsertSort1(testArr);
            PrintArr(testArr, "直插排序1");

            arr.CopyTo(testArr, 0);
            BubbleSort1(testArr);
            PrintArr(testArr, "冒泡排序1");

            arr.CopyTo(testArr, 0);
            QuickSort1(testArr, 0, testArr.Length - 1);
            PrintArr(testArr, "快速排序1");

            #endregion
        }

        #region Round_1

        #region 选择排序1

        static void SelectionSort1(int[] arr)
        {
            int len = arr.Length;
            int minIndex;

            for (int i = 0; i < len; i++)
            {
                minIndex = i;
                for (int j = minIndex+1; j < len; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                Swap(arr, i, minIndex);
            }
        }

        #endregion

        #region 直插排序1

        static void InsertSort1(int[] arr)
        {
            int len = arr.Length;

            int preIndex, curNum;

            for (int i = 1; i < len; i++)
            {
                preIndex = i - 1;
                curNum = arr[i];

                while (preIndex >= 0 && arr[preIndex] > curNum)
                {
                    arr[preIndex + 1] = arr[preIndex];
                    preIndex--;
                }

                arr[preIndex + 1] = curNum;
            }
        }

        #endregion

        #region 冒泡排序1

        static void BubbleSort1(int[] arr)
        {
            int len = arr.Length;

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 0; j < len-1-i; j++)
                {
                    if (arr[j + 1] < arr[j])
                        Swap(arr, j + 1, j);
                }
            }
        }

        #endregion

        #region 快速排序1

        static void QuickSort1(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int partition = Partition1(arr, left, right);
                QuickSort1(arr, left, partition - 1);
                QuickSort1(arr, partition + 1, right);
            }
        }

        static int Partition1(int[] arr, int left, int right)
        {
            int privot = left;
            int index = left + 1;

            for (int i = index; i <= right; i++)
            {
                if(arr[i] < arr[privot])
                {
                    Swap(arr, index, i);
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
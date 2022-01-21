using System;

namespace CsharpExam
{
    public class _20220121_排序练习
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        static void PrintArr(int[] arr, string desc)
        {
            Console.Write(desc + " : ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] arr = {-1, 2, 3, 7, 3, 2, -6, 9, 0, 1};
            int[] testArr = new int[arr.Length];

            arr.CopyTo(testArr, 0);
            SelectionSort(testArr);
            PrintArr(testArr, "选择排序");

            arr.CopyTo(testArr, 0);
            InsertSort(testArr);
            PrintArr(testArr, "直插排序");

            arr.CopyTo(testArr, 0);
            BubbleSort(testArr);
            PrintArr(testArr, "冒泡排序");

            arr.CopyTo(testArr, 0);
            QuickSort(testArr, 0, testArr.Length - 1);
            PrintArr(testArr, "快速排序");
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
                    if (arr[minIndex] > arr[j])
                        minIndex = j;
                }

                Swap(ref arr[i], ref arr[minIndex]);
            }
        }

        #endregion

        #region 直插排序

        static void InsertSort(int[] arr)
        {
            int len = arr.Length;
            int curNum = 0;
            int preIndex;

            for (int i = 1; i < len; i++)
            {
                curNum = arr[i];
                preIndex = i - 1;

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
                    if (arr[j + 1] < arr[j])
                        Swap(ref arr[j + 1], ref arr[j]);
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
                    Swap(ref arr[index], ref arr[i]);
                    index++;
                }
            }

            Swap(ref arr[index - 1], ref arr[privot]);
            return index - 1;
        }

        #endregion
    }
}
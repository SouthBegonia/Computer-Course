using System;

namespace CsharpExam
{
    public class _20221125_Sort
    {
        /*static void Main()
        {
            int[] originalArr = { 4, 5, 3, 2, 0, 7, 8, 9, 0 };
            int[] copyArr;

            //选择排序
            copyArr = (int[])originalArr.Clone();
            SelectSort(copyArr);
            LogArr(copyArr);

            //直插排序
            copyArr = (int[])originalArr.Clone();
            InsertSort(copyArr);
            LogArr(copyArr);


            //冒泡排序
            copyArr = (int[])originalArr.Clone();
            BubblingSort(copyArr);
            LogArr(copyArr);

            //快速排序
            copyArr = (int[])originalArr.Clone();
            QuickSort(copyArr, 0, copyArr.Length - 1);
            LogArr(copyArr);
        }*/

        static void Swap(int[] arr, int left, int right)
        {
            if (arr[left] == arr[right])
                return;

            arr[left] ^= arr[right];
            arr[right] ^= arr[left];
            arr[left] ^= arr[right];
        }

        static void LogArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");
            Console.WriteLine();
        }

        #region 选择排序

        public static void SelectSort(int[] arr)
        {
            int minIndex;
            for (int i = 0; i < arr.Length; i++)
            {
                minIndex = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }
                Swap(arr, i, minIndex);
            }
        }

        #endregion

        #region 直插排序

        static void InsertSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int curNum = arr[i];
                int preIndex = i - 1;

                while (preIndex >= 0 && arr[preIndex] > curNum)
                {
                    arr[preIndex + 1] = arr[preIndex];
                    --preIndex;
                }

                arr[preIndex + 1] = curNum;
            }
        }

        #endregion

        #region 冒泡排序

        static void BubblingSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length - i; j++)
                {
                    if (arr[j - 1] > arr[j])
                        Swap(arr, j - 1, j);
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
                QuickSort(arr, partition+1, right);
            }
        }

        static int Partition(int[] arr, int left, int right)
        {
            int privot = left;
            int index = left + 1;

            for (int i = index; i <= right; i++)
            {
                if (arr[i] < arr[privot])
                    Swap(arr, i, index++);
            }
            Swap(arr, privot, index - 1);

            return index - 1;
        }

        #endregion
    }
}
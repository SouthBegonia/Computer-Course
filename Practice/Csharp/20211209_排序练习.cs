using System;

namespace CsharpExam
{
    public class _20211209_排序练习
    {
        static void Main(string[] args)
        {
            int[] arr = {1, -2, 3, 10, -4, 7, 2, -5};
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


            #region Round_2

            arr.CopyTo(testArr, 0);
            SelectionSort2(testArr);
            PrintArr(testArr, "选择排序2");

            arr.CopyTo(testArr, 0);
            InsertSort2(testArr);
            PrintArr(testArr, "直插排序2");

            arr.CopyTo(testArr, 0);
            BubbleSort2(testArr);
            PrintArr(testArr, "冒泡排序2");

            arr.CopyTo(testArr, 0);
            QuickSort2(testArr, 0, testArr.Length - 1);
            PrintArr(testArr, "快速排序2");

            #endregion

            Console.ReadKey();
        }

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

        #region Round_1

        #region 选择排序1

        static void SelectionSort1(int[] arr)
        {
            if (arr == null || arr.Length < 1)
                return;

            int minIndex;
            int len = arr.Length;

            for (int i = 0; i < len-1; i++)
            {
                minIndex = i;
                for (int j = i+1; j < len; j++)
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
            if(arr == null || arr.Length<1)
                return;

            int len = arr.Length;
            int preIndex;
            int curNum;

            for (int i = 1; i < len; i++)
            {
                preIndex = i - 1;
                curNum = arr[i];

                while (preIndex>=0 && arr[preIndex] > curNum)
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
            if (arr == null || arr.Length < 1)
                return;

            int len = arr.Length;

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 0; j < len - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                        Swap(arr, j, j + 1);
                }
            }
        }

        #endregion

        #region 快速排序1

        static void QuickSort1(int[] arr, int left, int right)
        {
            if(arr == null || arr.Length<1)
                return;

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
            int index = privot + 1;

            for (int i = index; i <= right; i++)
            {
                if(arr[privot] > arr[i])
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

        #region Round_2

        #region 选择排序2

        static void SelectionSort2(int[] arr)
        {
            if(arr == null || arr.Length<1)
                return;

            int len = arr.Length;
            int minIndex;

            for (int i = 0; i < len; i++)
            {
                minIndex = i;
                for (int j = i+1; j < len; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                if (minIndex != i)
                    Swap(arr, minIndex, i);
            }
        }

        #endregion

        #region 直插排序2

        static void InsertSort2(int[] arr)
        {
            if (arr == null || arr.Length < 1)
                return;

            int len = arr.Length;

            int preIndex;
            int curNum;

            for (int i = 1; i < len; i++)
            {
                preIndex = i - 1;
                curNum = arr[i];

                while (preIndex>=0 && arr[preIndex] > curNum)
                {
                    arr[preIndex + 1] = arr[preIndex];
                    preIndex--;
                }

                arr[preIndex + 1] = curNum;
            }
        }

        #endregion

        #region 冒泡排序2

        static void BubbleSort2(int[] arr)
        {
            if (arr == null || arr.Length < 1)
                return;

            int len = arr.Length;

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 0; j < len - 1 - i; j++)
                {
                    if (arr[j + 1] < arr[j])
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
        }

        #endregion

        #region 快速排序2

        static void QuickSort2(int[] arr, int left, int right)
        {
            if (arr == null || arr.Length < 1)
                return;

            if (left < right)
            {
                int partition = Partition2(arr, left, right);
                QuickSort2(arr, left, partition - 1);
                QuickSort2(arr, partition + 1, right);
            }
        }

        static int Partition2(int[] arr, int left, int right)
        {
            int privot = left;
            int index = left + 1;

            for (int i = index; i <= right; i++)
            {
                if (arr[i] < arr[privot])
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
using System;

namespace CsharpExam
{
    public class _20211208_排序练习
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
            int[] arr = {9, 4, -7, 3, 1, 4, -1, 0, 10, 6, 2};
            int[] testArray = new int[arr.Length];
            arr.CopyTo(testArray, 0);
            int[] resultArr;

            resultArr = SelectionSort(testArray);
            PrintArr(resultArr, "选择排序");
            arr.CopyTo(testArray, 0);

            resultArr = InsertSort(testArray);
            PrintArr(resultArr, "直插排序");
            arr.CopyTo(testArray, 0);

            resultArr = BubbleSort(testArray);
            PrintArr(resultArr, "冒泡排序");
            arr.CopyTo(testArray, 0);

            resultArr = QuickSort(testArray, 0, testArray.Length - 1);
            PrintArr(resultArr, "快速排序");
            arr.CopyTo(testArray, 0);



            SelectionSort2(testArray);
            PrintArr(testArray, "选择排序2");
            arr.CopyTo(testArray, 0);

            InsertSort2(testArray);
            PrintArr(testArray, "直插排序2");
            arr.CopyTo(testArray, 0);

            BubbleSort2(testArray);
            PrintArr(testArray, "冒泡排序2");
            arr.CopyTo(testArray, 0);

            QuickSort2(testArray, 0, testArray.Length - 1);
            PrintArr(testArray, "快速排序2");
            arr.CopyTo(testArray, 0);



            SelectionSort3(testArray);
            PrintArr(testArray, "选择排序3");
            arr.CopyTo(testArray, 0);

            InsertSort3(testArray);
            PrintArr(testArray, "直插排序3");
            arr.CopyTo(testArray, 0);

            BubbleSort3(testArray);
            PrintArr(testArray, "冒泡排序3");
            arr.CopyTo(testArray, 0);

            QuickSort3(testArray, 0, testArray.Length - 1);
            PrintArr(testArray, "快速排序3");
            arr.CopyTo(testArray, 0);
            
            Console.ReadKey();
        }
        
        #region 选择排序

        static int[] SelectionSort(int[] arr)
        {
            if (arr == null || arr.Length < 1)
                return arr;

            int len = arr.Length;
            for (int i = 0; i < len-1; i++)
            {
                int minIndex = i;
                for (int j = i; j < len; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                Swap(ref arr[i], ref arr[minIndex]);
            }

            return arr;
        }


        #endregion

        #region 直插排序

        static int[] InsertSort(int[] arr)
        {
            if (arr == null || arr.Length < 1)
                return arr;

            int len = arr.Length;
            int preIndex;
            for (int i = 1; i < len; i++)
            {
                preIndex = i - 1;
                int curNum = arr[i];

                while (preIndex >= 0 && arr[preIndex] > curNum)
                {
                    arr[preIndex + 1] = arr[preIndex];
                    preIndex--;
                }

                arr[preIndex + 1] = curNum;
            }
            return arr;
        }
        

        #endregion

        #region 冒泡排序

        static int[] BubbleSort(int[] arr)
        {
            if (arr == null || arr.Length < 1)
                return arr;

            int len = arr.Length;
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 0; j < len - 1 - i; j++)
                {
                    if (arr[j + 1] < arr[j])
                        Swap(ref arr[j + 1], ref arr[j]);
                }
            }

            return arr;
        }
        
        #endregion

        #region 快速排序

        static int[] QuickSort(int[] arr, int left, int right)
        {
            if (arr == null || arr.Length < 1)
                return arr;

            if (left < right)
            {
                int partition = Partition(arr, left, right);
                QuickSort(arr, left, partition - 1);
                QuickSort(arr, partition + 1, right);
            }

            return arr;
        }

        static int Partition(int[] arr, int left, int right)
        {
            int privot = left;
            int index = privot + 1;

            for (int i =index; i <= right; i++)
            {
                if (arr[i] < arr[privot])
                {
                    Swap(ref arr[i], ref arr[index]);
                    index++;
                }
            }
            Swap(ref arr[index-1], ref arr[privot]);
            return index - 1;
        }


        #endregion

        #region 直插排序2

        static void InsertSort2(int[] arr)
        {
            int preIndex;
            int curNum;

            int len = arr.Length;
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

        #region 选择排序2

        static void SelectionSort2(int[] arr)
        {
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
                Swap(ref arr[minIndex], ref arr[i]);
            }
        }


        #endregion

        #region 冒泡排序2

        static void BubbleSort2(int[] arr)
        {
            int len = arr.Length;
            for (int i = 0; i < len-1; i++)
            {
                for (int j = 0; j < len-1-i; j++)
                {
                    if (arr[j] > arr[j + 1])
                        Swap(ref arr[j], ref arr[j + 1]);
                }
            }
        }


        #endregion

        #region 快速排序2

        static void QuickSort2(int[] arr, int left, int right)
        {
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
                    Swap(ref arr[i], ref arr[index]);
                    index++;
                }
            }
            Swap(ref arr[privot], ref arr[index-1]);
            return index - 1;
        }


        #endregion

        #region 直插排序3

        static void InsertSort3(int[] arr)
        {
            int len = arr.Length;

            int preIndex;
            int curNum;

            for (int i = 1; i < len; i++)
            {
                preIndex = i - 1;
                curNum = arr[i];

                while (preIndex >=0 && arr[preIndex] > curNum)
                {
                    arr[preIndex + 1] = arr[preIndex];
                    preIndex--;
                }

                arr[preIndex + 1] = curNum;
            }
        }
        #endregion

        #region 选择排序3

        static void SelectionSort3(int[] arr)
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
                Swap(ref arr[i], ref arr[minIndex]);
            }
        }


        #endregion

        #region 冒泡排序3

        static void BubbleSort3(int[] arr)
        {
            int len = arr.Length;

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 0; j < len - 1 - i; j++)
                {
                    if (arr[j + 1] < arr[j])
                        Swap(ref arr[j + 1], ref arr[j]);
                }
            }
        }


        #endregion

        #region 快速排序3

        static void QuickSort3(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int partition = Partition3(arr, left, right);
                QuickSort3(arr, left, partition - 1);
                QuickSort3(arr, partition + 1, right);
            }
        }

        static int Partition3(int[] arr, int left, int right)
        {
            int privot = left;
            int index = left + 1;

            for (int i = index; i <= right; i++)
            {
                if (arr[i] < arr[privot])
                {
                    Swap(ref arr[i], ref arr[index]);
                    index++;
                }
            }

            Swap(ref arr[index - 1], ref arr[privot]);
            return index - 1;
        }


        #endregion
    }
}
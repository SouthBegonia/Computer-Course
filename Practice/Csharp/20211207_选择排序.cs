using System;

namespace CsharpExam
{
    public class _20211207_选择排序
    {
        static void Main(string[] args)
        {
            int[] arr = {1, -2, 3, 10, -4, 7, 2, -5};

            SelectionSort(ref arr);
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }

        #region 选择排序

        static void SelectionSort(ref int[] arr)
        {
            if (arr == null || arr.Length < 1)
                return;

            int minIndex;
            int len = arr.Length;
            for (int i = 0; i < len - 1; i++)
            {
                minIndex = i;
                for (int j = minIndex + 1; j < len; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                if (minIndex != i)
                    Swap(ref arr[minIndex], ref arr[i]);
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }
        #endregion
    }
}
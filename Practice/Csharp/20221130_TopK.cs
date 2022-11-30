using System;

namespace CsharpExam
{
    public class _20221130_TopK
    {
        /*static void Main()
        {
            int[] arr = { 2, 4, 5, 6, 7, 8, 9, 9, 0 };
            int[] ret = TopK(arr, 3);
            foreach (int i in ret)
                Console.Write($"{i}, ");
        }*/

        public static int[] TopK(int[] arr, int k)
        {
            int len = arr.Length;
            if (k > len || k <= 0)
                return null;

            int left = 0;
            int right = len - 1;
            int[] ret = new int[k];

            while (left <= right)
            {
                int partition = Partition(arr, left, right);
                if (partition + 1 == k)
                {
                    Array.Copy(arr, ret, k);
                    break;
                }
                else if (partition + 1 > k)
                    right = partition;
                else
                    left = partition + 1;
            }

            Array.Sort(ret, (a, b) => a.CompareTo(b));
            return ret;
        }

        public static int Partition(int[] arr, int left, int right)
        {
            int privot = left;
            int index = left + 1;

            for (int i = index; i <= right; i++)
            {
                if (arr[i] > arr[privot])
                    Swap(ref arr[i], ref arr[index++]);
            }

            Swap(ref arr[privot], ref arr[index - 1]);
            return index - 1;
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
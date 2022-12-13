using System;

namespace CsharpExam
{
    public class _20221213_TopK
    {
        /*static void Main()
        {
            int[] testArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            foreach (int i in GetTopK(testArr, 3))
                Console.Write($"{i}, ");

            Console.WriteLine();
            testArr = new[] { 9, 0, 7, 6, 5, 4, 3, 2, 1, 8 };
            foreach (int i in GetTopK(testArr, 3))
                Console.Write($"{i}, ");

            Console.WriteLine();
            testArr = new[] { 0, 0, 7, 0, 5, 0, 3, 2, 1, 0 };
            foreach (int i in GetTopK(testArr, 3))
                Console.Write($"{i}, ");

            Console.WriteLine();
            testArr = new[] { 0, 0, 0 };
            foreach (int i in GetTopK(testArr, 3))
                Console.Write($"{i}, ");
        }*/

        public static int[] GetTopK(int[] arr, int k)
        {
            if (arr == null || arr.Length < k)
                return null;

            int[] ret = new int[k];
            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
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

            return ret;
        }

        public static int Partition(int[] arr, int left, int right)
        {
            int privot = left;
            int index = left + 1;

            for (int i = index; i <= right; i++)
            {
                if (arr[privot] < arr[i])
                {
                    Swap(ref arr[i], ref arr[index]);
                    ++index;
                }
            }

            Swap(ref arr[privot], ref arr[index - 1]);
            return index - 1;
        }

        public static void Swap(ref int a, ref int b)
        {
            if (a == b)
                return;

            a ^= b;
            b ^= a;
            a ^= b;
        }
    }
}
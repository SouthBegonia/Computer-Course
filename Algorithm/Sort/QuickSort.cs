using System;
using System.Collections;
using System.Collections.Generic;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 9,8,7,6,5,4,3,2,1,0 };

            QuickSort(arr, 0, 9);
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }

        public static void QuickSort(int[] arr, int L,int R)
        {
            if (L < R)
            {
                //随机选择一个划分值
                Random random = new Random();
                Swap(arr, L + random.Next(R - L), R);

                int[] p = Partition(arr, L, R);
                QuickSort(arr, L, p[0] - 1);
                QuickSort(arr, p[1] + 1, R);
            }
        }

        public static int[] Partition(int[] arr, int L, int R)
        {
            int less = L - 1;
            int more = R;

            while (L < more)
            {
                if (arr[L] < arr[R])
                    Swap(arr, ++less, L++);
                else if (arr[L] > arr[R])
                    Swap(arr, --more, L);
                else
                    L++;
            }
            Swap(arr, more, R);
            return new int[] { less + 1, more };
        }

        public static void Swap(int[] arr, int A,int B)
        {
            int temp = arr[A];
            arr[A] = arr[B];
            arr[B] = temp;
        }
    }
}
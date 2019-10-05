using System;
using System.Collections;
using System.Collections.Generic;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            Program program = new Program();

            program.InsertSort(arr, 0, 9);

            foreach (int i in arr)
                Console.Write(i + " ");

            Console.ReadKey();
        }

        public void InsertSort(int[] arr, int L, int R)
        {
            if (arr == null || arr.Length < 2)
                return;

            int temp;
            int j;
            for (int i = L + 1; i <= R; i++)
            {
                temp = arr[i];
                j = i - 1;

                while (j >= L && (temp < arr[j]))
                {
                    arr[j + 1] = arr[j];
                    --j;

                }
                arr[j + 1] = temp;
            }
        }
    }
}
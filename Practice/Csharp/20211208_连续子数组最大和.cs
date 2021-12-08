using System;
using System.Xml.Schema;

namespace CsharpExam
{
    public class _20211208_连续子数组最大和
    {
        static void Main(string[] args)
        {
            int[] arr = {1, -2, 3, 10, -4, 7, 2, -5};

            Console.Write("ans  = " + MaxAddOfArr(arr));

            Console.ReadKey();
        }

        static int MaxAddOfArr(int[] arr)
        {
            int curAdd = arr[0];
            int maxAdd = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (curAdd < 0)
                    curAdd = arr[i];
                else
                    curAdd += arr[i];

                maxAdd = Math.Max(maxAdd, curAdd);
            }

            return maxAdd;
        }
    }
}
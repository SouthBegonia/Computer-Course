using System;

namespace CsharpExam
{
    class _20211205_MaxAddOfArray
    {
        static void Main(string[] args)
        {
            int[] arr = { 1,-2,3,10,-4,7,2,-5 };

            Console.Write(GetMaxAddOfArray(arr));

            Console.ReadKey();
        }

        #region 连续子数组的最大和
        // https://blog.csdn.net/m0_37925202/article/details/80816684
        static int GetMaxAddOfArray(int[] arr)
        {
            if (arr == null || arr.Length < 1)
                return 0;

            int len = arr.Length;
            int maxAdd = arr[0];
            int curTotal = arr[0];

            for (int i = 1; i < len; i++)
            {
                if (curTotal < 0)
                    curTotal = arr[i];
                else
                    curTotal += arr[i];

                if (curTotal > maxAdd)
                    maxAdd = curTotal;
            }

            return maxAdd;
        }
        #endregion
    }
}
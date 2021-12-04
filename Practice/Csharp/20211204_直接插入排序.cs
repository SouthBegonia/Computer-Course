using System;

namespace CsharpExam
{
    class _20211204_InsertSort
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 9,8,7,6,5,4,3,2,1,0 };

            
            //直接插入排序
            InSertSort(ref arr);
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }

        #region 直接插入排序
        public static void InSertSort(ref int[] arr)
        {
            int len = arr.Length;
            int curNum;
            int preIndex;
            
            for (int i = 1; i < len; i++)
            {
                curNum = arr[i];
                preIndex = i - 1;

                while (preIndex >= 0 && curNum < arr[preIndex])
                {
                    arr[preIndex + 1] = arr[preIndex];
                    --preIndex;
                }
                arr[preIndex + 1] = curNum;
            }
        }
        #endregion
    }
}
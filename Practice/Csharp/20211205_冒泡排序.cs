using System;

namespace CsharpExam
{
    class _20211205_BubbleSort
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 9,8,7,6,5,4,3,2,1,0 };
            
            //直接插入排序
            //InSertSort(ref arr);
            
            BubbleSort(ref arr);
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }

        #region 冒泡排序
        public static void BubbleSort(ref int[] arr)
        {
            int len = arr.Length;

            for (int i = 0; i < len - 1; i++)
            {
                // -i 是因为每趟冒泡都排好了一个最大值，没必要再对末尾已经有序的部分进行比较
                for (int j = 0; j < len - 1 - i; j++)
                {
                    if (arr[j + 1] < arr[j])
                        Swap(ref arr[j + 1], ref arr[j]);
                }
            }
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }
        
        #endregion

        #region 直接插入排序
        public static void InSertSort(ref int[] arr)
        {
            int len = arr.Length;
            int preIndex;
            int curNum;

            for (int i = 1; i < len; i++)
            {
                preIndex = i - 1;
                curNum = arr[i];
                while (preIndex >= 0 && curNum < arr[preIndex])
                {
                    arr[preIndex + 1] = arr[preIndex];
                    preIndex--;
                }

                arr[preIndex + 1] = curNum;
            }
        }
        #endregion
    }
}
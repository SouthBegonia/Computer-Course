using System;

namespace Code013
{
    /// <summary>
    /// 013 调整数组顺序使奇数位于偶数前面
    /// </summary>
    class Algorithm_others_013
    {
        /// <summary>
        /// 013 调整数组顺序使奇数位于偶数前面
        /// Way1: 新建数组进行遍历、前奇后偶填充
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] ReOrderArray1(int[] array)
        {
            int len = array.Length;
            int[] newArray = new int[len];
            int index = 0;

            // 一次遍历，全部奇数在前
            for (int i = 0; i < len; i++)
            {
                if (array[i] % 2 == 1)
                {
                    newArray[index++] = array[i];
                }
            }

            // 二次遍历，全部偶数在后
            for (int i = 0; i < len; i++)
            {
                if (array[i] % 2 == 0)
                {
                    newArray[index++] = array[i];
                }

            }
            return newArray;
        }

        /// <summary>
        /// 013 调整数组顺序使奇数位于偶数前面
        /// Way2: 双指针遍历法
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] ReOrderArray2(int[] array)
        {
            int[] newArray = (int[])array.Clone();
            int len = newArray.Length;

            int oddIndex;       //奇数指针
            int evenIndex = 0;  //偶数指针
            int temp;

            while (evenIndex < len)
            {
                // 找到第一个偶数
                while (evenIndex < len && !IsEven(newArray[evenIndex]))
                    evenIndex++;

                // 找到第一个奇数
                oddIndex = evenIndex + 1;
                while (oddIndex < len && IsEven(newArray[oddIndex]))
                    oddIndex++;

                if (oddIndex < len)
                {
                    // 偶数位及其后续元素 进行后移
                    temp = newArray[oddIndex];
                    for (int oddIndex2 = oddIndex - 1; oddIndex2 >= evenIndex; oddIndex2--)
                    {
                        newArray[oddIndex2 + 1] = newArray[oddIndex2];
                    }

                    // 偶数位数值替换
                    newArray[evenIndex++] = temp;
                }
                else
                    break;
            }
            return newArray;
        }

        public static bool IsEven(int k)
        {
            if (k % 2 == 0)
                return true;
            else
                return false;
        }

        public static void Run()
        {
            int[][] nums = new int[4][];
            nums[0] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            nums[1] = new int[] { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };
            nums[2] = new int[] { 0 };
            nums[3] = new int[] { };

            foreach (int[] t in nums)
            {
                Print(t, ReOrderArray1(t));
            }
        }

        public static void Print(int[] oldNums, int[] newNums)
        {
            Console.Write("原数组： ");
            foreach (int i in oldNums)
                Console.Write(i + " ");

            Console.Write("\n处理后： ");
            foreach (int i in newNums)
                Console.Write(i + " ");
            Console.WriteLine("\n----------------------------");
        }
    }
}
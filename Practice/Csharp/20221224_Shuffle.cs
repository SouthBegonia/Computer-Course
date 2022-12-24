using System;

namespace CsharpExam
{
    /// <summary>
    /// 洗牌算法（数组乱序）
    /// </summary>
    public class _20221224_Shuffle
    {
        /*static void Main()
        {
            int[] testArr = new int[10];
            for (int i = 0; i < testArr.Length; i++)
                testArr[i] = i;

            int[] ret = Shuffle(testArr);
            foreach (int val in ret)
            {
                Console.Write($"{val}, ");
            }
        }*/

        static int[] Shuffle(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return arr;

            int[] ret = (int[])arr.Clone();
            int len = ret.Length;

            Random random = new Random();
            for (int i = 0; i < len; i++)
            {
                int randomIndex = random.Next(i, len - 1);
                Swap(ref ret[i], ref ret[randomIndex]);
            }

            return ret;
        }

        static void Swap(ref int a, ref int b)
        {
            if (a == b)
                return;
            a ^= b;
            b ^= a;
            a ^= b;
        }
    }
}
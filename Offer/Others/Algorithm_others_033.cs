using System;

namespace Code033
{
    /// <summary>
    /// 033 丑数
    /// </summary>
    class Algorithm_others_033
    {
        //  一个丑数的因子只有2,3,5，那么丑数 p = 2 ^ x * 3 ^ y * 5 ^ z，
        //  换句话说一个丑数一定由另一个丑数乘以2或者乘以3或者乘以5得到.
        //  那么我们从1开始乘以2,3,5，就得到2,3,5三个丑数，在从这三个丑数出发乘以2,3,5就得到4，6,10,6，9,15,10,15,25九个丑数

        /// <summary>
        /// 033 丑数
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int GetUglyNumber_Solution(int index)
        {
            // 0~6的丑数为0、6
            if (index < 7)
                return index;

            // p2、p3、p5分别为三个队列(乘以2、3、5)的指针
            int p2 = 0, p3 = 0, p5 = 0;

            // 丑数的数组
            int[] arr = new int[index];
            arr[0] = 1;

            for (int i = 1; i < index; i++)
            {
                // 先选出三个队列头中最小的数，入队
                arr[i] = Math.Min(arr[p2] * 2, Math.Min(arr[p3] * 3, arr[p5] * 5));

                // 后将 该最小的数 乘以2,3,5放入三个队列
                if (arr[i] == arr[p2] * 2)
                    p2++;
                if (arr[i] == arr[p3] * 3)
                    p3++;
                if (arr[i] == arr[p5] * 5)
                    p5++;
            }
            return arr[index - 1];
        }
    }
}

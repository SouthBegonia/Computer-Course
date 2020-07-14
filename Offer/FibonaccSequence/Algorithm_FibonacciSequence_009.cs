using System;

namespace Code009
{
    /// <summary>
    /// 009 变态跳台阶问题
    /// </summary>
    class Algorithm_FibonacciSequence_009
    {
        // f(n)   = f(n-1) + f(n-2) + ... +f(1)
        // f(n-1) = f(n-2) + ... + f(1)
        // 两式相减得f(n)=2f(n-1)

        /// <summary>
        /// 009 变态跳台阶问题
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int jumpFloorII(int number)
        {
            if (number == 0)
                return 0;

            // 动态规划
            int[] a = new int[number + 2];
            int b = 3;
            a[0] = 1;
            a[1] = 1;
            a[2] = 2;

            if (number < b && number > 0)
                return a[number];

            // 全部计算
            for (int i = 3; i <= number; i++)
            {
                a[i] = 2 * a[i - 1];
            }
            return a[number];
        }

        public static void Run()
        {
            while (true)
            {
                Console.Write("跳到第几阶台阶： ");
                int qus = Int32.Parse(Console.ReadLine());

                Console.WriteLine("共有 " + jumpFloorII(qus) + " 种跳法\n");
            }
        }
    }
}

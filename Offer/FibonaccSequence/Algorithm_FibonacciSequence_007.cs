using System;
using System.Collections.Generic;
using System.Text;

namespace Code007
{
    /// <summary>
    /// 007 斐波那契数列
    /// </summary>
    class Algorithm_FibonacciSequence_007
    {
        /// <summary>
        /// 007 斐波那契数列
        /// </summary>
        /// <param name="n">数列的第n项</param>
        /// <returns></returns>
        public static int Fibonacci(int n)
        {
            // 表达式： F(1)=1，F(2)=1, F(n) = F(n - 1) + F(n - 2) （n ≥ 3，n ∈ N*）
            // 实例：   1、 1、 2、 3、 5、 8、 13、 21、 34、 ……
            if (n == 0)
                return 0;
            else if (n <= 2 && n > 0)
                return 1;

            int ans = 1;
            int pre = 1;
            int temp;
            for (int i = 3; i <= n; i++)
            {
                temp = ans;
                ans = pre + ans;
                pre = temp;
            }
            return ans;
        }

        public static void Run()
        {
            while(true)
            {
                Console.Write("需要打印斐波那契数列的第几项？ ");
                int qus = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Ans = " + Fibonacci(qus) + "\n");
            }
        }
    }
}
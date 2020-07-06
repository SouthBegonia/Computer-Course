using System;
using System.Collections.Generic;
using System.Text;

namespace Code008
{
    /// <summary>
    /// 008 跳台阶
    /// </summary>
    class Algorithm_FibonacciSequence_008
    {
        /// <summary>
        /// 008 跳台阶
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int jumpFloor(int number)
        {
            // 如果我从第n个台阶进行下台阶，下一步有2中可能，一种走到第n - 1个台阶，一种是走到第n - 2个台阶。
            // 所以f[n] = f[n - 1] + f[n - 2]. 那么初始条件了，f[0] = f[1] = 1 
            // 所以就变成了：f[n] = f[n - 1] + f[n - 2], 初始值f[0] = 1, f[1] = 1，目标求f[n]

            if (number < 0)
                return 0;
            if (number <= 2)
                return number;

            return jumpFloor(number - 1) + jumpFloor(number - 2);
        }

        public static void Run()
        {
            while (true)
            {
                Console.Write("跳到第几阶台阶： ");
                int qus = Int32.Parse(Console.ReadLine());

                Console.WriteLine("共有 " + jumpFloor(qus) + " 种跳法\n");
            }
        }
    }
}

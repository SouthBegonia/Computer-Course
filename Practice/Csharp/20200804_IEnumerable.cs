using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;

namespace CsharpExam
{
    class _20200804_IEnumerable
    {
        private static void Main(string[] args)
        {
            foreach (int i in Test())
            {
                Console.WriteLine("返回的结果是：" + i);
            }
        }

        public static IEnumerable<int> Test()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return i;
                Thread.Sleep(1000);
            }
        }
    }
}

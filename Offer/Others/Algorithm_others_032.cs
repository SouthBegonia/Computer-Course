using System;
using System.Collections.Generic;

namespace Code032
{
    /// <summary>
    /// 032 把数组排成最小的数
    /// </summary>
    class Algorithm_others_032
    {
        /// <summary>
        /// 传入int类型数组，进行排列
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string PrintMinNumber(int[] numbers)
        {
            // 1. 将测试数组转换为string类型数组
            string[] strs = new string[numbers.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                strs[i] = numbers[i].ToString();
            }

            // 2. 对string类型数组进行排列操作
            return PrintMinNumber(strs);
        }

        /// <summary>
        /// 传入string类型数组，进行排列
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string PrintMinNumber(string[] strs)
        {
            //3. 使用自定义比较方法，对数组进行特殊升序排序
            //   例如{3,32,321} --> {321,32,3}
            MyCompare mycompare = new MyCompare();
            Array.Sort(strs, mycompare);

            //4. 最终将字符串连接并返回
            string str = "";
            for (int i = 0; i < strs.Length; i++)
            {
                str = str + strs[i];
            }
            return str;
        }

        /// <summary>
        /// 自定义比较方法类
        /// </summary>
        public class MyCompare : IComparer<string>
        {
            //特殊升序排列：a/b较小则str1/str2在前
            //        例如 332 > 323  ，因此 32 在前 3在后
            public int Compare(string str1, string str2)
            {
                // 两字符串前后组合，对形成的字符串进行比较
                long a = Int64.Parse(str1 + str2);
                long b = Int64.Parse(str2 + str1);        
                return a.CompareTo(b);
                //return (int)(a - b);
            }
        }

        #region 测试
        public static void Run()
        {
            int[][] nums = new int[3][];
            nums[0] = new int[] { 3, 32, 321 };
            nums[1] = new int[] { 1, 12, 123 };
            nums[2] = new int[] { 9, 1, 0 };

            foreach (var n in nums)
                Print(n, PrintMinNumber(n));

        }

        public static void Print(int[] origin, string ans)
        {
            Console.Write("测试数组：");
            foreach (int k in origin)
                Console.Write(k + " ");
            Console.WriteLine("\n排成最小的数为：" + ans + "\n");
        }
        #endregion
    }
}
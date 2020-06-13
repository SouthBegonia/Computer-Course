using System;
using System.Collections.Generic;
using System.Text;

namespace Code002
{
    /// <summary>
    /// 002 替换空格
    /// </summary>
    class Algorithm_others_002
    {
        /// <summary>
        /// 002 替换空格，Replace()方法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceSpace1(string str)
        {
            string myStr = str.Replace(" ", "%20");
            return myStr;
        }
        
        /// <summary>
        /// 002 替换空格，StringBuilder.Append()方法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceSpace2(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char c in str)
            {
                if (c.Equals(' '))
                    sb.Append("%20");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 002 替换空格，遍历+替换方法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceSpace3(string str)
        {
            // 创建新数组，长度 = str.Length*3
            // 单次顺序遍历，遇到空格用 '%' '2' '0' 代替

            // 也可一次遍历得到空格数目，再扩展空间
            // 从后往前遍历、替换 ...
            return str;
        }

        public static void Run()
        {
            string[] strs = new string[4];
            strs[0] = "12 34 56";
            strs[1] = " 1234 ";
            strs[2] = " ";
            strs[3] = "";

            Console.WriteLine("Way1: Replace()方法：");
            foreach (string st in strs)
            {
                Console.WriteLine("测试字符串：\'" + st+"\'");
                Console.WriteLine("替换后结果：\'" + ReplaceSpace1(st) + "\'\n");
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Way2: StringBuilder.Append()方法：");
            foreach(string st in strs)
            {
                Console.WriteLine("测试字符串：\'" + st + "\'");
                Console.WriteLine("替换后结果：\'" + ReplaceSpace2(st) + "\'\n");
            }
        }
    }
}
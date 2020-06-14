using System;

namespace StringTest
{
    class StringTest
    {
        /// <summary>
        /// string字符串的驻留机制
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // 1. 字符串常量连接
            string a1= "str_1" + "str_2";
            string b1= "str_1str_2";
            Console.WriteLine(a1.Equals(b1));
            Console.WriteLine(ReferenceEquals(a1, b1));
            Console.WriteLine();

            // 2. 字符串变量连接
            string a2= "str_1";
            string b2= a2 + "str_2";
            string c2= "str_1str_2";
            Console.WriteLine(b2.Equals(c2));
            Console.WriteLine(ReferenceEquals(b2, c2));
            Console.WriteLine();

            // 3. 显式实例化
            string a3 = "a";
            string b3 = new string('a', 1);
            Console.WriteLine(a3.Equals(b3));
            Console.WriteLine(ReferenceEquals(a3, b3));
            Console.WriteLine(ReferenceEquals(a3, String.Intern(b3)));  //手动实现字符串驻留
            Console.WriteLine();


            // Test 1: Copy()生成了新string对象
            string a4 = "str_1";
            string b4 = String.Copy(a4);
            Console.WriteLine(a4.Equals(b4));
            Console.WriteLine(ReferenceEquals(a4, b4));
            Console.WriteLine();

            // Test 2: 引用比较：实质为比较引用对象的地址
            string a5 = "str_1";
            string b5 = String.Copy(a5);
            string c5 = "str_1";
            Console.WriteLine((object)a5 == (object)b5);
            Console.WriteLine((object)a5 == (object)c5);
            Console.WriteLine();
        }
    }
}

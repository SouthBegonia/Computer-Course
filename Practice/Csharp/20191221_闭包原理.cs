using System;
using System.Collections.Generic;

namespace Program
{
    class Client
    {
        public static Action<int> TestCreateActionInstance()
        {
            // 由于 action闭包，该count并非分配在栈上,
            // 而是被另一个 临时类的字段 所捕获(无论值类型还是引用类型),
            // 其 作用域 随着匿名函数(或Lambda)的生存周期而延长，即存在于 托管堆 上
            int count = 0;

            //定义action
            Action<int> action = delegate (int number)
            {
                count += number;    //因此此处是对临时类实例中的count字段的引用
                Console.WriteLine(count);
            };

            //触发action
            action(1);      //1
            return action;
        }

        static void Main()
        {
            Action<int> act = TestCreateActionInstance();

            act(10);        //11
            act(100);       //111
            act(1000);      //1111

            Console.Read();
        }        
    }
}
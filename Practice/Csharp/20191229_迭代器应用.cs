using System;
using System.Collections.Generic;

namespace Program
{
    class Client
    {
        static IEnumerable<int> TestStateChange()
        {
            // 直至第一个MoveNext时才执行下列代码
            Console.WriteLine("-----TestStateChange 的第 1 行代码\n");

            Console.WriteLine("-----第 1 个 yield return 前的代码");
            yield return 1;
            Console.WriteLine("-----第 1 个 yield return 后的代码");

            Console.WriteLine("-----第 2 个 yield return 前的代码");
            yield return 2;
            Console.WriteLine("-----第 2 个 yield return 后的代码");

            /* 迭代器内的状态机 State：
             *    -2：仅存在于IEnumerable，初始构造时的状态
             *    -1：Running状态，表示此时迭代器正在执行；在当前迭代开始前表示Begin状态，结束时表示After状态
             *     0：Before状态，表示MoveNext 尚未执行过
             *     1、2、3...：标记从遇到 yield 关键字后，代码从哪恢复执行，底层为 goto 语句
             */
        }

        static void Main()
        {
            // IEnumerable 构造时 state 为-2
            Console.WriteLine("调用 TestStateChange");
            IEnumerable<int> myIteratorable = TestStateChange();

            // 调用GetEnumrator后 state为 0 
            Console.Write("调用 GetEnumerator");
            IEnumerator<int> myIterator = myIteratorable.GetEnumerator();
            Console.WriteLine(" 初始时 current = {0}\n", myIterator.Current);

            // 根据当前 state 选择执行TestStateChange 内的代码
            Console.WriteLine("第 1 次调用 MoveNext");
            bool hasNext = myIterator.MoveNext();
            Console.WriteLine("是否有数据 = {0};  current = {1}\n",hasNext,myIterator.Current);


            Console.WriteLine("第 2 次调用 MoveNext");
            hasNext = myIterator.MoveNext();
            Console.WriteLine("是否还有数据 = {0};  current = {1}\n", hasNext, myIterator.Current);


            Console.WriteLine("第 3 次调用 MoveNext");
            hasNext = myIterator.MoveNext();
            Console.WriteLine("是否还有数据 = {0};  current = {1}\n", hasNext, myIterator.Current);

            Console.Read();
        }
    }
}
using System;
using System.Xml.Schema;

namespace CsharpExam
{
    public class _20211221_Closure
    {
        static void Main()
        {
            Action ce1 = GenClosureAc(1);
            Action ce2 = GenClosureAc(2);

            ce1();
            ce1();

            ce2();
            ce2();
            ce2();
        }

        static Action GenClosureAc(int id)
        {
            int num = 0;
            return () => { Console.WriteLine($"ID={id}, Num={num++}"); };
        }
    }
}
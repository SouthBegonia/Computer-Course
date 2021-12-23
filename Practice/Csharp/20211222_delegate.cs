using System;
using System.Xml.Schema;

namespace CsharpExam
{
    public class _20211222_delegate
    {
        static void Main()
        {
            //委托
            OperateTwoNumDelegate addFun = (x, y) => x + y;
            OperateTwoNumDelegate subFun = Sub;

            Console.WriteLine(addFun(1, 2));
            Console.WriteLine(subFun(1, 2));


            //Action : 无返回值的委托
            Action ac_noParam = () => { Console.WriteLine("It's Action"); };
            Action<int, string> ac_Param = ParamAction;

            ac_noParam();
            ac_Param(12, "Hello");


            //Func : 有返回值的委托
            Func<string> func_noParam = () => "It's Func";
            Func<int, string> func_Param = (x) => $"num = {x}";
            Console.WriteLine(func_noParam());
            Console.WriteLine(func_Param(1));
        }

        #region delegate

        //声明
        delegate int OperateTwoNumDelegate(int x, int y);

        static int Sub(int a, int b)
        {
            return a - b;
        }

        #endregion

        #region Action

        static void ParamAction(int num, string str)
        {
            Console.WriteLine($"num={num}, str={str}");
        }

        #endregion
    }
}
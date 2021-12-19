using System;

namespace CsharpExam
{
    public class _20211219_简单工厂
    {
        static void Main()
        {
            BaseOperator addop = GenOpFactory.GenOp("+");
            addop.NumberA = 1;
            addop.NumberB = 2;
            Console.WriteLine(addop.OperateInt());

            BaseOperator subOp = GenOpFactory.GenOp("-");
            subOp.NumberA = 2;
            subOp.NumberB = 1;
            Console.WriteLine(subOp.OperateInt());
        }
    }

    /// <summary>
    /// 运算基类
    /// </summary>
    public class BaseOperator
    {
        public int NumberA;
        public int NumberB;

        public virtual int OperateInt()
        {
            return 0;
        }
    }

    public class AddOp : BaseOperator
    {
        public override int OperateInt()
        {
            return NumberA + NumberB;
        }
    }

    public class SubOp : BaseOperator
    {
        public override int OperateInt()
        {
            return NumberA - NumberB;
        }
    }

    /// <summary>
    /// 工厂类
    /// </summary>
    public class GenOpFactory
    {
        public static BaseOperator GenOp(string tag)
        {
            BaseOperator op = null;
            switch (tag)
            {
                case "+":
                    op = new AddOp();
                    break;
                case "-":
                    op = new SubOp();
                    break;
            }

            return op;
        }
    }
}
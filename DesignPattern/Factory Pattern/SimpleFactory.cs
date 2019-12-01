using System;


//简单工厂模式
namespace SimpleFactory
{
    //运算基类：
    public class Operation
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }

        public virtual double GetResult()
        {
            double result = 0;
            return result;
        }
    }

    //运算符派生类：
    //加法类：
    class OperationAdd : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA + NumberB;
            return result;
        }
    }

    //减法类：
    class OperationSub : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA - NumberB;
            return result;
        }
    }

    //乘法类：
    class OperationMul : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA * NumberB;
            return result;
        }
    }

    //除法类：
    class OperationDiv : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            if (NumberB == 0)
                throw new Exception("除数不可为 0");
            result = NumberA / NumberB;
            return result;
        }
    }

    //运算工厂类：
    public class OperationFactory
    {
        public static Operation CreateOperate(string operate)
        {
            //根据传入的参数operate选择实例化的类
            Operation oper = null;
            switch (operate)
            {
                case "+":
                    oper = new OperationAdd();
                    break;
                case "-":
                    oper = new OperationSub();
                    break;
                case "*":
                    oper = new OperationMul();
                    break;
                case "/":
                    oper = new OperationDiv();
                    break;
            }
            return oper;
        }
    }

    //测试类：
    class Test
    {
        static void Main(string[] args)
        {
            Operation oper;        
            oper = OperationFactory.CreateOperate("+");
            oper.NumberA = 4;  oper.NumberB = 2;
            double result = oper.GetResult();
            Console.WriteLine(result);

            oper = OperationFactory.CreateOperate("-");
            oper.NumberA = 4; oper.NumberB = 2;
            result = oper.GetResult();
            Console.WriteLine(result);

            oper = OperationFactory.CreateOperate("/");
            oper.NumberA = 4; oper.NumberB = 2;
            result = oper.GetResult();
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}

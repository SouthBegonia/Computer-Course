using System;

namespace FactoryMethod
{
    #region 运算符类
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
    #endregion


    #region 抽象工厂接口 
    //抽象工厂接口
    interface IFactory
    {
        Operation CreateOperation();
    }
    #endregion


    #region 各运算工厂类
    //加法工厂
    class AddFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationAdd();
        }
    }
    //减法工厂
    class SubFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationSub();
        }
    }
    //乘法工厂
    class MulFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationMul();
        }
    }
    //除法工厂
    class DivFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationDiv();
        }
    }
    #endregion


    //测试类：
    class Test
    {
        static void Main(string[] args)
        {
            var operFactory = new AddFactory();
            //IFactory operFactory = new AddFactory();
            Operation oper = operFactory.CreateOperation();
            oper.NumberA = 4; oper.NumberB = 2;
            double result = oper.GetResult();
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}

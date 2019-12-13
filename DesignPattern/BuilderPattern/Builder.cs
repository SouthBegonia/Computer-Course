using System;
using System.Collections.Generic;

// 建造者模式
namespace Builder
{
    // 产品类：
    // ------
    class Product
    {
        List<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("生产产品：");
            foreach (string part in parts)
                Console.WriteLine(part);
        }
    }

    // 抽象建造者类：
    // ------------
    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }

    // 具体建造者类：
    // ------------
    class ConcreteBuilder_1:Builder
    {
        private Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("部件A");
        }

        public override void BuildPartB()
        {
            product.Add("部件B");
        }

        public override Product GetResult()
        {
            return product;
        }
    }
    class ConcreteBuilder_2 : Builder
    {
        private Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("部件X");
        }

        public override void BuildPartB()
        {
            product.Add("部件Y");
        }

        public override Product GetResult()
        {
            return product;
        }
    }

    // 指挥者类：将复杂对象的构建与其表示分离
    // --------
    class Director
    {
        // 指挥具体的建造过程
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    // 客户端：
    // -------
    class Client
    {
        static void Main(string[] args)
        {
            // 客户端通过指挥者实现建造过程，而无需知道建造细节
            Director director = new Director();
            Builder builder_1 = new ConcreteBuilder_1();
            Builder builder_2 = new ConcreteBuilder_2();

            // 指挥第一个建造过程
            director.Construct(builder_1);
            Product product_1 = builder_1.GetResult();
            product_1.Show();

            Console.WriteLine();

            // 指挥第二个建造过程
            director.Construct(builder_2);
            Product product_2 = builder_2.GetResult();
            product_2.Show();

            Console.Read();
        }
    }
}

using System;

namespace Decorator
{
    // 装饰对象：
    // ---------
    class Person
    {
        private string name;

        public Person() { }
        public Person(string name) { this.name = name; }

        public virtual void Show()
        {
            Console.WriteLine($" 装扮的{name}");
        }
    }

    // 抽象服饰类 Decorator:
    // --------------------
    class Finery : Person
    {
        //打扮的对象
        protected Person component;

        //打扮
        public void Decorator(Person component) { this.component = component; }

        public override void Show()
        {
            if (component != null)
                component.Show();
        }
    }

    // 具体服饰类:
    // ----------
    class TShirts : Finery
    {
        public override void Show()
        {
            Console.Write("T恤");
            base.Show();
        }
    }
    class BigTrouser : Finery
    {
        public override void Show()
        {
            Console.Write("垮裤 ");
            base.Show();
        }
    }
    class Sneakers:Finery
    {
        public override void Show()
        {
            Console.Write("破球鞋 ");
            base.Show();
        }
    }

    // 客户端：
    // -------
    class Client
    {
        static void Main()
        {
            Person jack = new Person("杰克");

            Console.WriteLine("第一种装扮:");

            // 创建装饰物:
            // ----------
            var shirts = new TShirts();
            var sneakers = new Sneakers();           
            var bigtrouser = new BigTrouser();

            // 装饰过程：
            // --------
            // 机理：B对象装饰A、C对象装饰B、D对象装饰C ..
            //      核心在于都执行了base.Show() 即Finery.Show()
            shirts.Decorator(jack);
            sneakers.Decorator(shirts);
            bigtrouser.Decorator(sneakers);

            // 打印
            bigtrouser.Show();

            Console.Read();
        }
    }
}
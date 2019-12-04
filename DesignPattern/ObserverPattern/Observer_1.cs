using System;

//声明委托
delegate void EventHandler();

namespace Observer
{
    // 主题接口
    interface Subject
    {
        //通知事件
        void Notify();
    }

    // 具体主题
    class ConcreteSubject : Subject
    {
        public event EventHandler Update;

        public void Notify()
        {
            //主题改变则通知其所有订阅者进行变化
            Console.WriteLine("出现了野生布加拉提！");

            //事件发生
            Update();
        }
    }

    // 抽象订阅者
    abstract class Observer
    {
        protected string name;

        public Observer(string name)
        {
            this.name = name;
        }
    }

    // 具体订阅者A
    class ConcreteObserverA : Observer
    {
        public ConcreteObserverA(string name) : base(name) { }

        public void Attack()
        {
            Console.WriteLine($"{name} 发动攻击！");
        }
    }

    // 具体订阅者B
    class ConcreteObserverB : Observer
    {
        public ConcreteObserverB(string name) : base(name) { }

        public void Shout()
        {
            Console.WriteLine($"{name} 发出呐喊！");
        }
    }

    // 客户端
    class Client
    {
        static void Main(string[] args)
        {
            //创建主题对象
            ConcreteSubject Bucciarati = new ConcreteSubject();

            //创建订阅者
            ConcreteObserverA Prosciutto = new ConcreteObserverA("普罗修特");
            ConcreteObserverB Pesci = new ConcreteObserverB("贝西");

            //订阅者订阅主题对象（委托的多播）
            Bucciarati.Update += new EventHandler(Prosciutto.Attack);
            Bucciarati.Update += new EventHandler(Pesci.Shout);

            //主题对象通知事件
            Bucciarati.Notify();

            Console.Read();
        }
    }
}

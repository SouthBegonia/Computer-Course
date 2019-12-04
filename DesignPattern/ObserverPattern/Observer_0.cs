//using System;
//using System.Collections.Generic;

//namespace Observer
//{
//    // 主题接口
//    interface Subject
//    {
//        //添加/删除订阅者
//        void Attach(Observer observer);
//        void Detach(Observer observer);

//        //通知事件
//        void Notify();
//    }

//    // 具体主题
//    class ConcreteSubject : Subject
//    {
//        // 订阅者清单
//        private List<Observer> observers = new List<Observer>();

//        public void Attach(Observer obs)
//        {
//            observers.Add(obs);
//        }

//        public void Detach(Observer obs)
//        {
//            if (observers.Contains(obs))
//                observers.Remove(obs);
//        }

//        public void Notify()
//        {
//            //主题改变则通知其所有订阅者进行变化
//            Console.WriteLine("出现了野生布加拉提！");
//            foreach (Observer o in observers)
//                o.Update();
//        }
//    }

//    // 抽象订阅者
//    abstract class Observer
//    {
//        protected string name;

//        public Observer(string name)
//        {
//            this.name = name;
//        }

//        // 订阅者对通知事件的反应
//        public abstract void Update();
//    }

//    // 具体订阅者A
//    class ConcreteObserverA : Observer
//    {
//        public ConcreteObserverA(string name) : base(name) { }

//        public override void Update()
//        {
//            Console.WriteLine($"{name} 发动替身: \"The Grateful Dead\"");
//        }
//    }

//    // 具体订阅者B
//    class ConcreteObserverB : Observer
//    {
//        public ConcreteObserverB(string name) : base(name) { }

//        public override void Update()
//        {
//            Console.WriteLine($"{name} 发出呐喊：\"普罗修特大哥！\"");
//            // 随后失去了普罗修特大哥
//        }
//    }
    
//    // 客户端
//    class Client
//    {
//        static void Main(string[] args)
//        {
//            //创建主题对象
//            ConcreteSubject Bucciarati = new ConcreteSubject();

//            //创建订阅者
//            ConcreteObserverA Prosciutto = new ConcreteObserverA("普罗修特");
//            ConcreteObserverB Pesci = new ConcreteObserverB("贝西");

//            //订阅者订阅主题对象
//            Bucciarati.Attach(Prosciutto);
//            Bucciarati.Attach(Pesci);

//            //主题对象通知事件
//            Bucciarati.Notify();

//            Console.Read();
//        }
//    }
//}

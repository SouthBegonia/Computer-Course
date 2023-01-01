using System;

//观察者模式（发布-订阅模式）
namespace EventSubscriberPattern
{
    public delegate void NotifyEventHandler(Object evt);

    /// <summary>
    /// 抽象发布者
    /// </summary>
    public abstract class Publisher
    {
        private event NotifyEventHandler NotifyEvent;

        public virtual void AddSubscriber(NotifyEventHandler ob)
        {
            NotifyEvent += ob;
        }

        public virtual void RemoveSubscriber(NotifyEventHandler ob)
        {
            NotifyEvent -= ob;
        }

        public virtual void NotifySubscribers()
        {
            NotifyEvent?.Invoke("This is a message");
        }
    }

    /// <summary>
    /// 具体发布者
    /// </summary>
    class ConcretePublisher : Publisher
    {
    }

    /// <summary>
    /// 抽象订阅者
    /// </summary>
    abstract class Subscriber
    {
        public abstract void OnReceiveEvent(Object evt);
    }

    /// <summary>
    /// 具体订阅者
    /// </summary>
    class ConcreteSubscriber : Subscriber
    {
        private string name;
        public ConcreteSubscriber(string name) { this.name = name; }

        public override void OnReceiveEvent(object evt)
        {
            string msg = (string)evt;
            Console.WriteLine($"订阅者 {name} 收到来自发布者的消息：{msg}");
        }
    }

    class Client
    {
        static void Main()
        {
            //创建 发布者
            Publisher publisher = new ConcretePublisher();

            //创建 订阅者
            Subscriber subscriberA = new ConcreteSubscriber("A");
            Subscriber subscriberB = new ConcreteSubscriber("B");

            //建立 事件订阅机制
            publisher.AddSubscriber(subscriberA.OnReceiveEvent);
            publisher.AddSubscriber(subscriberB.OnReceiveEvent);
            //发布者 发布事件
            publisher.NotifySubscribers();


            Console.WriteLine();


            publisher.RemoveSubscriber(subscriberA.OnReceiveEvent);
            publisher.NotifySubscribers();
        }
    }
}
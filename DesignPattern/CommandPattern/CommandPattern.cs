using System;

//命令模式
namespace CommandPattern
{
    /// <summary>
    /// 抽象 命令接收者
    /// </summary>
    abstract class Receiver
    {
        public abstract void Action();
    }

    /// <summary>
    /// 具体 命令接收者
    /// </summary>
    class ConcreteReceiver : Receiver
    {
        public override void Action()
        {
            Console.WriteLine($"{typeof(ConcreteReceiver)} 收到命令");
        }
    }


    /// <summary>
    /// 抽象 命令类
    /// </summary>
    abstract class Command
    {
        protected Receiver receiver;

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public virtual void Excute()
        {
            receiver.Action();
        }
    }

    /// <summary>
    /// 具体 命令类
    /// </summary>
    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {
        }

        public override void Excute()
        {
            Console.WriteLine($"{typeof(ConcreteCommand)}  命令被发布");
            base.Excute();
        }
    }


    /// <summary>
    /// 命令发布者
    /// </summary>
    class Invoker
    {
        /// <summary>
        /// 操作的命令
        /// </summary>
        private Command command;

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        /// <summary>
        /// 发布命令
        /// </summary>
        public void ExcuteCommand()
        {
            Console.WriteLine($"{typeof(Invoker)}  发布命令");
            command.Excute();
        }
    }

    public class Client
    {
        static void Main()
        {
            //创建命令接收者
            Receiver receiver = new ConcreteReceiver();

            //创建命令 及 设置命令的接收者
            Command command = new ConcreteCommand(receiver);

            //创建命令发布者 及 设置发布者的目标操作命令
            Invoker invoker = new Invoker();
            invoker.SetCommand(command);

            //命令发布者 发布指令
            invoker.ExcuteCommand();

            //实现了 Invoker 与 Receiver 的解耦
        }
    }
}
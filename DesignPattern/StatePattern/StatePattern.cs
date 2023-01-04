using System;

//状态模式
namespace StatePattern
{
    /// <summary>
    /// 抽象状态
    /// </summary>
    public interface IState
    {
        void DoSomething();
    }

    /// <summary>
    /// 具体状态
    /// </summary>
    public class ConcreteState : IState
    {
        private string stateName;
        private Context context;

        public ConcreteState(string stateName)
        {
            this.stateName = stateName;
        }

        public void SetContext(Context context)
        {
            this.context = context;
        }

        public void DoSomething()
        {
            Console.WriteLine($"State={this.stateName}, Context={context}  :  Dosomething...");
        }
    }

    /// <summary>
    /// 上下文：保存了对于一个具体状态对象的引用，并将所有与该状态相关的工作委派于此
    /// （可理解为：状态机）
    /// </summary>
    public class Context
    {
        private ConcreteState state;

        public Context(ConcreteState initialState)
        {
            this.state = initialState;
            this.state.SetContext(this);
        }

        public void ChangeState(ConcreteState newState)
        {
            this.state = newState;
            this.state.SetContext(this);
        }

        public void Dosomething()
        {
            this.state?.DoSomething();
        }
    }

    class Client
    {
        static void Main()
        {
            //创建 具体状态
            var initialState = new ConcreteState("State_A");

            //创建 具体上下文
            var context = new Context(initialState);
            context.Dosomething();

            //状态切换
            var newState = new ConcreteState("State_B");
            context.ChangeState(newState);
            context.Dosomething();
        }
    }
}
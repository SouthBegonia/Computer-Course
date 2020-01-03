using System;

/*
状态模式：当一个对象的内在状态改变时允许改变其行为，这个对象看起来像是改变了其类
方法：把状态的判断转移到表示不同状态的一些列类当中，把复杂的判断逻辑简化
适用场合：当一个对象的行为取决于它的状态，并且它必须在运行时刻根据状态改变它的行为（本例中的Hour和TaskFinished）
*/
namespace StatePattern
{
    #region 各状态
    // 抽象状态
    public abstract class State
    {
        public abstract void WriteProgram(Work w);
    }

    // 上午的工作状态
    public class ForenoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 12)
                Console.WriteLine($"当前时间：{w.Hour}点，上午工作");
            else
            {
                // 超时则转到中午状态
                w.SetState(new NoonState());
                w.WriteProgram();
            }
        }
    }

    // 中午的工作状态
    public class NoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 13)
                Console.WriteLine($"当前时间：{w.Hour}点，吃午饭，午休");
            else
            {
                //// 超时则转到下午状态
                w.SetState(new AfternoonState());
                w.WriteProgram();
            }
        }
    }


    // 下午的工作状态
    public class AfternoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 19)
                Console.WriteLine($"当前时间：{w.Hour}点，下午工作");
            else
            {
                w.SetState(new EveningState());
                w.WriteProgram();
            }
        }
    }

    // 晚上的工作状态
    public class EveningState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.TaskFinished)
            {
                // 倘若工作完成，则转为休息状态
                w.SetState(new RestState());
                w.WriteProgram();
            }
            else
            {
                if (w.Hour < 21)
                    Console.WriteLine($"当前时间：{w.Hour}点，加班ing");
                else
                {
                    w.SetState(new SleepingState());
                    w.WriteProgram();
                }

            }
        }
    }

    // 下班休息的状态
    public class RestState : State
    {
        public override void WriteProgram(Work w)
        {
            Console.WriteLine($"当前时间：{w.Hour}点，下班休息");
        }
    }

    // 睡眠状态
    public class SleepingState : State
    {
        public override void WriteProgram(Work w)
        {
            Console.WriteLine($"当前时间：{w.Hour}点，已经睡着了");
        }
    }

    /*
     * 通过定义新的子类可方便的 添加、修改、切换状态，以减少各State类之间的依赖
     */
    #endregion

    // 工作 Context
    public class Work
    {
        private State _currentState;
        public Work() { _currentState = new ForenoonState(); }

        public double Hour { get; set; }
        public bool TaskFinished { get; set; }

        public void SetState(State s)
        {
            _currentState = s;
        }

        public void WriteProgram()
        {
            _currentState.WriteProgram(this);
        }
    }

    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("项目组A：");
            Work emergencyProjects_A = new Work();
            emergencyProjects_A.Hour = 9;
            emergencyProjects_A.WriteProgram();
            emergencyProjects_A.Hour = 10;
            emergencyProjects_A.WriteProgram();
            emergencyProjects_A.Hour = 12;
            emergencyProjects_A.WriteProgram();
            emergencyProjects_A.Hour = 13;
            emergencyProjects_A.WriteProgram();
            emergencyProjects_A.Hour = 14;
            emergencyProjects_A.WriteProgram();
            emergencyProjects_A.Hour = 17;
            emergencyProjects_A.WriteProgram();

            emergencyProjects_A.TaskFinished = false;

            emergencyProjects_A.WriteProgram();
            emergencyProjects_A.Hour = 19;
            emergencyProjects_A.WriteProgram();
            emergencyProjects_A.Hour = 22;
            emergencyProjects_A.WriteProgram();
            emergencyProjects_A.Hour = 23;
            emergencyProjects_A.WriteProgram();
            Console.WriteLine();


            Console.WriteLine("项目组B：");
            Work emergencyProjects_B = new Work();
            emergencyProjects_B.Hour = 8;
            emergencyProjects_B.WriteProgram();
            emergencyProjects_B.Hour = 11;
            emergencyProjects_B.WriteProgram();
            emergencyProjects_B.Hour = 12;
            emergencyProjects_B.WriteProgram();
            emergencyProjects_B.Hour = 13;
            emergencyProjects_B.WriteProgram();
            emergencyProjects_B.Hour = 17;
            emergencyProjects_B.WriteProgram();
            emergencyProjects_B.Hour = 18;
            emergencyProjects_B.WriteProgram();
            emergencyProjects_B.WriteProgram();
            emergencyProjects_B.Hour = 19;
            emergencyProjects_B.WriteProgram();

            emergencyProjects_B.TaskFinished = true;

            emergencyProjects_B.Hour = 20;
            emergencyProjects_B.WriteProgram();
            emergencyProjects_B.Hour = 21;
            emergencyProjects_B.WriteProgram();

            Console.Read();
        }
    }
}
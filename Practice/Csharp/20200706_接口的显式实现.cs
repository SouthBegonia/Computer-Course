using System;

/// <summary>
/// 接口的显式实现
/// </summary>
namespace IspExample3
{
    class Program
    {
        static void Main()
        {
            //way1：
            var wk = new WarmKiller();
            wk.Love();
            IKiller killer = wk;
            killer.Kill();

            // way2:
            //IKiller killer = new WarmKiller();
            //killer.Kill();
            //var wk = (IGentlemen)killer;
            //wk.Love();
        }
    }

    interface IGentlemen
    {
        void Love();
    }

    interface IKiller
    {
        void Kill();
    }

    class WarmKiller : IGentlemen, IKiller
    {
        // 普通实现
        public void Love()
        {
            Console.WriteLine("I will love you for ever");
        }

        // 显式实现
        void IKiller.Kill()
        {
            Console.WriteLine("Let me kill the enemy");
        }
    }
}

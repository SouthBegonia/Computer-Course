using System;

namespace Strategy
{
    // 游戏输入设备（抽象策略类）：
    // ---------------------
    public abstract class InputMode
    {
        public abstract void Play();
    }

    // 具体游戏输入设备（具体策略类）：
    // -------------------------
    public class Keyboard : InputMode
    {
        public override void Play()
        {
            Console.WriteLine("使用 Keyboard 进行游戏！");
        }
    }
    public class Xbox : InputMode
    {
        public override void Play()
        {
            Console.WriteLine("使用 Xbox 进行游戏！");
        }
    }
    public class PS4 : InputMode
    {
        public override void Play()
        {
            Console.WriteLine("使用 PS4 进行游戏！");
        }
    }


    // Context对象：随着策略对象改变而改变
    // ---------------------------------
    public class PlayContext
    {
        //当前游戏输入设备
        InputMode myInputWay;

        //初始化当前游戏输入设备
        public PlayContext(InputMode inputWay)
        {
            this.myInputWay = inputWay;
        }

        //调用游戏输入设备类中的方法
        public void PlayInTheMode()
        {
            myInputWay.Play();
        }
    }


    // 玩家（客户端）：
    // --------------
    class Player
    {
        static void Main(string[] args)
        {
            PlayContext playContext;
            playContext = new PlayContext(new Keyboard());
            playContext.PlayInTheMode();

            playContext = new PlayContext(new Xbox());
            playContext.PlayInTheMode();

            playContext = new PlayContext(new PS4());
            playContext.PlayInTheMode();

            Console.Read();
        }
    }
}

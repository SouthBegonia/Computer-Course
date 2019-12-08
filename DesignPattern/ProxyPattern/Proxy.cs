using System;

namespace Proxy
{
    // 玩家与代练都具备的游戏操作（公共接口）：
    // -----------------------------------
    interface IPlayGame
    {
        void KillEnemy();
        void KillBoss();
        void MissionFinished();
    }

    // 代练的游戏（代理直接接触对象）：
    // ----------------------------
    class Game
    {
        public Game(string name){  Name = name;  }
        public string Name { get; set; }
    }

    // 玩家（被代理对象）：
    // -----------------
    class Player : IPlayGame
    {
        //玩的游戏
        Game game;
        public Player(Game game)
        {
            this.game = game;
        }

        //玩家自己进行游戏
        public void KillEnemy(){  Console.WriteLine($"{game.Name} 击杀小兵！");  }
        public void KillBoss(){  Console.WriteLine($"{game.Name} 击杀Boss！");  }
        public void MissionFinished(){  Console.WriteLine($"{game.Name} 完成任务！");  }
    }

    // 代练（代理对象）：
    // ---------------
    class PlayerProxy : IPlayGame
    {
        //代练替代玩家
        Player player;
        public PlayerProxy(Game game)
        {
            player = new Player(game);
        }

        //代练进行游戏
        public void KillEnemy() {  player.KillEnemy();  }
        public void KillBoss()  {  player.KillBoss();  }
        public void MissionFinished(){  player.MissionFinished();  }
    }

    class Client
    {
        static void Main(string[] args)
        {
            Game LOL = new Game("英雄联盟代练：");

            //创建代练、设定代练游戏
            PlayerProxy playerProxy = new PlayerProxy(LOL);

            //代练直接接触游戏
            playerProxy.KillEnemy();
            playerProxy.KillBoss();
            playerProxy.MissionFinished();

            Console.Read();
        }
    }
}
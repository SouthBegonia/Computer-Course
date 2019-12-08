# 装饰模式

### 博文：
- [代理模式 - SouthBegonia's Blog](https://www.cnblogs.com/SouthBegonia/p/12005806.html)

### 含义：为其他对象提供一种代理以控制对这个对象的访问。也可以说，一个类代表另一个类的功能

### 实现过程：
- 理论性：创建**被代理类**及**代理类**，**客户端直接与代理类对象进行交互**，间接实现了被代理类功能
- 比喻：上班狗没空肝游戏，需要找游戏代练，代练替我们肝了日常活动，即代替我们实现了打游戏这一操作

### 优缺点：
- 优点：
	- 代码结构清晰
	- 高扩展性（代理类既把被代理类实现，又可扩展自身功能）
	- 智能化（动态代理）
- 缺点：
	- 由于在客户端和真实主题（被代理对象）之间增加了代理对象，某些类型的代理模式可能会造成请求的处理速度变慢
	- 介于两者中间的代理类，会造成额外的开销


### 适用场景：
- 远程代理：为了一个对象在不同的地址空间提供局部代表，进而隐藏对象存在于不同地址空间的事实
- 虚拟代理：根据需要创建开销很大的对象
- 安全代理：用于控制真实对象的访问权限
- 智能引用代理：指当调用真实的对象时，代理处理另外一些事
- 防火墙代理
- 同步化代理
- Cache代理

### 项目示例：

代理模式实现玩家找代练肝游戏的情景：

```
// 玩家与代练都会打游戏（公共接口）：
// -----------------------------
interface IPlayGame
{
    void KillEnemy();
    void KillBoss();
    void MissionFinished();
}

// 打的游戏（代理直接接触对象）：
// -------------------------
class Game
{
    public Game(string name){  Name = name;  }
    public string Name { get; set; }
}

// 玩家（被代理对象）：
// -----------------
class Player : IPlayGame
{
    Game game;
    public Player(Game game)
    {
        this.game = game;
    }

    //玩家自己打游戏
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

    //代练打游戏
    public void KillEnemy() {  player.KillEnemy();  }
    public void KillBoss()  {  player.KillBoss();  }
    public void MissionFinished(){  player.MissionFinished();  }
}

class Client
{
    static void Main(string[] args)
    {
		//创建打的游戏
        Game LOL = new Game("英雄联盟代练：");

        //创建代练、设定代练游戏
        PlayerProxy playerProxy = new PlayerProxy(LOL);

        //代练代打
        playerProxy.KillEnemy();
        playerProxy.KillBoss();
        playerProxy.MissionFinished();

		/* OUT:
			英雄联盟代练： 击杀小兵！
			英雄联盟代练： 击杀Boss！
			英雄联盟代练： 完成任务！
		*/
    }
}
```

### UML图

![](https://img2018.cnblogs.com/blog/1688704/201912/1688704-20191208150352614-360606301.png)

# 参考
- [大话设计模式 - 程杰]()
- [代理模式 - 菜鸟教程](https://www.runoob.com/design-pattern/proxy-pattern.html)
- [简说设计模式--代理模式 - JAdam](https://www.cnblogs.com/adamjwh/p/9102037.html)
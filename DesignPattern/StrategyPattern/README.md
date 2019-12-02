# 策略模式

### 博文：
- [策略模式 - SouthBegonia's Blog](https://www.cnblogs.com/SouthBegonia/p/11971521.html)

### 含义：定义了算法家族，并分别封装起来，让他们之间可以相互替换。也可以说：一个类的行为或其算法可以在运行时改变

### 实现过程：
- 概念性：创建**抽象策略接口**，所有**具体策略类**都继承该接口，并实现各自算法；创建**Context上下文**负责对接客户端与各策略类
- 比喻：存在火车、高铁、飞机三种具体交通策略方式，三者都存在于交通枢纽Context中，乘客只需要告诉枢纽他需要的交通方式，枢纽会为乘客提供具体的出行服务
- 备注：
    - **Context 上下文**：**负责和具体的策略实现交互**。通常Context对象会持有一个真正的**策略实现对象**，并具备设置策略对象、调用策略的方法

### 优缺点：
- 优点：
	- 策略算法动态切换便捷
	- 扩展性良好（新增的具体策略类通过继承抽象策略类并实现自身方法即可使用）
	- 简化单元测试（可逐一对各具体策略类进行测试）
	- 有效减少条件判断语句
- 缺点：
	- 每种策略算法即是一个类，造成类数量庞大
	- 具体策略类都需要对外暴露（Context和客户端都需要知道）

### 适用场景：
- 系统中存在多个特征相似的类（火车、高铁、飞机都属于交通方式类；UE4、U3D、Cocos都属于游戏引擎类 ...）
- 系统需要动态地在算法家族中选择执行某一算法（没钱时选择火车，有钱时选择飞机）


### 项目示例：
打游戏时，有三种游戏输入设备（键盘、Xbox手柄、PS4手柄）供玩家选择，玩家根据自身条件选择某一设备进行游戏：

```
// 游戏输入设备（抽象策略类）：
// ------------------------
public abstract class InputMode
{
    public abstract void Play();
}

// 具体游戏输入设备（具体策略类）：
// ---------------------------
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
// --------------------------------
public class PlayContext
{
    //当前游戏输入设备（策略实现对象）
    InputMode myInputMode;

    //构造函数：初始化当前游戏输入设备
    public PlayContext(InputMode inputMode)
    {
        this.myInputMode = inputMode;
    }

    //调用游戏输入设备类中的方法
    public void PlayInTheMode()
    {
        myInputMode.Play();
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
        playContext.PlayInTheMode();			//使用 Keyboard 进行游戏！

        playContext = new PlayContext(new Xbox());		
        playContext.PlayInTheMode();			//使用 Xbox 进行游戏！

        playContext = new PlayContext(new PS4());	
        playContext.PlayInTheMode();			//使用 PS4 进行游戏！
    }
}
```

### UML图：

![](https://img2018.cnblogs.com/blog/1688704/201912/1688704-20191202163449218-386385510.png)

# 参考
- [大话设计模式 - 程杰]()
- [深入解析策略模式 - 路易小七](https://www.cnblogs.com/lewis0077/p/5133812.html)
- [策略模式 - 嘟嘟碰碰叮叮当当](https://www.jianshu.com/p/4ffad05d0cce)
- [简说设计模式--策略模式 - JAdam](https://www.cnblogs.com/adamjwh/p/11011095.html)
- [策略模式 - 菜鸟教程](https://www.runoob.com/design-pattern/strategy-pattern.html)
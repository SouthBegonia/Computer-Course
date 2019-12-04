# 观察者模式

### 博文：
- [观察者模式 - SouthBegonia's Blog](https://www.cnblogs.com/SouthBegonia/p/11984014.html)

### 含义：定义了对象之间的一对多依赖关系，这样一来，当一个对象改变状态时，它的所有依赖者都会收到通知并且自动更新。又称为“发布-订阅模式”

### 实现过程：
- 理论性：创建一个主题对象及多个订阅者，**主题对象和订阅者之间形成一对多关系**，当主题发生变化时，调用通知事件函数，使其订阅者做出相应改变
- 比喻：居民订阅日报，报社每天将最新的报纸分发给订报者，订报者根据最新的报纸调整一天的形成，而没有订阅的人则无法享受该服务

### 优缺点：
- 优点：
	- 建立了 “主题-->多订阅者” 的**事件机制**
	- 使耦合双方依赖于抽象而不是具体（**抽象耦合**）
- 缺点：
	- 订阅者越多，主题通知用时越长，费时
	- 没有相应的机制让订阅者知道所订阅的对象是怎么发生变化的，仅仅知道变化了
	- 如果订阅者和主题对象间有循环依赖，可能导致系统崩溃

### 适用场景：
- 一个对象的改变将导致其他一个或多个对象也发生改变
- 一个对象必须通知其他对象，而并不知道这些对象是谁
- 触发反应机制

### 项目示例：

主题对象（布加拉提），订阅者（普罗修特、贝西），当布加拉提出现时，普罗修特和贝西做出各自反应：
```
// 主题接口:
// --------
interface Subject
{
    //添加/删除订阅者
    void Attach(Observer observer);
    void Detach(Observer observer);

    //通知事件
    void Notify();
}

// 具体主题:
// --------
class ConcreteSubject : Subject
{
    // 订阅者清单
    private List<Observer> observers = new List<Observer>();

    public void Attach(Observer obs)
    {
        observers.Add(obs);
    }

    public void Detach(Observer obs)
    {
        if (observers.Contains(obs))
            observers.Remove(obs);
    }

    public void Notify()
    {
        //主题改变则通知其所有订阅者进行变化
        Console.WriteLine("出现了野生布加拉提！");
        foreach (Observer o in observers)
            o.Update();
    }
}

// 抽象订阅者:
// ----------
abstract class Observer
{
    protected string name;

    public Observer(string name)
    {
        this.name = name;
    }

    // 各订阅者对通知事件的反应
    public abstract void Update();
}

// 具体订阅者:
// ----------
class ConcreteObserverA : Observer
{
    public ConcreteObserverA(string name) : base(name) { }

    public override void Update()
    {
        Console.WriteLine($"{name} 发动替身: \"The Grateful Dead！\"");
    }
}
class ConcreteObserverB : Observer
{
    public ConcreteObserverB(string name) : base(name) { }

    public override void Update()
    {
        Console.WriteLine($"{name} 发出呐喊：\"普罗修特大哥！\"");
    }
}

// 客户端:
// ------
class Client
{
    static void Main(string[] args)
    {
        //创建主题对象（布加拉提）
        ConcreteSubject Bucciarati = new ConcreteSubject();

        //创建订阅者（普罗修特、贝西）
        ConcreteObserverA Prosciutto = new ConcreteObserverA("普罗修特");
        ConcreteObserverB Pesci = new ConcreteObserverB("贝西");

        //订阅者订阅主题对象
        Bucciarati.Attach(Prosciutto);
        Bucciarati.Attach(Pesci);

        //主题对象通知事件（布加拉提出现）
        Bucciarati.Notify();

		/* OUT:
			出现了野生布加拉提！
			普罗修特 发动替身: "The Grateful Dead！"
			贝西 发出呐喊："普罗修特大哥！"
		*/
    }
}
```
### 备注：
除了上面的方法，C#中提供的 **委托事件机制** 也可较好实现观察者模式，该示例代码：[观察者模式示例_委托版 - SouthBegonia's Github](https://github.com/SouthBegonia/Computer-Course/blob/master/DesignPattern/ObserverPattern/Observer_1.cs)

### UML图

![](https://img2018.cnblogs.com/blog/1688704/201912/1688704-20191204165835141-694248369.png)

# 参考
- [大话设计模式 - 程杰]()
- [观察者模式 - 菜鸟教程](https://www.runoob.com/design-pattern/observer-pattern.html)
- [观察者模式详解 - C语言教程网](http://c.biancheng.net/view/1390.html)
- [简说设计模式--观察者模式 - JAdam](https://www.cnblogs.com/adamjwh/p/10913660.html)
# 装饰模式

### 博文：
- [装饰模式 - SouthBegonia's Blog](https://www.cnblogs.com/SouthBegonia/p/11995638.html)

### 含义：动态地给一个对象添加一些额外的职责，就增加功能来说，装饰模式比生成子类更为活跃。也可以说向一个现有的对象添加新的功能，同时又不改变其结构

### 实现过程：
- 理论性：创建多**装饰类**，用于**包装现有的类**，实现在保持类方法签名完整性的前提下，**提供了额外的功能**
- 比喻：穿衣是对人的装饰过程，从最底层的内衣、上下衣服、饰品，每一层都是在上一层的基础上进行装饰过程，即**不改变底层又添加了新功能**

### 优缺点：
- 优点：
	- 可以动态地**扩展一个实现类的功能**
	- 装饰类和被装饰类可以独立发展，而非相互耦合，即**把核心功能和修饰功能拆分**
- 缺点：
	- 由于核心是**多层次装饰**，某一层出问题检测费时，而且需要有**严格的装饰顺序**

### 适用场景：
- 扩展一个类的功能
- 动态增加、删除功能

### 项目示例：

对人物杰克（装饰对象）进行装饰，可装饰物有：T恤、垮裤、破球鞋
```
// 装饰对象：
// ---------
class Person
{
    private string name;

    public Person() { }
    public Person(string name) { this.name = name; }

    public virtual void Show()
    {
        Console.WriteLine($" 装扮的{name}");
    }
}

// 抽象服饰类 Decorator:
// --------------------
class Finery : Person
{
    //打扮的对象
    protected Person component;

    //打扮
    public void Decorator(Person component) { this.component = component; }

    public override void Show()
    {
        if (component != null)
            component.Show();
    }
}

// 具体服饰类:
// ----------
class TShirts : Finery
{
    public override void Show()
    {
        Console.Write("T恤 ");
        base.Show();
    }
}
class BigTrouser : Finery
{
    public override void Show()
    {
        Console.Write("垮裤 ");
        base.Show();
    }
}
class Sneakers:Finery
{
    public override void Show()
    {
        Console.Write("破球鞋 ");
        base.Show();
    }
}

// 客户端：
// -------
class Client
{
    static void Main()
    {
		//创建装饰对象：杰克
        Person jack = new Person("杰克");

        Console.WriteLine("第一种装扮:");

        // 创建装饰物:
        // ----------
        var shirts = new TShirts();
        var sneakers = new Sneakers();           
        var bigtrouser = new BigTrouser();

        // 装饰过程：
        // --------
        // 机理：B对象装饰A、C对象装饰B、D对象装饰C ..
        //      核心在于都执行了base.Show() 即Finery.Show()
        shirts.Decorator(jack);
        sneakers.Decorator(shirts);
        bigtrouser.Decorator(sneakers);

        // 打印
        bigtrouser.Show();

		/* OUT:
		   第一种装扮:
		   垮裤 破球鞋 T恤 装扮的杰克
		*/
    }
}
```

### UML图

![](https://img2018.cnblogs.com/blog/1688704/201912/1688704-20191206153859615-1816930573.png)

# 参考
- [大话设计模式 - 程杰]()
- [装饰模式 - 菜鸟教程](https://www.runoob.com/design-pattern/observer-pattern.html)
- [简说设计模式--装饰模式 - JAdam](https://www.cnblogs.com/adamjwh/p/9036358.html)
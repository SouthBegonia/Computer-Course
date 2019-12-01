**工厂模式**是创建型模式之一，其主要功能都是帮助我们把对象的实例化部分抽取了出来，**降低系统中代码耦合度**，增强了系统的**扩展性**，并**将对象的创建过程延迟到子类进行**

# 工厂模式

### 分类：
- 简单工厂模式（Simple Factory）：只有一个工厂，通过向工厂传参来选择工厂所要生产的产品
- 工厂方法模式（Factory Method）：允许多个工厂，但一个工厂只生产一种产品，通过不同的工厂类型来选择所要生产的产品
- 抽象工厂模式（Abstract Factory）：允许多个工厂，一个工厂允许生产多种产品，通过工厂实例的不同方法来选择所要生产的产品

### 博文 / Github源码：
- [工厂模式 - SouthBegonia's Blog](https://www.cnblogs.com/SouthBegonia/p/11967904.html)
- [工厂模式 - SouthBegonia's Github](https://github.com/SouthBegonia/Computer-Course/tree/master/DesignPattern/Factory%20Pattern)

# 简单工厂模式

### 含义：只有一个工厂类，客户端向工厂传递所需产品名，工厂生产产品交予客户

### 实现过程：

- 理论性：创建**产品的抽象类**做为产品基类，**产品类**（派生类）继承该基类并实现各自方法。**工厂类** 负责接收客户端传入的参数（产品名），根据参数选择对应产品类进行实例化，最终返回给客户端
- 比喻：客户去印刷厂印刷书籍，客户只需要告诉印刷厂其需求（书名、材质 ..），印刷厂根据该需求选择印刷对应的书籍，最终交予客户

### 优缺点：
- 优点：
	- 客户端无须知道所创建的具体产品类的创建细节，只需**将产品名参数传递到工厂类**即可实现创建并使用
	- 添加新类即可实现新产品的类，无需对客户端进行大改动
- 缺点：
	- 随着产品的增加，对应产品类数量增加，增加了系统复杂度
	- 新增加产品类都会修改工厂类，**违背 “开闭原则”** 
	- 由于工厂类集中了所有产品创建逻辑，一旦不能正常工作，整个系统都要受到影响

### 项目示例：
简单工厂模式实现加减乘除运算，工厂类OperationFactory 根据传入的运算符字符("+"、"-" ..)，自动选择实例化的运算类并返回，实现计算：

```
// 运算基类（抽象产品类）：
// --------------------
public class Operation
{
    public double NumberA { get; set; }
    public double NumberB { get; set; }

    public virtual double GetResult()
    {
        double result = 0;
        return result;
    }
}

// 运算符派生类（具体产品类）：
// ------------------------
class OperationAdd : Operation
{
    public override double GetResult()
    {
        double result = 0;
        result = NumberA + NumberB;
        return result;
    }
}
class OperationSub : Operation
{
    public override double GetResult()
    {
        double result = 0;
        result = NumberA - NumberB;
        return result;
    }
}
class OperationMul : Operation
{
    public override double GetResult()
    {
        double result = 0;
        result = NumberA * NumberB;
        return result;
    }
}
class OperationDiv : Operation
{
    public override double GetResult()
    {
        double result = 0;
        if (NumberB == 0)
            throw new Exception("除数不可为 0");
        result = NumberA / NumberB;
        return result;
    }
}

// 工厂类：
// ------
public class OperationFactory
{
    public static Operation CreateOperate(string operate)
    {
        //根据传入的参数operate选择实例化的类
        Operation oper = null;
        switch (operate)
        {
            case "+":
                oper = new OperationAdd();
                break;
            case "-":
                oper = new OperationSub();
                break;
            case "*":
                oper = new OperationMul();
                break;
            case "/":
                oper = new OperationDiv();
                break;
        }
        return oper;
    }
}

// 客户端：
// ------
class Test
{
    static void Main(string[] args)
    {
		//创建运算基类的对象，传入字符串到工厂类，返回对应实类的实例对象
        Operation oper;        
        oper = OperationFactory.CreateOperate("+");
        oper.NumberA = 4;  oper.NumberB = 2;
        double result = oper.GetResult();
        Console.WriteLine(result);		// 6

        oper = OperationFactory.CreateOperate("-");
        oper.NumberA = 4; oper.NumberB = 2;
        result = oper.GetResult();
        Console.WriteLine(result);		// 2

        oper = OperationFactory.CreateOperate("/");
        oper.NumberA = 4; oper.NumberB = 2;
        result = oper.GetResult();
        Console.WriteLine(result);		// 2
    }
}
```

### UML图

![](https://img2018.cnblogs.com/blog/1688704/201912/1688704-20191201214557029-1927579043.png)

# 工厂方法模式

### 含义：允许多个工厂，但一个工厂只生产一种产品，通过不同的工厂类型来选择所要生产的产品。也可以说：定义一个创建对象的接口，让其子类自己决定实例化哪一个工厂类，即使其创建过程延迟到子类进行

### 实现过程：
- 理论性：创建**抽象工厂接口**，创建**各类产品的工厂类**继承该接口并实现各自方法。客户端选择所需产品的工厂，对应工厂实现生产并返还
- 比喻：客户去印刷全彩书刊，需要找到对应的全彩书刊印刷厂，该工厂拥有印刷该类书籍的方法，因此可执行印刷功能并将产品交予客户

### 优缺点：
- 优点：
	- 用户只需关心产品对应工厂而无需知道创建细节、产品名
	- 添加新产品只需添加具体工厂类、产品类即可，可拓展性好，**符合 “开放封闭原则”**
	- 由于一个工厂只生产一种产品，因此也符合“单一职责原则”
- 缺点：
	- 随着产品的增加，对应工厂类、产品类数量增加，增加了系统复杂度

### 项目示例：
对上节简单工厂方法的项目示例做修改，实现工厂方法模式：抽象产品类、各运算类保持不变，添加抽象工厂接口，并由该接口派生出各类计算方法的工厂类，客户端通过工厂类即可实现计算功能

```
#region 上述的运算基类（抽象产品类） + 运算符派生类（具体产品类）
//...
#endregion

// 抽象工厂接口：
// -----------
interface IFactory
{
    Operation CreateOperation();
}

// 各运算工厂类：
// -----------
// 加法工厂
class AddFactory : IFactory
{
    public Operation CreateOperation()
    {
        return new OperationAdd();
    }
}
// 减法工厂
class SubFactory : IFactory
{
    public Operation CreateOperation()
    {
        return new OperationSub();
    }
}
// 乘法工厂
class MulFactory : IFactory
{
    public Operation CreateOperation()
    {
        return new OperationMul();
    }
}
// 除法工厂
class DivFactory : IFactory
{
    public Operation CreateOperation()
    {
        return new OperationDiv();
    }
}

// 客户端：
// ------
class Test
{
    static void Main(string[] args)
    {
		//用户选择产品对应的工厂进行生产
        IFactory operFactory = new AddFactory();
        Operation oper = operFactory.CreateOperation();
        oper.NumberA = 4;   oper.NumberB = 2;
        double result = oper.GetResult();		//6
    }
}
```

### UML图

![](https://img2018.cnblogs.com/blog/1688704/201912/1688704-20191201214611660-369839600.png)

# 抽象工厂模式

### 含义：允许多个工厂，一个工厂允许生产多种产品，通过工厂实例的不同方法来选择所要生产的产品。也可以说：提供一个创建一系列相关或相互依赖对象的接口，而无须指定它们具体的类

### 实现过程：
- 理论性：抽象产品接口->具体产品类，抽象工厂接口->具体工厂类，客户端创建工厂、选择生产产品
- 比喻：显示器（抽象产品接口）的产品有苹果显示器、戴尔显示器（具体产品类），主机的产品也有苹果和戴尔；生产电脑设备的工厂（抽象工厂接口）有苹果工厂和戴尔工厂（具体工厂类），客户可以选择苹果或者戴尔电脑工厂，再选择要生产该品牌的显示器或是主机

### 扩展：
- **产品族**：具有相同属性的同类型产品，如戴尔显示器、戴尔主机都属于戴尔
- **产品等级结构**：产品的继承结构，如产品抽象类（显示器），其具体产品类有戴尔显示器、苹果显示器，抽象类与产品类之间构成了产品等级结构

### 优缺点：
- 优点：
	- 将一个系列的产品族（戴尔的显示器、主机..）统一到对应工厂进行创建，便于客户端直接使用同一产品族的工厂进行生产操作
	- 较比与工厂方法模式，减少了工厂类和具体产品的类添加
- 缺点：
	- 产品族扩展困难（例如添加苹果ipad，则需要对产品的抽象、具体类修改，工厂的抽象、具体类修改）

### 项目示例：

采用抽象工厂模式实现苹果、戴尔电脑的生产工厂：创建两个**抽象产品接口**（显示器、主机），根据该接口实现**具体产品类**（苹果显示器、苹果主机、戴尔..）；创建**抽象工厂接口**（电脑工厂），根据该接口实现**具体工厂类**（苹果电脑工厂、戴尔电脑工厂）；最终在客户端进行工厂创建、生产产品

```
// 抽象产品类：
// ----------
// 抽象产品 - 显示器
interface IDisplay
{
    void Show();
}
// 抽象产品 - 主机
interface IMainFrame
{
    void Open();
}

// 具体产品类：
// ----------
// 具体产品 - 苹果显示器
class AppleDisplay : IDisplay
{
    public void Show()
    {
        Console.WriteLine("苹果显示器正常工作！");
    }
}
//具体产品 - 戴尔显示器
class DellDisplay : IDisplay
{
    public void Show()
    {
        Console.WriteLine("戴尔显示器正常工作！");
    }
}
// 具体产品 - 苹果主机
class AppleMainFrame : IMainFrame
{
    public void Open()
    {
        Console.WriteLine("苹果主机启动成功！");
    }
}
// 具体产品 - 戴尔主机
class DellMainFrame : IMainFrame
{
    public void Open()
    {
        Console.WriteLine("戴尔主机启动成功！");
    }
}

// 抽象工厂类：
// ----------
// 抽象电脑工厂
interface IComputerFactory
{
    // 生产一个显示器
    IDisplay ProduceADisplay();

    // 生产一个主机
    IMainFrame ProduceAMainFrame();
}

// 具体工厂类：
// ----------
// 具体工厂 - 苹果电脑工厂
class AppleComputerFactory:IComputerFactory
{
    public IDisplay ProduceADisplay()
    {
        return new AppleDisplay();
    }

    public IMainFrame ProduceAMainFrame()
    {
        return new AppleMainFrame();
    }
}
// 具体工厂 - 戴尔电脑工厂
class DellComputerFactory : IComputerFactory
{
    public IDisplay ProduceADisplay()
    {
        return new DellDisplay();
    }

    public IMainFrame ProduceAMainFrame()
    {
        return new DellMainFrame();
    }
}

// 客户端：
// ------
class Client
{
    static void Main()
    {
        //创建苹果电脑工厂
        IComputerFactory MyAppleFactory = new AppleComputerFactory();

        //生产苹果显示器
        IDisplay AppleDisplay = MyAppleFactory.ProduceADisplay();
        AppleDisplay.Show();		//苹果显示器正常工作！

        //创建戴尔电脑工厂
        IComputerFactory MyDellFactory = new DellComputerFactory();

        //生产戴尔主机
        IMainFrame DellMainFrame = MyDellFactory.ProduceAMainFrame();
        DellMainFrame.Open();		//戴尔主机启动成功！
    }
}
```

### UML图

![](https://img2018.cnblogs.com/blog/1688704/201912/1688704-20191201214625835-102639031.png)

# 参考
- [《大话设计模式》 - 程杰]()
- [（推荐）简单工厂模式 & 工厂方法模式 & 抽象工厂模式 - 秋风醉了](https://my.oschina.net/xinxingegeya/blog/1790817)
- [设计模式-简单工厂模式 - LouisvV](http://www.louisvv.com/archives/1539.html)
- [简单工厂模式、工厂方法模式与抽象工厂模式总结 - 小毛驴](https://zhuanlan.zhihu.com/p/38527016)
- [简单工厂模式 工厂方法模式 抽象工厂模式对比 - 假程序员](https://www.jianshu.com/p/f4e2246d7f59)
- [JAVA设计模式之工厂模式(简单工厂模式+工厂方法模式) - 炸斯特](https://blog.csdn.net/jason0539/article/details/23020989)
- [工厂模式 - 菜鸟教程](https://www.runoob.com/design-pattern/factory-pattern.html)
- [设计模式之三种工厂模式](https://learnku.com/articles/24372)
- [抽象工厂模式C# - 迷鹿](https://segmentfault.com/a/1190000020068097?utm_source=tag-newest)
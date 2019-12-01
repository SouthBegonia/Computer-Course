# 单例模式

### 博文：
- [单例模式 - SouthBegonia's Blog](https://www.cnblogs.com/SouthBegonia/p/11958875.html)

### 含义：
**保证一类仅有一个实例，并提供一个访问它的全局访问点**

### 优缺点：
- 优点：
	- 确保所有对象都访问一个实例
	- 节省内存，避免频繁地创建、销毁对象
	- 避免对共享资源的多重占用
- 缺点：
	- 违背了"单一职责原则"
	- 可扩展性差

### 实现过程：
1. 保证单一实例：创建private static类型的对象instance，其为空时才new实例化创建
2. 全局访问点：创建public类GetInstance()方法用于全局访问instance，并担当检测、new instance的责任

### 概念图：

### 代码实现：

```
//单例类：
class Singleton
{
	//私有化的构造函数
    private Singleton() { Console.WriteLine("This is a SingleObject"); }

	//单一的实例  
    private static Singleton instance;  	   
 
	//全局访问点
    public  static Singleton GetInstance()
    {
		//如果实例为空，则new一个新实例，否则返回已有的实例
        if (instance == null)
        {
            instance = new Singleton();
            Console.WriteLine("Create a new Instance");
        }
        else
        {
            Console.WriteLine("Get a Instance");                           
        }
        return instance;
    }
}

//测试类：
class Program
{
    static void Main(string[] args)
    {
        Singleton s1 =  Singleton.GetInstance2();
        Singleton s2 =  Singleton.GetInstance2();

		/* OUT:
		 This is a SingleObject
		 Create a new Instance
		 Get a Instance
		*/
    }
}
```

# 单例模式分类

根据new关键字**实例化单例的先后顺序**，可把单例模式分为**饿汉式单例、懒汉式单例**：

**饿汉式**：开始时就实例化instance
- 优点：线程安全（因为instance是static类型）
- 缺点：不管是否使用对象，开始时就实例化并占用了空间。即空间换时间

**懒汉式**：需要时才实例化instance
- 优点：资源利用率高。即时间换空间
- 缺点：多线程下存在隐患
	

```
//饿汉式：开始时就实例化instance
public class Singleton 
{  
	private Singleton (){} 
    private static Singleton instance = new Singleton();  
     
    public static Singleton getInstance() 
	{  
    	return instance;  
    }  
}

//懒汉式：需要时才实例化instance
//上一段代码同为懒汉式
public class Singleton 
{   
	private Singleton (){} 
    private static Singleton instance;  
     
    public static Singleton getInstance() 
	{  
    	if (instance == null) 
        	instance = new Singleton();  
    	return instance;  
    }  
}
```




# 多线程中的单例

在上述懒汉式单例中，若多个线程同时进行到`if (instance == null)`，则全部检测通过，也就会造成多线程下创建了多个实例，即 **多线程不安全**。因此需要对多线程下的单例模式进行调整，即实现**线程安全**。实现方法为 **lock机制**：

```
//饿汉式 + 线程安全 + 单锁
class Singleton
{
    private Singleton() {}
    private static Singleton instance;       
  	
	//静态只读对象用于辅助实现lock
    private static readonly object locker = new object();

    public static Singleton GetInstance()
    {
		//lock机制：确保一个线程位于该临界区时，其他线程不可再进入，直至当前线程访问完毕
        lock (locker)
        {
            if (instance == null)
                instance = new Singleton();
        }
        return instance;
    }
}
```

虽然加了lock锁实现了懒汉模式下的线程安全，但我们不难发现一个问题：若已经存在instance实例，在执行Getinstance()时还有必要lock{}吗？显然不需要，因此为了**节省lock的空间**，采用更优解法：**双重锁定（Double-Check-Locking）**：
```
//饿汉式 + 线程安全 + 双锁
class Singleton
{
    private Singleton() {}
    private static Singleton instance;       
  	
	//静态只读对象用于辅助实现lock
    private static readonly object locker = new object();

    public static Singleton GetInstance()
    {
		//首次检验：是否需要加锁
		if(instance == null)
		{
			//为当前线程加锁
	        lock (locker)
	        {
				//再次检验：避免当前线程实例化instance后，下一个线程再次实例
	            if (instance == null)
	                instance = new Singleton();
	        }
	        return instance;
		}
    }
}
```

# 参考
- [大话设计模式 - 程杰]()
- [单例模式的优缺点和使用场景 - 一介书生](https://www.cnblogs.com/restartyang/articles/7770856.html)
- [单例模式 - 菜鸟教程](https://www.runoob.com/design-pattern/singleton-pattern.html)
- [单例模式(懒汉式和饿汉式区别) - QALink](https://blog.csdn.net/qq_37904799/article/details/81807954)
- [C#Lock机制 - 戎夏不姓夏](https://blog.csdn.net/qq_39025293/article/details/84655433)
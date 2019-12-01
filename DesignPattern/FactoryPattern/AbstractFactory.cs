using System;

namespace Test
{
    #region 抽象产品类
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
    #endregion

    #region 具体产品类
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
    #endregion


    #region 抽象工厂类
    // 抽象电脑工厂
    interface IComputerFactory
    {
        // 生产一个显示器
        IDisplay ProduceADisplay();

        // 生产一个主机
        IMainFrame ProduceAMainFrame();
    }
    #endregion

    #region 具体工厂类
    // 具体工厂 - 苹果电脑工厂
    class AppleComputerFactory : IComputerFactory
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
    #endregion


    #region 客户端
    class Client
    {
        static void Main()
        {
            //创建苹果电脑工厂
            IComputerFactory MyAppleFactory = new AppleComputerFactory();

            //生产出苹果显示器
            IDisplay AppleDisplay = MyAppleFactory.ProduceADisplay();
            AppleDisplay.Show();


            //创建戴尔电脑工厂
            IComputerFactory MyDellFactory = new DellComputerFactory();

            //生产出戴尔主机
            IMainFrame DellMainFrame = MyDellFactory.ProduceAMainFrame();
            DellMainFrame.Open();


            Console.Read();
        }
    }
    #endregion
}
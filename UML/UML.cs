using System;

// 类与接口 + 继承与实现接口 + 依赖关系：
// ---------------------------------
namespace UML_0
{
    class Oxygen{ }

    class Water{ }

    class Animal
    {
        private string name { get; set; }

        public virtual void Live(Oxygen oxygen,Water water)
        {
            Console.WriteLine("动物生存！");
        }

        protected virtual void Reproduce()
        {
            Console.WriteLine("动物繁殖！");
        }

        public virtual void Die()
        {
            Console.WriteLine("动物死亡！");
        }      
    }

    class Bird : Animal
    {
        public override void Live(Oxygen oxygen, Water water)
        {
            Console.WriteLine("鸟类生存！");
        }

        protected override void Reproduce()
        {
            Console.WriteLine("鸟类繁殖！");
        }

        public override void Die()
        {
            Console.WriteLine("鸟类死亡！");
        }
    }

    interface IFly
    {
        void Fly();
    }

    class Hawk : Bird, IFly
    {
        public void Fly()
        {
            Console.WriteLine("雄鹰起飞！");
        }
    }

    //class Client
    //{
    //    static void Main(string[] args)
    //    {
    //        Animal animal = new Animal();
    //        Oxygen oxygen = new Oxygen();
    //        Water water = new Water();
    //        animal.Live(oxygen, water);
    //        animal.Die();

    //        Bird bird = new Bird();
    //        bird.Live(oxygen, water);
    //        bird.Die();

    //        Hawk hawk = new Hawk();
    //        hawk.Fly();

    //        Console.Read();
    //    }
    //}
}


// 关联关系:
// --------
namespace UML_1
{
    class Climate
    {
        public Climate(string cli) { climateNow = cli; }
        public string climateNow;
    }
        
    class Penguin
    {
        public Penguin() { }
        public Penguin(Climate climate) { this.climate = climate; }
        private Climate climate;

        public void Show()
        {
            if (climate.climateNow == "hot")
                Console.WriteLine("企鹅觉得天气太热了");
            else if (climate.climateNow == "cool")
                Console.WriteLine("企鹅觉得天气很合适");
        }

        public void ClimateChange(string cli)
        {
            climate.climateNow = cli;
        }
    }

    //class Client
    //{
    //    static void Main()
    //    {
    //        Climate climate = new Climate("hot");
    //        Penguin penguin = new Penguin(climate);
    //        penguin.Show();

    //        penguin.ClimateChange("cool");
    //        penguin.Show();
            
    //        Console.Read();
    //    }
    //}
}


// 聚合关系：
// --------
namespace UML_2
{
    class WideGoose
    {
        public void Fly()
        {
            Console.WriteLine("在飞行！");
        }
    }

    class WideGooseAggregate
    {
        WideGoose[] wideGooses = new WideGoose[5];

        public void VFlight()
        {
            Console.WriteLine("大雁群在 V字飞行！");
        }

        public void RectilinearFight()
        {
            Console.WriteLine("大雁群在 直线飞行！");
        }
    }
}


// 组合关系：
// --------
namespace UML_3
{
    class Wing
    {

    }

    class Bird
    {
        public Bird() { }
        public Bird(Wing wing) { birdWing = wing; }
        private Wing birdWing;

        public void Fly()
        {
            if (birdWing != null)
                Console.WriteLine("鸟在展翅翱翔！");
            else
                Console.WriteLine("鸟的双翼受伤了！");
        }

        public void Recover(Wing wing)
        {
            Console.WriteLine("鸟的翅膀痊愈了！");
            birdWing = wing;
        }
    }

    //class Client
    //{
    //    static void Main()
    //    {          
    //        Bird bird = new Bird();
    //        bird.Fly();

    //        Wing wing = new Wing();
    //        bird.Recover(wing);
    //        bird.Fly();

    //        Console.Read();
    //    }
    //}
}
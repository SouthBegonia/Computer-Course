using System;

namespace SingleObject
{
    class Singleton
    {
        private Singleton() { Console.WriteLine("This is a SingleObject"); }
        private static Singleton instance;       
      
        private static readonly object locker = new object();

        public int data = 10;
        public string str = "Name";

        //懒汉模式
        public  static Singleton GetInstance()
        {
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

        //线程安全，单锁（都要检验lock
        public static Singleton GetInstance2()
        {
            lock (locker)
            {
                Console.WriteLine("Pass");
                if (instance == null)
                {
                    Console.WriteLine("Create a new Instance");
                    instance = new Singleton();
                }
            }
            return instance;
        }

        //线程安全，双锁（空才检验lock
        public static Singleton GetInstance3()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if(instance==null)
                    {
                        Console.WriteLine("Create a new Instance");
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance2();
            Singleton s2 = Singleton.GetInstance2();
            s1.data = 20;
            s2.data = 30;
            s1.str = "Hi";
            s2.str = "OK";

            Console.WriteLine("\ndata ={0} {1} ,str = {2} {3}", s1.data, s2.data, s1.str, s2.str);
            Console.ReadKey();
        }
    }
}

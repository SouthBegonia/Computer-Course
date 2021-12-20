using System;

namespace CsharpExam
{
    public class _20211220_接口练习
    {
        interface ICreature
        {
            int Age { get; set; }

            void eat();
        }

        interface IHuman : ICreature
        {
            string Name { get; set; }

            void talk();
        }

        class Me : IHuman
        {
            public Me()
            {
                Console.WriteLine("[Start Create Me...]");
            }

            public Me(string name, int age) : this()
            {
                Console.WriteLine($"[Create : name={name}, age={age}]");
                Age = age;
                Name = name;
            }

            public int Age { get; set; }

            public void eat()
            {
                Console.WriteLine("eat.");
            }

            public string Name { get; set; }

            public void talk()
            {
                Console.WriteLine("talk.");
            }
        }
        
        static void Main()
        {
            Me me = new Me();
            me.eat();
            me.talk();

            Me me2 = new Me("Joker", 18);
        }
    }
}
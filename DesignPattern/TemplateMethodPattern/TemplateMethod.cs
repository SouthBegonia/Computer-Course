using System;

namespace TemplateMethod
{
    // 试题（抽象模板）：
    // ----------------
    class TestPaper
    {
        // 问题（模板方法）
        public void TestQuestion_1()
        {
            Console.WriteLine("问题1：谁是世界上最好的语言?   A.PHP    B.Java    C.C#");
            Console.WriteLine("选择：" +Ans_1());
        }
        public void TestQuestion_2()
        {
            Console.WriteLine("问题2：上一个说无敌的人在哪？  A.天上   B.海里    C.JO护车底");
            Console.WriteLine("选择：" + Ans_2());
        }
        public void TestQuestion_3()
        {
            Console.WriteLine("问题3：谁是天下第一？          A.P3P    B.P4G     C.P5R");
            Console.WriteLine("选择：" + Ans_3());
        }

        // 答案（抽象行为）
        protected virtual string Ans_1()
        {
            return "";
        }
        protected virtual string Ans_2()
        {
            return "";
        }
        protected virtual string Ans_3()
        {
            return "";
        }
    }

    class Student_1 : TestPaper
    {
        // 不同学生的答案（重写抽象行为方法）
        protected override string Ans_1()
        {
            return "B";
        }
        protected override string Ans_2()
        {
            return "A";
        }
        protected override string Ans_3()
        {
            return "C";
        }
    }

    class Student_2 : TestPaper
    {
        protected override string Ans_1()
        {
            return "A";
        }
        protected override string Ans_2()
        {
            return "C";
        }
        protected override string Ans_3()
        {
            return "B";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("学生A的试卷：");
            TestPaper stu_1 = new Student_1();
            stu_1.TestQuestion_1();
            stu_1.TestQuestion_2();
            stu_1.TestQuestion_3();

            Console.WriteLine("\n学生B的试卷：");
            TestPaper stu_2 = new Student_2();
            stu_2.TestQuestion_1();
            stu_2.TestQuestion_2();
            stu_2.TestQuestion_3();

            Console.Read();
        }
    }
}
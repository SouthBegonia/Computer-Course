using System;
using System.Collections.Generic;

namespace Solution
{
    class People : IComparable<People>
    {
        public People(string name, int age) { Name = name;Age = age; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(People other)
        {
            if (this.Name != other.Name)
            {
                return this.Name.CompareTo(other.Name);
            }
            else if (this.Age != other.Age)
            {
                return this.Age.CompareTo(other.Age);
            }
            else return 0;
        }
    }

    class PeopleComparer : IComparer<People>
    {
        public int Compare(People x, People y)
        {
            if (x.Name != y.Name)
            {
                return x.Name.CompareTo(y.Name);
            }
            else if (x.Age != y.Age)
            {
                return x.Age.CompareTo(y.Age);
            }
            else return 0;
        }
    }

    class Solution
    {
        public static int PeopleComparison(People p1, People p2)
        {
            if (p1.Name != p2.Name)
            {
                return p1.Name.CompareTo(p2.Name);
            }
            else if (p1.Age != p2.Age)
            {
                return p1.Age.CompareTo(p2.Age);
            }
            else return 0;
        }

        public static void Print(List<People> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Name} { item.Age}");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            List<People> peopleList = new List<People>();
            peopleList.Add(new People("张三", 22));
            peopleList.Add(new People("张三", 24));
            peopleList.Add(new People("李四", 18));
            peopleList.Add(new People("王五", 16));
            peopleList.Add(new People("王五", 30));

            // ---------------------------------------------------------------------
            // Way1: 重写CompareTo方法，需要People类继承IComparable<>，实现CompareTo()
            // OUTPUT:
            //      李四 18
            //      王五 16
            //      王五 30
            //      张三 22
            //      张三 24
            peopleList.Sort();
            Print(peopleList);

            // -----------------------------------------------------------------------------
            // Way2: 实现Comparer方法，需要创建PeopleComparer类并继承IComparer<>，实现Compare()
            // OUTPUT:
            //      李四 18
            //      王五 16
            //      王五 30
            //      张三 22
            //      张三 24
            peopleList.Sort(new PeopleComparer());
            Print(peopleList);

            // ----------------------------------------
            // Way3: 用Lambda表达式实现Comparison委托方法
            // OUTPUT:
            //      张三 24
            //      张三 22
            //      王五 30
            //      王五 16
            //      李四 18
            peopleList.Sort((p1, p2) =>
            {
                if (p1.Name != p2.Name)
                {
                    return p2.Name.CompareTo(p1.Name);
                }
                else if (p1.Age != p2.Age)
                {
                    return p2.Age.CompareTo(p1.Age);
                }
                else return 0;
            });
            Print(peopleList);

            // ---------------------------
            // Way4: 实现Comparison泛型委托方法    
            // Comparison原型：public delegate int Comparison<in T>(T x, T y);
            // OUTPUT:
            //      李四 18
            //      王五 16
            //      王五 30
            //      张三 22
            //      张三 24
            Comparison<People> MyComparison = PeopleComparison;
            peopleList.Sort(MyComparison);
            Print(peopleList);

            Console.Read();
        }
    }
}
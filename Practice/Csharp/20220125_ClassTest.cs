using System;

namespace CsharpExam
{
    public class _20220125_ClassTest
    {
        // static void Main()
        // {
        //     Student st = new Student(18, "Joker");
        // }

        abstract class Person
        {
            public string Name;

            public Person(string Name)
            {
                this.Name = Name;
                Console.WriteLine($"Init Person.  Name={Name}");
            }
        }

        sealed class Student : Person
        {
            public int Age;

            public Student(int Age, string Name) : base(Name)
            {
                this.Age = Age;
                Console.WriteLine($"Init Student.  Name={Name}, Age={Age}");
            }
        }
    }
}
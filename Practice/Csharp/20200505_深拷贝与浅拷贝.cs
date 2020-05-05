using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DesignPattern
{
    class Prototype
    {
        [Serializable]
        public class Student : ICloneable
        {
            public string Name { get; set; } = "xxx";

            public int Age { get; set; } = 0;

            /// <summary>
            /// 深拷贝：新建对象实现克隆
            /// </summary>
            /// <returns></returns>
            public Student NewClone()
            {
                return new Student() { Age = this.Age, Name = this.Name };
            }

            /// <summary>
            /// 浅拷贝：实现ICloneable接口
            /// </summary>
            /// <returns></returns>
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        [Serializable]
        public class School : ICloneable
        {
            // 尽管string属于引用类型，但是由于该引用类型的特殊性，Object.MemberwiseClone方法仍旧为他创建了副本，
            // 也就是说，在浅拷贝过程中，我们应该将 **字符串** 看成 **值类型**
            // 
            // String 对象称为不可变（只读），因为其值在创建后无法修改。 用于修改 String 对象的方法实际上会返回一个包含修改的新 String 对象
            public string Name { get; set; } = "init";

            public int Number { get; set; } = -1;

            // 注意：此处student是一个 引用类型，但其内的 值类型将以 引用类型的形式进行拷贝
            public Student Student { get; set; }

            /// <summary>
            /// 深拷贝：新建对象实现克隆，如果属性是引用类型，需要一层层new赋值，直到属性是值类型为止
            /// </summary>
            /// <returns></returns>
            public School NewClone()
            {
                return new School()
                {
                    Name = this.Name,
                    Number = this.Number,
                    Student = this.Student.NewClone()
                };
            }

            /// <summary>
            /// 浅拷贝：实现ICloneable接口
            /// </summary>
            /// <returns></returns>
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        public static class HelperTools
        {
            /// <summary>
            /// 深拷贝：序列化
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="source"></param>
            /// <returns></returns>
            public static T SerializableClone<T>(T source)
            {
                if (!typeof(T).IsSerializable)
                {
                    throw new ArgumentException("The type must be serializable.", source.GetType().ToString());
                }
                if (Object.ReferenceEquals(source, null))
                {
                    return default(T);
                }
                IFormatter formatter = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    formatter.Serialize(ms, source);
                    ms.Seek(0, SeekOrigin.Begin);
                    return (T)formatter.Deserialize(ms);
                }
            }

            /// <summary>
            /// 浅拷贝：反射
            /// </summary>
            /// <param name="t"></param>
            /// <returns></returns>
            public static T PropertyClone<T>(T t)
            {
                if (Object.ReferenceEquals(t, null))
                {
                    return default(T);
                }
                Type type = t.GetType();
                PropertyInfo[] propertyInfos = type.GetProperties();
                Object obj = Activator.CreateInstance<T>();
                Object p = type.InvokeMember("", BindingFlags.CreateInstance, null, t, null);
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    if (propertyInfo.CanWrite)
                    {
                        object value = propertyInfo.GetValue(t, null);
                        propertyInfo.SetValue(obj, value, null);
                    }
                }
                return (T)obj;
            }
        }


        public static void ShowSchoolInfo(School school)
        {
            Console.WriteLine("学校名：{0}, 学校编号：{1}, 学生名字:{2}, 学生年龄：{3}", school.Name, school.Number, school.Student.Name, school.Student.Age);
        }

        public static void Run()
        {
            School school = new School()
            {
                Name = "秀尽学院",
                Number = 0,
                Student = new Student()
                {
                    Name = "Joker",
                    Age = 18
                }
            };
            Console.WriteLine("--------原始对象");
            ShowSchoolInfo(school);

            Console.WriteLine("\n--------深拷贝方法1：序列化");
            School serSchool = HelperTools.SerializableClone(school);
            serSchool.Name = "序列化  ";
            serSchool.Number = 1;
            serSchool.Student.Name = "Skull";
            serSchool.Student.Age = 20;
            ShowSchoolInfo(serSchool);
            ShowSchoolInfo(school);

            Console.WriteLine("\n--------深拷贝方法2：新建对象");
            School newSchool = (School)school.NewClone();
            newSchool.Name = "new对象 ";
            newSchool.Number = 2;
            newSchool.Student.Name = "Panther";
            newSchool.Student.Age = 22;
            ShowSchoolInfo(newSchool);
            ShowSchoolInfo(school);


            Console.WriteLine("\n--------浅拷贝方法1：属性反射");
            School proSchool = HelperTools.PropertyClone(school);
            proSchool.Name = "反射    ";
            proSchool.Number = 3;
            proSchool.Student.Name = "Fox";
            proSchool.Student.Age = 21;
            ShowSchoolInfo(proSchool);
            ShowSchoolInfo(school);

            Console.WriteLine("\n--------浅拷贝2：克隆接口");
            School cloneSchool = (School)school.Clone();
            cloneSchool.Name = "克隆    ";
            cloneSchool.Number = 4;
            cloneSchool.Student.Name = "Queen";
            cloneSchool.Student.Age = 23;
            ShowSchoolInfo(cloneSchool);
            ShowSchoolInfo(school);

            Console.ReadLine();
        }
    }
}

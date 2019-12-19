using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    #region 派生自 Sytem.SystemException 的异常类
    class SystemException
    {
        // IndexOutOfRangeException
        // -------------------------
        public void Test_1()
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            try
            {
                arr[5] = 6;     //错误：索引超出数组范围
            }
            catch (IndexOutOfRangeException e1)
            {
                Console.WriteLine("Exception caught: {0}", e1);
            }
            finally
            {
                Console.WriteLine("Done!");
            }
        }

        // ArrayTypeMismatchException
        // ---------------------------
        public void Test_2()
        {
            string[] names = { "Dog", "Cat", "Fish" };
            Object[] objs = (Object[])names;

            try
            {
                objs[2] = "Elephant";   //正确
            }
            catch(ArrayTypeMismatchException ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
            }

            try
            {
                objs[2] = 11;           //错误：类型不匹配
            }
            catch(ArrayTypeMismatchException ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
            }
            finally
            {
                Console.WriteLine("Done!");
            }
        }

        // NullReferenceException
        // -----------------------
        public void Test_3()
        {
            EmptyClass emptyClass_1 = new EmptyClass();
            EmptyClass emptyClass_2 = null;

            try
            {
                emptyClass_1.EmptyFunc();   //正确
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
            }

            try
            {
                emptyClass_2.EmptyFunc();   //错误：引用了空对象
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
            }
            finally
            {
                Console.WriteLine("Done!");
            }
        }

        // DivideByZeroException
        // ----------------------
        public void Test_4()
        {
            int num = 10;
            int temp;

            try
            {
                temp = num / 0;     //错误：除零
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
            }
            finally
            {
                Console.WriteLine("Done!");
            }
        }

        // InvalidCastException
        // --------------------
        public void Test_5()
        {
            bool flag = false;

            try
            {
                IConvertible conv = flag;
                Char ch = conv.ToChar(null);    //错误：类型转换错误
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
            }
            finally
            {
                Console.WriteLine("Done!");
            }
        }

        // OutOfMemoryException
        // ---------------------
        public void Test_6()
        {
            StringBuilder stringBuilder = new StringBuilder(12, 12);
            stringBuilder.Append("hello world");

            try
            {
                stringBuilder.Insert(0, "say ", 1);     //错误：内存空间不足
                Console.WriteLine(stringBuilder);
            }
            catch(OutOfMemoryException ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
            }
            finally
            {
                Console.WriteLine("Done!");
            }
        }

        // StackOverflowException
        // -----------------------
        public void Test_7()
        {
            bool tag = true;

            try
            {
                while (tag)
                    Test_7();       //错误：无限递归导致栈溢出
            }
            catch(StackOverflowException ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
            }
            finally
            {
                Console.WriteLine("Done!");
            }
        }
    }

    class EmptyClass
    {
        public void EmptyFunc()
        {
            Console.WriteLine("This is EmptyFunc");
        }
    }
    #endregion


    #region 用户自定义的异常类
    class UserDefinedException
    {
        public void UserTest()
        {
            People people = new People();

            try
            {
                people.SetAge(20);      //正确：年龄合法
                people.ShowAge();

                people.SetAge(-1);      //错误：年龄不可为负
                people.ShowAge();
            }
            catch (IllegalAgeException ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
            }
            finally
            {
                Console.WriteLine("Done!");
            }
        }
    }

    class IllegalAgeException : ApplicationException
    {
        public IllegalAgeException(string message) : base(message)
        {

        }
    }

    class People
    {
        private int _age = 10;

        public void SetAge(int age)
        {
            if (age < 0 || age > 120)
                throw new IllegalAgeException("The Age is illegal");
            else _age = age;
        }

        public void ShowAge()
        {
            Console.WriteLine("Age : " + _age);
        }
    }
    #endregion

    // 客户端
    // ------
    class Client
    {
        static void Main()
        {
            //SystemException se = new SystemException();
            //se.Test_1();
            //se.Test_2();

            UserDefinedException user = new UserDefinedException();
            user.UserTest();

            Console.Read();
        }
    }
}
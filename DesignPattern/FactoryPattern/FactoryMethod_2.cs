using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    // 抽象产品接口
    public interface IUser
    {
        void Insert(User user);
        User GetUser(int id);
    }

    // 具体产品类
    public class SqlserverUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在SQL Server中给User表添加一条记录");
        }

        public User GetUser(int id)
        {
            Console.WriteLine("在SQL Server中根据ID得到User表一条记录");
            return null;
        }
    }
    public class AccessUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在Access 中给User表添加一条记录");
        }

        public User GetUser(int id)
        {
            Console.WriteLine("在Access 中根据ID得到User表一条记录");
            return null;
        }
    }


    // 抽象工厂接口
    public interface IFactory
    {
        IUser CreateUser();
    }
    // 具体工厂类
    public class SqlServerFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new SqlserverUser();
        }
    }
    public class AccessFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new AccessUser();
        }
    }


    // 客户端
    class Test
    {
        static void Main()
        {
            User user = new User();
            IFactory factory = new SqlServerFactory();

            IUser iu = factory.CreateUser();

            iu.Insert(user);
            iu.GetUser(1);

            Console.Read();
        }
    }
}
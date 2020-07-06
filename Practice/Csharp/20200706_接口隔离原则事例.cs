using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 接口隔离原则事例1
/// </summary>
namespace CsharpExam
{
    class Progrm
    {
        static void Main()
        {
            var driver = new Driver(new Car());
            driver.Drive();
        }
    }

    class Driver
    {
        private IVehicle _vehicle;
        public Driver(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Drive()
        {
            _vehicle.Run();
        }
    }

    interface IVehicle
    {
        void Run();
    }

    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is running ...");
        }
    }

    class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is running ...");
        }
    }

    interface IWeapon
    {
        void Fire();
    }

    interface ITank : IVehicle, IWeapon
    {

    }

    class LightTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom");
        }

        public void Run()
        {
            Console.WriteLine("ka ka ka ...");
        }
    }

    class MediumTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!");
        }

        public void Run()
        {
            Console.WriteLine("ka! ka! ka! ...");
        }
    }

    class HeavyTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!");
        }

        public void Run()
        {
            Console.WriteLine("ka!! ka!! ka!! ...");
        }
    }
}

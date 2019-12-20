using System;
using System.Collections.Generic;

namespace Program
{
    class Hero
    {
        public int _id;
        public float _currentHp;
        public float _maxHp;
        public float _attack;
        public float _defence;

        public Hero(int id, float maxHp, float attack, float defence)
        {
            _id = id;
            _maxHp = maxHp;
            _currentHp = _maxHp;
            _attack = attack;
            _defence = defence;
        }
    }

    class Client
    {
        static void Main()
        {
            List<Hero> heroes = new List<Hero>();
            heroes.Add(new Hero(1, 1000f, 50f, 100f));
            heroes.Add(new Hero(2, 1200f, 20f, 125f));
            heroes.Add(new Hero(3, 800f, 100f, 128f));
            heroes.Add(new Hero(4, 600f, 55f, 120f));
            heroes.Add(new Hero(5, 2000f, 5f, 110f));
            heroes.Add(new Hero(6, 3000f, 60f, 105f));

            // Comparison<T>泛型委托
            SortHeros(heroes, delegate (Hero Obj, Hero Obj2)
             {
                 return Obj._id.CompareTo(Obj2._id);
             }, "\n-----------------\n按英雄的ID排序：");

            SortHeros(heroes, delegate (Hero Obj, Hero Obj2)
            {
                return Obj._maxHp.CompareTo(Obj2._maxHp);
            }, "\n-----------------\n按英雄的MaxHp排序：");

            SortHeros(heroes, delegate (Hero Obj, Hero Obj2)
            {
                return Obj._attack.CompareTo(Obj2._attack);
            }, "\n-----------------\n按英雄的Attack排序：");

            SortHeros(heroes, delegate (Hero Obj, Hero Obj2)
            {
                return Obj._defence.CompareTo(Obj2._defence);
            }, "\n-----------------\n按英雄的Defence排序：");

            Console.Read();
        }

        public static void SortHeros(List<Hero> targets, Comparison<Hero> sortOrder, string orderTitle)
        {
            Hero[] heroes = targets.ToArray();
            Array.Sort(heroes, sortOrder);
            Console.WriteLine(orderTitle);

            Console.WriteLine("ID   MaxHp   Attack  Defence");        
            foreach (var t in heroes)
            {           
                Console.WriteLine($"{t._id}     {t._maxHp}     {t._attack}     {t._defence}");
            }
        }
    }
}
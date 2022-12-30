using System;
using System.Collections;

//迭代器模式
namespace IteratorPattern
{
    /// <summary>
    /// 抽象 迭代器
    /// </summary>
    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    /// <summary>
    /// 具体 迭代器
    /// </summary>
    public class ConcreteIterator : Iterator
    {
        private ConcreteAggregate _aggregate;
        private int _current = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this._current = 0;
            this._aggregate = aggregate;
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        public override bool IsDone()
        {
            return _current >= _aggregate.Count - 1;
        }
    }

    /// <summary>
    /// 抽象 集合
    /// </summary>
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    /// <summary>
    /// 具体 集合
    /// </summary>
    public class ConcreteAggregate : Aggregate
    {
        private ArrayList _items = new ArrayList();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }

    public class Client
    {
        static void Main()
        {
            //创建 具体集合
            ConcreteAggregate aggregate = new ConcreteAggregate
            {
                [0] = "Item A",
                [1] = "Item B",
                [2] = "Item C",
                [3] = "Item D"
            };

            //创建 具体迭代器
            //对同一个aggregate集合，可以实现不同迭代器进行迭代
            ConcreteIterator iterator = new ConcreteIterator(aggregate);
            Console.WriteLine($"iterator : CurrentItem={iterator.CurrentItem()}  IsDone={iterator.IsDone()}\n");

            var item = iterator.First();
            while (item != null)
            {
                Console.WriteLine($"iterator  item={item}");
                item = iterator.Next();
            }

            Console.WriteLine($"\niterator : CurrentItem={iterator.CurrentItem()}  IsDone={iterator.IsDone()}");
        }
    }
}
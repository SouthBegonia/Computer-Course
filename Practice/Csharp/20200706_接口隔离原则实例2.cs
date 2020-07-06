using System;
using System.Collections;

namespace IspExample2
{
    class Program
    {
        static void Main()
        {
            int[] nums1 = { 1, 2, 3, 4, 5 };
            ArrayList nums2 = new ArrayList { 1, 2, 3, 4, 5 };

            Console.WriteLine(Sum(nums1));
            Console.WriteLine(Sum(nums2));

            var roc = new ReadOnlyCollection(nums1);
            //foreach(var n in roc)
            //    Console.WriteLine(n);

            var nums3 = new ReadOnlyCollection(nums1);
            Console.WriteLine(Sum(nums3));
        }

        static int Sum(IEnumerable nums)
        {
            int sum = 0;

            // 仅用于迭代，因此可以使用IEnumerable
            foreach (var n in nums)
            {
                sum += (int)n;
            }
            return sum;
        }
    }

    /// <summary>
    /// 只能被迭代，不可被添加、清除元素的集合
    /// </summary>
    class ReadOnlyCollection : IEnumerable
    {
        private int[] _array;
        public ReadOnlyCollection(int[] array)
        {
            _array = array;
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        /// 迭代器
        /// </summary>
        public class Enumerator : IEnumerator
        {
            private ReadOnlyCollection _collection;
            private int _head;
            public Enumerator(ReadOnlyCollection collection)
            {
                _collection = collection;
                _head = -1;
            }

            public object Current
            {
                get
                {
                    object o = _collection._array[_head];
                    return o;
                }
            }

            public bool MoveNext()
            {
                if (++_head < _collection._array.Length)
                {
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                _head = -1;
            }
        }
    }
}

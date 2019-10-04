using System;

//数组模拟实现队列
namespace ArrayQueue
{
    class Program
    {
        int[] arr = new int[5];
        int queueSize = 0;
        int start = 0;
        int end = 0;

        void Main(string[] args)
        {           
            Program p = new Program();
            int num;
            while (true)
            {
                Console.WriteLine("1.Push  2.Poll");
                num = int.Parse(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter a number:");
                            int input = int.Parse(Console.ReadLine());
                            p.Push(input);
                            p.DisplayInformation();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Poll={0}", p.Poll());
                            p.DisplayInformation();
                            break;
                        }
                    default:
                        Console.WriteLine("Input Error!");
                        break;
                }
            }          
        }

        public void Push(int num)
        {
            if (queueSize == arr.Length)
                throw new ArgumentException("The Queue is full!");
            queueSize++;
            arr[end] = num;
            end = NextIndex(arr.Length, end);
        }

        public int Poll()
        {
            if (queueSize == 0)
                throw new ArgumentException("The Queue is empty!");
            queueSize--;
            int temp = start;
            start = NextIndex(arr.Length, start);
            return arr[temp];
        }

        public int NextIndex(int size, int index)
        {
            //如果某个标记到底，则重新归到顶部
            return index == size - 1 ? 0 : index + 1;
        }

        public void DisplayInformation()
        {
            Console.Write("Array = ");
            foreach (int i in arr)
                Console.Write(i+" ");
            Console.WriteLine();
            Console.WriteLine("QueueSize={0}, start={1}, end={2}", queueSize, start, end);
        }
    }
}
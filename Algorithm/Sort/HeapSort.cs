using System;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            HeapSort(numbers);

            foreach (int i in numbers)
                Console.Write(i + " ");

            Console.ReadKey();
        }

        //堆排序函数：
        public static void HeapSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return;

            //大根堆的实现
            for (int i = 0; i < arr.Length; ++i)
                HeapInsert(arr, i);

            //将堆顶(最大值)交换到堆底，堆大小减小
            int heapSize = arr.Length;
            Swap(arr, 0, --heapSize);

            //进行堆调整
            while (heapSize > 0)
            {
                Heapify(arr, 0, heapSize);
                Swap(arr, 0, --heapSize);
            }
        }

        //堆插入函数（向上
        public static void HeapInsert(int[] arr,int index)
        {
            //如果当前节点大于其父节点，则交换
            while (arr[index] > arr[(index - 1) / 2])
            {
                Swap(arr, index, (index - 1) / 2);
                index = (index - 1) / 2;
            }
        }

        //堆调整函数（向下
        public static void Heapify(int[] arr, int index,int size)
        {
            //扫描左孩子
            int left = index * 2 + 1;
            while (left < size)
            {
                //取得左右孩子中较大的下标
                int largest = left + 1 < size && arr[left + 1] > arr[left] ? left + 1 : left;

                largest = arr[largest] > arr[index] ? largest : index;

                if (largest == index)
                    break;

                Swap(arr, largest, index);
                index = largest;
                left = index * 2 + 1;
            }
        }

        public static void Swap(int[] arr, int A, int B)
        {
            int temp = arr[A];
            arr[A] = arr[B];
            arr[B] = temp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Code028
{
    /// <summary>
    /// 028 数组中出现次数超过一半的数字
    /// </summary>
    class Algorithm_others_028
    {
        /// <summary>
        /// 028 数组中出现次数超过一半的数字
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int MoreThanHalfNum_Solution(int[] numbers)
        {
            // 合法性检验
            if (numbers.Length <= 0 || numbers == null)
                return 0;

            // 特例：数组只有单一元素或双元素，则返回首元素
            if (numbers.Length == 1 || numbers.Length == 2)
                return numbers[0];

            List<int> list = new List<int>(numbers);

            //Way1：O(2n)
            int halfnum = list[0];  //数组存于表内
            int times = 1;          //当前标记的、出现次数最多的元素的出现次数
            int listTimes = 0;

            // 1. 一次遍历：找出出现次数最多的元素halfnum
            for (int i = 1; i < list.Count; ++i)
            {
                if (times == 0)
                {
                    halfnum = list[i];
                    times = 1;
                }
                else if (list[i] == halfnum)
                    times++;
                else
                    times--;
            }

            // 2. 求得halfnum在list内出现的次数
            for (int i = 0; i < list.Count; ++i)
                if (list[i] == halfnum)
                    ++listTimes;

            //3. 最终检验：halfnum是否为出现次数过半的数字
            if (listTimes > list.Count / 2)
                return halfnum;
            else
                return 0;


            ////Way2：针对有序list的扫描
            //list.Sort();
            //int pre = list[0];
            //int time = 0;            //当前数字重复次数
            //int max = 0;             //数组内数字最大重复次数
            //int halfnum = 0;         //最大重复次数的数值
            //foreach(int i in list)
            //{
            //    if(pre == i)
            //    {
            //        ++time;
            //    }else 
            //    {
            //        pre = i;
            //        time = 1;
            //    }

            //    if(time>=max)
            //    {
            //        max = time;
            //        halfnum = i;
            //    }
            //}

            ////Way2：最数组进行排序后遍历出现次数
            //int halfnum = list[list.Count/2];
            //int max = 0;
            //foreach(int i in list)
            //{
            //    if(i == halfnum)
            //        ++max;
            //}

            //if(max > numbers.Length/2)
            //    return halfnum;
            //else return 0;
        }

        public static void Run()
        {
            // 注意：测试数组的“出现过半的数字”不要为0，因为核心函数中返回值0被表示检索失败
            int[][] nums = new int[4][];
            nums[0] = new int[] { 1, 1, 0, 3, 1, 5, 1};
            nums[1] = new int[] { 1, 2};
            nums[2] = new int[] { 1 };
            nums[3] = new int[] { };

            int ans = 0;

            foreach (int[] t in nums)
            {
                Print(t);
                ans = MoreThanHalfNum_Solution(t);
                if (ans == 0)
                    Console.WriteLine("没有出现次数过半的数字\n");
                else
                    Console.WriteLine("出现次数过半的数字为" + ans + "\n");
            }
        }

        public static void Print(int[] nums)
        {
            foreach (int i in nums)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}

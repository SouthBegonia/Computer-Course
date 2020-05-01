using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace OfferCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
    }

    /// <summary>
    /// 003 从尾到头打印链表
    /// </summary>
    class DataStructure_LinkedList_003
    {
        /// <summary>
        /// 003 从尾到头打印链表
        /// </summary>
        /// <param name="listNode">元素为ListNode的链表的头元素</param>
        /// <returns>返回倒序链表的val的数组</returns>
        public static List<int> printListFromTailToHead(ListNode listNode)
        {
            List<int> list = new List<int>();
            ListNode node = listNode;
            while (node != null)
            {
                list.Add(node.val);
                node = node.next;
            }
            list.Reverse();
            return list;
        }

        /// <summary>
        /// 取得初始化的ListNode的链表
        /// </summary>
        /// <returns></returns>
        public static List<ListNode> Init()
        {
            int[][] nums = new int[2][];
            nums[0] = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }; 
            nums[1] = new int[] { 10, 56, 34, 21, 56, 100, 96, 0, -10 };


            List<ListNode> listNodes = new List<ListNode>();

            for(int i=0;i< nums[1].Length;i++)
            {
                listNodes.Add(new ListNode(nums[1][i]));
            }

            for(int i=0;i<listNodes.Count;i++)
            {
                if (i + 1 < listNodes.Count)
                    listNodes[i].next = listNodes[i + 1];
                else
                    listNodes[i].next = null;
            }
            return listNodes;
        }

        /// <summary>
        /// 打印传入的链表信息
        /// </summary>
        /// <param name="listNodes"></param>
        public static void PrintList(List<ListNode> listNodes)
        {
            if (listNodes.Count <= 0)
                return;

            foreach (ListNode listNode in listNodes)
            {
                Console.Write("val=" + listNode.val);
                if (listNode.next != null)
                    Console.Write("\t\tnext.val=" + listNode.next.val);
                else
                    Console.Write("\t\tnext=null");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 测试
        /// </summary>
        public static void Run()
        {
            List<ListNode> listNodes1 = Init();
            PrintList(listNodes1);

            List<int> listInt = printListFromTailToHead(listNodes1[0]);
            foreach (int i in listInt)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Code014
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
    /// 014 链表中倒数第k的节点
    /// </summary>
    class DataStructure_LinkedList_014
    {
        /// <summary>
        /// 014 寻找链表中倒数第k个节点
        /// </summary>
        /// <param name="head">传入的目标链表的头结点</param>
        /// <param name="k">倒数第k个</param>
        /// <returns></returns>
        public static ListNode FindKthToTail(ListNode head, int k)
        {
            if (head == null || k == 0)
                return null;

            ListNode first = head;
            ListNode sec = head;

            //前指针先走 k-1 个节点，如果链表长度还不足k，则输出空
            for (int i = 0; i < k - 1; ++i)
            {
                if (first.next != null)
                    first = first.next;
                else
                    return null;
            }

            //前后指针一起走直至尾节点
            while (first.next != null)
            {
                first = first.next;
                sec = sec.next;
            }
            return sec;
        }

        public static void Run()
        {
            ListNode ListHead = Init(); //创建并初始化测试链表
            PrintList(ListHead);

            int k = 2;  //倒数第k个节点

            ListNode TargetNode = FindKthToTail(ListHead, k);//查找函数

            if (TargetNode == null)
                Console.WriteLine("无法求得倒数第{0}个节点", k);
            else
                Console.WriteLine("倒数第{0}个节点：{1}", k, TargetNode.val);
        }

        /// <summary>
        /// 生成测试链表
        /// </summary>
        /// <returns>返回测试链表的头结点</returns>
        public static ListNode Init()
        {
            int[][] nums = new int[5][];
            nums[0] = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            nums[1] = new int[] { 10, 56, 34, 21, 56, 100, 96, 0, -10 };
            nums[2] = new int[] { };
            nums[3] = new int[] { 1 };

            return GenerateLinkedList(nums[0]);
        }

        /// <summary>
        /// 尾插法创建单链表，返回头节点
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>单链表的头结点</returns>
        public static ListNode GenerateLinkedList(int[] arr)
        {
            if (arr.Length <= 0)
                return null;

            // 尾插法创建单链表
            ListNode head = new ListNode(0);
            head.next = null;
            ListNode curr;
            ListNode prev = head;
            for (int i = 0; i < arr.Length; i++)
            {
                curr = new ListNode(arr[i]);
                prev.next = curr;
                prev = curr;
            }

            return head.next;
        }

        /// <summary>
        /// 打印传入的链表信息
        /// </summary>
        /// <param name="listNode"></param>
        public static void PrintList(ListNode listNode)
        {
            if (listNode == null)
            {
                Console.WriteLine("链表为空");
                return;
            }

            Console.Write("LinkedList: ");
            while (listNode.next != null)
            {
                Console.Write(listNode.val + " -> ");
                listNode = listNode.next;
            }
            Console.Write(listNode.val + " ->null");

            Console.WriteLine();
        }
    }
}

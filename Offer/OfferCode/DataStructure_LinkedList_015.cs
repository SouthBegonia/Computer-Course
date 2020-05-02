using System;
using System.Collections.Generic;
using System.Text;

namespace Code015
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
    /// 015 反转单链表
    /// </summary>
    class DataStructure_LinkedList_015
    {
        /// <summary>
        /// 015 反转单链表，返回反转后链表的头节点
        /// </summary>
        /// <param name="pHead">待反转链表的头节点</param>
        /// <returns>反转后链表的头节点</returns>
        public static ListNode ReverseList(ListNode pHead)
        {
            ListNode newHead = null;
            ListNode p;

            while (pHead != null)
            {
                // 逐个反转节点的指向，直至末尾节点
                p = pHead;
                pHead = pHead.next;

                p.next = newHead;
                newHead = p;
            }
            return newHead;
        }

        public static void Run()
        {
            ListNode ListHead = Init(); //创建并初始化测试链表
            PrintList(ListHead);

            ListNode ReversedList = ReverseList(ListHead);
            if (ReversedList != null)
            {
                Console.WriteLine("反转后的链表：");
                PrintList(ReversedList);
            }
            else
                Console.WriteLine("该链表无法进行反转");
        }

        /// <summary>
        /// 生成并返回测试链表
        /// </summary>
        /// <returns></returns>
        public static ListNode Init()
        {
            int[][] nums = new int[5][];
            nums[0] = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            nums[1] = new int[] { -1, 56, 21, 100, 0, -10 };
            nums[2] = new int[] { };
            nums[3] = new int[] { 1 };

            return GenerateLinkedList(nums[1]);
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
            Console.Write(listNode.val + " ->null\n");
        }
    }
}

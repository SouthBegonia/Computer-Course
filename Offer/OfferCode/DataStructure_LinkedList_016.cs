using System;
using System.Collections.Generic;
using System.Text;

namespace Code016
{
    /// <summary>
    /// 016 合并两个单调递增的链表
    /// </summary>
    class DataStructure_LinkedList_016
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
        /// 016 合并两个有单调递增链表
        /// </summary>
        /// <param name="pHead1">待合并链表1的头结点</param>
        /// <param name="pHead2">待合并链表2的头结点</param>
        /// <returns>合并后的链表的头结点</returns>
        public static ListNode Merge(ListNode pHead1, ListNode pHead2)
        {
            //1. 合法性检验：若其中某个链表为空则无需合并，返回非空链表
            if (pHead1 == null)
                return pHead2;
            else if (pHead2 == null)
                return pHead1;

            //2. 选择两个链表中较小的头结点作为起始节点mergedHead
            ListNode p;
            ListNode mergedHead = null;
            if (pHead1.val <= pHead2.val)
            {
                mergedHead = pHead1;
                pHead1 = pHead1.next;
            }
            else
            {
                mergedHead = pHead2;
                pHead2 = pHead2.next;
            }
            p = mergedHead;

            //3. 首次遍历直至任意链表完结
            while (pHead1 != null && pHead2 != null)
            {
                if (pHead1.val <= pHead2.val)
                {
                    p.next = pHead1;
                    p = p.next;
                    pHead1 = pHead1.next;
                }
                else
                {
                    p.next = pHead2;
                    p = p.next;
                    pHead2 = pHead2.next;
                }
            }

            //4. 则剩余链表的剩余节点都有序，遍历完即可
            while (pHead1 != null)
            {
                p.next = pHead1;
                p = p.next;
                pHead1 = pHead1.next;
            }
            while (pHead2 != null)
            {
                p.next = pHead2;
                p = p.next;
                pHead2 = pHead2.next;
            }

            //5. 返回合并后的链表的头结点
            return mergedHead;
        }

        public static void Run()
        {
            ListNode list1 = Init(0); //创建并初始化测试链表
            ListNode list2 = Init(1);
            PrintList("链表1：",list1);
            PrintList("链表2：",list2);

            ListNode mergedList =  Merge(list1, list2);
            if (mergedList != null)
            {
                PrintList("合并后的链表：",mergedList);
            }
            else
                Console.WriteLine("两链表为空，无法合并");
        }

        /// <summary>
        /// 生成并返回测试链表
        /// </summary>
        /// <param name="index">选择的测试链表数据组</param>
        /// <returns></returns>
        public static ListNode Init(int index)
        {
            int[][] nums = new int[5][];
            nums[0] = new int[] { 0, 2, 4, 6, 8, 10 };
            nums[1] = new int[] { -10,-4,-1, 0, 12, 20 };

            nums[2] = new int[] { 0 };

            nums[3] = new int[] { };
            nums[4] = new int[] { };

            return GenerateLinkedList(nums[index]);
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
        /// 打印传入链表的信息
        /// </summary>
        /// <param name="remarks">备注说明该链表的信息</param>
        /// <param name="listNode">待打印的链表</param>
        public static void PrintList(string remarks, ListNode listNode)
        {
            if (listNode == null)
            {
                Console.WriteLine(remarks+"为空");
                return;
            }

            Console.Write(remarks);
            while (listNode.next != null)
            {
                Console.Write(listNode.val + " -> ");
                listNode = listNode.next;
            }
            Console.Write(listNode.val + " ->null\n");
        }
    }
}

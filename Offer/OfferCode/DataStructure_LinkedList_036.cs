using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Code036
{
    /// <summary>
    /// 036 两个链表的第一个公共结点
    /// </summary>
    class DataStructure_LinkedList_036
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
        /// 036 两个链表的第一个公共结点
        /// （注意：测试要求在非null情况下，两个测试链表 存在公共链（尾部或者全部））
        /// </summary>
        /// <param name="pHead1"></param>
        /// <param name="pHead2"></param>
        /// <returns></returns>
        public static ListNode FindFirstCommonNode(ListNode pHead1, ListNode pHead2)
        {
            //1. 合法性检验
            if (pHead1 == null || pHead2 == null)
                return null;

            ListNode index1 = pHead1;
            ListNode index2 = pHead2;
            int len1 = 0;
            int len2 = 0;

            //2. 计算两链表的长度
            while (index1 != null)
            {
                index1 = index1.next;
                ++len1;
            }
            while (index2 != null)
            {
                index2 = index2.next;
                ++len2;
            }

            //3. 消除长度差（较长链表 先走 长度差步
            index1 = pHead1;
            index2 = pHead2;
            while (len1 != len2)
            {
                if (len1 > len2)
                {
                    index1 = index1.next;
                    --len1;
                }

                if (len1 < len2)
                {
                    index2 = index2.next;
                    --len2;
                }
            }

            //4. 两链表一起走（因为两链表剩余节点数相同，仅需判断对应val是否等值
            while (index1 != null && index2 != null)
            {
                if (index1.val == index2.val)
                    return index1;
                else
                {
                    index1 = index1.next;
                    index2 = index2.next;
                }
            }

            //5. 返回首个公共节点
            return index1;
        }


        public static void Run()
        {
            ListNode list1 = Init(0); //创建并初始化测试链表
            ListNode list2 = Init(1);
            PrintList("链表1：", list1);
            PrintList("链表2：", list2);

            ListNode commonList = FindFirstCommonNode(list1, list2);
            if(commonList!=null)
            {
                PrintList("公共链表：", commonList);
            }
            else
            {
                Console.WriteLine("不存在首个公共节点");
            }
        }

        /// <summary>
        /// 生成并返回测试链表
        /// </summary>
        /// <param name="index">选择的测试链表数据组</param>
        /// <returns></returns>
        public static ListNode Init(int index)
        {
            int[][] nums = new int[5][];
            nums[0] = new int[] { 0, 2, 4, 5, 6, 7, 8, 9, 10 };
            nums[1] = new int[] { -10, -4, -1, 0, 8, 9, 10 };

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
                Console.WriteLine(remarks + "为空");
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Code055
{
    /// <summary>
    /// 055 链表中环的入口节点
    /// </summary>
    class DataStructure_LinkedList_055
    {
        /// <summary>
        /// 055 链表中环的入口结点
        /// </summary>
        /// <param name="pHead">待测试链表</param>
        /// <returns>返回入口结点</returns>
        public static ListNode EntryNodeOfLoop(ListNode pHead)
        {
            //1. 合法性检验
            if (pHead == null || pHead.next == null)
                return null;

            //2. 创建快慢指针
            ListNode fnode = pHead;
            ListNode snode = pHead;

            //3. 快慢指针差速扫描，若扫描到null，说明链表内不存在环
            while (fnode != null)
            {
                fnode = fnode.next.next;
                snode = snode.next;

                //4. 若快慢指针相遇，说明链表内有环
                if (fnode == snode)
                {
                    //5. 快指针从头开始，两指针同速扫描
                    //原理：设头结点到环入口长度a，环长度b+c，则总链长为a+b+c;
                    //     首次相遇时，snode在环内，且未走完一圈，设其已走长度为a+b; 而fnode已走 ((a+b+c)+b)；
                    //     根据快慢指针路程比等于速率比，有 (a+b+c+b)/(a+b) = V快/V慢 = 2/1;
                    //     解得 a=c，即snode在环内还未走完的长度=头结点到环入口结点的长度；
                    //     因此快指针重头走，并与慢指针同速，最终必定在入口结点相遇。
                    fnode = pHead;
                    while (fnode != snode)
                    {
                        fnode = fnode.next;
                        snode = snode.next;
                    }
                    return fnode;
                }
            }
            return null;
        }

        public static void Run()
        {
            ListNode list1 = EntryNodeOfLoop(Init(0, true, 5)); //链表正常有环
            ListNode list2 = EntryNodeOfLoop(Init(0, false, -1));//链表正常无环
            ListNode list3 = EntryNodeOfLoop(Init(3, false, -1));//链表为空
            ListNode list4 = EntryNodeOfLoop(Init(2, false, -1));//链表只有一个结点

            if (list1 != null)
                Console.WriteLine("链表1的环入口结点：" + list1.val);

            if (list2 == null)
                Console.WriteLine("链表2无环");

            if (list3 == null)
                Console.WriteLine("链表3无环");
            if (list4 == null)
                Console.WriteLine("链表4无环");
        }

        #region 测试代码
        /// <summary>
        /// 生成测试链表
        /// </summary>
        /// <param name="index">选取的数组</param>
        /// <param name="hasCircle">生成的链表是否有环</param>
        /// <param name="entryIndex">环的入口是第几个结点</param>
        /// <returns></returns>
        public static ListNode Init(int index, bool hasCircle, int entryIndex)
        {
            int[][] nums = new int[5][];
            nums[0] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            nums[1] = new int[] { -10, -4, -1, 0, 8, 9, 10 };

            nums[2] = new int[] { 0 };

            nums[3] = new int[] { };
            nums[4] = new int[] { };

            if (hasCircle)
                return GenerateLinkedList(nums[index], entryIndex);
            else
                return GenerateLinkedList(nums[index]);
        }

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
        /// 无环链表
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static ListNode GenerateLinkedList(int[] arr)
        {
            if (arr.Length <= 0)
                return null;

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
            prev.next = null;
            return head.next;
        }

        /// <summary>
        /// 有环链表
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="entryNode">入口结点的下标，第entryNode个结点</param>
        /// <returns></returns>
        public static ListNode GenerateLinkedList(int[] arr, int entryNode)
        {
            if (arr.Length <= 1)
                return null;

            List<ListNode> lists = new List<ListNode>();

            ListNode head = new ListNode(0);
            head.next = null;
            ListNode curr;
            ListNode prev = head;
            for (int i = 0; i < arr.Length; i++)
            {
                curr = new ListNode(arr[i]);
                lists.Add(curr);
                prev.next = curr;
                prev = curr;
            }
            prev.next = lists[entryNode - 1];
            return head.next;
        }
    }
    #endregion
}

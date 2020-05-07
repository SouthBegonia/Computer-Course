using System;
using System.Collections.Generic;
using System.Text;
using Code003;

namespace Code056
{
    /// <summary>
    /// 056 删除链表中重复的结点
    /// </summary>
    class DataStructure_LinkedList_056
    {
        /// <summary>
        /// 056 删除链表中重复的结点
        /// </summary>
        /// <param name="pHead">测试链表（已排序</param>
        /// <returns></returns>
        public static ListNode deleteDuplication(ListNode pHead)
        {
            //1. 合法性检验
            if (pHead == null || pHead.next == null)
            { 
                return pHead; 
            }

            //2. 保留头结点标记Head，创建前后遍历指针prev、last
            ListNode Head = new ListNode(0);
            Head.next = pHead;
            ListNode prev = Head;
            ListNode last = Head.next;

            while (last != null)
            {
                //3. 当last和last.next重复时，last持续遍历，直到最后一个重复结点
                if (last.next != null && last.val == last.next.val)
                {
                    while (last.next != null && last.val == last.next.val)
                    { 
                        last = last.next; 
                    }

                    //4. prev.next指向最后一重复结点的下一结点，过滤期间的重复结点
                    prev.next = last.next;
                    last = last.next;
                }
                else
                {
                    //3. 否则前后指针持续遍历
                    prev = prev.next;
                    last = last.next;
                }
            }
            //5. 返回已做删除重复结点处理后的链表的头结点
            return Head.next;
        }

        public static void Run()
        {
            ListNode list1 = Init(0);   //正常升序链表
            ListNode list2 = Init(1);   //正常降序链表
            ListNode list3 = Init(2);   //0
            ListNode list4 = Init(3);   //空链表

            PrintList("原链表1：", list1);
            PrintList("原链表2：", list2);
            PrintList("原链表3：", list3);
            PrintList("原链表4：", list4);
            Console.WriteLine();

            list1 = deleteDuplication(list1);
            list2 = deleteDuplication(list2);
            list3 = deleteDuplication(list3);
            list4 = deleteDuplication(list4);

            PrintList("现链表1：", list1);
            PrintList("现链表2：", list2);
            PrintList("现链表3：", list3);
            PrintList("现链表4：", list4);
        }

        #region 非核心代码
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
        /// 生成并返回测试链表
        /// </summary>
        /// <param name="index">选择的测试链表数据组</param>
        /// <returns></returns>
        public static ListNode Init(int index)
        {
            int[][] nums = new int[5][];
            nums[0] = new int[] { 0, 1, 2, 2, 4, 5, 5, 5, 10, 11, 11, 12 };
            nums[1] = new int[] { 12, 11, 11, 10, 5, 5, 5, 4, 2, 2, 1, 0 };

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
            prev.next = null;
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
        #endregion
    }
}

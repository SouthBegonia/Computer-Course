using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 删除有序链表中的重复元素
    /// </summary>
    public class _20221209_deleteDuplicates
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
        /// 删除链表内重复元素（元素出现次数唯一）
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode deleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            HashSet<int> hashset = new HashSet<int>();
            hashset.Add(head.val);

            ListNode pre = head;
            ListNode cur = head.next;

            while (cur != null)
            {
                if (hashset.Contains(cur.val))
                {
                    pre.next = cur.next;
                }
                else
                {
                    pre.next = cur;
                    pre = pre.next;
                    hashset.Add(cur.val);
                }

                cur = cur.next;
            }

            return head;
        }

        /// <summary>
        /// 删除链表内重复元素（删除出现次数重复的所有元素）
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode deleteDuplicates2(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode newHead = new ListNode(-1);
            newHead.next = head;

            ListNode cur = newHead;
            while (cur.next != null && cur.next.next != null)
            {
                if (cur.next.val == cur.next.next.val)
                {
                    int tempVal = cur.next.val;
                    while (cur.next != null && cur.next.val == tempVal)
                        cur.next = cur.next.next;
                }
                else
                    cur = cur.next;
            }

            return newHead.next;
        }
    }
}
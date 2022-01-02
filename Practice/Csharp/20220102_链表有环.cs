using System.Collections.Generic;

namespace CsharpExam
{
    public class _20220102_链表有环
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        //双指针
        public bool HasCycle(ListNode head)
        {
            //快慢指针
            ListNode fast = head;
            ListNode slow = head;

            while (fast != null && slow != null)
            {
                if (fast.next != null && fast.next.next != null)
                    fast = fast.next.next;
                else
                    return false;

                if (slow.next != null)
                    slow = slow.next;
                else
                    return false;

                //不能用val比较
                if (fast != null && slow != null && fast == slow)
                    return true;

            }
            return false;
        }

        //集合
        public bool HasCycle2(ListNode head)
        {
            List<ListNode> list = new List<ListNode>();

            while (head != null)
            {
                if (list.Contains(head))
                    return true;
                list.Add(head);
                head = head.next;
            }

            return false;
        }
    }
}
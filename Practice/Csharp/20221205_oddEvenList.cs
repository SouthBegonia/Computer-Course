using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 链表的奇偶重排  https://www.nowcoder.com/practice/02bf49ea45cd486daa031614f9bd6fc3?tpId=295&sfm=html&channel=nowcoder
    /// </summary>
    public class _20221205_oddEvenList
    {
        public ListNode oddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            
            Queue<ListNode> queue_even = new Queue<ListNode>();//偶数
            Queue<ListNode> queue_uneven = new Queue<ListNode>();//奇数

            int index = 1;
            ListNode temp = head;
            while (temp != null)
            {
                if (index % 2 == 0)
                    queue_even.Enqueue(temp);
                else
                    queue_uneven.Enqueue(temp);

                temp = temp.next;
                ++index;
            }

            ListNode newHead = queue_uneven.Dequeue();
            temp = newHead;
            while (queue_uneven.Count > 0)
            {
                ListNode node = queue_uneven.Dequeue();
                temp.next = node;
                temp = temp.next;
            }

            while (queue_even.Count > 0)
            {
                ListNode node = queue_even.Dequeue();
                temp.next = node;
                temp = temp.next;
            }

            temp.next = null;

            return newHead;
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
    }
}
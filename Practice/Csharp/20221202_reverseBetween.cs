namespace CsharpExam
{
    /// <summary>
    /// 链表内指定区域反转  https://www.nowcoder.com/practice/b58434e200a648c589ca2063f1faf58c?tpId=295&tqId=654&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221202_reverseBetween
    {
        public ListNode reverseBetween(ListNode head, int m, int n)
        {
            if (m == n || m == 0)
                return head;

            ListNode newHead = new ListNode(-1);
            newHead.next = head;

            ListNode start = head;
            ListNode leftHead = newHead;
            for (int i = 2; i <= m; i++)
            {
                leftHead = start;
                start = start.next;
            }

            ListNode end = leftHead;
            ListNode rightHead = start;
            for (int i = m; i <= n; i++)
            {
                end = end.next;
                rightHead = rightHead.next;
            }

            leftHead.next = null;
            end.next = null;
            ReverseListNodes(start);

            leftHead.next = end;
            start.next = rightHead;

            return newHead.next;
        }

        public void ReverseListNodes(ListNode head)
        {
            ListNode cur = head;
            ListNode pre = null;

            while (cur != null)
            {
                ListNode curNext = cur.next;
                cur.next = pre;
                pre = cur;
                cur = curNext;
            }
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
namespace CsharpExam
{
    /// <summary>
    /// 删除链表的倒数第n个节点  https://www.nowcoder.com/practice/f95dcdafbde44b22a6d741baf71653f6?tpId=295&sfm=html&channel=nowcoder
    /// </summary>
    public class _20221205_removeNthFromEnd
    {
        public ListNode removeNthFromEnd(ListNode head, int n)
        {
            int len = 0;
            ListNode temp = head;
            while (temp != null)
            {
                temp = temp.next;
                ++len;
            }
            if (n > len)
                return head;

            //删除头个节点的情况
            if (n == len)
                return head.next;

            //找到待删节点的前一节点
            temp = head;
            for (int i = 0; i < len - n - 1; i++)
                temp = temp.next;

            ListNode nextNode = temp.next.next;
            temp.next = nextNode;

            return head;
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
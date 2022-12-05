namespace CsharpExam
{
    /// <summary>
    /// 两个链表的第一个公共结点  https://www.nowcoder.com/practice/6ab1d9a29e88450685099d45c9e31e46?tpId=295&sfm=html&channel=nowcoder
    /// </summary>
    public class _20221205_FindFirstCommonNode
    {
        public ListNode FindFirstCommonNode(ListNode pHead1, ListNode pHead2)
        {
            ListNode p1 = pHead1;
            ListNode p2 = pHead2;

            while (p1 != p2)
            {
                //任意链表index走完就走对方的链表，若链表有公共节点则2个index会相遇且null，否则链表无公共节点
                p1 = p1 == null ? pHead2 : p1.next;
                p2 = p2 == null ? pHead1 : p2.next;
            }

            return p1;
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
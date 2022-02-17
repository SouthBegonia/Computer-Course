namespace CsharpExam
{
    // https://leetcode-cn.com/problems/shan-chu-lian-biao-de-jie-dian-lcof/
    // 18 删除链表的节点
    public class Offer_20220217_18
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

        public ListNode DeleteNode(ListNode head, int val)
        {
            ListNode pre = null;
            ListNode cur = head;

            while (cur != null)
            {
                if (cur.val == val)
                {
                    if (pre == null)
                        head = cur.next;
                    else
                    {
                        pre.next = cur.next;
                    }
                }

                pre = cur;
                cur = cur.next;
            }

            return head;
        }
    }
}
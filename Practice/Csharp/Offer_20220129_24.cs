namespace CsharpExam
{
    //https://leetcode-cn.com/problems/fan-zhuan-lian-biao-lcof/
    // 24 反转链表
    public class Offer_20220129_24
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

        public ListNode ReverseList(ListNode head)
        {
            ListNode preNode = null;
            ListNode curNode = head;
            ListNode nextNode = head?.next;

            while (curNode != null)
            {
                curNode.next = preNode;

                preNode = curNode;
                curNode = nextNode;
                nextNode = nextNode?.next;
            }

            return preNode;
        }
    }
}
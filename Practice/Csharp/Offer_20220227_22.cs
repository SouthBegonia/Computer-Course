namespace CsharpExam
{
    // https://leetcode-cn.com/problems/lian-biao-zhong-dao-shu-di-kge-jie-dian-lcof/
    // 22 链表中倒数第K个节点
    public class Offer_20220227_22
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

        public ListNode GetKthFromEnd(ListNode head, int k)
        {
            if (head == null || k <= 0)
                return head;

            ListNode preIndex = head;
            ListNode latterIndex = head;

            //前指针先走k步
            for (int i = 0; i < k; i++)
            {
                if (preIndex == null) //k越界
                    return head;

                preIndex = preIndex.next;
            }

            //两指针一起走
            while (preIndex != null)
            {
                preIndex = preIndex.next;
                latterIndex = latterIndex.next;
            }

            return latterIndex;
        }
    }
}
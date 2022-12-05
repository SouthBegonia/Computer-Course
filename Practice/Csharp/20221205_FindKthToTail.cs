namespace CsharpExam
{
    /// <summary>
    /// 链表中倒数最后k个结点  https://www.nowcoder.com/practice/886370fe658f41b498d40fb34ae76ff9?tpId=295&tqId=1377477&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221205_FindKthToTail
    {
        public ListNode FindKthToTail(ListNode pHead, int k)
        {
            int len = 0;
            ListNode temp = pHead;
            while (temp != null)
            {
                temp = temp.next;
                ++len;
            }
            if (k > len)
                return null;

            temp = pHead;
            for (int i = 0; i < len - k; i++)
                temp = temp.next;

            return temp;
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
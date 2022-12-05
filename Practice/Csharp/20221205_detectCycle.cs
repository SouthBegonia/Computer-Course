namespace CsharpExam
{
    /// <summary>
    /// 链表中环的入口节点  https://www.nowcoder.com/practice/6e630519bf86480296d0f1c868d425ad?tpId=295&sfm=html&channel=nowcoder
    /// </summary>
    public class _20221205_detectCycle
    {
        public ListNode detectCycle(ListNode head)
        {
            ListNode quickIndex = head;
            ListNode slowIndex = head;

            while (quickIndex != null)
            {
                slowIndex = slowIndex.next;
                quickIndex = quickIndex.next != null ? quickIndex.next.next : null;

                if (slowIndex == quickIndex && slowIndex != null)
                {
                    //相遇后 慢指针和新的头指针一齐遍历直至相遇
                    ListNode newHeadIndex = head;
                    while (newHeadIndex != slowIndex)
                    {
                        newHeadIndex = newHeadIndex.next;
                        slowIndex = slowIndex.next;
                    }

                    return newHeadIndex;
                }
            }

            return null;
        }

        public class ListNode
        {
            int val;
            public ListNode next;

            ListNode(int x)
            {
                val = x;
                next = null;
            }
        }
    }
}
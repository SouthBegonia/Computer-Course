namespace CsharpExam
{
    /// <summary>
    /// 链表有环  https://www.nowcoder.com/practice/650474f313294468a4ded3ce0f7898b9?tpId=295&tqId=605&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221205_hasCycle
    {
        public bool hasCycle(ListNode head)
        {
            //双指针
            ListNode quickIndex = head;
            ListNode slowIndex = head;

            while (quickIndex != null)
            {
                slowIndex = slowIndex.next;
                quickIndex = quickIndex.next != null ? quickIndex.next.next : null;

                if (slowIndex == quickIndex && slowIndex != null)
                    return true;
            }

            return false;
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
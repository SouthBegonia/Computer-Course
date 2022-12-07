using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 单链表的排序  https://www.nowcoder.com/practice/f23604257af94d939848729b1a5cda08?tpId=295&tqId=1008897&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221207_sortInList
    {
        public ListNode sortInList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode newHead = new ListNode(-1);
            List<ListNode> list = new List<ListNode>();

            while (head != null)
            {
                list.Add(head);
                head = head.next;
            }

            //val升序排列
            list.Sort((ListNode a, ListNode b) => a.val.CompareTo(b.val));

            ListNode temp = newHead;
            for (int i = 0; i < list.Count; i++)
            {
                temp.next = list[i];
                temp = temp.next;

                //注意链表尾null
                temp.next = null;
            }

            return newHead.next;
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
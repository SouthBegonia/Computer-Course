using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 链表相加  https://www.nowcoder.com/practice/c56f6c70fb3f4849bc56e33ff2a50b6b?tpId=295&tqId=1008772&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221208_addInList
    {
        public static ListNode addInList(ListNode head1, ListNode head2)
        {
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();

            //原始链表数据入栈
            ListNode temp = head1;
            while (temp != null)
            {
                s1.Push(temp.val);
                temp = temp.next;
            }
            temp = head2;
            while (temp != null)
            {
                s2.Push(temp.val);
                temp = temp.next;
            }

            //出栈计算
            ListNode newHead = new ListNode(0);
            int addNum = 0;
            while (s1.Count > 0 || s2.Count > 0)
            {
                int num1 = s1.Count > 0 ? s1.Pop() : 0;
                int num2 = s2.Count > 0 ? s2.Pop() : 0;

                int sum = num1 + num2 + addNum;
                if (sum >= 10)
                {
                    addNum = sum / 10;
                    sum %= 10;
                }
                else
                    addNum = 0;

                //尾插节点
                ListNode node = new ListNode(sum);
                node.next = null;
                InsetListNodeToHead(ref newHead, ref node);
            }

            //进位处理
            if (addNum > 0)
            {
                ListNode node = new ListNode(addNum);
                node.next = null;
                InsetListNodeToHead(ref newHead, ref node);
            }

            return newHead.next;
        }

        public static void InsetListNodeToHead(ref ListNode head, ref ListNode targetNode)
        {
            if (targetNode == null)
            {
                head.next = targetNode;
                return;
            }

            ListNode headNext = head.next;
            head.next = targetNode;
            targetNode.next = headNext;
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
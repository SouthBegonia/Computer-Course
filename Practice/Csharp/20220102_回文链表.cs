using System.Collections.Generic;

namespace CsharpExam
{
    public class _20220102_回文链表
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        //回文链表
        public bool IsPalindrome(ListNode head)
        {
            //使用栈逆序输出，与源正序链表对比。正反一致即为回文链表
            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode stackIndex = head;

            while (stackIndex != null)
            {
                stack.Push(stackIndex);
                stackIndex = stackIndex.next;
            }

            //检测一半即可
            int len = stack.Count / 2;
            while (len-- > 0)
            {
                if (head != null && head.val == stack.Pop().val)
                {
                    head = head.next;
                }
                else
                    return false;
            }
            return true;
        }
    }
}
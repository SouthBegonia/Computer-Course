using System;
using System.Collections.Generic;

namespace CsharpExam
{
    class _20211229_ReversListNode
    {
        static void Main(string[] args)
        {

        }

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

        //顺序遍历
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode tempNode;
            ListNode right = head.next;
            ListNode left = head;

            while (right != null)
            {
                tempNode = right.next;
                right.next = left;

                left = right;
                right = tempNode;
            }
            head.next = null;
            return left;
        }

        //递归
        public ListNode ReverseList2(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode tempNode = head.next;
            ListNode reverse = ReverseList2(tempNode);

            tempNode.next = head;
            head.next = null;

            return reverse;
        }

        //栈
        public ListNode ReverseList3(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            Stack<ListNode> stack = new Stack<ListNode>();

            while (head != null)
            {
                stack.Push(head);
                head = head.next;
            }

            ListNode newHead = stack.Pop();
            head = newHead;

            while (stack.Count > 0)
            {
                head.next = stack.Pop();
                head = head.next;
            }

            head.next = null;
            return newHead;
        }
    }
}
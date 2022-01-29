using System.Collections.Generic;

namespace CsharpExam
{
    //https://leetcode-cn.com/problems/fu-za-lian-biao-de-fu-zhi-lcof/
    // 35 复杂链表的复制
    public class Offer_20220129_35
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;

            Node curNode = head;
            for (Node node = head; node != null; node = node.next.next)
            {
                Node newNext = new Node(node.val);
                newNext.next = node.next;
                node.next = newNext;
            }

            for (Node node = head; node != null; node = node.next.next)
            {
                node.next.random = node.random?.next;
            }

            Node newHead = head.next;
            for (Node node = head; node !=null; node = node.next)
            {
                Node newNext = node.next;
                node.next = node.next.next;

                newNext.next = newNext.next?.next;
            }

            return newHead;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace CsharpExam
{
    //https://leetcode-cn.com/problems/cong-wei-dao-tou-da-yin-lian-biao-lcof/
    // 06 从尾到头打印链表
    public class Offer_20220129_06
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

        public int[] ReversePrint(ListNode head)
        {
            ListNode curNode = head;
            Stack<int> stack = new Stack<int>();

            while (curNode != null)
            {
                stack.Push(curNode.val);
                curNode = curNode.next;
            }

            int[] arr = new int[stack.Count];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = stack.Pop();

            return arr.ToArray();
        }
    }
}
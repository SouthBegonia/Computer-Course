using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 判断一个链表是否为回文结构  https://www.nowcoder.com/practice/3fed228444e740c8be66232ce8b87c2f?tpId=295&sfm=html&channel=nowcoder
    /// </summary>
    public class _20221205_isPail
    {
        public bool isPail(ListNode head)
        {
            int len = 0;
            ListNode temp = head;
            while (temp != null)
            {
                temp = temp.next;
                len++;
            }

            if (len == 0)
                return false;
            if (len == 1)
                return true;

            temp = head;
            int halfCount = len % 2 == 0 ? (len / 2) : ((len - 1) / 2);
            Stack<int> stack = new Stack<int>(halfCount);
            for (int i = 0; i < halfCount; i++)
            {
                stack.Push(temp.val);
                temp = temp.next;
            }

            temp = len % 2 == 0 ? temp : temp.next;
            for (int i = 0; i < halfCount; i++)
            {
                int val = stack.Pop();
                if (val != temp.val)
                    return false;
                temp = temp.next;
            }

            return true;
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
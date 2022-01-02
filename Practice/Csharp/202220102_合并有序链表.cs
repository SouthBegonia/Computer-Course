namespace CsharpExam
{
    public class _202220102_合并有序链表
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

        //合并有序链表
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode index_1 = list1;
            ListNode index_2 = list2;

            ListNode newHead = new ListNode();
            ListNode indexN = newHead;

            while (index_1 != null && index_2 != null)
            {
                if (index_1.val < index_2.val)
                {
                    indexN.next = index_1;
                    index_1 = index_1.next;
                    indexN = indexN.next;
                }
                else
                {
                    indexN.next = index_2;
                    index_2 = index_2.next;
                    indexN = indexN.next;
                }
            }

            if (index_1 != null)
            {
                indexN.next = index_1;
            }
            else if (index_2 != null)
            {
                indexN.next = index_2;
            }

            return newHead;
        }
    }
}
namespace CsharpExam
{
    //https://leetcode-cn.com/problems/add-two-numbers/
    public class _20220120_两数相加
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

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode tempHeadIndex = new ListNode();
            ListNode head = tempHeadIndex;

            ListNode leftIndex = l1;
            ListNode rightIndex = l2;

            //1.双指针遍历两量表直至完毕
            int addNum = 0;    //遍历到当前位，需额外累加的数（也就是前一位进的值）
            while (leftIndex != null || rightIndex != null)
            {
                if (leftIndex != null)
                {
                    if (rightIndex == null)
                    {
                        int total = leftIndex.val + addNum;
                        addNum = total >= 10 ? total / 10 : 0;
                        ListNode node = new ListNode(total >= 10 ? total % 10 : total);

                        tempHeadIndex.next = node;
                        tempHeadIndex = tempHeadIndex.next;
                    }
                    else
                    {
                        int total = leftIndex.val + rightIndex.val + addNum;
                        addNum = total >= 10 ? total / 10 : 0;
                        ListNode node = new ListNode(total >= 10 ? total % 10 : total);

                        tempHeadIndex.next = node;
                        tempHeadIndex = tempHeadIndex.next;
                    }
                }
                else if (rightIndex != null)
                {
                    int total = rightIndex.val + addNum;
                    addNum = total >= 10 ? total / 10 : 0;
                    ListNode node = new ListNode(total >= 10 ? total % 10 : total);

                    tempHeadIndex.next = node;
                    tempHeadIndex = tempHeadIndex.next;
                }

                leftIndex = leftIndex?.next;
                rightIndex = rightIndex?.next;
            }

            //2.遍历完后可能还有进位，检查并入链
            int multi = 10;
            while (addNum > 0)
            {
                if (addNum < 10)
                {
                    ListNode node = new ListNode(addNum);
                    tempHeadIndex.next = node;
                    tempHeadIndex = tempHeadIndex.next;
                    break;
                }
                else
                {
                    ListNode node = new ListNode(addNum % multi);
                    tempHeadIndex.next = node;
                    tempHeadIndex = tempHeadIndex.next;
                    multi *= 10;
                    addNum /= 10;
                }
            }

            return head.next;
        }
    }
}
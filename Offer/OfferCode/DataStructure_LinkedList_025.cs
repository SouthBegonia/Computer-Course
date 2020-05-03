using Code015;
using System;
using System.Collections.Generic;
using System.Text;

namespace Code025
{
    /// <summary>
    /// 025 复杂链表的复制
    /// </summary>
    class DataStructure_LinkedList_025
    {
        public class RandomListNode
        {
            public int label;
            public RandomListNode next, random;
            public RandomListNode(int x)
            {
                this.label = x;
            }
        }

        /// <summary>
        /// 025 复杂链表的复制
        /// </summary>
        /// <param name="pHead"></param>
        /// <returns></returns>
        public static RandomListNode Clone(RandomListNode pHead)
        {
            if (pHead == null)
                return null;

            RandomListNode currentNode = pHead;

            //1. 复制每个结点，如复制结点A得到A1，将结点A1插到结点A后面；
            while (currentNode != null)
            {
                RandomListNode cloneNode = new RandomListNode(currentNode.label);
                RandomListNode nextNode = currentNode.next;
                currentNode.next = cloneNode;
                cloneNode.next = nextNode;
                currentNode = nextNode;
            }

            //2. 重新遍历链表，复制老结点的随机指针给新结点，如A1.random = A.random.next;
            currentNode = pHead;
            while (currentNode != null)
            {
                currentNode.next.random = (currentNode.random == null) ? null : currentNode.random.next;
                currentNode = currentNode.next.next;
            }

            //3. 拆分链表，将链表拆分为原链表和复制后的链表
            currentNode = pHead;
            RandomListNode pCloneHead = pHead.next;
            while (currentNode != null)
            {
                RandomListNode cloneNode = currentNode.next;
                currentNode.next = cloneNode.next;
                cloneNode.next = (cloneNode.next == null) ? null : cloneNode.next.next;
                currentNode = currentNode.next;
            }

            return pCloneHead;

            ////1. 合法性检验
            //if (pHead == null)
            //    return null;

            ////ret：最终拷贝链表的头结点
            //RandomListNode ret = new RandomListNode(pHead.label);

            ////两链表的扫描结点：
            //RandomListNode ptrDst = ret;
            //RandomListNode ptrSrc = pHead;

            ////2. 建立字典，存储两个链表的相同结点
            //Dictionary<RandomListNode, RandomListNode> dict = new Dictionary<RandomListNode, RandomListNode>();
            //dict.Add(ptrSrc, ptrDst);

            ////3. 拷贝设置next和label
            //while (ptrSrc.next != null)
            //{
            //    ptrDst.next = new RandomListNode(ptrSrc.next.label);
            //    ptrDst = ptrDst.next;
            //    ptrSrc = ptrSrc.next;
            //    dict.Add(ptrSrc, ptrDst);
            //}

            ////4 拷贝设置random
            //ptrSrc = pHead;
            //ptrDst = ret;
            //while (ptrSrc != null)
            //{
            //    if (ptrSrc.random != null)
            //        ptrDst.random = dict[ptrSrc.random];
            //    ptrSrc = ptrSrc.next;
            //    ptrDst = ptrDst.next;
            //}
            //return ret;
        }

        public static void Run()
        {
            RandomListNode list1 = Init(0); //创建并初始化测试链表
            PrintList("链表的", list1);

            RandomListNode clonedList = Clone(list1);
            if (clonedList != null)
            {
                PrintList("克隆链表的", clonedList);
            }
            else
                Console.WriteLine("原链表为空，无法克隆");


        }

        /// <summary>
        /// 生成并返回测试链表
        /// </summary>
        /// <param name="index">选择的测试链表数据组</param>
        /// <returns></returns>
        public static RandomListNode Init(int index)
        {
            int[][] nums = new int[5][];
            nums[0] = new int[] { 0, 2, 4, 6, 8, 10 };
            nums[1] = new int[] { -10, -4, -1, 0, 12, 20 };

            nums[2] = new int[] { 0 };

            nums[3] = new int[] { };
            nums[4] = new int[] { };

            return GenerateRandomLinkedList(nums[index]);
        }

        /// <summary>
        /// 尾插法创建链表，返回头节点
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>单链表的头结点</returns>
        public static RandomListNode GenerateRandomLinkedList(int[] arr)
        {
            int arrLen = arr.Length;
            if (arrLen <= 0)
                return null;

            // 记录创建的节点
            List<RandomListNode> listNodes = new List<RandomListNode>(arr.Length);

            // 尾插法创建链表，设置label、next
            RandomListNode head = new RandomListNode(0);
            head.next = null;
            RandomListNode curr;
            RandomListNode prev = head;
            for (int i = 0; i < arrLen; i++)
            {
                curr = new RandomListNode(arr[i]);
                prev.next = curr;
                prev = curr;

                listNodes.Add(curr);
            }

            // random可能指向null
            listNodes.Add(null);

            // 设置链表的random参数，注意排除末尾null
            Random random = new Random();
            for (int i = 0; i < listNodes.Count - 1; i++)
            {
                //random = random.Next(0, arrLen);
                listNodes[i].random = listNodes[random.Next(0, listNodes.Count)];
            }
            return head.next;
        }

        /// <summary>
        /// 打印传入链表的信息
        /// </summary>
        /// <param name="remarks">备注说明该链表的信息</param>
        /// <param name="listNode">待打印的链表</param>
        public static void PrintList(string remarks, RandomListNode listNode)
        {
            if (listNode == null)
            {
                Console.WriteLine(remarks + "为空");
                return;
            }
            RandomListNode index = listNode;

            // 打印label
            Console.Write(remarks + "val: ");
            while (index.next != null)
            {
                Console.Write(index.label + " -> ");
                index = index.next;
            }
            Console.Write(index.label + " ->null\n");

            // 打印random的label
            index = listNode;
            Console.Write(remarks + "random: ");
            while (index != null)
            {
                if (index.random != null)
                    Console.Write(index.random.label + " -> ");
                else
                    Console.Write(" null ->");
                index = index.next;
            }
            //Console.Write(listNode.random.label);
            Console.WriteLine();
        }
    }
}

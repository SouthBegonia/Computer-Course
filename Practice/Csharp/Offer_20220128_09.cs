using System.Collections.Generic;

namespace CsharpExam
{
    //https://leetcode-cn.com/problems/yong-liang-ge-zhan-shi-xian-dui-lie-lcof/
    // 09 两个栈实现队列
    public class Offer_20220128_09
    {
        public class CQueue
        {
            private Stack<int> mainStack;
            private Stack<int> tempStack;

            public CQueue()
            {
                mainStack = new Stack<int>();
                tempStack = new Stack<int>();
            }

            public void AppendTail(int value)
            {
                mainStack.Push(value);
            }

            public int DeleteHead()
            {
                if (tempStack.Count == 0)
                {
                    while (mainStack.Count>0)
                        tempStack.Push(mainStack.Pop());
                }

                if (tempStack.Count == 0)
                    return -1;
                else
                    return tempStack.Pop();

                //低效：
                // while (mainStack.Count > 0)
                //     tempStack.Push(mainStack.Pop());
                //
                // int val = -1;
                // if (tempStack.Count > 0)
                //     val = tempStack.Pop();
                //
                // while (tempStack.Count > 0)
                //     mainStack.Push(tempStack.Pop());
                //
                // return val;
            }
        }
    }
}
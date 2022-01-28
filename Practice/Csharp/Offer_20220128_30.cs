using System;
using System.Collections.Generic;

namespace CsharpExam
{
    //https://leetcode-cn.com/problems/bao-han-minhan-shu-de-zhan-lcof/
    // 30 包含min函数的栈
    public class Offer_20220128_30
    {
        public class MinStack
        {
            private Stack<int> stack;
            private Stack<int> minStack;    //存储较小值的栈（非严格降序）
            public MinStack()
            {
                stack = new Stack<int>();
                minStack = new Stack<int>();
            }

            public void Push(int x)
            {
                stack.Push(x);
                if (minStack.Count == 0 || minStack.Peek() >= x)    //只有较小之才入minStack栈
                    minStack.Push(x);
            }

            public void Pop()
            {
                int val = stack.Pop();
                if (minStack.Count > 0 && minStack.Peek() == val)
                    minStack.Pop();
            }

            public int Top()
            {
                return stack.Count > 0 ? stack.Peek() : -1;
            }

            public int Min()
            {
                return minStack.Count > 0 ? minStack.Peek() : -1;
            }
        }
    }
}
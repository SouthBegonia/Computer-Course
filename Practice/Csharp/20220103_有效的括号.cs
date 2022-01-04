using System.Collections.Generic;

namespace CsharpExam
{
    public class _20220103_有效的括号
    {
        public static bool IsCoupled(char a, char b)
        {
            switch (a)
            {
                case '(':
                    return b == ')';
                case '[':
                    return b == ']';
                case '{':
                    return b == '}';
            }
            return false;
        }

        public static bool IsValid(string s)
        {
            Stack<char> charStack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                    charStack.Push(c);
                else
                {
                    if (charStack.Count == 0)
                        charStack.Push(c);
                    else
                    {
                        if (IsCoupled(charStack.Peek(), c))
                            charStack.Pop();
                        else
                            charStack.Push(c);
                    }
                }
            }

            return charStack.Count == 0;
        }
    }
}
using System;
using System.Linq;
using System.Text;

namespace CsharpExam
{
    //https://leetcode-cn.com/problems/reverse-prefix-of-word/
    public class _20220202_反转单词前缀
    {
        public string ReversePrefix(string word, char ch)
        {
            int endIndex = word.IndexOf(ch);
            if (endIndex > -1)
            {
                string preStr = word.Substring(0, endIndex + 1);
                string followStr = word.Substring(endIndex + 1, word.Length - endIndex - 1);
                char[] preArr = preStr.ToCharArray();
                Array.Reverse(preArr);
                
                return new string(preArr) + followStr;
            }

            return word;
        }
    }
}
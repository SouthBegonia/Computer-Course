using System;
using System.Text;

namespace CsharpExam
{
    //https://leetcode-cn.com/leetbook/read/array-and-string/crmp5/
    public class _20220112_翻转字符串里的单词
    {
        // static void Main()
        // {
        //     _20220112_翻转字符串里的单词 test = new _20220112_翻转字符串里的单词();
        //
        //     string testArr = "  a 333 fdsd df  d";
        //
        //     string str = test.ReverseWords(testArr);
        //
        //     Console.Write("|" + str +"|");
        // }

        public string ReverseWords(string s)
        {
            //双指针
            int endIndex = s.Length - 1;
            int wordIndex = endIndex;

            StringBuilder sb = new StringBuilder();
            StringBuilder result = new StringBuilder();

            while (endIndex >= 0)
            {
                while (endIndex > 0 && s[endIndex] == ' ')
                    endIndex--;

                wordIndex = endIndex;
                while (wordIndex >= 0)
                {
                    if (s[wordIndex] != ' ')
                        wordIndex--;
                    else
                        break;
                }

                sb.Clear();
                if (wordIndex + 1 >= 0)
                {
                    for (int i = wordIndex+1; i <= endIndex; i++)
                        sb.Append(s[i]);
                }

                if (sb.Length > 0)
                {
                    sb.Append(' ');
                    result.Append(sb);
                }

                endIndex = wordIndex - 1;
            }

            //去尾部空格
            return result.ToString().TrimEnd(' ');
        }
    }
}
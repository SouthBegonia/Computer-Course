namespace CsharpExam
{
    /// <summary>
    /// 58 最后一个单词的长度  https://leetcode.cn/problems/length-of-last-word/
    /// </summary>
    public class _20221116_LengthOfLastWord
    {
        public int LengthOfLastWord(string s)
        {
            int lengthOfLastWord = 0;
            int latterIndex = s.Length - 1;

            while (latterIndex >= 0)
            {
                if (s[latterIndex] == ' ')
                    --latterIndex;
                else
                    break;
            }

            int preIndex = latterIndex;
            while (preIndex >= 0)
            {
                if (s[preIndex] != ' ')
                    ++lengthOfLastWord;
                else
                    break;
                --preIndex;
            }

            return lengthOfLastWord;
        }
    }
}
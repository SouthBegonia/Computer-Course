namespace CsharpExam
{
    /// <summary>
    /// 最长回文子串
    /// </summary>
    public class _20221105_LongestPalindrome
    {
        public string LongestPalindrome(string s)
        {
            if (s.Length == 1)
                return s;

            int maxLen = 0;
            int maxStrStartIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                //奇数情况
                int maxLenOnUnevenNum = GetStrMaxLen(s, i, i);
                if (maxLenOnUnevenNum > maxLen)
                {
                    maxLen = maxLenOnUnevenNum;
                    maxStrStartIndex = i - (maxLenOnUnevenNum - 1) / 2;
                }

                //偶数情况
                int maxLenOnEvenNum = GetStrMaxLen(s, i, i + 1);
                if (maxLenOnEvenNum > maxLen)
                {
                    maxLen = maxLenOnEvenNum;
                    maxStrStartIndex = i - (maxLenOnEvenNum / 2 - 1);
                }
            }

            return s.Substring(maxStrStartIndex, maxLen);
        }

        private int GetStrMaxLen(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length)
            {
                if (s[left] == s[right])
                {
                    --left;
                    ++right;
                }
                else
                    break;
            }

            return right - left - 1;
        }
    }
}
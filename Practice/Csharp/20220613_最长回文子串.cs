using System;

namespace CsharpExam
{
    public class _20220613_最长回文子串
    {
        /*static void Main()
        {
            Console.WriteLine(LongestPalindrome("a"));
            Console.WriteLine(LongestPalindrome("ac"));
            Console.WriteLine(LongestPalindrome("aaaa"));
            Console.WriteLine(LongestPalindrome("abcb"));
            Console.WriteLine(LongestPalindrome("abcbcb"));
            Console.WriteLine(LongestPalindrome("abcbcb123454321123"));

            Console.WriteLine(LongestPalindrome2("a"));
            Console.WriteLine(LongestPalindrome2("ac"));
            Console.WriteLine(LongestPalindrome2("aaaa"));
            Console.WriteLine(LongestPalindrome2("abcb"));
            Console.WriteLine(LongestPalindrome2("abcbcb"));
            Console.WriteLine(LongestPalindrome2("abcbcb123454321123"));
        }*/

        #region 暴力遍历

        public static string LongestPalindrome(string s)
        {
            int maxLen = 1;
            string maxStr = s[0].ToString();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                int checkIndex = i;
                int nextSameLetterIndex = -1;

                do
                {
                    nextSameLetterIndex = GetNextSameLettersIndex(s, checkIndex, c);
                    if (nextSameLetterIndex > 0)
                    {
                        string subStr = s.Substring(i, nextSameLetterIndex - i+1);
                        if (CheckIsPalindrome(subStr))
                        {
                            if (subStr.Length > maxLen)
                            {
                                maxLen = subStr.Length;
                                maxStr = subStr;
                            }
                        }
                        checkIndex = nextSameLetterIndex;
                    }
                } while (nextSameLetterIndex > 0);
            }

            return maxStr;
        }

        private static bool CheckIsPalindrome(string s)
        {
            int preIndex = 0;
            int latterIndex = s.Length - 1;

            while (preIndex < latterIndex)
            {
                if (s[preIndex] != s[latterIndex])
                    return false;
                preIndex++;
                latterIndex--;
            }

            return true;
        }

        private static int GetNextSameLettersIndex(string s, int startIndex, char targetChar)
        {
            int index = startIndex + 1;
            while (index < s.Length)
            {
                if (s[index] == targetChar)
                    return index;
                index++;
            }

            return -1;
        }

        #endregion

        #region 中心扩展遍历

        public static string LongestPalindrome2(string s)
        {
            if (s == null || s.Length <= 1)
                return s;

            int maxLen = 1;
            int resStartIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                //奇数
                int unevenNumLen = GetlongestLen(s, i, i);
                if (unevenNumLen > maxLen)
                {
                    maxLen = unevenNumLen;
                    resStartIndex = i - unevenNumLen / 2;
                }

                //偶数
                int evenNumLen = GetlongestLen(s, i, i + 1);
                if (evenNumLen > maxLen)
                {
                    maxLen = evenNumLen;
                    resStartIndex = i - evenNumLen / 2 + 1;
                }
            }

            return s.Substring(resStartIndex, maxLen);
        }

        private static int GetlongestLen(string s, int leftIndex, int rightIndex)
        {
            while (leftIndex >=0 && rightIndex < s.Length)
            {
                if (s[leftIndex] != s[rightIndex])
                    break;
                leftIndex--;
                rightIndex++;
            }

            return rightIndex - leftIndex - 1;
        }

        #endregion
    }
}
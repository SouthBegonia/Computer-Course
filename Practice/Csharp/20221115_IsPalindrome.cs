using System;
using System.Linq;

namespace CsharpExam
{
    /// <summary>
    /// 09 回文数  https://leetcode.cn/problems/palindrome-number/
    /// </summary>
    public class _20221115_IsPalindrome
    {
        /*public bool IsPalindrome(int x)
        {
            var chars = x.ToString().ToArray();
            int len = chars.Length;

            int leftIndex = len % 2 == 0 ? (len/2-1) : (len / 2);
            int rightIndex = len / 2;

            while (leftIndex >= 0 && rightIndex < len)
            {
                if (chars[leftIndex] != chars[rightIndex])
                    return false;
                --leftIndex;
                ++rightIndex;
            }

            return true;
        }*/

        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
                return false;

            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            return x == revertedNumber || x == revertedNumber / 10;
        }
    }
}
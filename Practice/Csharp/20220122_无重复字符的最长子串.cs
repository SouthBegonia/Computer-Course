using System;
using System.Collections;
using System.Collections.Generic;

namespace CsharpExam
{
    //https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/submissions/
    public class _20220122_无重复字符的最长子串
    {
        public int LengthOfLongestSubstring2(string s)
        {
            //暴力遍历
            int minLen = 0;
            int len = s.Length;
            List<char> list = new List<char>(len);

            for (int i = 0; i < len; i++)
            {
                int nextIndex = i;
                list.Clear();

                //每次都以i为起点向后遍历
                while (nextIndex < len)
                {
                    if (list.Contains(s[nextIndex]))
                        break;
                    else
                    {
                        list.Add(s[nextIndex]);
                        minLen = Math.Max(minLen, list.Count);
                        ++nextIndex;
                    }
                }
            }
            return minLen;
        }
    }
}
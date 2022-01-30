using System;

namespace CsharpExam
{
    public class Offer_20220130_58
    {
        //https://leetcode-cn.com/problems/zuo-xuan-zhuan-zi-fu-chuan-lcof/
        // 58 左旋转字符串
        public string ReverseLeftWords(string s, int n)
        {
            int len = s.Length;
            n = n % len;

            string left = s.Substring(0, n);
            string right = s.Substring(n, len - n);
            left = ReverseStr(left);
            right = ReverseStr(right);

            return ReverseStr(left + right);
        }

        string ReverseStr(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
using System.Collections.Generic;

namespace CsharpExam
{
    //https://leetcode-cn.com/problems/di-yi-ge-zhi-chu-xian-yi-ci-de-zi-fu-lcof/
    // 50 第一个只出现一次的字符
    public class Offer_20220203_50
    {
        public char FirstUniqChar(string s)
        {
            char[] arr = s.ToCharArray();
            Dictionary<char, int> dictionary = new Dictionary<char, int>(arr.Length);

            foreach (char c in arr)
            {
                if (dictionary.ContainsKey(c))
                    dictionary[c] += 1;
                else
                    dictionary.Add(c, 1);
            }

            foreach (KeyValuePair<char,int> keyValuePair in dictionary)
            {
                if (keyValuePair.Value == 1)
                    return keyValuePair.Key;
            }

            return ' ';
        }
    }
}
using System;
using System.Text;

namespace CsharpExam
{
    /// <summary>
    /// 43 字符串相乘  https://leetcode.cn/problems/multiply-strings/
    /// </summary>
    public class _20221204_Multiply
    {
        /*static void Main()
        {
            string num1 = "123";
            string num2 = "456";

            Console.WriteLine(Multiply(num1, num2));    //56088
        }*/

        public static string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
                return "0";

            int num1Len = num1.Length; // 12345
            int num2Len = num2.Length; //67

            string ret = "0";
            int curIndex = 1;   //当前位乘积系数
            StringBuilder temp = new StringBuilder();

            for (int i = num2Len - 1; i >= 0; i--)
            {
                int lastRemainder = 0;
                temp.Length = 0;
                for (int j = num1Len - 1; j >= 0; j--)
                {
                    int tempMulti = (num2[i] - '0') * (num1[j] - '0') + lastRemainder;
                    if (tempMulti >= 10)
                    {
                        lastRemainder = tempMulti / 10;
                        tempMulti %= 10;
                    }
                    else
                        lastRemainder = 0;

                    temp.Append(tempMulti);
                }
                if (lastRemainder > 0)
                    temp.Append(lastRemainder);

                string curVal = GetReverseString(temp);
                for (int m = 2; m <= curIndex; m++)
                    curVal += "0"; // 7*12345 = ...  60*12345= ...
                ++curIndex;

                ret = AddStringNum(ret, curVal);
            }

            return ret;
        }

        private static string GetReverseString(StringBuilder sb)
        {
            StringBuilder ret = new StringBuilder(sb.Length);
            for (int i = sb.Length - 1; i >= 0; i--)
                ret.Append(sb[i]);
            return ret.ToString();
        }

        public static string AddStringNum(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
                return t;
            if (string.IsNullOrEmpty(t))
                return s;

            int slen = s.Length;
            int tlen = t.Length;
            int sIndex = 0;
            int tIndex = 0;
            int lastRemainder = 0;

            StringBuilder tempRet = new StringBuilder();
            while (sIndex < slen || tIndex < tlen)
            {
                int sNum = sIndex < slen ? s[slen - sIndex - 1] - '0' : 0;
                int tNum = tIndex < tlen ? t[tlen - tIndex - 1] - '0' : 0;
                int sum = sNum + tNum + lastRemainder;
                if (sum >= 10)
                {
                    lastRemainder = sum / 10;
                    sum %= 10;
                }
                else
                    lastRemainder = 0;

                tempRet.Append(sum);

                sIndex++;
                tIndex++;
            }

            if (lastRemainder > 0)
                tempRet.Append(lastRemainder);

            StringBuilder ret = new StringBuilder();
            for (int i = 0; i < tempRet.Length; i++)
                ret.Append(tempRet[tempRet.Length - i - 1]);

            return ret.ToString();
        }
    }
}
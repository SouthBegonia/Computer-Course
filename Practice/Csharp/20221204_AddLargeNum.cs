using System;
using System.Text;

namespace CsharpExam
{
    public class _20221204_AddLargeNum
    {
        /*static void Main()
        {
            string s = "999";
            string t = "99999";

            solve(s, t);
        }*/

        public static string solve(string s, string t)
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
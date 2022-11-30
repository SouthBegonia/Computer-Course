using System;

namespace CsharpExam
{
    /// <summary>
    /// 模式串匹配 - Sunday算法
    /// </summary>
    public class _20221130_Sunday
    {
        /*static void Main()
        {
            string s, p;

            s = "substring searching";
            p = "search";
            Sunday(s, p);

            s = "hella hellb hello! ";
            p = "hello";
            Sunday(s, p);

            s = "hella hellb hello! ";
            p = "hallo";
            Sunday(s, p);

            s = "a";
            p = "a";
            Sunday(s, p);
        }*/

        public static int Sunday(string str1, string str2)
        {
            int str1Len = str1.Length;
            int str2Len = str2.Length;

            if (str2Len > str1Len)
                return -1;

            int retStartIndex = -1;
            int str1Index = 0;
            int str2Index = 0;

            while (str2Index < str2Len && str1Index < str1Len)
            {
                if (str1[str1Index] == str2[str2Index])
                {
                    str1Index++;
                    str2Index++;
                }
                else
                {
                    //计算末尾+1位置的char
                    int checkCharIndexInStr1 = str1Index + (str2Len - str2Index);
                    if (checkCharIndexInStr1 >= str1.Length)
                        break;
                    int checkCharIndexInStr2 = GetLastCharIndex(str2, str1[checkCharIndexInStr1]);
                    if (checkCharIndexInStr2 == -1)
                        //str2中没有目标char，str1Index整体位移到char后一位
                        str1Index = checkCharIndexInStr1 + 1;
                    else
                        //str2中有目标char，则str1Index位移直至对齐
                        str1Index += (str2Len - checkCharIndexInStr2);

                    //模式串重置index
                    str2Index = 0;
                }
            }

            if (str2Index == str2Len)
                retStartIndex = str1Index - str2Len;

            //LOG(str1, str2, retStartIndex);

            return retStartIndex;
        }

        private static int GetLastCharIndex(string str, char c)
        {
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == c)
                    return i;
            }
            return -1;
        }

        private static void LOG(string s, string p, int ret)
        {
            if (ret == -1)
            {
                Console.WriteLine(ret);
                return;
            }

            Console.WriteLine(s.Substring(ret, p.Length));
        }
    }
}
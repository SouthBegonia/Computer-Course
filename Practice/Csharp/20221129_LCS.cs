namespace CsharpExam
{
    /// <summary>
    /// 最长公共子串  https://www.nowcoder.com/practice/f33f5adc55f444baa0e0ca87ad8a6aac?tpId=295&tqId=991150&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221129_LCS
    {
        public string LCS(string str1, string str2)
        {
            //dp[i][j]表示在str1中以第i个字符结尾在str2中以第j个字符结尾时的公共子串长度
            int[,] dp = new int[str1.Length + 1, str2.Length + 1];

            int max = 0;
            int pos = 0;

            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = 0;
                    if (dp[i, j] > max)
                    {
                        max = dp[i, j];
                        pos = i - 1;
                    }
                }
            }

            if (max > 0)
                return str1.Substring(pos - max + 1, max);
            else
                return "";
        }
    }
}
using System;

namespace Code031
{
    /// <summary>
    /// 031 整数中1出现的次数
    /// </summary>
    class Algorithm_others_031
    {
        /*
        设N = abcde ,其中abcde分别为十进制中各位上的数字。
        如果要计算百位上1出现的次数，它要受到3方面的影响：百位上的数字，百位以下（低位）的数字，百位以上（高位）的数字。
        ① 如果百位上数字为0，百位上可能出现1的次数由更高位决定。比如：12013，则可以知道百位出现1的情况可能是：100~199，1100~1199,2100~2199，，...，11100~11199，一共1200个。可以看出是由更高位数字（12）决定，并且等于更高位数字（12）乘以 当前位数（100）。
        ② 如果百位上数字为1，百位上可能出现1的次数不仅受更高位影响还受低位影响。比如：12113，则可以知道百位受高位影响出现的情况是：100~199，1100~1199,2100~2199，，....，11100~11199，一共1200个。和上面情况一样，并且等于更高位数字（12）乘以 当前位数（100）。但同时它还受低位影响，百位出现1的情况是：12100~12113,一共114个，等于低位数字（113）+1。
        ③ 如果百位上数字大于1（2~9），则百位上出现1的情况仅由更高位决定，比如12213，则百位出现1的情况是：100~199,1100~1199，2100~2199，...，11100~11199,12100~12199,一共有1300个，并且等于更高位数字+1（12+1）乘以当前位数（100）。

        参考链接：https://www.nowcoder.com/questionTerminal/bd7f978302044eee894445e244c7eee6
        */

        /// <summary>
        /// 031 整数中1出现的次数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int NumberOf1Between1AndN_Solution(int n)
        {
            int count = 0;      // 1的个数
            int i = 1;          // 当前位
            int current = 0, after = 0, before = 0;

            while ((n / i) != 0)
            {
                current = (n / i) % 10;     // 高位数字
                before = n / (i * 10);      // 当前位数字
                after = n - (n / i) * i;    // 低位数字

                // 如果为0,出现1的次数由 高位 决定,等于 高位数字 * 当前位数
                if (current == 0)
                    count += before * i;

                // 如果为1,出现1的次数由 高位和低位 决定,等于 高位*当前位+低位+1
                else if (current == 1)
                    count += before * i + after + 1;
                else
                {
                    // 如果大于1,出现1的次数由 高位 决定,等于 （高位数字+1）* 当前位数
                    count += (before + 1) * i;
                }

                // 前移一位
                i = i * 10;
            }
            return count;
        }

        public static void Run()
        {
            int[] testNums = new int[] { 0, 13, 199, 1099, 1299, 12013, 12113, 12213 };
            foreach (int i in testNums)
            {
                Console.Write("{0} 中1出现的次数为：{1}\n\n", i, NumberOf1Between1AndN_Solution(i));
            }
        }
    }
}
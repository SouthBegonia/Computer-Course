using System;

namespace CsharpExam
{
    /// <summary>
    /// 比较版本号  https://www.nowcoder.com/practice/2b317e02f14247a49ffdbdba315459e7?tpId=295&tqId=1024572&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221210_compareVersion
    {
        /// <summary>
        /// 判断 <see cref="version1"/> 的版本号是否大于 <see cref="version2"/>
        /// </summary>
        /// <param name="version1"></param>
        /// <param name="version2"></param>
        /// <returns></returns>
        public int compare(string version1, string version2)
        {
            string[] v1Arr = version1.Split('.');
            string[] v2Arr = version2.Split('.');

            int maxVersionCount = Math.Max(v1Arr.Length, v2Arr.Length);
            for (int i = 0; i < maxVersionCount; i++)
            {
                string curV1Version = i < v1Arr.Length ? v1Arr[i] : "0";
                string curV2Version = i < v2Arr.Length ? v2Arr[i] : "0";

                int curV1Number = Convert.ToInt32(curV1Version);
                int curV2Number = Convert.ToInt32(curV2Version);

                if (curV1Number > curV2Number)
                    return 1;
                else if (curV1Number < curV2Number)
                    return -1;
            }

            return 0;
        }
    }
}
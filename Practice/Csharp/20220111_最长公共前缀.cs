namespace CsharpExam
{
    //https://leetcode-cn.com/leetbook/read/array-and-string/ceda1/
    public class _20220111_最长公共前缀
    {
        public string LongestCommonPrefix(string[] strs)
        {
            string minStr = strs[0];
            foreach (string str in strs)
            {
                if (str.Length < minStr.Length)
                    minStr = str;
            }

            int minLen = minStr.Length;

            foreach (string str in strs)
            {
                while (minLen > 0)
                {
                    if(str.StartsWith(minStr.Substring(0,minLen)))
                        break;
                    minLen--;
                }
            }

            return minStr.Substring(0, minLen);
        }
    }
}
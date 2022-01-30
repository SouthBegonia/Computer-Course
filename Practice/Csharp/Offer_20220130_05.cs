using System.Linq;
using System.Text;

namespace CsharpExam
{
    //https://leetcode-cn.com/problems/ti-huan-kong-ge-lcof/
    // 05 替换空格
    public class Offer_20220130_05
    {
        public string ReplaceSpace(string s)
        {
            char[] arr = s.ToArray();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == ' ')
                    sb.Append("%20");
                else
                    sb.Append(arr[i]);
            }

            return sb.ToString();
        }
    }
}
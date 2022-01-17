using System.Collections.Generic;

namespace CsharpExam
{
    //https://leetcode-cn.com/leetbook/read/array-and-string/cuj3m/
    public class _20220117_杨辉三角
    {
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> result = new List<IList<int>>(numRows);
            for (int i = 0; i < numRows; i++)
                result.Add(new List<int>(i + 1));

            for (int i = 0; i < numRows; i++)
            {
                int len = i + 1;
                for (int j = 0; j < len; j++)
                {
                    if (j == 0 || j == len - 1)
                        result[i].Add(1);
                    else
                        result[i].Add(result[i - 1][j - 1] + result[i - 1][j]);
                }
            }

            return result;
        }
    }
}
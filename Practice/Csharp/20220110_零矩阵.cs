using System.Collections.Generic;

namespace CsharpExam
{
    //https://leetcode-cn.com/leetbook/read/array-and-string/ciekh/
    public class _20220110_零矩阵
    {
        public void SetZeroes(int[][] matrix)
        {
            int rows = matrix?.Length ?? 0;
            int cols = rows > 0 ? matrix[0].Length : 0;

            //待删除行列的index
            List<int> rowDelIndexList = new List<int>();
            List<int> colDelIndexList = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        if (!rowDelIndexList.Contains(i))
                            rowDelIndexList.Add(i);

                        if (!colDelIndexList.Contains(j))
                            colDelIndexList.Add(j);
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (rowDelIndexList.Contains(i) || colDelIndexList.Contains(j))
                        matrix[i][j] = 0;
                }
            }
        }
    }
}
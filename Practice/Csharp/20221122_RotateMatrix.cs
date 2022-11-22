using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 顺时针旋转矩阵
    /// </summary>
    public class _20221122_RotateMatrix
    {
        public List<List<int>> rotateMatrix(List<List<int>> mat, int n)
        {
            List<List<int>> rotatedMatrix = new List<List<int>>(n);
            for (int i = 0; i < n; i++)
            {
                List<int> arr = new List<int>(n);
                for (int j = 0; j < n; j++)
                    arr.Add(0);

                rotatedMatrix.Add(arr);
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    rotatedMatrix[i][j] = mat[n - 1 - j][i];

            return rotatedMatrix;
        }
    }
}
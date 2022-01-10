using System;
using System.Collections.Generic;

namespace CsharpExam
{
    public class _20220110_对角线遍历
    {
        static void Main()
        {
            int[][] matrix3 = new int[3][];
            matrix3[0] = new[] {1, 2, 3, 0};
            matrix3[1] = new[] {4, 5, 6, 0};
            matrix3[2] = new[] {7, 8, 9, 0};

            _20220110_对角线遍历 test = new _20220110_对角线遍历();
            var result = test.FindDiagonalOrder(matrix3);
        }

        public int[] FindDiagonalOrder(int[][] mat)
        {
            int rows = mat?.Length - 1 ?? 0;
            int cols = rows >= 0 ? mat[0].Length - 1 : 0;

            int x = 0;
            int y = 0;

            List<int> result = new List<int>(mat?.Length ?? 0);

            for (int i = 0; i <= rows + cols; i++)
            {
                if (i % 2 != 0)
                {

                    //奇数层：左下到右上
                    for (int j = y; j >= i - x; j--)
                        result.Add(mat[i - j][j]);
                }
                else
                {
                    //偶数层：右上到左下
                    for (int j = x; j >= i - y; j--)
                        result.Add(mat[j][i - j]);
                }

                x = x >= rows? rows : x + 1;
                y = y >= cols? cols : y + 1;
            }

            return result.ToArray();
        }
    }
}
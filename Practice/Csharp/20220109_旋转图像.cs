using System;
using System.Collections.Generic;

namespace CsharpExam
{
    //https://leetcode-cn.com/problems/rotate-image/
    public class _20220109_旋转图像
    {
        static void Main()
        {
            int[][] matrix3 = new int[3][];
            matrix3[0] = new[] {1, 2, 3};
            matrix3[1] = new[] {4, 5, 6};
            matrix3[2] = new[] {7, 8, 9};

            Rotate(matrix3);

            int[][] matrix4 = new int[4][];
            matrix4[0] = new[] {5, 1, 9, 11};
            matrix4[1] = new[] {2, 4, 8, 10};
            matrix4[2] = new[] {13, 3, 6, 7};
            matrix4[3] = new[] {15, 14, 12, 16};

            Rotate(matrix4);
        }

        public static void Rotate(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = rows;

            int count = rows / 2 - 1; //需要转的圈数

            //用队列顺时针存储当前圈的数据，再从旋转90度的index起出队
            Queue<int> queue = new Queue<int>();

            //从外到内，顺时针转90度
            for (int i = 0; i <= count; i++)
            {
                //进
                for (int j = i; j < rows - i; j++)
                    queue.Enqueue(matrix[i][j]);

                for (int j = i; j < rows - i; j++)
                    queue.Enqueue(matrix[j][rows - i - 1]); //注意边界

                for (int j = i; j < rows - i; j++)
                    queue.Enqueue(matrix[rows - i - 1][rows - j - 1]);

                for (int j = i; j < rows - i; j++)
                    queue.Enqueue(matrix[rows - j - 1][i]);

                //出
                for (int j = i; j < rows - i; j++)
                    matrix[j][rows - i - 1] = queue.Dequeue();

                for (int j = i; j < rows - i; j++)
                    matrix[rows - i - 1][rows - j - 1] = queue.Dequeue();

                for (int j = i; j < rows - i; j++)
                    matrix[rows - j - 1][i] = queue.Dequeue();

                for (int j = i; j < rows - i; j++)
                    matrix[i][j] = queue.Dequeue();
            }
        }
    }
}
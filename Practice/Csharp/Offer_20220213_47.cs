using System;

namespace CsharpExam
{
    // https://leetcode-cn.com/problems/li-wu-de-zui-da-jie-zhi-lcof/
    // 47 礼物的最大价值
    public class Offer_20220213_47
    {
        public int MaxValue(int[][] grid)
        {
            int row = grid.Length;
            int col = grid[0].Length;

            //grid[i][j] 转换为  grid[0][0]到grid[i][j]的最大累计价值
            for (int j = 1; j < col; j++) // 初始化第一行
                grid[0][j] += grid[0][j - 1];

            for (int i = 1; i < row; i++) // 初始化第一列
                grid[i][0] += grid[i - 1][0];

            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                    grid[i][j] += Math.Max(grid[i][j - 1], grid[i - 1][j]);
            }

            return grid[row - 1][col - 1];
        }
    }
}
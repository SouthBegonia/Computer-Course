namespace CsharpExam
{
    //https://leetcode-cn.com/problems/er-wei-shu-zu-zhong-de-cha-zhao-lcof/
    // 04 二维数字中的查找
    public class Offer_20220203_04
    {
        public bool FindNumberIn2DArray(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return false;

            int row = matrix.Length, col = matrix[0].Length;
            int i = 0, j = col - 1;

            while (i < row && j >= 0)
            {
                if (target > matrix[i][j])
                    i++;
                else if (target < matrix[i][j])
                    j--;
                else
                    return true;
            }
            return false;
        }
    }
}
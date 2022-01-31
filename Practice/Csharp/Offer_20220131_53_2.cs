namespace CsharpExam
{
    //https://leetcode-cn.com/problems/que-shi-de-shu-zi-lcof/
    // 53 0~n中缺失的数字
    public class Offer_20220131_53_2
    {
        public int MissingNumber(int[] nums)
        {
            int i = 0, j = nums.Length - 1;
            while (i <= j)
            {
                int m = (i + j) / 2;
                if (nums[m] == m)
                    i = m + 1;
                else
                    j = m - 1;
            }

            return i;
        }
    }
}
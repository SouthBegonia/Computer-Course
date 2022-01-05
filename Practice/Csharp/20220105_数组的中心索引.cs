namespace CsharpExam
{
    public class _20220105_数组的中心索引
    {
        public int PivotIndex(int[] nums)
        {
            int leftTotal = 0;
            int rightTotal = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                leftTotal = GetTotalCount(nums, 0, i - 1);
                rightTotal = GetTotalCount(nums, i + 1, nums.Length - 1);

                if (leftTotal == rightTotal)
                    return i;
            }

            if (nums.Length == 1)
                return 0;
            else
                return -1;
        }

        public static int GetTotalCount(int[] nums, int left, int right)
        {
            int total = 0;
            for (int i = left; i <= right; i++)
                total += nums[i];

            return total;
        }

        public int PivotIndex2(int[] nums)
        {
            //先求总和
            int sum = 0;
            foreach (int num in nums)
                sum += num;

            //顺序遍历
            int leftSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum -= nums[i];    //总和内扣除当前遍历值，剩下的即为当前值的右侧值的总和
                if (leftSum == sum)
                    return i;        //左和右和相等
                leftSum += nums[i];    //左侧总值累加
            }

            return -1;
        }
    }
}
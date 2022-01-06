namespace CsharpExam
{
    //https://leetcode-cn.com/leetbook/read/array-and-string/cxqdh/
    public class _20220106_搜索插入位置
    {
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int middle;

            while (left <= right)
            {
                middle = left + (right - left) / 2;

                if (nums[middle] == target)
                    return middle;
                else if (nums[middle] < target)
                    left = middle + 1;
                else if (nums[middle] > target)
                    right = middle - 1;
            }

            return left;
        }
    }
}
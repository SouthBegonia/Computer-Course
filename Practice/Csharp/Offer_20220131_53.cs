namespace CsharpExam
{
    //https://leetcode-cn.com/problems/zai-pai-xu-shu-zu-zhong-cha-zhao-shu-zi-lcof/
    // 53 在排序数组中查找数字
    public class Offer_20220131_53
    {
        public int Search(int[] nums, int target)
        {
            //双指针
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                if (nums[left] == nums[right] && nums[right] == target)
                    break;

                if (nums[left] != target)
                    left++;
                if (nums[right] != target)
                    right--;
            }

            return right >= left ? right - left + 1 : 0;
        }
    }
}
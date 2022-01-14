namespace CsharpExam
{
    //https://leetcode-cn.com/leetbook/read/array-and-string/cwuyj/
    public class _20220114_移除元素
    {
        public int RemoveElement(int[] nums, int val)
        {
            int newIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                    nums[newIndex++] = nums[i];
            }

            return newIndex;
        }
    }
}
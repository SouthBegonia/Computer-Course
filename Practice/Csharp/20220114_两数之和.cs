namespace CsharpExam
{
    //https://leetcode-cn.com/leetbook/read/array-and-string/cnkjg/
    public class _20220114_两数之和
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            int endIndex = numbers.Length - 1;
            int startIndex = 0;

            while (endIndex > startIndex)
            {
                int sum = numbers[endIndex] + numbers[startIndex];
                if (sum == target)
                    return new int[] {startIndex + 1, endIndex + 1};
                else if (sum > target)
                    endIndex--;
                else
                    startIndex++;
            }

            return new[] {0, 0};
        }
    }
}
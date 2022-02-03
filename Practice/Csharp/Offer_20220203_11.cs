namespace CsharpExam
{
    //https://leetcode-cn.com/problems/xuan-zhuan-shu-zu-de-zui-xiao-shu-zi-lcof/
    // 11 旋转数组里的最小数字
    public class Offer_20220203_11
    {
        public int MinArray(int[] numbers)
        {
            int left = 0, right = numbers.Length - 1;

            while (left < right)
            {
                int middle = (left + right) / 2;
                if (numbers[middle] > numbers[right])
                {
                    left = middle + 1;
                }
                else if (numbers[middle] < numbers[right])
                {
                    right = middle;
                }
                else
                {
                    right -= 1;
                }
            }

            return numbers[left];
        }
    }
}
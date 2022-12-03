using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 旋转数组最小数字  https://www.nowcoder.com/practice/9f3231a991af4f55b95579b44b7a01ba?tpId=295&tqId=23269
    /// </summary>
    public class _20221203_minNumberInRotateArray
    {
        public int minNumberInRotateArray(List<int> rotateArray)
        {
            int left = 0;
            int right = rotateArray.Count - 1;

            while (left <= right)
            {
                if (left == right)
                    return rotateArray[left];

                int mid = (left + right) / 2;
                if (rotateArray[mid] > rotateArray[right])
                {
                    //右侧非升序，则旋转点在右侧
                    left = mid + 1;
                }
                else if (rotateArray[mid] < rotateArray[right])
                {
                    //右侧均升序，则旋转点一定在左侧
                    right = mid;
                }
                else
                {
                    --right;
                }
            }

            return 0;
        }
    }
}
using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 数组中出现次数超过一半的数字  https://www.nowcoder.com/practice/e8a1b01a2df14cb2b228b30ee6a92163?tpId=295&tqId=23271&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221124_MoreThanHalfNum
    {
        public int MoreThanHalfNum_Solution (List<int> numbers)
        {
            int numsCount = numbers.Count;
            if (numsCount == 0)
                return 0;

            int mostNumCount = 1;
            int result = numbers[0];

            for(int i=1; i<numsCount; i++)
            {
                if (numbers[i] != result)
                    --mostNumCount;
                else
                    ++mostNumCount;

                if (mostNumCount <= 0)
                {
                    result = numbers[i];
                    mostNumCount = 1;
                }
            }

            return result;
        }
    }
}
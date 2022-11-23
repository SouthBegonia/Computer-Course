using System;
using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 二维数组中的查找 https://www.nowcoder.com/practice/abc3fe2ce8e146608e868a70efebf62e?tpId=295&tqId=23256&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221123_FindTargetIn2DArray
    {
        public bool Find (int target, List<List<int>> array)
        {
            if (array == null || array.Count == 0)
                return false;

            //从左下角开始遍历
            int MaxRow = array.Count;
            int MaxCol = array[0].Count;
            int rowIndex = MaxRow - 1;
            int colIndex = 0;

            while(rowIndex >= 0 && colIndex < MaxCol)
            {
                Console.WriteLine(array[rowIndex][colIndex]);
                int temp = array[rowIndex][colIndex];
                if (temp == target)
                    return true;
                else
                {
                    if (temp < target)
                        ++colIndex;
                    else
                        --rowIndex;
                }
            }

            return false;
        }
    }
}
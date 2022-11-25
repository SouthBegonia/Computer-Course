using System;
using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 数组中只出现一次的两个数字  https://www.nowcoder.com/practice/389fc1c3d3be4479a154f63f495abff8?tpId=295&tqId=1375231&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221125_FindNumsAppearOnce
    {
        public List<int> FindNumsAppearOnce (List<int> array)
        {
            HashSet<int> hashSet = new HashSet<int>();
            List<int> result = new List<int>(2);

            for(int i=0; i<array.Count; i++)
            {
                if (hashSet.Contains(array[i]))
                    hashSet.Remove(array[i]);
                else
                    hashSet.Add(array[i]);
            }

            foreach (int val in hashSet)
            {
                Console.WriteLine(val);
                result.Add(val);
            }

            if (result[0] > result[1])
                result.Reverse();

            return result;
        }
    }
}
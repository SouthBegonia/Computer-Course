using System;
using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 最长无重复子数组  https://www.nowcoder.com/practice/b56799ebfd684fb394bd315e89324fb4?tpId=295&tqId=1008889&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221211_maxUniqueStringLength
    {
        public int maxLength(List<int> arr)
        {
            if (arr == null)
                return -1;
            if (arr.Count <= 1)
                return arr.Count;

            Queue<int> queue = new Queue<int>();

            int ret = 0;
            int index = 0;
            int count = arr.Count;

            while (index < count)
            {
                int val = arr[index];
                if (!queue.Contains(val))
                {
                    //非重复数字，加入
                    queue.Enqueue(val);
                    ret = Math.Max(ret, queue.Count);
                }
                else
                {
                    //重复数字，舍弃原有重复数字及其前面的所有
                    RemoveQueueElements(ref queue, val);
                    queue.Enqueue(val);
                }
                ++index;
            }

            return ret;
        }

        /// <summary>
        /// 移除queue内val及其前面的所有值
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="val"></param>
        public void RemoveQueueElements(ref Queue<int> queue, int val)
        {
            if (queue == null || !queue.Contains(val))
                return;

            while (queue.Count > 0)
            {
                int tempVal = queue.Peek();
                if (tempVal != val)
                {
                    queue.Dequeue();
                }
                else
                {
                    queue.Dequeue();
                    return;
                }
            }
        }
    }
}
using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 最小的k个数  https://www.nowcoder.com/practice/6a296eb82cf844ca8539b57c23e6e9bf?tpId=295&tqId=23263&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221126_GetLeastNumbers_Solution
    {
        /// <summary>
        /// 快排实现
        /// </summary>
        /// <param name="input"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public List<int> GetLeastNumbers_Solution(List<int> input, int k)
        {
            int left = 0;
            int right = input.Count - 1;
            List<int> result = new List<int>(k);

            if (k == 0 || k > right + 1)
                return result;

            while (left <= right)
            {
                int partition = Partition(input, left, right);
                if (partition + 1 == k)
                {
                    for (int i = 0; i < k; i++)
                        result.Add(input[i]);
                    break;
                }

                if (partition + 1 < k)
                    left = partition + 1;
                else
                    right = partition;
            }

            result.Sort((a, b) => a.CompareTo(b));
            return result;
        }

        public int Partition(List<int> arr, int left, int right)
        {
            int privot = left;
            int index = left + 1;

            for (int i = index; i <= right; i++)
            {
                if (arr[i] < arr[privot])
                {
                    Swap(arr, i, index);
                    ++index;
                }
            }

            Swap(arr, privot, index - 1);
            return index - 1;
        }

        public void Swap(List<int> arr, int a, int b)
        {
            if (arr[a] != arr[b])
            {
                arr[a] ^= arr[b];
                arr[b] ^= arr[a];
                arr[a] ^= arr[b];
            }
        }
    }
}
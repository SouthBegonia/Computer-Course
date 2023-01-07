using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 寻找第K大  https://www.nowcoder.com/practice/e016ad9b7f0b45048c58a9f27ba618bf?tpId=295&tqId=44581&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20230107_findKth
    {
        public int findKth(List<int> a, int n, int K)
        {
            if (K > n)
                return 0;

            int left = 0;
            int right = n - 1;

            while (left <= right)
            {
                int partition = Partition(a, left, right);

                if (partition + 1 == K)
                {
                    return a[partition];
                }
                else if (partition + 1 < K)
                    left = partition + 1;
                else
                    right = partition;
            }

            return 0;
        }

        public int Partition(List<int> arr, int left, int right)
        {
            int privot = left;
            int index = left + 1;

            for (int i = index; i <= right; i++)
            {
                if (arr[i] > arr[privot])
                {
                    Swap(arr, i, index);
                    index++;
                }
            }

            Swap(arr, privot, index - 1);
            return index - 1;
        }

        public void Swap(List<int> arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
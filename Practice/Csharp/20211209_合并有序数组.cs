namespace CsharpExam
{
    public class _20211209_合并有序数组
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int mIndex = m - 1;            //长组数尾指针
            int nIndex = n - 1;            //短数组尾指针
            int endIndex = m + n - 1;      //整数组尾指针

            //双指针遍历
            while (nIndex >= 0)
            {
                nums1[endIndex--] = (mIndex >= 0 && nums1[mIndex] > nums2[nIndex]) ? nums1[mIndex--] : nums2[nIndex--];
            }
        }
    }
}
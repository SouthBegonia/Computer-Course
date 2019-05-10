/*
程序功能：冒泡排序
基本思路：
从左往右，对每对相邻元素比较，较大的向后，一趟比较循环，会将序列内最大元素移动至末尾；
使得无序序列长度-1，有序序列长度+1，重复该过程，每次都找出无序序列内最大值移动到有序序列；
最终当循环过程不发生任何元素交换移动时，标志冒泡排序结束。

时间复杂度：
最坏情况：操作次数 n(n-1)/2  O(n^2)
最好情况：操作次数 n-1       O(n)

空间复杂度：
额外辅助空间仅有temp，故复杂度 O(1)
*/
#include<iostream>
using namespace std;

void BubbleSort(int arr[], int n)
{
    int i,j;
    int flag;       //排序是否完毕 1未完 0完成
    int temp;

    for(i=n-1;i>=1;i--)         //每趟排序把最大元素移至后面
    {
        flag = 0;
        for(j=1;j<=i;j++)       //从左往右，相邻元素比较
            if(arr[j-1]>arr[j]) //交换移动
            {
                temp = arr[j];
                arr[j] = arr[j-1];
                arr[j-1] = temp;
                flag = 1;
            }
        if(flag==0)             //若某趟排序中没有发生交换，标志排序完毕
            return;
    }
}

int main()
{
    int R[8] = {49,38,65,97,76,13,27,49};
    for(int i=0;i<8;i++)
        cout<<R[i]<<" ";
    cout<<endl;

    BubbleSort(R,8);
    for(int i=0;i<8;i++)
        cout<<R[i]<<" ";
    return 0;
}


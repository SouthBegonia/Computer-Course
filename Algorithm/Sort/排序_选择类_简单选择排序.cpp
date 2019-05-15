/*
程序功能：简单选择排序
基本思路：
将原序列看作有序序列与无序序列组成(初始全为无序序列)；
对无序序列进行扫描，找出序列内最小值；
将其与无序序列首元素交换；
由此有序序列增长，无序序列缩短；
重复每次找最小值放于前列的过程，实现排序。

时间复杂度：
循环次数与初始序列无关，操作次数 n(n-1)/2  O(N^2)

空间复杂度
O(1)
*/
#include<iostream>
using namespace std;

void SelectSort(int arr[], int n)
{
    int i,j,k;
    int temp;

    for(i=0;i<n;i++)    //默认无需序列首元素为待交换值
    {
        k = i;
        for(j=i+1;j<n;j++)      //扫描无序序列
            if(arr[k]>arr[j])   //更新无序序列内最小值标记
                k = j;
        /*
        注意：此处 j=i+1 即实现概念上无序序列--，有序序列++
        */
        temp = arr[i];      //最小值与首元素交换
        arr[i] = arr[k];
        arr[k] = temp;
    }
}

int main()
{
    int R[8] = {49,38,65,97,76,13,27,49};
    for(int i=0;i<8;i++)
        cout<<R[i]<<" ";
    cout<<endl;

    SelectSort(R,8);
    for(int i=0;i<8;i++)
        cout<<R[i]<<" ";
    return 0;
}


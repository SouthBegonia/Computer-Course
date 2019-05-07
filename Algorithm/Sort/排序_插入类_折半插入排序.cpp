/*
程序功能：折半插入排序
基本思路：
对于0~i~n-1的数组，0~i-1为有序序列，左右端值low,high，从i~n-1进行循环；
每次循环选取有序序列的中间值m=(low+high)/2，将待插入元素i与m比较，根据大小改变Low/high；
重复循环至low>high，此时high+1位置即为待插入位置，对有序序列后部分移动进而实现插入；

时间复杂度：
最好情况：O(N^2)
最坏情况：O(NlogN)
*/
#include<iostream>
using namespace std;

/*折半插入：升序排列*/
void InsertSort_UP(int Array[], int n)
{
	int low,high;       //已排序列左右端下标
	int x,m;            //待交换值x 已排序列中间值m
	int i,j;

	for(i=1;i<n;i++)
	{
		x = Array[i];
		low = 0;
		high = i-1;     //已排序列 [0~i-1]

		while(low<=high)    //low=high是比较过程中的最后一个比较数
		{
			m = (low+high)/2;

			if(x>Array[m])  //例： 1 2 6 |4
				low = m+1;
			else
				high = m-1;
		}
		for(j=i-1;j>high;j--)   //待插位置~原位置内元素后移覆盖，最后赋值x完成插入
			Array[j+1] = Array[j];
		Array[j+1] = x;
	}
}

/*折半插入：降序排列*/
void InsertSort_Down(int Array[], int n)
{
	int low,high;
	int x,m;
	int i,j;

	for(i=1;i<n;i++)
	{
		x = Array[i];
		low = 0;
		high = i-1;

		while(low<=high)
		{
			m = (low+high)/2;

			if(x<Array[m])      //唯一差别
				low = m+1;
			else
				high = m-1;
		}
		for(j=i-1;j>high;j--)
			Array[j+1] = Array[j];
		Array[j+1] = x;
	}
}

int main()
{
	int arr[10] = {8,3,2,1,6,5,7,4,9,0};
	for(int i=0;i<10;i++)
		cout<<arr[i]<<" ";
	cout<<endl;

	InsertSort_UP(arr,10);
	for(int i=0;i<10;i++)
		cout<<arr[i]<<" ";
	cout<<endl;
	
	return 0;
}

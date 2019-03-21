/*
程序功能：删除(递增)顺序表内重复元素，返还删除后的表长
基本思路：从左往右扫描，tag标记扫描过程；
当扫到重复元素说明它是待删元素，最终表长-1;
当扫描到非重复元素时，添加至非重复表的末尾(a[i+1]位置)；
即最终表长=原表长-删除元素个数
*/
#include<iostream>
using namespace std;
#define Maxsize 50

/*删除顺序表 a[]内重复元素，并修改其表长*/
int  Dels(int a[],int &len)     //涉及修改 len 长度
{
	int i=0;    //非重复片段末位元素。起始为a[0]
	int tag=1;  //元素标记

	while(i<len)
	{
		while(a[tag]==a[i])
		{
			tag++;      //tag++ 扫描过程
			len--;      //表示这个元素待删除，表长-1
		}
		i++;            //直到非重复元素则将其移至末尾元素
		a[i] = a[tag];
		tag++;
	}
	return len;
}

int main()
{
	int LA = 4;
	int A[Maxsize] = {1,1,1,1};

	cout<<"LA="<<LA<<endl;
	for(int i=0;i<LA;i++)
		cout<<A[i]<<" ";
	cout<<endl;

	Dels(A,LA);

	cout<<"LA="<<LA<<endl;
	for(int i=0;i<LA;i++)
		cout<<A[i]<<" ";

	return 0;
}


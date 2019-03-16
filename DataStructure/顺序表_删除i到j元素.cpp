/*程序功能：删除顺序表L内下标为i~j的元素(后续元素前移)*/
#include<iostream>
#include<stdio.h>
using namespace std;

typedef struct
{
	int data[50];
	int length;
}Sqlist;

/*删除下标为 i~j 的元素*/
void deleteNodes(Sqlist &L, int i, int j)
{
	int k,delta;
	delta = j-i+1;      //待删除元素的个数

	for(k=j+1;k<L.length;k++)
		L.data[k-delta] = L.data[k];    //核心算法
	L.length -= delta;
}

int main()
{
	Sqlist L;
	int i,j;        //待删除元素范围的下标

	cout<<"L.length:";      //输入表的信息
	cin>>L.length;
	for(int m=0;m<L.length;m++)
	  cin>>L.data[m];
	cout<<"i j:";
	cin>>i>>j;

	if(i>=0 && j<L.length && i<=j)      //打印处理完后的表
	{
		deleteNodes(L,i,j);

		for(int m=0;m<L.length;m++)
			cout<<L.data[m]<<" ";
		cout<<endl<<"L.length="<<L.length<<endl;
	}
	else	cout<<"ERROR"<<endl;

	return 0;
}


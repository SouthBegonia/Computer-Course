/*
程序功能：将整数顺序表L内比表头元素小的元素排在左边，大的排在右边。如[2 1 -7 13 5 6 -1]处理后[-1 1 -7 -3 2 6 5]
*/
#include<iostream>
using namespace std;

typedef struct
{
	int data[50];
	int length;
}Sqlist;

void move(Sqlist &L)
{
	int temp;
	int i=0;    //左标记
	int j=L.length-1;   //右标记
	temp = L.data[i];

	/*核心算法*/
	while(i<j)      //左右标记相遇为止
	{
		while(i<j && L.data[j]>temp)    //j从右向左扫，直至比temp小的元素
			j--;
		if(i<j){
			L.data[i]=L.data[j];
			i++;
		}

		while(i<j && L.data[i]<temp)    //i从左向右扫，直至比temp大的元素
			i++;
		if(i<j){
			L.data[j] = L.data[i];
			j--;
		}
	}
	L.data[i] = temp;       //i=j时退出，白头元素置于此
}

int main()
{
	Sqlist L;

	cout<<"L.length:";
	cin>>L.length;
	for(int i=0;i<L.length;i++)
		cin>>L.data[i];
		
	move(L);
	
	for(int i=0;i<L.length;i++)
		cout<<L.data[i]<<" ";
	return 0;
}


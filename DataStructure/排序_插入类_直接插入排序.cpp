/*
程序功能：直接插入法排序(升序)
基本思路：每次插入一个元素，将元素与原序列比较，找到合适位置进行插入，重复过程

时间复杂度：
最坏情况：原序列逆序，操作次数 n(n-1)/2  O(n^2)
最好情况：原序列升序，操作次数 n   O(n)

空间复杂度：
算法所需的辅助空间不随待排序列规模的变化而变化(常量)，故空间复杂度 O(1)
*/
#include<iostream>
using namespace std;

void InsertSort(int R[], int n)
{
	int i,j;
	int temp;

	for(i=1;i<n;i++){
		temp = R[i];        //待排(待插入)的关键字
		j = i-1;

        /*核心：将待排关键字与前面元素比较，直至顶端或者小于关键字*/
		while(j>=0 && temp<R[j]){
			R[j+1] = R[j];
			--j;
		}
		R[j+1] = temp;      //找到合适位置即插入
	}
}

int main()
{
	int num[8] = {49,38,65,97,76,13,27,49};
	for(int i=0;i<8;i++)
		cout<<num[i]<<" ";

	InsertSort(num,8);
	
	cout<<endl;
	for(int i=0;i<8;i++)
		cout<<num[i]<<" ";
}


/*
程序功能：重排数组，奇数在左偶数在右
基本思路：左右分设标记，扫描到奇数、偶数则交换
*/
#include<iostream>
using namespace std;

void Divide(int A[], int n)
{
	int i=0,j=n-1;
	int temp;

	while(i<j){
		while(A[i]%2==1 && i<j)     //从左往右扫描到偶数
			++i;
		while(A[j]%2==0 && i<j)     //从右往左扫描到奇数
			--j;
		if(i<j){
			temp = A[i];    //交换
			A[i] = A[j];
			A[j] = temp;
			++i;
			--j;
		}
	}
}

int main()
{
	int a[10] = {0,1,2,3,4,5,6,7,8,9};
	for(int i=0;i<10;i++)
		cout<<a[i]<<" ";
	cout<<endl;

	Divide(a,10);
	for(int i=0;i<10;i++)
		cout<<a[i]<<" ";
	cout<<endl;
}


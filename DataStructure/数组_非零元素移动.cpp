/*
程序功能：将数组num[]内的非0元素排在左侧
基本思路：分设两标记i,j，i标记非零元素末位；j扫描数组，扫描到非0元素则移到i++位置
*/
#include<iostream>
using namespace std;

/*功能函数*/
void Movelement(int A[], int n)
{
	int i=-1;   //已排非0串的末位元素
	int j;      //扫描到的非0待交换元素
	int temp;   //中间值

	for(j=0;j<n;j++)
		if(A[j]!=0){
			++i;
			if(i!=j){
				temp = A[i];
				A[i] = A[j];
				A[j] = temp;
			}
		}
}

int main()
{
	int size = 8;
	int num[size] = {1,0,0,3,0,1,0,2};

	for(int i=0;i<size;i++)
		cout<<num[i]<<" ";
	cout<<endl;

	Movelement(num,size);

	for(int i=0;i<size;i++)
		cout<<num[i]<<" ";
	return 0;
}



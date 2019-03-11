/*
程序功能：对A[MAX]内的元素左移 step 个位置，例如[0 1 2 3]左移2变为[2 3 0 1]
核心算法：先对step前面的元素进行倒置，再对step及后序元素进行倒置，最后全倒置即可实现
*/

#include<stdio.h>
#define MAX 10

/*倒置函数：倒置 len~lost 区间内元素*/
void Reverse(int a[], int len, int lost)
{
	int i,j;
	int temp;
	for(i=len,j=lost; i<j;i++,j--)
	{
		temp = a[i];
		a[i] = a[j];
		a[j] = temp;
	}
}

/*功能函数：检验位移数合法性及调用倒置函数*/
void RCR(int a[], int n, int p)
{
	if(p<=0 || p>=n)
		printf("ERROR!\n");
	else
	{   //核心算法，
		Reverse(a,0,p-1);
		Reverse(a,p,n-1);
		Reverse(a,0,n-1);
	}
}

int main()
{
	int A[MAX] = {0,1,2,3,4,5,6,7,8,9};
	int step = 2;       //左移位数

	for(int i=0;i<MAX;i++)
		printf("%d ",A[i]);
	printf("\n");
	
	RCR(A,MAX,step);
	
	for(int i=0;i<MAX;i++)
		printf("%d ",A[i]);
		
	getchar();
	return 0;
}

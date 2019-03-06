/*最大子列和问题：在线算法，且返回子列首尾元素，O(N)*/
#include<stdio.h>

int MaxSubseqSum(int A[],int n);
int start,end;
int tag=0;

int main()
{
	int num,i;
	int max;

	scanf("%d",&num);
	int a[num];

	for(i=0;i<num;i++)
		scanf("%d",&a[i]);

	max = MaxSubseqSum(a,num);
	printf("%d %d %d",max,a[start],a[end]);

	return 0;
}

int MaxSubseqSum(int A[],int N)
{
	int i;
	int ThisSum=0,MaxSum=-9999;

	for(i=0;i<N;i++)
	{
		ThisSum += A[i];    //向右累加
		if(ThisSum > MaxSum)
		{
		    MaxSum = ThisSum;
		    start = tag;
		    end = i;
		}
		if(ThisSum < 0)
		{
		    ThisSum = 0;    //不可能使后面的部分增大，故舍弃
        	tag = i+1;
		}
	}

	//假若全为负数或0，则MaxSum为0，
	if(MaxSum < 0)
	{
		MaxSum = 0;
		start = 0;
		end = N-1;
	}
	return MaxSum;
}

/*枚举法：O(N*3)*/
/*
int MaxSubseqSum1(int A[], int n)
{
	int ThisSum, MaxSum = 0;
	int i,j,k;
	for(i = 0; i < N; i++)      //i是子列左端位置
	{
		for(j = i; j < N; j++)  //j是子列右端位置
		{
			ThisSum = 0;
			for(k = i; k <= j; k++)     //多余耗时的循环
			ThisSum += A[k];
			if(ThisSum > MaxSum)
				MaxSum = ThisSum;
		}
	}
	return MaxSum;
}
*/

/*枚举法改进:O(N*2)*/
/*
int MaxSubseqSum1(int A[], int n)
{
	int ThisSum, MaxSum = 0;
	int i,j,k;
	for(i = 0; i < N; i++)      //i是子列左端位置
	{
		ThisSum = 0;
		for(j = i; j < N; j++)  //j是子列右端位置
		{
			ThisSum += A[k];
			//对于相同的i，不同的j，只要在 j-1 次循环的基础上累加1项即可
			if(ThisSum > MaxSum)
				MaxSum = ThisSum;
		}
	}
	return MaxSum;
}
*/

/*分而治之：O(NlogN)*/

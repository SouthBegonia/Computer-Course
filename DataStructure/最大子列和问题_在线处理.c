/*������к����⣺�����㷨���ҷ���������βԪ�أ�O(N)*/
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
		ThisSum += A[i];    //�����ۼ�
		if(ThisSum > MaxSum)
		{
		    MaxSum = ThisSum;
		    start = tag;
		    end = i;
		}
		if(ThisSum < 0)
		{
		    ThisSum = 0;    //������ʹ����Ĳ������󣬹�����
        	tag = i+1;
		}
	}

	//����ȫΪ������0����MaxSumΪ0��
	if(MaxSum < 0)
	{
		MaxSum = 0;
		start = 0;
		end = N-1;
	}
	return MaxSum;
}

/*ö�ٷ���O(N*3)*/
/*
int MaxSubseqSum1(int A[], int n)
{
	int ThisSum, MaxSum = 0;
	int i,j,k;
	for(i = 0; i < N; i++)      //i���������λ��
	{
		for(j = i; j < N; j++)  //j�������Ҷ�λ��
		{
			ThisSum = 0;
			for(k = i; k <= j; k++)     //�����ʱ��ѭ��
			ThisSum += A[k];
			if(ThisSum > MaxSum)
				MaxSum = ThisSum;
		}
	}
	return MaxSum;
}
*/

/*ö�ٷ��Ľ�:O(N*2)*/
/*
int MaxSubseqSum1(int A[], int n)
{
	int ThisSum, MaxSum = 0;
	int i,j,k;
	for(i = 0; i < N; i++)      //i���������λ��
	{
		ThisSum = 0;
		for(j = i; j < N; j++)  //j�������Ҷ�λ��
		{
			ThisSum += A[k];
			//������ͬ��i����ͬ��j��ֻҪ�� j-1 ��ѭ���Ļ������ۼ�1���
			if(ThisSum > MaxSum)
				MaxSum = ThisSum;
		}
	}
	return MaxSum;
}
*/

/*�ֶ���֮��O(NlogN)*/

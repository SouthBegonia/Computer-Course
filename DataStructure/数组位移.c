/*
�����ܣ���A[MAX]�ڵ�Ԫ������ step ��λ�ã�����[0 1 2 3]����2��Ϊ[2 3 0 1]
�����㷨���ȶ�stepǰ���Ԫ�ؽ��е��ã��ٶ�step������Ԫ�ؽ��е��ã����ȫ���ü���ʵ��
*/

#include<stdio.h>
#define MAX 10

/*���ú��������� len~lost ������Ԫ��*/
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

/*���ܺ���������λ�����Ϸ��Լ����õ��ú���*/
void RCR(int a[], int n, int p)
{
	if(p<=0 || p>=n)
		printf("ERROR!\n");
	else
	{   //�����㷨��
		Reverse(a,0,p-1);
		Reverse(a,p,n-1);
		Reverse(a,0,n-1);
	}
}

int main()
{
	int A[MAX] = {0,1,2,3,4,5,6,7,8,9};
	int step = 2;       //����λ��

	for(int i=0;i<MAX;i++)
		printf("%d ",A[i]);
	printf("\n");
	
	RCR(A,MAX,step);
	
	for(int i=0;i<MAX;i++)
		printf("%d ",A[i]);
		
	getchar();
	return 0;
}

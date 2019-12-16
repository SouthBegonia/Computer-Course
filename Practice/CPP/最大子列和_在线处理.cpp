#include<stdio.h>

int MaxSubseqSum(int A[], int N)
{
    int ThisSum, MaxSum;
    int i;
    ThisSum = MaxSum = 0;
    for (i = 0; i < N; i++)
	{
        ThisSum += A[i];//�����ۼ�
        if (ThisSum>MaxSum)
            MaxSum = ThisSum; // ���ָ��������µ�ǰ���
        else if (ThisSum < 0)  // �����ǰ���к�Ϊ����
            ThisSum = 0; // �򲻿���ʹ���沿�ֺ���������֮
    }
    return MaxSum;
}

int main()
{
	int a[8] = {4,-5,5,-6,-1,2,6,-2};
	int ans;
	ans = MaxSubseqSum(a,8);
	printf("%d",ans);
	getchar();
	
	return 0;
}


/*
�����ܣ�����ϡ��������Ԫ����ṹ����ʵ�ּ���xֵ�Ĺ���
����˼·�����ö�Ԫ���鴢����������ݼ�������Ϣ������ֻ������ö�Ԫ����
*/
#include<iostream>
#define Maxsize 16
using namespace std;

/*������Ԫ����ṹ*/
void Create(int A[][4], int m, int n, int B[][3])
{
	int i,j,k=1;
	for(i=0;i<m;i++)
		for(j=0;j<n;j++)
			if(A[i][j]!=0){     //��0Ԫ�ش�����Ԫ��
				B[k][0] = A[i][j];
				B[k][1] = i;
				B[k][2] = j;
				++k;
			}
	B[0][0] = k-1;  //ϡ�������Ϣ
	B[0][1] = m;
	B[0][2] = n;
}

/*����xֵ�Ƿ����*/
int Search(int B[][3], int x)
{
	int i=1,t;
	t = B[0][0];    //��0Ԫ�ظ���
	while(i<=t && B[i][0]!=x)
		++i;
	if(i<=t)
		return 1;
	else
		return 0;
}

int main()
{
	int A[4][4] ={
		{0,0,0,1},
		{0,0,3,2},
		{4,0,0,0},
		{0,5,0,0}
	};
	int B[Maxsize][3];
	int ip = 0;
	
	Create(A,4,4,B);

	while(1){
		cout<<"Input a number: ";
		cin>>ip;
		if(Search(B,ip)==1)
			cout<<"YES"<<endl;
		else cout<<"NO"<<endl;
	}

	return 0;
}

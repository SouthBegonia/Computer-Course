/*
�����ܣ�������Ԫ��A��B��ʵ�־�����ӹ��ܣ����������Ԫ��C
����˼·���Ƚ�����������Ϣ��
�����������Ӵ���C���е��в��ȣ���С�ߴ���C��
�в��ȣ���С�ߴ���C�����մ�����ʣ��Ԫ�صľ���A��B��
*/
#include<iostream>
#define Maxsize 25
using namespace std;

void Create(int A[][Maxsize], int m, int n, int B[][3])
{
	int i,j,k=1;
	for(i=0;i<m;i++)
		for(j=0;j<n;j++)
			if(A[i][j]!=0){
				B[k][0] = A[i][j];
				B[k][1] = i;
				B[k][2] = j;
				++k;
			}
	B[0][0] = k-1;
	B[0][1] = m;
	B[0][2] = n;
}

void Print(int B[][3])
{
	int n = B[0][0];
	cout<<"   Data Row Col"<<endl;
	for(int i=0;i<=n;i++)
		cout<<"["<<i<<"]  "<<B[i][0]<<"   "<<B[i][1]<<"   "<<B[i][2]<<endl;
}

void Addmat(int A[][3], int B[][3], int C[][3])
{
	int i=1,j=1,k=1,m;

	while(i<=A[0][0] && j<=B[0][0])
		if(A[i][1]==B[j][1]){           //�к�������ٱȽ��к�
			if(A[i][2]<B[j][2]){        //�кŽ�СԪ����C
				C[k][0] = A[i][0];
				C[k][1] = A[i][1];
				C[k][2] = A[i][2];
				++k;++i;
			}else if(A[i][2]>B[j][2]){
				C[k][0] = B[j][0];
				C[k][1] = B[j][1];
				C[k][2] = B[j][2];
				++k;++j;
			}else if(A[i][2]==B[j][2]){
				m = A[i][0] + B[j][0];  //�ų���Ԫ�ض�Ϊ0���
				if(m!=0){
					C[k][1] = B[j][1];
					C[k][2] = B[j][2];
					C[k][0] = m;
					++k;
				}
				++i;++j;
			}
		}else if(A[i][1]<B[j][1]){      //�кŽ�СԪ����C
			C[k][0] = A[i][0];
			C[k][1] = A[i][1];
			C[k][2] = A[i][2];
			++k;++i;
		}else if(A[i][1]>B[j][1]){
			C[k][0] = B[j][0];
			C[k][1] = B[j][1];
			C[k][2] = B[j][2];
			++k;++j;
		}

	while(i<=A[0][0]){      //����A��ʣ��Ԫ��
		C[k][0] = A[i][0];
		C[k][1] = A[i][1];
		C[k][2] = A[i][2];
		++k;++i;
	}
	while(j<=B[0][0]){      //����B��ʣ��Ԫ��
		C[k][0] = B[j][0];
		C[k][1] = B[j][1];
		C[k][2] = B[j][2];
		++k;++j;
	}
	C[0][0] = k-1;
	C[0][1] = A[0][1];
	C[0][2] = A[0][2];
}

int main()
{
	int A[4][Maxsize] ={
		{0,0,0,1},
		{0,0,3,2},
		{4,0,0,0},
		{0,5,0,0}
	};
	int A2[5][Maxsize] ={
		{1,0,0,1,2},
		{0,2,0,3,0},
		{0,0,4,0,4},
		{2,0,0,6,3},
		{2,0,0,1,0}
	};
	int B[Maxsize][3];
	int B2[Maxsize][3];
	int C[2*Maxsize][3];

	Create(A,4,4,B);
	Create(A2,5,5,B2);
	Print(B);
	Print(B2);

	Addmat(B,B2,C);
	Print(C);

	return 0;
}

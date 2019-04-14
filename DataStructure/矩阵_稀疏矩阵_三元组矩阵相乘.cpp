/*
�����ܣ�����A,A2�������Ԫ��B,B2��ʵ��A,A2������ˣ�����Ԫ��C����������
����˼·��ѭ���� A(i,j)�� A2(j,i) ��ֵȡ����ˣ��������������C
*/
#include<iostream>
#define Maxsize 25
using namespace std;

/*��������A����Ԫ��B*/
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

/*����D��Ӧ��ϡ�����A��(i,j)λ���ϵ�ֵ*/
int Getvalue(int D[][3], int i, int j)
{
	int k=1;
	while(k<=D[0][0] && (D[k][1]!=i || D[k][2]!=j))
		++k;
	if(k<=D[0][0])
		return D[k][0];
	else
		return 0;
}

/*��Ԫ��ľ�����ˣ�A * B = C*/
void Mulmat(int A[][3], int B[][3], int C[][3], int m, int n, int k)
{
	//�������Ҫ��A��������B����
    //A����ߴ磺m * n
    //C����ߴ磺n * k
    
	int p=1,s;
	for(int i=0;i<m;i++)
		for(int j=0;j<k;j++){
			s = 0;
			for(int l=0;l<n;l++)
				s += Getvalue(A,i,l)*Getvalue(B,l,j);
			if(s!=0){
				C[p][1] = i;
				C[p][2] = j;
				C[p][0] = s;
				++p;
			}
		}
	C[0][1] = m;
	C[0][2] = k;
	C[0][0] = p-1;
}

/*ϡ����������ˣ� A * B = C*/
void Mutmat(int C[][Maxsize], int A[][Maxsize], int B[][Maxsize], int m, int n, int k)
{
	for(int i=0;i<m;i++)
		for(int j=0;j<k;j++)
		{
			C[i][j] = 0;
			for(int h=0;h<n;++h)
				C[i][j] += A[i][h]*B[h][j];
		}
}

/*��ӡ����*/
void Dismat(int C[][Maxsize],int m, int n)
{
	for(int i=0;i<m;i++)
	{
		for(int j=0;j<n;j++)
			cout<<C[i][j]<<" ";
		cout<<endl;
	}
	cout<<endl;
}

/*��ӡ��Ԫ��*/
void Print(int B[][3])
{
	int n = B[0][0];
	cout<<"   Data Row Col"<<endl;
	for(int i=0;i<=n;i++)
		cout<<"["<<i<<"]  "<<B[i][0]<<"   "<<B[i][1]<<"   "<<B[i][2]<<endl;
}

int main()
{
	int A[4][Maxsize] ={
		{0,0,0,1},
		{0,0,3,2},
		{4,0,0,0},
		{0,5,0,0}
	};
	int A2[4][Maxsize] ={
		{1,0,0,1},
		{0,2,0,3},
		{2,0,4,0},
		{0,1,0,6},
	};
	int A3[4][Maxsize];

	int B[Maxsize][3];
	int B2[Maxsize][3];
	int C[Maxsize][3];

	Dismat(A,4,4);          //��ͨ������
	Dismat(A2,4,4);         //���� A * A2 = A3
	Mutmat(A3,A,A2,4,4,4);
	Dismat(A3,4,4);

	cout<<endl;
	Create(A,4,4,B);        //��Ԫ�鷽����
	Create(A2,4,4,B2);		//A,A2 ����Ԫ�� B * B2 = C
	Print(B);
	Print(B2);
	Mulmat(B,B2,C,4,4,4);
	Print(C);

	return 0;
}

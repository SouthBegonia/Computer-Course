/*
程序功能：对已知矩阵A,B尽心倒置、相加、相乘操作
基本思路：二维数组表示矩阵；
矩阵相乘，要求 A列数=B行数，A对应行 x B对应列 = C[行][列]
*/
#include<iostream>
using namespace std;
#define Maxsize 4

/*矩阵倒置：将A倒置赋于B*/
void Trsmat(int A[][Maxsize], int B[][Maxsize], int m, int n)
{
	for(int i=0;i<m;i++)
		for(int j=0;j<n;j++)
			B[j][i] = A[i][j];
}

/*矩阵相加：A + B = C*/
void Addmat(int C[][Maxsize], int A[][Maxsize], int B[][Maxsize], int m, int n)
{
	for(int i=0;i<m;i++)
		for(int j=0;j<n;j++)
			C[i][j] = A[i][j] + B[i][j];
}

/*矩阵相乘： A * B = C*/
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

/*打印矩阵*/
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

/*初始化矩阵为0*/
void Initmat(int C[][Maxsize], int m, int n)
{
	for(int i=0;i<m;i++)
		for(int j=0;j<n;j++)
			C[i][j] = 0;
}

int main()
{
	int A[4][4] ={
		{0,0,0,1},
		{0,0,3,2},
		{1,0,0,0},
		{0,2,0,0}};
	int B[4][4];
	int C[4][4];

	cout<<"Trsmat B from A :"<<endl;
	Trsmat(A,B,4,4);
	Dismat(A,4,4);
	Dismat(B,4,4);

	cout<<"Addmat A + B :"<<endl;
	Addmat(C,A,B,4,4);
	Dismat(C,4,4);

	cout<<"Mutmat A x B :"<<endl;
	Initmat(C,4,4);
	Mutmat(C,A,B,4,4,4);
	Dismat(C,4,4);

	return 0;
}


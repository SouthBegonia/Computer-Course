/*
程序功能：实现稀疏矩阵的三元组表示，且实现倒置矩阵的三元组
基本思路：在原矩阵A中首先找出第1列中所有元素，它们作为转置矩阵的第1行存入B矩阵，以此类推
但感觉先矩阵倒置再算三元组，复杂度也差不多(0元素不是特别庞大情况下)
*/
#include<iostream>
#define Maxsize 16
using namespace std;

/*创建三元表*/
void Create(int A[][4], int m, int n, int B[][3])
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

/*打印三元组信息*/
void Print(int B[][3], int n)
{
	cout<<"   Data Row Col"<<endl;
	for(int i=0;i<=n;i++)
		cout<<"["<<i<<"]  "<<B[i][0]<<"   "<<B[i][1]<<"   "<<B[i][2]<<endl;
}

/*传入两三元组，A倒置到B*/
void Transpose(int A[][3], int B[][3])
{
	int p,q,col;
	B[0][0] = A[0][0];
	B[0][1] = A[0][2];
	B[0][2] = A[0][1];

	if(B[0][0]>0){
		q = 1;
		for(col=0;col<B[0][1];col++)    //按列倒置
			for(p=1;p<=B[0][0];p++)
				if(A[p][2]==col){
					B[q][0] = A[p][0];
					B[q][1] = A[p][2];
					B[q][2] = A[p][1];
					++q;
				}
	}
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
	int BT[Maxsize][3];

	Create(A,4,4,B);
	Transpose(B,BT);
	Print(B,5);
	Print(BT,5);

	return 0;
}


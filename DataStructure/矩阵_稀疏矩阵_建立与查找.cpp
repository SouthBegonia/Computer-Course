/*
程序功能：创建稀疏矩阵的三元储存结构，并实现检索x值的功能
基本思路：采用二元数组储存非零点的数据及坐标信息，检索只需检索该二元数组
*/
#include<iostream>
#define Maxsize 16
using namespace std;

/*创建三元储存结构*/
void Create(int A[][4], int m, int n, int B[][3])
{
	int i,j,k=1;
	for(i=0;i<m;i++)
		for(j=0;j<n;j++)
			if(A[i][j]!=0){     //非0元素存入三元组
				B[k][0] = A[i][j];
				B[k][1] = i;
				B[k][2] = j;
				++k;
			}
	B[0][0] = k-1;  //稀疏矩阵信息
	B[0][1] = m;
	B[0][2] = n;
}

/*检索x值是否存在*/
int Search(int B[][3], int x)
{
	int i=1,t;
	t = B[0][0];    //非0元素个数
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

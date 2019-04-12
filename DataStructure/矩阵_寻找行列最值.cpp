/*
程序功能：找出矩阵内，满足行最小且列最小的数
基本思路：扫描得到i行最小值后，再扫描其所在列minj，若都满足最小则打印
*/
#include<iostream>
#define Maxsize 4
using namespace std;

/*行列最小值*/
void Printmin(int A[][Maxsize], int m, int n)
{
	int i,j,k,min;
	int minj;   //i行上最小值的列号
	int flag;   //1满足 0不满足

	for(int i=0;i<m;i++){   //行循环
		min = A[i][0];
		minj = 0;
		for(j=1;j<n;j++)    //列循环
		if(A[i][j]<min){
			min = A[i][j];  //i行上最小值，列号minj
			minj = j;
		}

		flag = 1;
		for(k=0;k<m;k++)
		if(min>A[k][minj]){ //扫描所在列判断min是否为minj列上最小值
			flag = 0;
			break;
		}

		if(flag)
			cout<<min<<",["<<i<<", "<<minj<<"]"<<" ";
	}
	cout<<endl;
}

/*行列最大值*/
void Printmax(int A[][Maxsize], int m, int n)
{
	int i,j,k,max,maxj;
	int flag;

	for(i=0;i<m;i++){
		max = A[i][0];
		maxj = 0;

		for(j=1;j<n;j++)
		if(A[i][j]>max){
			max = A[i][j];
			maxj = j;
		}
		flag = 1;
		for(k=0;k<m;k++)
		if(max<A[k][maxj]){
			flag = 0;
			break;
		}
		if(flag)
			cout<<max<<",["<<i<<", "<<maxj<<"]"<<" ";
	}
	cout<<endl;
}

int main()
{
	int A[][Maxsize] = {
		{1,8,5,7},
		{2,3,6,8},
		{9,0,1,2},
		{4,6,8,1}
	};
	Printmin(A,4,4);
	Printmax(A,4,4);
	return 0;
}

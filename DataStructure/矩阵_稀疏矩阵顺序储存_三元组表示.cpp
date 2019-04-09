/*
程序功能：稀疏矩阵的顺序储存方法-三元组表示法
基本思路：三元组表示方法有 结构体 数组
二维数组B[][]存储矩阵内非0元素的坐标及数值，及矩阵行列长度信息
	B[0][0]: 表示矩阵内非零元素个数
	B[0][1]
	B[0][2]: 表示矩阵行列长度
	B[1~Maxsize-1][0]: 表示 1~Maxsize-1 标号的非0元素的数值
	B[1~Maxsize-1][1]
	B[1~Maxsize-1][2]: 表示 1~Maxsize-1 标号的非0元素的矩阵坐标
*/
#include<iostream>
using namespace std;
#define Maxsize 4

/*结构体表示三元组*/
typedef struct{
	int val;
	int i,j;
}Trimat;

/*创建三元组*/
void CreateTrimat(float A[][Maxsize], int m, int n, float B[][3])
{
	int k = 1;  //非零元素的个数(编号)
	
	for(int i=0;i<m;i++)
		for(int j=0;j<n;j++)
			if(A[i][j]!=0)  //仅存入非零元素
			{
				B[k][0] = A[i][j];  //非零元素入组
				B[k][1] = i;    //非零元素在矩阵内的坐标
				B[k][2] = j;
				++k;
			}
	B[0][0] = k-1;  //最终非零元素个数
	B[0][1] = m;    //矩阵行数
	B[0][2] = n;    //矩阵列数
}

/*通过三元组打印矩阵*/
void Printmat(float B[][3])
{
	int k = 1;
	for(int i=0;i<B[0][1];++i){
		for(int j=0;j<B[0][2];j++){
			if(i==(int)B[k][1] && j==(int)B[k][2]){
				cout<<B[k][0]<<" ";     //仅在非零元素位置打印
				++k;
			}else
				cout<<"0 ";     //其余位置用0代替
		}
		cout<<endl;
	}
}

int main()
{
	float A[4][4] ={
		{0,0,0,1},
		{0,0,3,2},
		{1,0,0,0},
		{0,2,0,0}};
		
	float B[4][3];

	CreateTrimat(A,4,4,B);
	Printmat(B);
	
	return 0;
}


/*
程序功能：数组A[m+n]内包含两顺序表 (a1,a2,...,am)和(b1,b2,...,bn)，且a表在前b表在后，程序要实现a，b表位置交换
基本思路：对A[]表全倒置，再对a，b表倒置；
即A(a1,a2,b1,b2)，先全倒置为 A(b2,b1,a2,a1)，再两表分别倒置 A(b1,b2,a1,a2)
通用性：表的移动，交换
*/
#include<iostream>
using namespace std;

/*倒置表函数：将表A[]内L~R位置元素倒置(逆序)*/
void Reverse(int A[], int L, int R)
{
	int i = L, j = R;
	
	while(i<j)
	{
		int temp = A[i];
		A[i] = A[j];
		A[j] = temp;
		++i;
		--j;
	}
}

/*主功能函数：对A[]内两表倒置*/
void Exchange(int A[], int m, int n)
{
	/*A[m+n]表内 0~m-1 存放顺序表 (a1,a1,...,am), m~m+n-1 存放表 (b1,b2,...,bn)*/
	/*先将A[m+n]表逆序，变为 (bn,bn-1,...,bi,am,am-1,...,a1)*/
	Reverse(A,0,m+n-1);
	
	/*逆序 b 表，变为 (b1,b2,...,bn,am,am-1,...,a1)*/
	Reverse(A,0,n-1);
	
	/*逆序 a 表，变为 (b1,b2,...,bn,a1,a2,...,am)*/
	Reverse(A,n,m+n-1);
}

int main()
{
	//其他信息
	return 0;
}

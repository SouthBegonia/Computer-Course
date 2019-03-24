/*
�����ܣ�����A[m+n]�ڰ�����˳��� (a1,a2,...,am)��(b1,b2,...,bn)����a����ǰb���ں󣬳���Ҫʵ��a��b��λ�ý���
����˼·����A[]��ȫ���ã��ٶ�a��b���ã�
��A(a1,a2,b1,b2)����ȫ����Ϊ A(b2,b1,a2,a1)��������ֱ��� A(b1,b2,a1,a2)
ͨ���ԣ�����ƶ�������
*/
#include<iostream>
using namespace std;

/*���ñ���������A[]��L~Rλ��Ԫ�ص���(����)*/
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

/*�����ܺ�������A[]��������*/
void Exchange(int A[], int m, int n)
{
	/*A[m+n]���� 0~m-1 ���˳��� (a1,a1,...,am), m~m+n-1 ��ű� (b1,b2,...,bn)*/
	/*�Ƚ�A[m+n]�����򣬱�Ϊ (bn,bn-1,...,bi,am,am-1,...,a1)*/
	Reverse(A,0,m+n-1);
	
	/*���� b ����Ϊ (b1,b2,...,bn,am,am-1,...,a1)*/
	Reverse(A,0,n-1);
	
	/*���� a ����Ϊ (b1,b2,...,bn,a1,a2,...,am)*/
	Reverse(A,n,m+n-1);
}

int main()
{
	//������Ϣ
	return 0;
}

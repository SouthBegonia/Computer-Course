/*
�����ܣ�������A,Bģ�����ʽ������A+B,A*B������
����˼·�������±�Ϊx�ļ������������Ϊ��Ӧ�����
A+B��Ϊ��Ӧ��Ԫ����ӣ�
A*B��˫��ѭ�������� 12X^5 * 6X^3 �����������arr[5+3]����� 12*6
*/
#include<iostream>
#define Maxsize 50
using namespace std;

/*����ʽ�ṹ��
coef�����±�Ϊx�Ĵη�������Ϊ�����orderΪ��ߴ�����*/
typedef struct polynomial{
	float coef[Maxsize];
	int order;
}polynomial;

/*����ʽ��� A+B=C*/
void Add(polynomial &a, polynomial &b, polynomial &c)
{
	int m = a.order,n = b.order,i;

	for(i=0;i<m && i<n;i++)
		c.coef[i] = a.coef[i] + b.coef[i];
	while(i<=m)
	{
		c.coef[i] = a.coef[i];
		++i;
	}
	while(i<=n)
	{
		c.coef[i] = a.coef[i];
		++i;
	}
	c.order = (m>n) ? m:n;
}

/*����ʽ��� A*B=C*/
void Mul(polynomial &a, polynomial &b, polynomial &c)
{
	int m = a.order,n = b.order;

	if(m+n+1>Maxsize)
	{
		cout<<"Error"<<endl;
		return;
	}

	for(int i=0;i<=m+n;i++)     //��ʼ������ C Ϊ 0.0
		c.coef[i] = 0.0;
		
	for(int i=0;i<=m;i++)
	{
		for(int j=0;i<=n;j++)
			c.coef[i+j] += a.coef[i]*b.coef[j];     //�������
	}
	c.order = m+n;  //�������ߴ�����
}

/*��ӡ����ʽ*/
void DispArr(polynomial Arr)
{
	for(int i=0;i<Arr.order;i++)
		cout<<i<<" ";
	cout<<endl;
	for(int i=0;i<Arr.order;i++)
		cout<<Arr.coef[i]<<" ";
	cout<<endl<<endl;
}

int main()
{
	polynomial A;
	A.order = 6;
	polynomial B;
	B.order = 5;
	polynomial C;
	polynomial D;
	D.order = 0;

	for(int i=0;i<A.order;i++)  //��ʼ������ʽ A[6]=[1,2,3,4,5,6]
		A.coef[i] = i+1;
	for(int i=0;i<B.order;i++)  //��ʼ������ʽ B[5]=[0,2,4,6,8]
		B.coef[i] = i*2;

	cout<<"Array A:"<<endl;
	DispArr(A);
	cout<<"Array B:"<<endl;
	DispArr(B);
	cout<<"Array C = A + B:"<<endl;
	Add(A,B,C);
	DispArr(C);

	cout<<"Array D = A * B:"<<endl;
	Mul(A,B,D);
	DispArr(D);

	return 0;
}


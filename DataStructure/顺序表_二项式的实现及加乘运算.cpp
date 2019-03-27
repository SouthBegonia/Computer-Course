/*
程序功能：用数组A,B模拟二项式，进行A+B,A*B的运算
基本思路：数组下标为x的几次项，数组内容为对应常数项；
A+B即为对应项元素相加；
A*B即双重循环，例如 12X^5 * 6X^3 ，将结果存于arr[5+3]项，内容 12*6
*/
#include<iostream>
#define Maxsize 50
using namespace std;

/*二项式结构体
coef数组下标为x的次方，数据为常数项，order为最高次项数*/
typedef struct polynomial{
	float coef[Maxsize];
	int order;
}polynomial;

/*二项式相加 A+B=C*/
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

/*二项式相乘 A*B=C*/
void Mul(polynomial &a, polynomial &b, polynomial &c)
{
	int m = a.order,n = b.order;

	if(m+n+1>Maxsize)
	{
		cout<<"Error"<<endl;
		return;
	}

	for(int i=0;i<=m+n;i++)     //初始化数组 C 为 0.0
		c.coef[i] = 0.0;
		
	for(int i=0;i<=m;i++)
	{
		for(int j=0;i<=n;j++)
			c.coef[i+j] += a.coef[i]*b.coef[j];     //相乘运算
	}
	c.order = m+n;  //结果的最高次项数
}

/*打印多项式*/
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

	for(int i=0;i<A.order;i++)  //初始化二项式 A[6]=[1,2,3,4,5,6]
		A.coef[i] = i+1;
	for(int i=0;i<B.order;i++)  //初始化二项式 B[5]=[0,2,4,6,8]
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


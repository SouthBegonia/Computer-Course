/*
程序功能：a，b为非递减顺序表，编写顺序表c将ab表归并升序排列，要求ab表内相同元素只保留一个
基本思路：先调用Dels()函数对a，b数组进行删除组内相同元素处理，并修改其长度；
其次在调用Unions()进行对比归并处理即可实现
*/
#include<iostream>
using namespace std;
#define Maxsize 50

/*删除顺序表 a[]内重复元素，并修改其表长*/
int  Dels(int a[],int &len)     //涉及修改 len 长度
{
	int i=0;    //非重复片段末位元素。起始为a[0]
	int tag=1;  //元素标记

	while(i<len)
	{
		while(a[tag]==a[i])
		{
			tag++;      //tag++ 扫描过程
			len--;      //表示这个元素待删除，表长-1
		}
		i++;            //直到非重复元素则将其移至末尾元素
		a[i] = a[tag];
		tag++;
	}
	return len;
}

/*合并两数组到C*/
int Unions(int a[], int na, int b[], int nb, int *(c), int &nc)
{
	int i=0;    //数组标记i,j
	int j=0;
	int k=0;    //归并顺序表标记

	if(na+nb>Maxsize)	//数组上溢
		return -1;

	if(na<0 && nb>0)    //存在空表
		return -1;//b表元素归于c表

	if(nb<0 && na>0)
		return -1;//a表元素归于c表


	while(i<na && j<nb)
	{
		if(a[i]<b[j])
		{
			c[k++] = a[i++];
		}

		if(a[i]>b[j])
		{
			c[k++] = b[j++];
		}

		if(a[i]==b[j])
		{
			c[k++] = a[i];
			i++;
			j++;
		}
	}
	if(i==na)
	{
		while(j!=nb)
			c[k++] = b[j++];
	}
	
	if(j==nb)
	{
		while(i!=na)
			c[k++] = a[i++];
	}
	nc = k;
	return nc;
}

int main()
{
	/*
	int LA = 5;
	int LB = 8;
	int A[LA] = {1,4,7,8,10};
	int B[LB] = {2,3,4,8,9,11,12,13};
	*/
	/*
	int LA = 7;
	int LB = 3;
	int A[LA] = {1,4,6,6,6,7,7};
	int B[LB] = {1,4,9};
	*/

	int LA = 7;
	int LB = 10;
	int A[LA] = {1,1,1,2,2,3,9};
	int B[LB] = {1,2,2,3,4,4,5,6,7,10};
	
	int Nc = 0;
	int C[Maxsize] = {0};

	Dels(A,LA);
	Dels(B,LB);
	
	Unions(A,LA,B,LB,C,Nc);
	for(int i=0;i<Nc;i++)
		cout<<C[i]<<" ";
	cout<<endl<<"Nc="<<Nc;
	return 0;
}


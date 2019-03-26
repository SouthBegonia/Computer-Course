/*
程序功能：使用递归对不带头结点得链表L实现求最值、链表长、元素平均值的功能
基本思路：递归算法
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct LNode{
	int data;
	struct LNode *next;
}LNode;

/*求不带头结点链表L中的最大整数*/
int GetMax(LNode *L)
{
	if(L->next==NULL)   //当仅有一个结点
		return L->data;

	int temp = GetMax(L->next); //递归求后续链表中的最大值
	if(L->data>temp)    //再次与首结点比较
		return L->data;
	else
		return temp;
}

/*求不带头结点的链表L的结点个数*/
int GetNum(LNode *L)
{
	if(L->next==NULL)
		return 1;
	return 1+GetNum(L->next);
}

/*求不带头结点的链表L内元素的平均值*/
float GetAvg(LNode *L, int n)
{
	if(L->next==NULL)       //当仅有一个结点
		return (float)(L->data);
	else
	{
		float Sum = GetAvg(L->next,n-1)*(n-1);  //求后边n-1 个结点值得和
		return (float)(L->data+Sum)/n;      //加上首结点求均值
	}
}

int CreateList(LNode *&L,int a[], int n)
{
	LNode *r,*s;
	L = (LNode *)malloc(sizeof(LNode));
	r = L;

	r->data = a[0];
	r->next = NULL;

	for(int i=1;i<n;i++)
	{
		s = (LNode *)malloc(sizeof(LNode));
		s->data = a[i];
		s->next = NULL;

		r->next = s;
		r = s;
	}
}

int Displist(LNode *L)
{
	LNode *p;
	p = L;

	while(p!=NULL)
	{
		cout<<p->data<<" ";
		p = p->next;
	}
}

int main()
{
	int A[10] = {0,9,6,1,2,3,4,7,5,8};
	LNode *L;
	int MaxData = 0;
	int LenList = 0;
	float AvgData = 0;

	CreateList(L,A,10);
	Displist(L);

	MaxData = GetMax(L);
	LenList = GetNum(L);
	AvgData = GetAvg(L,10);

	cout<<endl;
	cout<<"Maxdata = "<<MaxData<<endl;
	cout<<"LenList = "<<LenList<<endl;
	cout<<"AvgData = "<<AvgData<<endl;

	free(L);

	return 0;
}


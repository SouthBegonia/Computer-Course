/*
程序功能：在不破坏、不新建结点的情况下将表内的结点倒序
核心思路：将结点采用头插法倒序重排
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct LNode{
	int data;
	struct LNode *next;
}LNode;

/*尾插法创建单链表*/
void CreateList(LNode *&L, int a[], int n)
{
	LNode *r,*s;
	L = (LNode *)malloc(sizeof(LNode));
	r = L;
	r->next = NULL;

	for(int i=0;i<n;i++)
	{
		s = (LNode *)malloc(sizeof(LNode));

		s->data = a[i];
		r->next = s;
		s->next = NULL;
		r = s;
	}
}

/*打印单链表 L*/
void Displist(LNode *L)
{
	LNode *p=L->next;
	while(p!=NULL){
		cout<<p->data<<" ";
		p=p->next;
	}
	cout<<endl;
}

/*倒序核心：头插法
分设标记p，q标记当结点及其后驱结点，采用头插法，在不新建表的情况下将表倒序*/
void Reversel(LNode *&L)
{
	LNode *p=L->next,*q;        //p指向旧表开始的非头结点，q是p的后继结点
	L->next = NULL;

	while(p != NULL)
	{
		q = p->next;
		p->next = L->next;      //头插法解决倒序问题
		L->next = p;
		p = q;
	}
}

int main()
{
	int N;
	LNode *L;

	cout<<"N:";     	//键入单链表信息(有序)
	cin>>N;
	int *A = new int (N);
	for(int i=0;i<N;i++)
		cin>>A[i];

	CreateList(L,A,N);  //创建一单链表
	Reversel(L);        //倒序过程
	Displist(L);        //打印处理后的表

	free(L);
	return 0;
}


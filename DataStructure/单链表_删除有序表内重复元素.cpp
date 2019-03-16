/*
程序功能：删除有序链表内数值域相同的元素，如[1 1 1 2 2 3 3 3]删除后为[1 2 3]
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

/*删除有序单链表L内重复元素
p指向起始结点，将p于其后继结点比较，如果相等，则删除后继结点，p指向后继结点的后继结点*/
void Delsl1(LNode *L)
{
	LNode *p = L->next,*q;
	while(p->next != NULL)
	{
		if(p->data == p->next->data)    //p与后继结点等值
		{
			q = p->next;
			p->next = q->next;
			free(q);
		}else
			p = p->next;    //不重复，p往后走
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

int main()
{
	int N;
	LNode *L;

	cout<<"N:";     	//键入单链表信息(有序)
	cin>>N;
	int *A = new int (N);
	for(int i=0;i<N;i++)
		cin>>A[i];

	CreateList(L,A,N);  //创建带头结点的单链表
	Delsl1(L);          //删除重复元素
	Displist(L);        //打印处理后的单链表

	free(L);
	return 0;
}


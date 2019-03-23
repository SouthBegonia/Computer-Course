/*
程序功能：将单链表L进行逆序或链方向逆转处理
基本思路：
Way1：头插法对每个结点重新排列
Way2：每次对单个结点进行转向处理
*/
#include<iostream>
#include<stdlib.h>
#define Maxsize 50
using namespace std;

typedef struct LNode{
	int data;
	struct LNode *next;
}LNode;

/*尾插法创建单链表*/
void Create(LNode *&L,int a[],int n)
{
	LNode *p,*s;
	L = (LNode *)malloc(sizeof(LNode));
	L->next = NULL;
	p = L;

	for(int i=0;i<n;i++)
	{
		s = (LNode *)malloc(sizeof(LNode));
		s->data = a[i];
		s->next = NULL;
		p->next = s;
		p = s;
	}
}

/*逆转单链表链方向：实质为尾插法重排链表
核心在于将 L链表进行拆分为 L头结点链表及 p头结点两链表，特设 q放丢失*/
void Reverlist(LNode *&L)
{
	LNode *p,*q;        //p待插入结点，q为p后继结点
	p = L->next;
	L->next = NULL;

	while(p!=NULL)
	{
		q = p->next;
		p->next = L->next;
		L->next = p;
		p = q;
	}
}

/*逆转单链表链方向2：实质为逐个结点进行转向处理，最后进行表头指向处理*/
int Reverlist2(LNode *&L)
{
	LNode *h;
	LNode *p,*pr;
	h = L->next;    	//h 为目前转向结点
	L->next = NULL; 	//剥离头结点

	if(h==NULL)
		return 0;

	p = h->next;        //p 为下个待转向结点
	pr = NULL;      	//pr 为上个转向后的结点
	
	while(p!=NULL)
	{
		h->next = pr;   //h转向上个已转向的结点
		pr = h;         //更新 pr
		h = p;          //更新下个待转向结点
		p = p->next;
	}
	h->next = pr;   //最后结点处理
	L->next = h;    //表头指针更新
}

/*打印链表*/
void Displist(LNode *L)
{
	LNode *p;
	p = L->next;

	while(p!=NULL)
	{
		cout<<p->data<<" ";
		p = p->next;
	}
	cout<<endl;
}

int main()
{
	LNode *h;
	int N;
	cout<<"N: ";
	cin>>N;
	int *A = new int (N);
	cout<<"A[]= ";
	for(int i=0;i<N;i++)
		cin>>A[i];

	Create(h,A,N);      //创建初始单链表
	cout<<"Before Reverse: ";
	Displist(h);

	Reverlist(h);       //链方向逆转
	cout<<"After Reverse: ";
	Displist(h);

	Reverlist2(h);       //链方向逆转2
	cout<<"Then After Reverse2: ";
	Displist(h);

	free(h);
	return 0;
}


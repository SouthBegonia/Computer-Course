#include<iostream>
#include<stdio.h>
#include<stdlib.h>
using namespace std;

typedef struct DLNode
{
	int data;
	DLNode *prior;
	DLNode *next;
}DLNode;

/*尾插法创建双链表*/
void createDlistR(DLNode *&L, int a[], int n)
{
	DLNode *s,*r;
	int i;
	L =(DLNode *)malloc(sizeof(DLNode));

	L->prior=NULL;
	L->next=NULL;
	r=L;

	for(i=0;i<n;i++)
	{
		s = (DLNode *)malloc(sizeof(DLNode));
		s->data = a[i];

		/*尾插法创建双链表核心*/
		r->next = s;
		s->prior = r;
		r = s;
	}
	r->next = NULL;
}

/*打印链表 L*/
void Displist(DLNode *L)
{
	DLNode *p=L->next;
	while(p!=NULL){
		cout<<p->data<<" ";
		p=p->next;
	}
	cout<<endl;
}

/*查找链表C内值为x的结点*/
DLNode *findNode(DLNode *C, int x)
{
	DLNode *p = C->next;
	while(p!=NULL)
	{
		if(p->data==x)
			break;
		p=p->next;
	}
	return p;
}

int main()
{
	int A[5];
	int i;
	DLNode *dl;
	DLNode *ans;

	for(i=0;i<5;i++)    //键入数组信息
		cin>>A[i];

	createDlistR(dl,A,5);   //尾插法
	Displist(dl);       //打印链表
	ans = findNode(dl,3);   //查询链表内值为x的结点
	cout<<ans->data<<endl;
	
	free(dl);
	getchar();

	return 0;
}


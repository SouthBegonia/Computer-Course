/*程序功能：查找单链表中倒数第 k 个结点是否存在*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct LNode{
	int data;
	struct LNode *next;
}LNode;

/*尾插法创建单链表*/
L CreateList(LNode *&L, int a[], int n)
{
	LNode *r,*s;
	L = (LNode *)malloc(sizeof(LNode));
	L->next = NULL;
	r = L;

	for(int i=0;i<n;i++)
	{
		s = (LNode *)malloc(sizeof(LNode));
		s->data = a[i];
		s->next = NULL;
		r->next = s;
		r = r->next;
	}
}

/*打印单链表*/
void Displist(LNode *L)
{
	LNode *p;
	p = L->next;
	while(p!=NULL){
		cout<<p->data<<" ";
		p = p->next;
	}
	cout<<endl;
}

/*查找倒数第 k 个结点*/
int FindElem(LNode *head, int k)
{
	int i=1;
	LNode *p1,*p;
	p1 = head->next;    //p1 指向当前遍历的结点
	p = head;

	while(p1!=NULL){
		p1 = p1->next;
		++i;
		if(i>k)         //算法核心
			p = p->next;
	}
	
	if(p==head){
		cout<<"不存在倒数第"<<k<<"个结点!";
		return 0;
	}
	else{
		cout<<"存在倒数第"<<k<<"个结点: "<<p->data;
		return 1;
	}
}

int main()
{
	LNode *list;
	int N;
	int tag=0;
	int *A = new int (N);

	cout<<"N:";
	cin>>N;
	cout<<"list:";
	for(int i=0;i<N;i++)
		cin>>A[i];
	cout<<"查找倒数第几个结点:";
	cin>>tag;

	CreateList(list,A,N);
	FindElem(list,tag);

	free(list);
	return 0;
}


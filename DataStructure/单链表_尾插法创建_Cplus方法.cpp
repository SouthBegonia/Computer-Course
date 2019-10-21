/*
单链表的创建，将数组A[]的内容尾插法插入链表，并显示
C++方法
备注：C/C++内创建结构体的办法存在差异
*/
#include<stdio.h>
#include<stdlib.h>
#include<iostream>
using namespace std;

typedef struct LNode
{
	int data;
	struct LNode *next;
}Linklist;

/*尾插法建立单链表，传入数组及其长度*/
void createlistHead(LNode *&newlist, int a[], int n)
{
	int i;
	LNode *s,*r;

	newlist = (LNode *)malloc(sizeof(LNode));
	newlist->next = NULL;
	r = newlist;

	for(i=0;i<n;i++)
	{
		s = (LNode *)malloc(sizeof(LNode));
		s->data = a[i];
		r->next = s;
		r = r->next;
	}
	r->next = NULL;
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
	int A[5];   //预设数组
	LNode *list;    //预设单链表

	for(int i=0;i<5;i++)    //数组初始化及打印
		A[i] = i+1;
	for(int i=0;i<5;i++)
		cout<<A[i]<<" ";
	cout<<endl;
	
	createlistHead(list,A,5);
	Displist(list);
	
	free(list);
	getchar();
	return 0;
}

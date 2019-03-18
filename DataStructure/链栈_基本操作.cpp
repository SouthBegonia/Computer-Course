/*
程序功能：实现链栈的基本操作(创建、入栈、出栈)
基本思路：采用头插法创建的单链表作为链栈，最后入栈的结点始终作为头结点
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct LNode{
	int data;
	struct LNode *next;
}LNode;

/*初始化链栈：无头节点*/
void InitStack(LNode *&lst)
{
	lst = NULL;
}

/*是否栈空，0空 1非空*/
int IsEmpty(LNode *lst)
{
	if(lst==NULL)
		return 0;
	else
		return 1;
}

/*入栈操作：头插法，最后入栈的为头结点*/
void Push(LNode *&lst, int x)
{
	LNode *p;
	p = (LNode *)malloc(sizeof(LNode));
	p->next = NULL;
	p->data = x;

	p->next = lst;
	lst = p;
}

/*出栈操作：从头结点起删*/
int Pop(LNode *&lst, int &x)
{
	LNode *p;
	
	p = lst;
	x = p->data;
	lst = p->next;
	
	free(p);
	return 1;
}

/*打印链栈*/
void DispStack(LNode *lst)
{
	LNode *p;
	p = lst;

	cout<<"LStack : [";
	while(p != NULL)
	{
		cout<<p->data<<" ";
		p = p->next;
	}
	cout<<"]"<<endl;
}

int main()
{
	int tag = 0;        	//栈空标记 0空 1非空
	int choice = 0;     	//栈操作
	int num=0;          	//入栈数值
	LNode *Lstack;

	InitStack(Lstack);      //初始化链栈

	while(choice==0 || choice==1)   //选择栈操作
	{
		cout<<"Push or Pop?(0/1): ";
		cin>>choice;

		if(choice==0)       //入栈
		{
			cout<<"Num: ";
			cin>>num;
			Push(Lstack,num);
		}else
		if(choice==1)       //出栈
		{
			if((tag=IsEmpty(Lstack)) == 1)     //tag为 1 非空，可出栈
				Pop(Lstack,num);
			else
				cout<<"Stack is empty!"<<endl;
		}
		DispStack(Lstack);      //打印当前栈
		cout<<endl;
	}
	cout<<"Done!";
	
	free(Lstack);
	return 0;
}


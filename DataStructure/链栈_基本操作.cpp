/*
�����ܣ�ʵ����ջ�Ļ�������(��������ջ����ջ)
����˼·������ͷ�巨�����ĵ�������Ϊ��ջ�������ջ�Ľ��ʼ����Ϊͷ���
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct LNode{
	int data;
	struct LNode *next;
}LNode;

/*��ʼ����ջ����ͷ�ڵ�*/
void InitStack(LNode *&lst)
{
	lst = NULL;
}

/*�Ƿ�ջ�գ�0�� 1�ǿ�*/
int IsEmpty(LNode *lst)
{
	if(lst==NULL)
		return 0;
	else
		return 1;
}

/*��ջ������ͷ�巨�������ջ��Ϊͷ���*/
void Push(LNode *&lst, int x)
{
	LNode *p;
	p = (LNode *)malloc(sizeof(LNode));
	p->next = NULL;
	p->data = x;

	p->next = lst;
	lst = p;
}

/*��ջ��������ͷ�����ɾ*/
int Pop(LNode *&lst, int &x)
{
	LNode *p;
	
	p = lst;
	x = p->data;
	lst = p->next;
	
	free(p);
	return 1;
}

/*��ӡ��ջ*/
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
	int tag = 0;        	//ջ�ձ�� 0�� 1�ǿ�
	int choice = 0;     	//ջ����
	int num=0;          	//��ջ��ֵ
	LNode *Lstack;

	InitStack(Lstack);      //��ʼ����ջ

	while(choice==0 || choice==1)   //ѡ��ջ����
	{
		cout<<"Push or Pop?(0/1): ";
		cin>>choice;

		if(choice==0)       //��ջ
		{
			cout<<"Num: ";
			cin>>num;
			Push(Lstack,num);
		}else
		if(choice==1)       //��ջ
		{
			if((tag=IsEmpty(Lstack)) == 1)     //tagΪ 1 �ǿգ��ɳ�ջ
				Pop(Lstack,num);
			else
				cout<<"Stack is empty!"<<endl;
		}
		DispStack(Lstack);      //��ӡ��ǰջ
		cout<<endl;
	}
	cout<<"Done!";
	
	free(Lstack);
	return 0;
}


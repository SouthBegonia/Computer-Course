/*
程序功能：用带头结点的循环链队表示队列，并只设一个指针指向队尾结点，不设头指针
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct LNode{
	int data;
	struct LNode *next;
}LNode;

/*尾插法入队
rear是带头结点的循环链队的尾指针，将x插入队尾*/
void EnQuquq(LNode *&rear, int x)
{
	LNode *s = (LNode *)malloc(sizeof(LNode));
	s->data = x;
	s->next = rear->next;
	rear->next = s;
	rear = s;
}

/*队头元素出队
rear是带头结点的循环链队的尾指针，x接收出队元素*/
int DeQueue(LNode *&rear, int &x)
{
	LNode *s;
	if(rear->next==rear)
		return 0;
	else
	{
		s = rear->next->next;
		rear->next->next = s->next;
		x = s->data;
		
		if(s==rear)     //若元素出队后队列为空
			rear=rear->next;    //rear指向头结点
		free(s);
		return 1;
	}
}

int main()
{
	//function
	return 0;
}

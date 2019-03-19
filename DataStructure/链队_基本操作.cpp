/*
程序功能：演示链队的创建、判断、出入队
*/
#include<iostream>
using namespace std;

typedef struct QNode{
	int data;
	struct QNode *next;
}QNode;

typedef struct LQueue{
	struct QNode *front;
	struct QNode *near;
}LQueue;

/*初始化链队*/
void InitQueue(LQueue *&lqu)
{
	lqu = (LQueue *)malloc(sizeof(LQueue));
	lqu->front = lqu->near = NULL;
}

/*判断队空*/
int IsQueueEmpty(LQueue *lqu)
{
	if(lqu->near==NULL || lqu->front==NULL)
		return 1;
	else
		return 0;
}

/*入队*/
void EnQueue(LQueue *lqu, int x)
{
	QNode *p;
	p = (QNode *)malloc(sizeof(QNode));
	p->data = x;
	p->next = NULL;
	
	if(lqu->near==NULL)     //若队列为空，则新的结点是队首和队尾结点
		lqu->front = lqu->near = p;
	else{
		lqu->near->next = p;    //新结点链接到队尾
		lqu->near = p;
	}
}

int DeQueue(LQueue *lqu, int &x)
{
	QNode *p;
	if(lqu->near==NULL)     	//队空
		return 0;
	else
		p = lqu->front;
		
	if(lqu->front==lqu->near)       //当队列中只有一个结点的出队需要特殊操作
		lqu->front = lqu->near = NULL;
	else
		lqu->front - lqu->front->next;
		
	x = p->data;
	free(p);
	return 1;
}

int main()
{
	return 0;
}

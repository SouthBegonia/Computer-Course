/*
�����ܣ���ʾ���ӵĴ������жϡ������
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

/*��ʼ������*/
void InitQueue(LQueue *&lqu)
{
	lqu = (LQueue *)malloc(sizeof(LQueue));
	lqu->front = lqu->near = NULL;
}

/*�ж϶ӿ�*/
int IsQueueEmpty(LQueue *lqu)
{
	if(lqu->near==NULL || lqu->front==NULL)
		return 1;
	else
		return 0;
}

/*���*/
void EnQueue(LQueue *lqu, int x)
{
	QNode *p;
	p = (QNode *)malloc(sizeof(QNode));
	p->data = x;
	p->next = NULL;
	
	if(lqu->near==NULL)     //������Ϊ�գ����µĽ���Ƕ��׺Ͷ�β���
		lqu->front = lqu->near = p;
	else{
		lqu->near->next = p;    //�½�����ӵ���β
		lqu->near = p;
	}
}

int DeQueue(LQueue *lqu, int &x)
{
	QNode *p;
	if(lqu->near==NULL)     	//�ӿ�
		return 0;
	else
		p = lqu->front;
		
	if(lqu->front==lqu->near)       //��������ֻ��һ�����ĳ�����Ҫ�������
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

/*
�����ܣ��ô�ͷ����ѭ�����ӱ�ʾ���У���ֻ��һ��ָ��ָ���β��㣬����ͷָ��
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct LNode{
	int data;
	struct LNode *next;
}LNode;

/*β�巨���
rear�Ǵ�ͷ����ѭ�����ӵ�βָ�룬��x�����β*/
void EnQuquq(LNode *&rear, int x)
{
	LNode *s = (LNode *)malloc(sizeof(LNode));
	s->data = x;
	s->next = rear->next;
	rear->next = s;
	rear = s;
}

/*��ͷԪ�س���
rear�Ǵ�ͷ����ѭ�����ӵ�βָ�룬x���ճ���Ԫ��*/
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
		
		if(s==rear)     //��Ԫ�س��Ӻ����Ϊ��
			rear=rear->next;    //rearָ��ͷ���
		free(s);
		return 1;
	}
}

int main()
{
	//function
	return 0;
}

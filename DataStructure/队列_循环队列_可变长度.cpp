/*
�����ܣ�ʵ��ѭ�����еĳ���ӣ�������Ԫ����������ռ�1/4�򽫿ռ���Сһ�룬����ʱ������ռ�����һ��
����˼·��ջ����չ�ռ���malloc�¿ռ䣬����Ԫ�أ�����޸�Ԫ����ָ���¿ռ�
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct{
	int *data;
	int front,rear;
	int maxsize;
}SqQueue;

/*��ӣ�����ʱ������ռ�����һ��*/
int EnQueue(SqQueue &q,int x)
{
	if((q.rear+1)%q.maxsize==q.front)
	{
		int newSize = 2*q.maxsize;      //������һ��������
		int *newArray = (int *)malloc(newSize*sizeof(int));
		if(newArray==NULL)      //����
			return 0;

		int newRear = q.front;
		int newFront = q.front;
		while(q.rear!=q.front)
		{
			newArray[newRear] = q.data[q.front];
			q.front = (q.front+1)%q.maxsize;
			newRear = (newRear+1)%newSize;
		}
		free(q.data);
		q.data = newArray;
		q.rear = newRear;
		q.front = newFront;
		q.maxsize = newSize;
	}
	q.data[q.rear] = x;
	q.rear = (q.rear+1)%q.maxsize;  //�������
	return 1;
}

/*���ӣ�������Ԫ����������ռ�1/4�򽫿ռ���Сһ��*/
int DeQueue(SqQueue &q,int &x)
{
	if((q.rear-q.front+q.maxsize)%q.maxsize < q.maxsize/4)
	{
		int newSize = q.maxsize/2;
		int *newArray = (int *)malloc(newSize*sizeof(int));
		if(newArray==NULL)
			return 0;

		int newRear = q.front;
		int newFront = q.front;
		while(q.front!=q.rear)
		{
			newArray[newRear] = q.data[q.front];
			q.front = (q.front+1)%q.maxsize;
			newRear = (newRear+1)%newSize;
		}
		free(q.data);
		q.data = newArray;
		q.rear = newRear;
		q.front = newFront;
		q.maxsize = newSize;
	}
	if(q.rear==q.front)
		return 0;
	x = q.data[q.rear];
	q.front = (q.front+1)%q.maxsize;
	return 1;
}

int main()
{
	return 0;
}

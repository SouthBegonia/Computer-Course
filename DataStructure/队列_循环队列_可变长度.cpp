/*
程序功能：实现循环队列的出入队，当队内元素少于数组空间1/4则将空间缩小一半，队满时将数组空间扩大一倍
基本思路：栈满扩展空间则malloc新空间，拷贝元素，最后修改元队列指向到新空间
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct{
	int *data;
	int front,rear;
	int maxsize;
}SqQueue;

/*入队：队满时将数组空间扩大一倍*/
int EnQueue(SqQueue &q,int x)
{
	if((q.rear+1)%q.maxsize==q.front)
	{
		int newSize = 2*q.maxsize;      //创建大一倍的数组
		int *newArray = (int *)malloc(newSize*sizeof(int));
		if(newArray==NULL)      //检验
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
	q.rear = (q.rear+1)%q.maxsize;  //正常入队
	return 1;
}

/*出队：当队内元素少于数组空间1/4则将空间缩小一半*/
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

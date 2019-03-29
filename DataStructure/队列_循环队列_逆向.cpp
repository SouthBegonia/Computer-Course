/*
程序功能：建立循环队列，要求逆序入队，即队首指针沿着 Maxsize-1,Maxsize-2,...,0,Maxsize-1,...
基本思路：两种队首指针的移向
队首指针正向： front = (front+1) % Maxsize
队首指针逆向： front = (front-1+Maxsize) % Maxsize
*/
#include<iostream>
#define Maxsize 7
using namespace std;

typedef struct Cycqueue{
	int data[Maxsize];
	int front;      //标记入队元素的前一个位置
	int rear;       //标记队尾元素的位置
}Cycqueue;

/*出队，出队值赋予 x */
int DeQueue(Cycqueue &q, int &x)
{
	if(q.front==q.rear)     //队空
		return 0;
	else
	{
		x = q.data[q.rear];
		q.rear = (q.rear-1+Maxsize)%Maxsize;    //修改队尾指针
		return 1;
	}
}

/*入队，将值 x 入队*/
int EnQueue(Cycqueue &q, int x)
{
	if(q.rear==(q.front-1+Maxsize)%Maxsize)     //队满
		return 0;
	else
	{
		q.data[q.front] = x;
		q.front = (q.front-1+Maxsize)%Maxsize;  //修改队头指针
		return 1;
	}
}

/*初始化循环队列，默认数值 0*/
void Init(Cycqueue &q)
{
	q.front = 0;
	q.rear = 0;
	for(int i=0;i<Maxsize;i++)
		q.data[i] = 0;
}

/*打印队列*/
void DispQ(Cycqueue &q)
{
	cout<<"front="<<q.front<<" rear="<<q.rear<<endl;
	for(int i=0;i<Maxsize;i++)
		cout<<q.data[i]<<" ";
	cout<<endl;
}

int main()
{
	int A[5] = {1,2,3,4,5}; //入队元素的数组
	int num=0;      //出队值
	Cycqueue Q;     //循环队列 Q
	
	Init(Q);    	//初始化
	DispQ(Q);
	cout<<endl;

	for(int i=0;i<5;i++)    //将A[]内元素顺序入队并打印队列情况
	{
		EnQueue(Q,A[i]);
		DispQ(Q);
		cout<<endl;
	}
	cout<<endl;
	
	for(int i=0;i<5;i++)    //将Q队列内5个元素出队，打印队列情况及出队值
	{
		DeQueue(Q,num);
		DispQ(Q);
		cout<<"Num = "<<num<<endl<<endl;
	}
	return 0;
}


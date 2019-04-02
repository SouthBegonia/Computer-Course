/*
程序功能：用数组建立循环队列，实现出入队，仅用尾指针和队列长度标记
基本思路：顺时针入队，即队尾指针 rear 顺时针变化，每次入队修改rear及队列长度length；
当出队时，队首元素即为 (rear-length+Maxsize)%Maxsize;
与采用队首front队尾rear的表示方法存在差别；
*/
#include<isotream>
#define Maxsize 20
using namespace std;

typedef struct{
	int elems[Maxsize]; //队列的数组
	int rear;   //队尾指针，指向最新入队的元素
	int length; //队列的长度
}SqQueue;

/*入队：将元素 x 入队*/
int EnQueue(SqQueue &q,int x)
{
	if(q.length==Maxsize)
		return 0;
	q.rear = (q.rear+1)%Maxsize;    //队尾指针前移，
	e.elem[q.rear] = x;     //入队
	++q.length;     //队列长度+1
	return 1;
}

/*出队：出队元素由 x 返回*/
int DeQueue(SqQueue &q,int &x)
{
	if(q.length==0)
		return 0;

	x = q.elems[(q.rear-q.length+Maxsize)%Maxsize];   //例rear=4，len=2，则队首为 2
	--q.length;     //队列长度-1
	return 1;
}

int main()
{
	return 0;
}

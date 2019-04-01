/*
程序功能：实现栈s1,s2共享数组，实现出入栈等操作
基本思路：设好双栈的头指针，栈空栈满条件；
本例采用 int *elem + malloc() 申请空间建立数组，区别于普通 int arr[]
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct DblStack{
	int top[2],bot[2];      //双栈的栈顶栈底
	int *elem;      //栈数组
	int m;      //栈数组最大可容纳元素个数
}DblStack;

/*初始化栈：分配一个最大尺寸为sz的空栈*/
void InitStack(DblStack &s, int sz)
{
	s.elem = (int *)malloc(sizeof(int) * sz);   //创建栈的数组空间

	if(s.elem==NULL)
	{
		cout<<"Error"<<endl;
		return;
	}
	s.m = sz;
	s.top[0] = s.bot[0] = -1;
	s.top[1] = s.bot[1] = sz;
}

/*判断是否栈空*/
int IsEmpty(DblStack &s,int i)
{
	if(s.top[i]==s.bot[i])
		return 1;
	else
		return 0;
}

/*判断是否栈满*/
int IsFUll(DblStack &s)
{
	if((s.top[0]+1)==s.top[1])
		return 1;
	else
		return 0;
}

/*入栈：将 x 入到栈i 的栈顶*/
int Push(DblStack &s, int x, int i)
{
	if(IsFUll(s))
		return 0;
	if(i==0)
		s.elem[++s.top[0]] = x; //入栈到 s1
	else
		s.elem[--s.top[1]] = x; //入栈到 s2
	return 1;
}

/*出栈：将栈i 的栈顶元素出栈到 x*/
int Pop(DblStack &s, int &x, int i)
{
	if(IsEmpty(s,i))
		return 0;
	if(i==0)
		x = s.elem[s.top[0]--]; //s1 出栈
	else
		x = s.elem[s.top[1]++]; //s2 出栈
	return 1;
}

/*取得栈i 的栈顶元素到 x*/
int GetTop(DblStack &s, int &x, int i)
{
	if(IsEmpty(s,i))
		return 0;
	x = s.elem[s.top[i]];
	return 1;
}

/*清空栈：重设栈顶栈底指针*/
void ClearStack(DblStack &s, int i)
{
	if(i==0)
		s.top[0] = s.bot[0] = -1;
	else
		s.top[1] = s.bot[1] = s.m;
}

int main()
{
    int sizes = 10; //栈数组大小
    int num = 0;    //出栈元素
    DblStack S;

	InitStack(S,sizes);

	Push(S,1,0);
	Pop(S,num,0);
	cout<<"Push and Pop s1, Num = "<<num<<endl;

	Push(S,2,1);
	GetTop(S,num,1);
	cout<<"Push and GetTop s2, Num = "<<num<<endl;

	free(S.elem);
	return 0;
}


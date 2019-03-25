/*
程序功能：用两个同类型的栈s1,s2模拟实现队列的入队出队操作
基本思路：队列最大长度为Maxsize，即单个栈的长度；
先将元素入到s1，若要出队，则将s1内退栈到s2，两次倒序即实现先进先出的输出方式
*/
#include<iostream>
#define Maxsize 5
using namespace std;

typedef struct Sqstack{
	int data[Maxsize];
	int top;
}Sqstack;

/*入栈*/
int Push(Sqstack &st, int x)
{
	if(st.top>=Maxsize)
		return 0;
	else{
		++st.top;
		st.data[st.top] = x;
		return 1;
	}
}

/*出栈*/
int Pop(Sqstack &st, int &x)
{
	if(st.top==-1)
		return 0;
	else{
		x = st.data[st.top];
		--st.top;
		return 1;
	}
}

/*入s1,s2组成的模拟队列*/
int EnQueue(Sqstack &s1, Sqstack &s2, int x)
{
	int y;
	
	if(s1.top == Maxsize-1)
	{
		if(s2.top!=-1)          //若 s1满s2非空，则s1不能再入栈(s1,s2长度相同)
			return 0;
		else if(s2.top==-1)     //若 s1满s2空，则先将s1退栈到s2，再将新的元素入栈s1
		{
			while(s1.top!=-1)
			{
				Pop(s1,y);      //s1 退栈
				Push(s2,y);
			}
			Push(s1,x);     //新元素 x 入s1
			return 1;
		}
	}else
	{
		Push(s1,x);     //s1 未满，直接入栈
		return 1;
	}
}

/*出s1,s2组成的模拟队列*/
int DeQueue(Sqstack &s2,Sqstack &s1, int &x)
{
	int y;
	
	if(s2.top!=-1)      //s2 非空，直接出栈
	{
		Pop(s1,x);
		return 1;
	}else
	{
		if(s1.top==-1)  //s1,s2均空，队列为空
			return 0;
		else
		{
			while(s1.top!=-1)   //s2空,s1非空，则将s1退栈到s2
			{
				Pop(s1,y);
				Push(s2,y);
			}
			Pop(s2,x);      //最后s2出栈即为出队
			return 1;
		}
	}
}

/*当s1,s2均为空，则模拟队列空*/
int IsQueueEmpty(Sqstack s1, Sqstack s2)
{
	if((s1.top==-1) && (s2.top==-1))
		return 1;
	else
		return 0;
}

int main()
{
	Sqstack s1,s2;
	s1.top = -1;    //栈底默认 -1
	s2.top = -1;

	int A[5] = {1,2,3,4,5};
	for(int i=0;i<5;i++)
		Push(s1,A[i]);  //初始 s1[1 2 3 4 5]

	EnQueue(s1,s2,7);   //尝试将 7 入满栈 s1
	//详细过程调试查看
	
	return 0;
}

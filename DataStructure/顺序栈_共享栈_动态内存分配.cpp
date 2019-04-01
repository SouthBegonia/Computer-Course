/*
�����ܣ�ʵ��ջs1,s2�������飬ʵ�ֳ���ջ�Ȳ���
����˼·�����˫ջ��ͷָ�룬ջ��ջ��������
�������� int *elem + malloc() ����ռ佨�����飬��������ͨ int arr[]
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct DblStack{
	int top[2],bot[2];      //˫ջ��ջ��ջ��
	int *elem;      //ջ����
	int m;      //ջ������������Ԫ�ظ���
}DblStack;

/*��ʼ��ջ������һ�����ߴ�Ϊsz�Ŀ�ջ*/
void InitStack(DblStack &s, int sz)
{
	s.elem = (int *)malloc(sizeof(int) * sz);   //����ջ������ռ�

	if(s.elem==NULL)
	{
		cout<<"Error"<<endl;
		return;
	}
	s.m = sz;
	s.top[0] = s.bot[0] = -1;
	s.top[1] = s.bot[1] = sz;
}

/*�ж��Ƿ�ջ��*/
int IsEmpty(DblStack &s,int i)
{
	if(s.top[i]==s.bot[i])
		return 1;
	else
		return 0;
}

/*�ж��Ƿ�ջ��*/
int IsFUll(DblStack &s)
{
	if((s.top[0]+1)==s.top[1])
		return 1;
	else
		return 0;
}

/*��ջ���� x �뵽ջi ��ջ��*/
int Push(DblStack &s, int x, int i)
{
	if(IsFUll(s))
		return 0;
	if(i==0)
		s.elem[++s.top[0]] = x; //��ջ�� s1
	else
		s.elem[--s.top[1]] = x; //��ջ�� s2
	return 1;
}

/*��ջ����ջi ��ջ��Ԫ�س�ջ�� x*/
int Pop(DblStack &s, int &x, int i)
{
	if(IsEmpty(s,i))
		return 0;
	if(i==0)
		x = s.elem[s.top[0]--]; //s1 ��ջ
	else
		x = s.elem[s.top[1]++]; //s2 ��ջ
	return 1;
}

/*ȡ��ջi ��ջ��Ԫ�ص� x*/
int GetTop(DblStack &s, int &x, int i)
{
	if(IsEmpty(s,i))
		return 0;
	x = s.elem[s.top[i]];
	return 1;
}

/*���ջ������ջ��ջ��ָ��*/
void ClearStack(DblStack &s, int i)
{
	if(i==0)
		s.top[0] = s.bot[0] = -1;
	else
		s.top[1] = s.bot[1] = s.m;
}

int main()
{
    int sizes = 10; //ջ�����С
    int num = 0;    //��ջԪ��
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


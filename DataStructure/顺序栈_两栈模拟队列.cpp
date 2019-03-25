/*
�����ܣ�������ͬ���͵�ջs1,s2ģ��ʵ�ֶ��е���ӳ��Ӳ���
����˼·��������󳤶�ΪMaxsize��������ջ�ĳ��ȣ�
�Ƚ�Ԫ���뵽s1����Ҫ���ӣ���s1����ջ��s2�����ε���ʵ���Ƚ��ȳ��������ʽ
*/
#include<iostream>
#define Maxsize 5
using namespace std;

typedef struct Sqstack{
	int data[Maxsize];
	int top;
}Sqstack;

/*��ջ*/
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

/*��ջ*/
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

/*��s1,s2��ɵ�ģ�����*/
int EnQueue(Sqstack &s1, Sqstack &s2, int x)
{
	int y;
	
	if(s1.top == Maxsize-1)
	{
		if(s2.top!=-1)          //�� s1��s2�ǿգ���s1��������ջ(s1,s2������ͬ)
			return 0;
		else if(s2.top==-1)     //�� s1��s2�գ����Ƚ�s1��ջ��s2���ٽ��µ�Ԫ����ջs1
		{
			while(s1.top!=-1)
			{
				Pop(s1,y);      //s1 ��ջ
				Push(s2,y);
			}
			Push(s1,x);     //��Ԫ�� x ��s1
			return 1;
		}
	}else
	{
		Push(s1,x);     //s1 δ����ֱ����ջ
		return 1;
	}
}

/*��s1,s2��ɵ�ģ�����*/
int DeQueue(Sqstack &s2,Sqstack &s1, int &x)
{
	int y;
	
	if(s2.top!=-1)      //s2 �ǿգ�ֱ�ӳ�ջ
	{
		Pop(s1,x);
		return 1;
	}else
	{
		if(s1.top==-1)  //s1,s2���գ�����Ϊ��
			return 0;
		else
		{
			while(s1.top!=-1)   //s2��,s1�ǿգ���s1��ջ��s2
			{
				Pop(s1,y);
				Push(s2,y);
			}
			Pop(s2,x);      //���s2��ջ��Ϊ����
			return 1;
		}
	}
}

/*��s1,s2��Ϊ�գ���ģ����п�*/
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
	s1.top = -1;    //ջ��Ĭ�� -1
	s2.top = -1;

	int A[5] = {1,2,3,4,5};
	for(int i=0;i<5;i++)
		Push(s1,A[i]);  //��ʼ s1[1 2 3 4 5]

	EnQueue(s1,s2,7);   //���Խ� 7 ����ջ s1
	//��ϸ���̵��Բ鿴
	
	return 0;
}

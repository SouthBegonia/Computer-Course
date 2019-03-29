/*
�����ܣ�����ѭ�����У�Ҫ��������ӣ�������ָ������ Maxsize-1,Maxsize-2,...,0,Maxsize-1,...
����˼·�����ֶ���ָ�������
����ָ������ front = (front+1) % Maxsize
����ָ������ front = (front-1+Maxsize) % Maxsize
*/
#include<iostream>
#define Maxsize 7
using namespace std;

typedef struct Cycqueue{
	int data[Maxsize];
	int front;      //������Ԫ�ص�ǰһ��λ��
	int rear;       //��Ƕ�βԪ�ص�λ��
}Cycqueue;

/*���ӣ�����ֵ���� x */
int DeQueue(Cycqueue &q, int &x)
{
	if(q.front==q.rear)     //�ӿ�
		return 0;
	else
	{
		x = q.data[q.rear];
		q.rear = (q.rear-1+Maxsize)%Maxsize;    //�޸Ķ�βָ��
		return 1;
	}
}

/*��ӣ���ֵ x ���*/
int EnQueue(Cycqueue &q, int x)
{
	if(q.rear==(q.front-1+Maxsize)%Maxsize)     //����
		return 0;
	else
	{
		q.data[q.front] = x;
		q.front = (q.front-1+Maxsize)%Maxsize;  //�޸Ķ�ͷָ��
		return 1;
	}
}

/*��ʼ��ѭ�����У�Ĭ����ֵ 0*/
void Init(Cycqueue &q)
{
	q.front = 0;
	q.rear = 0;
	for(int i=0;i<Maxsize;i++)
		q.data[i] = 0;
}

/*��ӡ����*/
void DispQ(Cycqueue &q)
{
	cout<<"front="<<q.front<<" rear="<<q.rear<<endl;
	for(int i=0;i<Maxsize;i++)
		cout<<q.data[i]<<" ";
	cout<<endl;
}

int main()
{
	int A[5] = {1,2,3,4,5}; //���Ԫ�ص�����
	int num=0;      //����ֵ
	Cycqueue Q;     //ѭ������ Q
	
	Init(Q);    	//��ʼ��
	DispQ(Q);
	cout<<endl;

	for(int i=0;i<5;i++)    //��A[]��Ԫ��˳����Ӳ���ӡ�������
	{
		EnQueue(Q,A[i]);
		DispQ(Q);
		cout<<endl;
	}
	cout<<endl;
	
	for(int i=0;i<5;i++)    //��Q������5��Ԫ�س��ӣ���ӡ�������������ֵ
	{
		DeQueue(Q,num);
		DispQ(Q);
		cout<<"Num = "<<num<<endl<<endl;
	}
	return 0;
}


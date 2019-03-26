/*
�����ܣ�ʹ�õݹ�Բ���ͷ��������Lʵ������ֵ��������Ԫ��ƽ��ֵ�Ĺ���
����˼·���ݹ��㷨
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct LNode{
	int data;
	struct LNode *next;
}LNode;

/*�󲻴�ͷ�������L�е��������*/
int GetMax(LNode *L)
{
	if(L->next==NULL)   //������һ�����
		return L->data;

	int temp = GetMax(L->next); //�ݹ�����������е����ֵ
	if(L->data>temp)    //�ٴ����׽��Ƚ�
		return L->data;
	else
		return temp;
}

/*�󲻴�ͷ��������L�Ľ�����*/
int GetNum(LNode *L)
{
	if(L->next==NULL)
		return 1;
	return 1+GetNum(L->next);
}

/*�󲻴�ͷ��������L��Ԫ�ص�ƽ��ֵ*/
float GetAvg(LNode *L, int n)
{
	if(L->next==NULL)       //������һ�����
		return (float)(L->data);
	else
	{
		float Sum = GetAvg(L->next,n-1)*(n-1);  //����n-1 �����ֵ�ú�
		return (float)(L->data+Sum)/n;      //�����׽�����ֵ
	}
}

int CreateList(LNode *&L,int a[], int n)
{
	LNode *r,*s;
	L = (LNode *)malloc(sizeof(LNode));
	r = L;

	r->data = a[0];
	r->next = NULL;

	for(int i=1;i<n;i++)
	{
		s = (LNode *)malloc(sizeof(LNode));
		s->data = a[i];
		s->next = NULL;

		r->next = s;
		r = s;
	}
}

int Displist(LNode *L)
{
	LNode *p;
	p = L;

	while(p!=NULL)
	{
		cout<<p->data<<" ";
		p = p->next;
	}
}

int main()
{
	int A[10] = {0,9,6,1,2,3,4,7,5,8};
	LNode *L;
	int MaxData = 0;
	int LenList = 0;
	float AvgData = 0;

	CreateList(L,A,10);
	Displist(L);

	MaxData = GetMax(L);
	LenList = GetNum(L);
	AvgData = GetAvg(L,10);

	cout<<endl;
	cout<<"Maxdata = "<<MaxData<<endl;
	cout<<"LenList = "<<LenList<<endl;
	cout<<"AvgData = "<<AvgData<<endl;

	free(L);

	return 0;
}


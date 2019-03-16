/*
�����ܣ��ڲ��ƻ������½���������½����ڵĽ�㵹��
����˼·����������ͷ�巨��������
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct LNode{
	int data;
	struct LNode *next;
}LNode;

/*β�巨����������*/
void CreateList(LNode *&L, int a[], int n)
{
	LNode *r,*s;
	L = (LNode *)malloc(sizeof(LNode));
	r = L;
	r->next = NULL;

	for(int i=0;i<n;i++)
	{
		s = (LNode *)malloc(sizeof(LNode));

		s->data = a[i];
		r->next = s;
		s->next = NULL;
		r = s;
	}
}

/*��ӡ������ L*/
void Displist(LNode *L)
{
	LNode *p=L->next;
	while(p!=NULL){
		cout<<p->data<<" ";
		p=p->next;
	}
	cout<<endl;
}

/*������ģ�ͷ�巨
������p��q��ǵ���㼰�������㣬����ͷ�巨���ڲ��½��������½�����*/
void Reversel(LNode *&L)
{
	LNode *p=L->next,*q;        //pָ��ɱ�ʼ�ķ�ͷ��㣬q��p�ĺ�̽��
	L->next = NULL;

	while(p != NULL)
	{
		q = p->next;
		p->next = L->next;      //ͷ�巨�����������
		L->next = p;
		p = q;
	}
}

int main()
{
	int N;
	LNode *L;

	cout<<"N:";     	//���뵥������Ϣ(����)
	cin>>N;
	int *A = new int (N);
	for(int i=0;i<N;i++)
		cin>>A[i];

	CreateList(L,A,N);  //����һ������
	Reversel(L);        //�������
	Displist(L);        //��ӡ�����ı�

	free(L);
	return 0;
}


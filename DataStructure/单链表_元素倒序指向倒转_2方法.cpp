/*
�����ܣ���������L�����������������ת����
����˼·��
Way1��ͷ�巨��ÿ�������������
Way2��ÿ�ζԵ���������ת����
*/
#include<iostream>
#include<stdlib.h>
#define Maxsize 50
using namespace std;

typedef struct LNode{
	int data;
	struct LNode *next;
}LNode;

/*β�巨����������*/
void Create(LNode *&L,int a[],int n)
{
	LNode *p,*s;
	L = (LNode *)malloc(sizeof(LNode));
	L->next = NULL;
	p = L;

	for(int i=0;i<n;i++)
	{
		s = (LNode *)malloc(sizeof(LNode));
		s->data = a[i];
		s->next = NULL;
		p->next = s;
		p = s;
	}
}

/*��ת������������ʵ��Ϊβ�巨��������
�������ڽ� L������в��Ϊ Lͷ������� pͷ������������� q�Ŷ�ʧ*/
void Reverlist(LNode *&L)
{
	LNode *p,*q;        //p�������㣬qΪp��̽��
	p = L->next;
	L->next = NULL;

	while(p!=NULL)
	{
		q = p->next;
		p->next = L->next;
		L->next = p;
		p = q;
	}
}

/*��ת������������2��ʵ��Ϊ���������ת���������б�ͷָ����*/
int Reverlist2(LNode *&L)
{
	LNode *h;
	LNode *p,*pr;
	h = L->next;    	//h ΪĿǰת����
	L->next = NULL; 	//����ͷ���

	if(h==NULL)
		return 0;

	p = h->next;        //p Ϊ�¸���ת����
	pr = NULL;      	//pr Ϊ�ϸ�ת���Ľ��
	
	while(p!=NULL)
	{
		h->next = pr;   //hת���ϸ���ת��Ľ��
		pr = h;         //���� pr
		h = p;          //�����¸���ת����
		p = p->next;
	}
	h->next = pr;   //����㴦��
	L->next = h;    //��ͷָ�����
}

/*��ӡ����*/
void Displist(LNode *L)
{
	LNode *p;
	p = L->next;

	while(p!=NULL)
	{
		cout<<p->data<<" ";
		p = p->next;
	}
	cout<<endl;
}

int main()
{
	LNode *h;
	int N;
	cout<<"N: ";
	cin>>N;
	int *A = new int (N);
	cout<<"A[]= ";
	for(int i=0;i<N;i++)
		cin>>A[i];

	Create(h,A,N);      //������ʼ������
	cout<<"Before Reverse: ";
	Displist(h);

	Reverlist(h);       //��������ת
	cout<<"After Reverse: ";
	Displist(h);

	Reverlist2(h);       //��������ת2
	cout<<"Then After Reverse2: ";
	Displist(h);

	free(h);
	return 0;
}


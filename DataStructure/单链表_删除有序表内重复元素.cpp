/*
�����ܣ�ɾ��������������ֵ����ͬ��Ԫ�أ���[1 1 1 2 2 3 3 3]ɾ����Ϊ[1 2 3]
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

/*ɾ����������L���ظ�Ԫ��
pָ����ʼ��㣬��p�����̽��Ƚϣ������ȣ���ɾ����̽�㣬pָ���̽��ĺ�̽��*/
void Delsl1(LNode *L)
{
	LNode *p = L->next,*q;
	while(p->next != NULL)
	{
		if(p->data == p->next->data)    //p���̽���ֵ
		{
			q = p->next;
			p->next = q->next;
			free(q);
		}else
			p = p->next;    //���ظ���p������
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

int main()
{
	int N;
	LNode *L;

	cout<<"N:";     	//���뵥������Ϣ(����)
	cin>>N;
	int *A = new int (N);
	for(int i=0;i<N;i++)
		cin>>A[i];

	CreateList(L,A,N);  //������ͷ���ĵ�����
	Delsl1(L);          //ɾ���ظ�Ԫ��
	Displist(L);        //��ӡ�����ĵ�����

	free(L);
	return 0;
}


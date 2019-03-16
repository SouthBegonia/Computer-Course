/*
�����ܣ���֪һ����ͷ�ڵ�ĵ�����LA��������ΪLA��LB����������LA����ֵ��Ϊ�����Ľ�㣬LB��ż����
����˼·�����½��LB����LA��Ļ����ϣ���LAԪ����ֵ�����жϣ�ż����Ԫ�ص�ɾ��������LB����
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

/*��A������������A��ż������B��*/
void Split2(LNode *A,LNode *&B)
{
	LNode *p,*q,*r;
	B = (LNode *)malloc(sizeof(LNode));
	B->next = NULL;

	p = A, r = B;

	while(p->next != NULL)
	{
		if(p->next->data %2 == 0)   //����ǰ p ֵ��Ϊż����������� B ����
		{
			q = p->next;            //q Ϊ��ǽ�� p �ĺ������(��Ҫ�ƶ���B��Ľ��)
			p->next = q->next;      //p Ϊ A ����ĩβ���(������A���ڵĽ��)
			q->next = NULL;
			r->next = q;
			r = q;
		}
		else
			p = p->next;            //��Ϊ������������ A ���ڣ�ĩβ��� p ����
	}
	r->next = NULL;
}

int main()
{
	int N;
	LNode *LA,*LB;

	cout<<"N:";     		//���뵥������Ϣ(����)
	cin>>N;
	int *A = new int (N);
	cout<<"SqList A:";
	for(int i=0;i<N;i++)
		cin>>A[i];

	CreateList(LA,A,N);  	//������ʼ������
	Split2(LA,LB);          //��ֹ���
	
	cout<<"LA:";			//��ӡ�����ı�
	Displist(LA);         	
	cout<<endl<<"LB:";
	Displist(LB);

	free(LA);
	free(LB);

	return 0;
}


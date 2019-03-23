/*
�����ܣ���֪��LA�ڽ����ֵ�������֡���ĸ�������ַ����ͣ�Ҫ�������ַ�ɸ����3����ͬ��
����˼·����LA�����������LB��LC����LA����ɸ�֣�
�Ա�LA���ǽ�������ɨ�裬��ӦԪ���޳���β������������
*/
#include<iostream>
#include<stdlib.h>
#include<ctype.h>
#define Maxsize 50
using namespace std;

typedef struct LNode{
	/*char num;
	char letter;
	char other;*/
	char data;
	struct LNode *next;
}LNode;

/*β�巨����������*/
void CreateList(LNode *&L, char a[], int n)
{
	LNode *r,*s;
	L = (LNode *)malloc(sizeof(LNode));
	L->next = NULL;
	r = L;

	for(int i=0;i<n;i++)
	{
		s = (LNode *)malloc(sizeof(LNode));
		s->data = a[i];
		s->next = NULL;
		r->next = s;
		r = r->next;
	}
}

/*ɸ�����֡���ĸ�������ַ����ڱ�LA,LB,LC*/
void Separate(LNode *&LA, LNode *&LB, LNode *&LC)
{
	LNode *pa,*pb,*pc;
	LNode *p = LA->next;
	pa = LA;
	pb = LB = (LNode *)malloc(sizeof(LNode));
	pc = LC = (LNode *)malloc(sizeof(LNode));

	while(p!=NULL)      //p��LA���ڼ���
	{
		if(isdigit(p->data))    //�����ַ�β���� pa����
		{
			pa->next = p;
			pa = pa->next;
		}else
		if(isalpha(p->data))    //��ĸ�ַ�β���� pb����
		{
			pb->next = p;
			pb = pb->next;
		}else       //�����ַ�δ���� pc����
		{
			pc->next = p;
			pc = pc->next;
		}
		p = p->next;
	}
	pa->next = NULL;    //��β����
	pb->next = NULL;
	pc->next = NULL;
}

void Displist(LNode *L)
{
	LNode *p;
	p = L->next;

	while(p!=NULL)
	{
		cout<<p->data;
		p = p->next;
	}
	cout<<endl;
}

int main()
{
	LNode *LA,*LB,*LC;
	int N;
	cout<<"N: ";
	cin>>N;
	char *A = new char (N);
	cout<<"A[]= ";
	for(int i=0;i<N;i++)
		cin>>A[i];

	CreateList(LA,A,N);      //������ʼ������
	Separate(LA,LB,LC);      //�ڱ�LA�Ļ�����ɸ��
	cout<<endl;

	Displist(LA);
	Displist(LB);
	Displist(LC);

	free(LA);
	free(LB);
	free(LC);

	return 0;
}


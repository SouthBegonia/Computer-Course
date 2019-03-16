#include<iostream>
#include<stdio.h>
#include<stdlib.h>
using namespace std;

typedef struct DLNode
{
	int data;
	DLNode *prior;
	DLNode *next;
}DLNode;

/*β�巨����˫����*/
void createDlistR(DLNode *&L, int a[], int n)
{
	DLNode *s,*r;
	int i;
	L =(DLNode *)malloc(sizeof(DLNode));

	L->prior=NULL;
	L->next=NULL;
	r=L;

	for(i=0;i<n;i++)
	{
		s = (DLNode *)malloc(sizeof(DLNode));
		s->data = a[i];

		/*β�巨����˫�������*/
		r->next = s;
		s->prior = r;
		r = s;
	}
	r->next = NULL;
}

/*��ӡ���� L*/
void Displist(DLNode *L)
{
	DLNode *p=L->next;
	while(p!=NULL){
		cout<<p->data<<" ";
		p=p->next;
	}
	cout<<endl;
}

/*��������C��ֵΪx�Ľ��*/
DLNode *findNode(DLNode *C, int x)
{
	DLNode *p = C->next;
	while(p!=NULL)
	{
		if(p->data==x)
			break;
		p=p->next;
	}
	return p;
}

int main()
{
	int A[5];
	int i;
	DLNode *dl;
	DLNode *ans;

	for(i=0;i<5;i++)    //����������Ϣ
		cin>>A[i];

	createDlistR(dl,A,5);   //β�巨
	Displist(dl);       //��ӡ����
	ans = findNode(dl,3);   //��ѯ������ֵΪx�Ľ��
	cout<<ans->data<<endl;
	
	free(dl);
	getchar();

	return 0;
}


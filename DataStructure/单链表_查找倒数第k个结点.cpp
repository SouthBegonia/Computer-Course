/*�����ܣ����ҵ������е����� k ������Ƿ����*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct LNode{
	int data;
	struct LNode *next;
}LNode;

/*β�巨����������*/
L CreateList(LNode *&L, int a[], int n)
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

/*��ӡ������*/
void Displist(LNode *L)
{
	LNode *p;
	p = L->next;
	while(p!=NULL){
		cout<<p->data<<" ";
		p = p->next;
	}
	cout<<endl;
}

/*���ҵ����� k �����*/
int FindElem(LNode *head, int k)
{
	int i=1;
	LNode *p1,*p;
	p1 = head->next;    //p1 ָ��ǰ�����Ľ��
	p = head;

	while(p1!=NULL){
		p1 = p1->next;
		++i;
		if(i>k)         //�㷨����
			p = p->next;
	}
	
	if(p==head){
		cout<<"�����ڵ�����"<<k<<"�����!";
		return 0;
	}
	else{
		cout<<"���ڵ�����"<<k<<"�����: "<<p->data;
		return 1;
	}
}

int main()
{
	LNode *list;
	int N;
	int tag=0;
	int *A = new int (N);

	cout<<"N:";
	cin>>N;
	cout<<"list:";
	for(int i=0;i<N;i++)
		cin>>A[i];
	cout<<"���ҵ����ڼ������:";
	cin>>tag;

	CreateList(list,A,N);
	FindElem(list,tag);

	free(list);
	return 0;
}


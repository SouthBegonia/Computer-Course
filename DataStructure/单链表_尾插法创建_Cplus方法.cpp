/*
������Ĵ�����������A[]������β�巨������������ʾ
C++����
��ע��C/C++�ڴ����ṹ��İ취���ڲ���
*/
#include<stdio.h>
#include<stdlib.h>
#include<iostream>
using namespace std;

typedef struct LNode
{
	int data;
	struct LNode *next;
}Linklist;

/*β�巨�����������������鼰�䳤��*/
void createlistHead(LNode *&newlist, int a[], int n)
{
	int i;
	LNode *s,*r;

	newlist = (LNode *)malloc(sizeof(LNode));
	newlist->next = NULL;
	r = newlist;

	for(i=0;i<n;i++)
	{
		s = (LNode *)malloc(sizeof(LNode));
		s->data = a[i];
		r->next = s;
		r = r->next;
	}
	r->next = NULL;
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
	int A[5];   //Ԥ������
	LNode *list;    //Ԥ�赥����

	for(int i=0;i<5;i++)    //�����ʼ������ӡ
		A[i] = i+1;
	for(int i=0;i<5;i++)
		cout<<A[i]<<" ";
	cout<<endl;
	
	createlistHead(list,A,5);
	Displist(list);
	
	free(list);
	getchar();
	return 0;
}

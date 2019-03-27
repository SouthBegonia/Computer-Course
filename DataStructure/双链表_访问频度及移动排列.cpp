/*
�����ܣ���֪һ˫����DL����������Ԫ��data��Ƶ��Ԫ��freq������ĳ���һ����Ƶ��+1������㷨�Ա���Ƶ�ȵݼ�����
����˼·������Locate()���������ֵx������������data=x�Ľ����Ƶ��+1��
����һ�κ�Ա�������У����ƶ�˫����Ľ�㣬ʹƵ�ȸߵĽ������ǰ(��ֵ���ڽ�)��
ÿ�μ�����ӡ����Ƶ��ֵ�鿴������ƥ��dataֵ�����������
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct DLNode{
	struct DLNode *prior;
	int data;
	int freq;
	struct DLNode *next;
}DLNode;

/*β�巨����˫������*/
void CreateList(DLNode *&L, int a[], int n)
{
	DLNode *r,*s;
	L = (DLNode *)malloc(sizeof(DLNode));
	L->next = NULL;
	L->prior = NULL;
	r = L;

	for(int i=0;i<n;i++)
	{
		s = (DLNode *)malloc(sizeof(DLNode));
		s->data = a[i];
		s->next = NULL;
		s->freq = 0;

		s->prior = r;
		r->next = s;
		r = r->next;
	}
}

/*��ӡ˫������Ƶ��*/
void Displist(DLNode *L)
{
	DLNode *p;
	
	p = L->next;
	cout<<"List Data: ";
	while(p!=NULL){
		cout<<p->data<<" ";
		p = p->next;
	}
	
	cout<<endl<<"Frequency: ";
	p = L->next;
	while(p!=NULL){
		cout<<p->freq<<" ";
		p = p->next;
	}
	cout<<endl;
}

/*��DL���ڷ����Ƿ���dataΪx�Ľ�㣬������Ƶ��freq+1������Ƶ�ȵݼ����иñ�*/
DLNode *Locate(DLNode *&DL, int x)
{
	DLNode *p = DL->next,*q;

	while(p!=NULL && p->data!=x)    //ɨ��ֱ����Ӧ����x�Ľ��
		p = p->next;

	if(p!=NULL)
	{
		++(p->freq);    //����һ����Ƶ�� +1
		q = p;          //ȡ���ý��
		q->prior->next = q->next;
		q->next->prior = q->prior;
		p = q->prior;

		while(p!=DL && q->freq>p->freq)     //Ѱ�� freq ���ڵ��ڸõ��λ��
			p = p->prior;
		q->next = p->next;      //�� p �������
		q->prior = p;
		p->next->prior = q;
		p->next = q;

		return q;
	}else
		return NULL;
}

int main()
{
	DLNode *dl;
	DLNode *tag;    //ѭ������
	int num = 0;
	int A[10] = {0,1,2,3,4,5,6,7,8,9};
	CreateList(dl,A,10);    //β�崴����ʼ˫����
	tag = dl;

	while(tag!=NULL)
	{
		Displist(dl);
		cout<<endl;

		cout<<"Input x: ";
		cin>>num;
		tag = Locate(dl,num);   //�ɹ�����Ƶ��������� NULL
	}
	
	free(dl);
	free(tag);
	return 0;
}


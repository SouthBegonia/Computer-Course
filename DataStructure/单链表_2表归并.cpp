/*
�����ܣ���֪A��B�Ǵ�ͷ���ĵ����������Ԫ�ض�������������鲢��һ������������C��
����˼·����һ����Ļ����Ͻ��в���������������Сֵ�ı�ǣ�һ�����Ϊ�±�(����һ��������ϵ�)���ն˽�㡣
ʱ�临�Ӷȣ�
��������A��������Ԫ�ض�С��B����Ԫ��ʱ������Ҫ�Ƚ� n ��
�����������������Ԫ�ض����Ա�һ�Σ��� 2*(n-1) �Σ����A��B����ĩλԪ��ֻ��Ҫһ�αȽ�(�пձ�����)���� 2n-1 ��
*/
#include<stdio.h>
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct LNode
{
	int data;
	struct LNode *next;
}LNode;

void merge(LNode *A, LNode *B, LNode *&C)
{
	LNode *p = A->next;     //p ���A����Сֵ���
	LNode *q = B->next;     //q ���B����Сֵ���
	LNode *r;       //r ���ʼ��ָ��C���ն˽��
	C = A;
	C->next = NULL;
	free(B);    	//��A��Ļ����ϴ������ͷ�Bͷ���
	
	r = C;          //r ʼ��ָ��ǰ������ն˽��
	while(p!=NULL && q!=NULL)
	{
		if(p->data <= q->data)
		{
			r->next = p;    //β�巨
			p = p->next;
			r = r->next;
		}
		else
		{
			r->next = q;
			q = q->next;
			r = r->next;
		}
	}
	r->next = NULL;

	if(p!=NULL)         //���ʣ��Ľ��������Cβ��
		r->next = p;
	if(q!=NULL)
		r->next = q;
}

int main()
{
	//����2��ͬ����������������ռ�
	//������3�������Ϊ�鲢��ı�
	//����merge()���б�Ĺ鲢
	getchar();
}

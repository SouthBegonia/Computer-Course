/*
程序功能：已知A，B是带头结点的单链表，两表的元素都递增。将两表归并成一个递增的链表C。
基本思路：在一个表的基础上进行操作，两表设置最小值的标记，一个标记为新表(其中一个表基础上的)的终端结点。
时间复杂度：
最佳情况：A表中所有元素都小于B表内元素时，仅需要比较 n 次
最坏情况：除两表内最后元素都被对比一次，即 2*(n-1) 次，最后A，B表内末位元素只需要一次比较(有空表即结束)，故 2n-1 次
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
	LNode *p = A->next;     //p 标记A内最小值结点
	LNode *q = B->next;     //q 标记B内最小值结点
	LNode *r;       //r 标记始终指向C的终端结点
	C = A;
	C->next = NULL;
	free(B);    	//在A表的基础上处理，故释放B头结点
	
	r = C;          //r 始终指向当前链表的终端结点
	while(p!=NULL && q!=NULL)
	{
		if(p->data <= q->data)
		{
			r->next = p;    //尾插法
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

	if(p!=NULL)         //最后剩余的结点链接在C尾部
		r->next = p;
	if(q!=NULL)
		r->next = q;
}

int main()
{
	//创建2不同的增序单链表，并分配空间
	//创建第3个结点作为归并后的表
	//调用merge()进行表的归并
	getchar();
}

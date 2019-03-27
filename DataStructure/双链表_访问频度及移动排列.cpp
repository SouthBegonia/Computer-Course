/*
程序功能：已知一双链表DL，包含数据元素data和频度元素freq，访问某结点一次其频度+1，设计算法对表按照频度递减排列
基本思路：创建Locate()传入表及检索值x，检索表若有data=x的结点其频度+1；
检索一次后对表进行排列，以移动双链表的结点，使频度高的结点排在前(等值则邻近)；
每次检索打印链表及频度值查看，若无匹配data值，程序结束；
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

/*尾插法创建双向链表*/
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

/*打印双链表及其频度*/
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

/*在DL表内访问是否有data为x的结点，有则其频度freq+1，依据频度递减排列该表*/
DLNode *Locate(DLNode *&DL, int x)
{
	DLNode *p = DL->next,*q;

	while(p!=NULL && p->data!=x)    //扫描直至对应数据x的结点
		p = p->next;

	if(p!=NULL)
	{
		++(p->freq);    //访问一次其频度 +1
		q = p;          //取出该结点
		q->prior->next = q->next;
		q->next->prior = q->prior;
		p = q->prior;

		while(p!=DL && q->freq>p->freq)     //寻找 freq 大于等于该点的位置
			p = p->prior;
		q->next = p->next;      //在 p 结点后插入
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
	DLNode *tag;    //循环体标记
	int num = 0;
	int A[10] = {0,1,2,3,4,5,6,7,8,9};
	CreateList(dl,A,10);    //尾插创建初始双链表
	tag = dl;

	while(tag!=NULL)
	{
		Displist(dl);
		cout<<endl;

		cout<<"Input x: ";
		cin>>num;
		tag = Locate(dl,num);   //成功进行频度运算则非 NULL
	}
	
	free(dl);
	free(tag);
	return 0;
}


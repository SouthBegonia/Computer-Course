/*
程序功能：已知一个带头节点的单链表LA，将其拆分为LA，LB两个单链表，LA存数值域为奇数的结点，LB存偶数的
基本思路：另创新结点LB，在LA表的基础上，对LA元素数值进行判断，偶数的元素的删除并插于LB表内
*/
#include<iostream>
#include<stdlib.h>
using namespace std;

typedef struct LNode{
	int data;
	struct LNode *next;
}LNode;

/*尾插法创建单链表*/
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

/*打印单链表 L*/
void Displist(LNode *L)
{
	LNode *p=L->next;
	while(p!=NULL){
		cout<<p->data<<" ";
		p=p->next;
	}
	cout<<endl;
}

/*将A表内奇数留在A表，偶数移至B表*/
void Split2(LNode *A,LNode *&B)
{
	LNode *p,*q,*r;
	B = (LNode *)malloc(sizeof(LNode));
	B->next = NULL;

	p = A, r = B;

	while(p->next != NULL)
	{
		if(p->next->data %2 == 0)   //若当前 p 值域为偶数，则将其插入 B 表内
		{
			q = p->next;            //q 为标记结点 p 的后驱结点(需要移动到B表的结点)
			p->next = q->next;      //p 为 A 表内末尾结点(保留于A表内的结点)
			q->next = NULL;
			r->next = q;
			r = q;
		}
		else
			p = p->next;            //若为奇数，则保留于 A 表内，末尾结点 p 后移
	}
	r->next = NULL;
}

int main()
{
	int N;
	LNode *LA,*LB;

	cout<<"N:";     		//键入单链表信息(有序)
	cin>>N;
	int *A = new int (N);
	cout<<"SqList A:";
	for(int i=0;i<N;i++)
		cin>>A[i];

	CreateList(LA,A,N);  	//创建初始单链表
	Split2(LA,LB);          //拆分过程
	
	cout<<"LA:";			//打印处理后的表
	Displist(LA);         	
	cout<<endl<<"LB:";
	Displist(LB);

	free(LA);
	free(LB);

	return 0;
}


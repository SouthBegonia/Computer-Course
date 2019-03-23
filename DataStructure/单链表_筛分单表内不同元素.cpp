/*
程序功能：已知表LA内结点数值包括数字、字母及其他字符类型，要求将三类字符筛分至3个不同表
基本思路：在LA表基础上另设LB，LC表，对LA进行筛分；
对表LA设标记进行整表扫描，对应元素剔除、尾插入其他两表
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

/*尾插法创建单链表*/
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

/*筛分数字、字母、其他字符置于表LA,LB,LC*/
void Separate(LNode *&LA, LNode *&LB, LNode *&LC)
{
	LNode *pa,*pb,*pc;
	LNode *p = LA->next;
	pa = LA;
	pb = LB = (LNode *)malloc(sizeof(LNode));
	pc = LC = (LNode *)malloc(sizeof(LNode));

	while(p!=NULL)      //p在LA表内检索
	{
		if(isdigit(p->data))    //数字字符尾插入 pa链表
		{
			pa->next = p;
			pa = pa->next;
		}else
		if(isalpha(p->data))    //字母字符尾插入 pb链表
		{
			pb->next = p;
			pb = pb->next;
		}else       //其他字符未插入 pc链表
		{
			pc->next = p;
			pc = pc->next;
		}
		p = p->next;
	}
	pa->next = NULL;    //表尾处理
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

	CreateList(LA,A,N);      //创建初始单链表
	Separate(LA,LB,LC);      //在表LA的基础上筛分
	cout<<endl;

	Displist(LA);
	Displist(LB);
	Displist(LC);

	free(LA);
	free(LB);
	free(LC);

	return 0;
}


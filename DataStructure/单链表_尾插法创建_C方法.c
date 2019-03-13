/*
链表的创建，将数组A[]的内容尾插法插入链表，并显示
C语言方法
缺陷：传递给函数createlistHead()的链表L未被改变，问题待解决
*/
#include<stdio.h>
#include<stdlib.h>

typedef struct LNode
{
	int data;
	struct LNode *next;
}Linklist;

/*尾插法建立单链表，传入数组及其长度*/
void createlistHead(LNode *newlist, int a[], int n)
{
	int i;
	LNode *s,*r;

	newlist = (LNode *)malloc(sizeof(LNode));   //链表初始化
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
	
	//函数内可正确显示链表
	r = newlist->next;
	while(r != NULL)
	{
		printf("%d ",r->data);
		r = r->next;
	}
}

int main()
{
	int A[5];   //传入链表的数组

	LNode *list;    //待插入链表
	LNode *head;    //头指针

	for(int i=0;i<5;i++)    //数组初始化及打印
		A[i] = i+1;
	for(int i=0;i<5;i++)
		printf("%d ",A[i]);
	printf("\n");
	
	createlistHead(list,A,5);
	
	/*无法显示链表，传入的 list 未改变
	head = list->next;
	while(head != NULL)
	{
		printf("%d ",head->data);
		head = head->next;
	}
	*/

	free(list);
	getchar();
	return 0;
}

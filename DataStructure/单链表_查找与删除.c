/*
程序功能：查找单链表C内数值为x的元素，并将其删除
备注：需要知道前驱结点p才可删除该结点
*/
#include<stdio.h>
#include<stdlib.h>

typedef struct LNode
{
	int data;
	struct LNode *next;
}LNode;

int findAndDelete(LNode *C, int x)
{
	LNode *p,*q;
	p=C;
	
	while(p->next != NULL)
	{
		if(p->next->data == x)
			break;
		p=p->next;
	}
	
	if(p->next == NULL)
		return 0;
	else
	{
		q=p->next;
		p->next=p->next->next;
		//free(q);
		
		return 1;
	}
}
int main()
{
	//创建结点分配空间
	//调用findAndDelete()传入表及待查找的元素的值
	
	return 0;
}

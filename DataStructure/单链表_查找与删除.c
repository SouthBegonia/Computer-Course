/*
�����ܣ����ҵ�����C����ֵΪx��Ԫ�أ�������ɾ��
��ע����Ҫ֪��ǰ�����p�ſ�ɾ���ý��
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
	//����������ռ�
	//����findAndDelete()����������ҵ�Ԫ�ص�ֵ
	
	return 0;
}

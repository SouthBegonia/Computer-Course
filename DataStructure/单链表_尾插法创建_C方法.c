/*
����Ĵ�����������A[]������β�巨������������ʾ
C���Է���
ȱ�ݣ����ݸ�����createlistHead()������Lδ���ı䣬��������
*/
#include<stdio.h>
#include<stdlib.h>

typedef struct LNode
{
	int data;
	struct LNode *next;
}Linklist;

/*β�巨�����������������鼰�䳤��*/
void createlistHead(LNode *newlist, int a[], int n)
{
	int i;
	LNode *s,*r;

	newlist = (LNode *)malloc(sizeof(LNode));   //�����ʼ��
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
	
	//�����ڿ���ȷ��ʾ����
	r = newlist->next;
	while(r != NULL)
	{
		printf("%d ",r->data);
		r = r->next;
	}
}

int main()
{
	int A[5];   //�������������

	LNode *list;    //����������
	LNode *head;    //ͷָ��

	for(int i=0;i<5;i++)    //�����ʼ������ӡ
		A[i] = i+1;
	for(int i=0;i<5;i++)
		printf("%d ",A[i]);
	printf("\n");
	
	createlistHead(list,A,5);
	
	/*�޷���ʾ��������� list δ�ı�
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

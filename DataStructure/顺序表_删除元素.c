/*
�����ܣ�����˳���ɾ�������½Ǳ�Ϊ tag ��Ԫ��
����˼·����Ŀ��Ԫ�غ�������ǰ�Ƹ��Ǽ���
*/
#include<stdio.h>
#include<stdlib.h>

#define MaxSize 50

typedef struct
{
	int data[MaxSize];  //���������
	int len;            //ʵ�����鳤��
}Sqlist;

/*ɾ�������½Ǳ�Ϊ p(0<=p<=len-1)��Ԫ�� e*/
int deleteElem(Sqlist *L, int p)
{
	if(p<0 || p>L->len-1)
		return 0;

	for(int i=p;i<L->len-1;i++)
		L->data[i] = L->data[i+1];  //Ŀ��Ԫ�صĺ���Ԫ��ǰ�Ƹ���ʵ��ɾ��
	--(L->len);
	return 1;
}

int main()
{
	int i;
	int tag = 4;    //��ɾ��Ԫ�ص��±�

	Sqlist *L = (Sqlist *)malloc(sizeof(Sqlist));

	/*��ʼ������*/
	L->len = 10;
	for(i=0;i<L->len;i++)
		L->data[i] = i;

	for(i=0;i<L->len;i++)
		printf("%-2d ",L->data[i]);
	printf("\n");

    /*ɾ������*/
	if(deleteElem(L,tag))
	{
		printf("ɾ���±�Ϊ %-2d ��Ԫ�غ�ı�Ϊ��\n",tag);
		for(i=0;i<L->len;i++)
			printf("%-2d ",L->data[i]);
		printf("\n");
	}
	else printf("ɾ��Ԫ�ص���Ϣ����");

	free(L);

	getchar();
	return 0;
}


/*
�����ܣ�����˳�����˳����ڵ� tag ����λ�������µ�Ԫ��
����˼·��˳���Ĳ�����Ҫ������λ�õĺ���Ԫ�غ��ƣ���չ����ſɽ��в������
*/
#include<stdio.h>
#include<stdlib.h>

#define MaxSize 50

typedef struct
{
	int data[MaxSize];  //���������
	int len;        	//ʵ�����鳤��
}Sqlist;

/*�ڱ�ĵ� p(0<=p<=len)��λ���ϲ����µ�Ԫ�� e*/
int deleteElem(Sqlist *L, int p)
{
	if(p<0 || p>L->len-1)
		return 0;

	for(int i=p;i<L->len-1;i++)
		L->data[i] = L->data[i+1];
	--(L->len);
	return 1;
}

int main()
{
	int i;
	int tag = 4;    //�ڵ�tag��λ�ò�����Ԫ��

	Sqlist *L = (Sqlist *)malloc(sizeof(Sqlist));

	/*��ʼ������*/
	L->len = 10;
	for(i=0;i<L->len;i++)
		L->data[i] = i;

	for(i=0;i<L->len;i++)
		printf("%-2d ",L->data[i]);
	printf("\n");

    /*���뺯��*/
	if(deleteElem(L,tag))
	{
		printf("ɾ���±�Ϊ %-2d ��Ԫ�غ�ı�Ϊ��\n",tag);
		for(i=0;i<L->len;i++)
			printf("%-2d ",L->data[i]);
		printf("\n");
	}
	else printf("����Ԫ����Ϣ����");

	free(L);

	getchar();
	return 0;
}

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
int insertElem(Sqlist *L, int p, int e)
{
	if(p<0 || p>L->len || L->len==MaxSize)
		return 0;

	for(int i=L->len-1; i>=p; --i)
		L->data[i+1] = L->data[i];
	L->data[p] = e;
	++(L->len);
	return 1;
}

int main()
{
	int i;
	int tag = 0;    //�ڵ�tag��λ�ò�����Ԫ��
	int tag_data = 12;  //����Ԫ�ص���Ϣ
	
	Sqlist *L = (Sqlist *)malloc(sizeof(Sqlist));

	/*��ʼ������*/
	L->len = 10;
	for(i=0;i<L->len;i++)
		L->data[i] = i+1;
	
	for(i=0;i<L->len;i++)
		printf("%-2d ",L->data[i]);
	printf("\n");

    /*���뺯��*/
	if(insertElem(L,tag,tag_data))
	{
		printf("�� %-2d ��λ�ò��� %-2d ��ı�Ϊ��\n",tag,tag_data);
		for(i=0;i<L->len;i++)
			printf("%-2d ",L->data[i]);
		printf("\n");
	}
	else printf("����Ԫ����Ϣ����");

	free(L);

	getchar();
	return 0;
}

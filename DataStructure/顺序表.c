/*
�����ܣ�����˳�������˳������׸���Ŀ��ֵ���Ԫ��
����˼·��˳���Ĵ��������Լ�����ӳ��ȱ�����Ҳ��ʵ�ýṹ��(��ͨ�ṹ���ָ����)
*/
#include<stdio.h>
#define MaxSize 50

typedef struct
{
	int data[MaxSize];  //���������
	int len;        	//ʵ�����鳤��
}Sqlist;

int findElem(Sqlist L, int x)
{
	int i;
	for(i=0;i<L.len;i++)
	{
		if(x<L.data[i])     //�������ڲ�ѯ��һ���� x ���Ԫ��
			return i;       //���ڣ������±�
	}
	return -1;      //�����ڵ����
}

int main()
{
	int i;
	int n = 10;     //ʵ�����鳤��
	int num = 6;    //Ŀ��ֵ
	int tag = 0;    //����Ŀ��Ԫ���±�
	Sqlist L;       //����˳���(���鼰�䳤����Ϣ)
	
	//ָ�뷨��Sqlist *L = (Sqlist *)malloc(sizeof(Sqlist));
	
	/*��ʼ������*/
	for(i=0;i<n;i++)
		L.data[i] = i+2;
	L.len = n;
	
	for(i=0;i<n;i++)
		printf("%d ",L.data[i]);
	printf("\n");
	
	/*��������Ŀ��ֵ���׸�Ԫ��*/
	tag = findElem(L,num);
	if(tag>=0)
		printf("�����׸������� %d ���Ԫ���� a[%d]=%d\n",num,tag,L.data[tag]);
	else printf("���ڲ����ڴ��� %d ����\n",num);
	
	//free(L);
	
	getchar();
	return 0;
}

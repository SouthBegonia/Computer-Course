/*
程序功能：构建顺序表，删除表内下角标为 tag 的元素
核心思路：将目标元素后续数组前移覆盖即可
*/
#include<stdio.h>
#include<stdlib.h>

#define MaxSize 50

typedef struct
{
	int data[MaxSize];  //最长可用数组
	int len;            //实用数组长度
}Sqlist;

/*删除表内下角标为 p(0<=p<=len-1)的元素 e*/
int deleteElem(Sqlist *L, int p)
{
	if(p<0 || p>L->len-1)
		return 0;

	for(int i=p;i<L->len-1;i++)
		L->data[i] = L->data[i+1];  //目标元素的后续元素前移覆盖实现删除
	--(L->len);
	return 1;
}

int main()
{
	int i;
	int tag = 4;    //待删除元素的下标

	Sqlist *L = (Sqlist *)malloc(sizeof(Sqlist));

	/*初始化数组*/
	L->len = 10;
	for(i=0;i<L->len;i++)
		L->data[i] = i;

	for(i=0;i<L->len;i++)
		printf("%-2d ",L->data[i]);
	printf("\n");

    /*删除函数*/
	if(deleteElem(L,tag))
	{
		printf("删除下标为 %-2d 的元素后的表为：\n",tag);
		for(i=0;i<L->len;i++)
			printf("%-2d ",L->data[i]);
		printf("\n");
	}
	else printf("删除元素的信息错误！");

	free(L);

	getchar();
	return 0;
}


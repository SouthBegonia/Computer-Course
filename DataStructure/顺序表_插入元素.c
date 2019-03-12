/*
程序功能：构建顺序表，在顺序表内第 tag 个空位处插入新的元素
核心思路：顺序表的插入需要将插入位置的后续元素后移，扩展数组才可进行插入操作
*/
#include<stdio.h>
#include<stdlib.h>

#define MaxSize 50

typedef struct
{
	int data[MaxSize];  //最长可用数组
	int len;        	//实用数组长度
}Sqlist;

/*在表的第 p(0<=p<=len)个位置上插入新的元素 e*/
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
	int tag = 0;    //在第tag个位置插入新元素
	int tag_data = 12;  //插入元素的信息
	
	Sqlist *L = (Sqlist *)malloc(sizeof(Sqlist));

	/*初始化数组*/
	L->len = 10;
	for(i=0;i<L->len;i++)
		L->data[i] = i+1;
	
	for(i=0;i<L->len;i++)
		printf("%-2d ",L->data[i]);
	printf("\n");

    /*插入函数*/
	if(insertElem(L,tag,tag_data))
	{
		printf("第 %-2d 个位置插入 %-2d 后的表为：\n",tag,tag_data);
		for(i=0;i<L->len;i++)
			printf("%-2d ",L->data[i]);
		printf("\n");
	}
	else printf("插入元素信息错误！");

	free(L);

	getchar();
	return 0;
}

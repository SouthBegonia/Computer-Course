/*
程序功能：构建顺序表，查找顺序表内首个比目标值大的元素
核心思路：顺序表的创建，可以简单数组加长度变量，也可实用结构体(普通结构体或指针型)
*/
#include<stdio.h>
#define MaxSize 50

typedef struct
{
	int data[MaxSize];  //最长可用数组
	int len;        	//实用数组长度
}Sqlist;

int findElem(Sqlist L, int x)
{
	int i;
	for(i=0;i<L.len;i++)
	{
		if(x<L.data[i])     //递增表内查询第一个比 x 大的元素
			return i;       //存在，返回下标
	}
	return -1;      //不存在的情况
}

int main()
{
	int i;
	int n = 10;     //实用数组长度
	int num = 6;    //目标值
	int tag = 0;    //所得目标元素下标
	Sqlist L;       //创建顺序表(数组及其长度信息)
	
	//指针法：Sqlist *L = (Sqlist *)malloc(sizeof(Sqlist));
	
	/*初始化数组*/
	for(i=0;i<n;i++)
		L.data[i] = i+2;
	L.len = n;
	
	for(i=0;i<n;i++)
		printf("%d ",L.data[i]);
	printf("\n");
	
	/*检索大于目标值的首个元素*/
	tag = findElem(L,num);
	if(tag>=0)
		printf("表内首个比数字 %d 大的元素是 a[%d]=%d\n",num,tag,L.data[tag]);
	else printf("表内不存在大于 %d 的数\n",num);
	
	//free(L);
	
	getchar();
	return 0;
}

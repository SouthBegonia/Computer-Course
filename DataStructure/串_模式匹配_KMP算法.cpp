/*
程序功能：采用KMP算法，建立模式串的跳转数组next[]，计算模式串sub在主串str中的起始下标位置；
基本思路：顺序扫描，当遇到两串i,j字符不匹配时，仅跳转模式串标记j到next[]位置，主串不回溯；
详解KMP -[https://www.cnblogs.com/yjiyjige/p/3263858.html]
备注：next[]跳转原理，KMP再优化
*/
#include<iostream>
#include<stdlib.h>
#include<string.h>
#define Maxsize 50
using namespace std;

typedef struct{
	char *ch;
	int len;
}Str;

/*计算模式串的next[]*/
void GetNext(Str substr, int next[])
{
	int i=1,j=0;
	next[1] = 0;

	while(i<substr.len)
	{
		if(j==0 || substr.ch[i]==substr.ch[j])
		{
			++i;
			++j;
			next[i] = j;
		}else
			j = next[j];
	}
}

void Getnextval(Str substr, int nextval[])
{
	int i=1,j=0;
	nextval[1] = 0;

	while(i<substr.len)
	{
		if(j==0 || substr.ch[i]==substr.ch[j])
		{
			++i;
			++j;
			if(substr.ch[i]!=substr.ch[j])
				nextval[i] = j;
			else
				nextval[i] = nextval[j];
		}else
			j = nextval[j];
	}
}

/*创建两字符串*/
void CreateStr(Str &str)
{
	if(str.ch)
		free(str.ch);

	char a[Maxsize] = "";
	cout<<"Input a string to S: ";
	cin>>a;

	str.ch = (char *)malloc(sizeof(char)*strlen(a)+1);
	strcpy(str.ch,a);
	str.len = strlen(a);

	cout<<"ch : "<<str.ch<<"  len = "<<str.len<<"  size = "<<sizeof(str.ch)<<endl;
}

/*模式匹配：KMP算法：返回模式串在主串内下标*/
int KMP(Str str, Str substr, int next[])
{
	int i=0,j=0;
	
	while(i<str.len && j<substr.len)    //某标记到达末尾元素后结束
	{
		if(j==0 || str.ch[i]==substr.ch[j])
		{
			++i;
			++j;
		}else
			j = next[j];    //不匹配：跳转模式串标记到next[j]位置
	}

	if(j>=substr.len)   //模式串扫描完整，返回在主串内下标
		return i-substr.len;
	else
		return 0;
}

int main()
{
	Str S;  //主串
	Str SUB;    //模式串
	int ans = 0;
	int next[Maxsize];

	/*SUB_next[1~5] =[0 1 1 1 1]  ans = 5
	SUB.ch = (char *)malloc(sizeof(char) * 5);
	strcpy(SUB.ch,"ABCAC");
	SUB.len = strlen("ABCAC");

	S.ch = (char *)malloc(sizeof(char) * 13);
	strcpy(S.ch,"ABABCABCACBAB");
	S.len = strlen("ABABCABCACBAB");
	*/

	next[0] = 0;
	while(1)
	{
		CreateStr(S);   //创建主串与模式串
		CreateStr(SUB);
		GetNext(SUB,next);  //取得模式串的跳转数组next[]
		
		cout<<"next[] :";
		for(int i=0;i<=SUB.len;i++)
			cout<<next[i]<<" ";

		ans = KMP(S,SUB,next);  //模式串匹配
		cout<<endl<<"ans = "<<ans<<endl;
	}
	free(S.ch);
	free(SUB.ch);

	return 0;
}


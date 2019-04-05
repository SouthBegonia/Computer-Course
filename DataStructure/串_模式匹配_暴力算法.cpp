/*
程序功能：简单模式匹配算法的实现
基本思路：当两串元素对比不匹配时，则主串和模式串标记回溯
本算法虽能解决问题，但时间复杂度偏高，可采用KMP算法改进
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

/*简单模式匹配算法：每次回溯标记逐一比较*/
int Index(Str str, Str substr)
{
	int i=1,j=1,k=i;

	while(i<=str.len &&j<=substr.len)
	{
		if(str.ch[i]==substr.ch[j])
		{
			++i;
			++j;
		}else{
			j = 1;
			i = ++k;    //i的回溯
		}
	}
	if(j>substr.len)
		return k;
	else return -1;
}

/*建立读取字符串*/
void CreateStr(Str &str)
{
	if(str.ch)
		free(str.ch);

	char a[Maxsize] = "";
	cout<<"Input a string : ";
	cin>>a;

	str.ch = (char *)malloc(sizeof(char)*strlen(a)+1);
	strcpy(str.ch,a);
	str.len = strlen(a);

	cout<<"ch : "<<str.ch<<"  len = "<<str.len<<"  size = "<<sizeof(str.ch)<<endl;
}

int main()
{
	Str S;      //主串
	Str Sb;     //子串(模式串)
	int ans = -1;    //模式匹配位置

	while(1)
	{
		CreateStr(S);
		CreateStr(Sb);
		ans = Index(S,Sb);
		cout<<"Ans = "<<ans<<endl;
		cout<<endl;
	}

	free(S.ch);
	free(Sb.ch);

	return 0;
}


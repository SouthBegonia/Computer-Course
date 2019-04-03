/*
程序功能：创建串的结构体，实现赋值、取长、连接、求字串、清空的基本功能
基本思路：为了方便检索串长度，采用ch[]或*ch数组+len的形式，时间复杂度从O(n)减到O(1);
串的赋值不同于普通'='赋值，需要逐一对元素赋值；
易错在于串的释放申请、各类操作后的长度变化
*/
#include<iostream>
#include<stdlib.h>
#include<string.h>
#define Maxsize 50
using namespace std;

typedef struct{
	char *ch;       //动态分配储存
	int length;     //字符长度
}Str;

/*赋值操作：将字符串ch 赋值到 str内*/
int StrAssign(Str &str, char *ch)
{
	if(str.ch)
		free(str.ch);   //释放原串空间
	int len = 0;
	
	char *c = ch;       //求ch串的长度
	while(*c){
		++len;
		++c;
	}
	if(len==0)      //若ch串为空则返回空串
	{
		str.ch = NULL;
		str.length = 0;
		return 1;
	}else
	{
		str.ch = (char *)malloc(sizeof(char) * (len+1));    //为原串申请新空间(计入末尾'\0')
		if(str.ch==NULL)
			return 0;
		else
		{
			c = ch;
			for(int i=0;i<=len;i++,c++)     //将 ch 末尾'\0'也复制过来
				str.ch[i] = *c;
			str.length = len;
			return 1;
		}
	}
}

/*取得字符串长度：返回长度值*/
int StrLength(Str str)
{
	return str.length;
}

/*串的比较：比较s1 和 s2 串，返回两串首个不同元素的差值*/
int StrCompare(Str s1, Str s2)
{
	for(int i=0;i<s1.length && i<s2.length;i++)
		if(s1.ch[i] != s2.ch[i])
			return s1.ch[i]-s2.ch[i];   //首个不同元素的差
	return s1.length-s2.length;
}

/*串的连接：将str1 和 str2 连接并复制到 str内*/
int StrConcat(Str &str, Str str1, Str str2)
{
	if(str.ch){
		free(str.ch);   //释放原串空间
		str.ch = NULL;
	}

	str.ch = (char *)malloc(sizeof(char) * (str1.length+str2.length+1));    //申请新空间
	if(str.ch==NULL)
		return 0;

	int i=0;
	while(i<str1.length){
		str.ch[i] = str1.ch[i];     //复制str1 串
		++i;
	}
	int j=0;
	while(j<=str2.length){
		str.ch[i+j] = str2.ch[j];   //复制str2 串到str1 尾，注此处复制str2包含末尾'\0'
		++j;
	}
	str.length = str1.length + str2.length;
	return 1;
}

/*求子串：将str 内下标 pos~len的元素的子串复制到 substr 内*/
int SubString(Str &substr, Str str, int pos, int len)
{
	if(pos<0 || pos>=str.length || len<0 || len>str.length-pos) //子串合法性
		return 0;
	if(substr.ch){
		free(substr.ch);    //释放原串空间
		substr.ch = NULL;
	}

	if(len==0)  //子串为空
	{
		substr.ch = NULL;
		substr.length = 0;
		return 1;
	}else
	{
		substr.ch = (char *)malloc(sizeof(char) * (len+1));
		
		int i = pos;
		int j = 0;
		while(i<pos+len)
		{
			substr.ch[j] = str.ch[i];
			++i;
			++j;
		}
		substr.ch[j] = '\0';    //字符串尾标
		substr.length = len;
		return 1;
	}
}

/*串的清空：释放str 的空间，长度归零*/
int ClearStr(Str &str)
{
	if(str.ch){
		free(str.ch);
		str.ch = NULL;
	}
	str.length = 0;
	return 1;
}

/*输入字符串*/
void InputStr(char s[])
{
	cout<<"Input a string:";
	cin>>s;
}

/*打印字符串*/
void OutputStr(Str str)
{
	cout<<"\""<<str.ch<<"\""<<endl;
}

/*初始化：串结构体*/
void Init(Str &s)
{
	s.ch = (char *)malloc(sizeof(char));
	s.length = 0;
}

int main()
{
	char message[Maxsize];  //键入的串
	int choice=0;   //选择功能
	int tag[2];     //子串首尾下标
	
	Str S;      //赋值后的串
	Str ComS;   //被比较串
	Str CatS;   //连接S与ComS后的串
	Str SubS;   //S内的子串

	Init(S);    //初始化各串
	Init(CatS);
	Init(ComS);
	Init(SubS);
	StrAssign(ComS,"South");    //预设被比较串

	cout<<"Choose a function:"<<endl;
	cout<<"1)StrAssign  2)StrLength  3)StrCompare"<<endl;
	cout<<"4)StrConcat  5)SubString  Other)Quit"<<endl;
	cin>>choice;

	while(choice==1||choice==2||choice==3||choice==4||choice==5||choice==6)
	{
		switch(choice)      //功能选择
		{
			case 1:{
				InputStr(message);
				StrAssign(S,message);
				OutputStr(S);
			}break;

			case 2:{
				OutputStr(S);
				cout<<"Length = "<<StrLength(S)<<endl;
			}break;

			case 3:{
				OutputStr(S);
				OutputStr(ComS);
				cout<<"Conpare s1 with s2: "<<StrCompare(S,ComS)<<endl;
			}break;

			case 4:{
				OutputStr(S);
				OutputStr(ComS);
				StrConcat(CatS,S,ComS);
				cout<<"Concat s1 and s2: ";
				OutputStr(CatS);
				cout<<"Length = "<<StrLength(CatS)<<endl;
			}break;

			case 5:{
				OutputStr(S);
				cout<<"Input star and end:";
				cin>>tag[0]>>tag[1];
				SubString(SubS,S,tag[0],tag[1]);
				OutputStr(SubS);
			}break;

			default:
				cout<<"Error"<<endl;
		}
		cout<<"--------------"<<endl<<endl;
		cout<<"Choose a function:"<<endl;
		cout<<"1)StrAssign  2)StrLength  3)StrCompare"<<endl;
		cout<<"4)StrConcat  5)SubString  6)ClearStr  Other)Quit"<<endl;
		cin>>choice;
		cout<<endl;
	}
	cout<<"Done!"<<endl;
	ClearStr(S);
	ClearStr(ComS);
	ClearStr(CatS);
	ClearStr(SubS);

	return 0;
}

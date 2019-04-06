/*
程序功能：扫描字符串，删除串内字符为ch的元素
基本思路：
- 解法1：将字符串内除ch外其他字符复制到新串，释放原串；
- 解法2：逐一扫描，扫描到ch则将其删除，后续元素前移，重复过程；
- 解法3：在解法2的基础上改进，将两个待删除ch之间的字串前移 目前扫描了ch个 的位置；
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

typedef struct{
	char ch[Maxsize];
	int len;
}Str2;

/*解法一：将字符串内除ch外其他字符复制到新串，释放原串；*/
void Del_1(Str &str, char ch)
{
	if(str.len!=0){
		int sum = 0;
		int i,j;

		for(i=0;i<str.len;i++)
			if(str.ch[i]==ch)
				++sum;
		if(sum!=0){
			char *temp_ch = (char *)malloc(sizeof(char) * (str.len-sum+1));
			for(i=0,j=0;i<str.len;i++)
				if(str.ch[i]!=ch)
					temp_ch[j++] = str.ch[i];   //非ch字符入新串
			temp_ch[j] = '\0';
			str.len = str.len-sum;  //新串长度
			free(str.ch);   //释放就串
			str.ch = temp_ch;   //修改指向
		}
	}
}

/*解法2：逐一扫描，扫描到ch则将其删除，后续元素前移，重复过程；*/
void Del_2(Str2 &str, char ch)
{
	if(str.len!=0){
		for(int i=0;i<str.len;)
			if(str.ch[i]==ch){
				for(int j=i;j<str.len-1;j++)
					str.ch[j] = str.ch[j+1];
				--str.len;
			}else ++i;
		str.ch[str.len] = '\0';
	}
}

/*解法3：在解法2的基础上改进，将两个待删除ch之间的字串前移 目前扫描了ch个 的位置；*/
void Del_3(Str2 &str, char ch)
{
	if(str.len!=0){
		int ch_num = 0;     //目前扫描到ch的个数
		int i=0,j;

		while(str.ch[i]!='\0'){
			if(str.ch[i]==ch){
				++ch_num;
				for(j=i+1;str.ch[j]!=ch && str.ch[j]!='\0';j++) //前移第一个ch到下一个ch或\0内的的字串
					str.ch[j-ch_num] = str.ch[j];
				i = j;
				--str.len;
			}else ++i;
		}
		str.ch[str.len] = '\0';
	}
}

void Init(Str &str)
{
	if(str.ch){
		free(str.ch);
		str.ch = NULL;
	}

	char st[] = "HelloWorld";
	int st_len = sizeof(st);
	str.ch = (char *)malloc(sizeof(char) * st_len);
	str.len = strlen(st);
	strcpy(str.ch,st);
}

void Init2(Str2 &str)
{
	char st[] = "HelloWorld";
	str.len = strlen(st);
	strcpy(str.ch,st);
}

int main()
{
	Str S;
	Str2 S2;

	Init(S);
	cout<<"Delete \'o\' from \""<<S.ch<<"\" by way1"<<endl;
	Del_1(S,'o');
	cout<<"Ans: "<<S.ch<<endl<<endl;

	Init2(S2);
	cout<<"Delete \'l\' from \""<<S2.ch<<"\" by way2"<<endl;
	Del_2(S2,'l');
	cout<<"Ans: "<<S2.ch<<endl<<endl;

	Init2(S2);
	cout<<"Delete \'e\' from \""<<S2.ch<<"\" by way3"<<endl;
	Del_3(S2,'e');
	cout<<"Ans: "<<S2.ch<<endl<<endl;

	free(S.ch);
	return 0;
}

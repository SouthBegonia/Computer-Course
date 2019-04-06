/*
�����ܣ�ɨ���ַ�����ɾ�������ַ�Ϊch��Ԫ��
����˼·��
- �ⷨ1�����ַ����ڳ�ch�������ַ����Ƶ��´����ͷ�ԭ����
- �ⷨ2����һɨ�裬ɨ�赽ch����ɾ��������Ԫ��ǰ�ƣ��ظ����̣�
- �ⷨ3���ڽⷨ2�Ļ����ϸĽ�����������ɾ��ch֮����ִ�ǰ�� Ŀǰɨ����ch�� ��λ�ã�
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

/*�ⷨһ�����ַ����ڳ�ch�������ַ����Ƶ��´����ͷ�ԭ����*/
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
					temp_ch[j++] = str.ch[i];   //��ch�ַ����´�
			temp_ch[j] = '\0';
			str.len = str.len-sum;  //�´�����
			free(str.ch);   //�ͷžʹ�
			str.ch = temp_ch;   //�޸�ָ��
		}
	}
}

/*�ⷨ2����һɨ�裬ɨ�赽ch����ɾ��������Ԫ��ǰ�ƣ��ظ����̣�*/
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

/*�ⷨ3���ڽⷨ2�Ļ����ϸĽ�����������ɾ��ch֮����ִ�ǰ�� Ŀǰɨ����ch�� ��λ�ã�*/
void Del_3(Str2 &str, char ch)
{
	if(str.len!=0){
		int ch_num = 0;     //Ŀǰɨ�赽ch�ĸ���
		int i=0,j;

		while(str.ch[i]!='\0'){
			if(str.ch[i]==ch){
				++ch_num;
				for(j=i+1;str.ch[j]!=ch && str.ch[j]!='\0';j++) //ǰ�Ƶ�һ��ch����һ��ch��\0�ڵĵ��ִ�
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

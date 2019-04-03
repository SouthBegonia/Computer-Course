/*
�����ܣ��������Ľṹ�壬ʵ�ָ�ֵ��ȡ�������ӡ����ִ�����յĻ�������
����˼·��Ϊ�˷�����������ȣ�����ch[]��*ch����+len����ʽ��ʱ�临�Ӷȴ�O(n)����O(1);
���ĸ�ֵ��ͬ����ͨ'='��ֵ����Ҫ��һ��Ԫ�ظ�ֵ��
�״����ڴ����ͷ����롢���������ĳ��ȱ仯
*/
#include<iostream>
#include<stdlib.h>
#include<string.h>
#define Maxsize 50
using namespace std;

typedef struct{
	char *ch;       //��̬���䴢��
	int length;     //�ַ�����
}Str;

/*��ֵ���������ַ���ch ��ֵ�� str��*/
int StrAssign(Str &str, char *ch)
{
	if(str.ch)
		free(str.ch);   //�ͷ�ԭ���ռ�
	int len = 0;
	
	char *c = ch;       //��ch���ĳ���
	while(*c){
		++len;
		++c;
	}
	if(len==0)      //��ch��Ϊ���򷵻ؿմ�
	{
		str.ch = NULL;
		str.length = 0;
		return 1;
	}else
	{
		str.ch = (char *)malloc(sizeof(char) * (len+1));    //Ϊԭ�������¿ռ�(����ĩβ'\0')
		if(str.ch==NULL)
			return 0;
		else
		{
			c = ch;
			for(int i=0;i<=len;i++,c++)     //�� ch ĩβ'\0'Ҳ���ƹ���
				str.ch[i] = *c;
			str.length = len;
			return 1;
		}
	}
}

/*ȡ���ַ������ȣ����س���ֵ*/
int StrLength(Str str)
{
	return str.length;
}

/*���ıȽϣ��Ƚ�s1 �� s2 �������������׸���ͬԪ�صĲ�ֵ*/
int StrCompare(Str s1, Str s2)
{
	for(int i=0;i<s1.length && i<s2.length;i++)
		if(s1.ch[i] != s2.ch[i])
			return s1.ch[i]-s2.ch[i];   //�׸���ͬԪ�صĲ�
	return s1.length-s2.length;
}

/*�������ӣ���str1 �� str2 ���Ӳ����Ƶ� str��*/
int StrConcat(Str &str, Str str1, Str str2)
{
	if(str.ch){
		free(str.ch);   //�ͷ�ԭ���ռ�
		str.ch = NULL;
	}

	str.ch = (char *)malloc(sizeof(char) * (str1.length+str2.length+1));    //�����¿ռ�
	if(str.ch==NULL)
		return 0;

	int i=0;
	while(i<str1.length){
		str.ch[i] = str1.ch[i];     //����str1 ��
		++i;
	}
	int j=0;
	while(j<=str2.length){
		str.ch[i+j] = str2.ch[j];   //����str2 ����str1 β��ע�˴�����str2����ĩβ'\0'
		++j;
	}
	str.length = str1.length + str2.length;
	return 1;
}

/*���Ӵ�����str ���±� pos~len��Ԫ�ص��Ӵ����Ƶ� substr ��*/
int SubString(Str &substr, Str str, int pos, int len)
{
	if(pos<0 || pos>=str.length || len<0 || len>str.length-pos) //�Ӵ��Ϸ���
		return 0;
	if(substr.ch){
		free(substr.ch);    //�ͷ�ԭ���ռ�
		substr.ch = NULL;
	}

	if(len==0)  //�Ӵ�Ϊ��
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
		substr.ch[j] = '\0';    //�ַ���β��
		substr.length = len;
		return 1;
	}
}

/*������գ��ͷ�str �Ŀռ䣬���ȹ���*/
int ClearStr(Str &str)
{
	if(str.ch){
		free(str.ch);
		str.ch = NULL;
	}
	str.length = 0;
	return 1;
}

/*�����ַ���*/
void InputStr(char s[])
{
	cout<<"Input a string:";
	cin>>s;
}

/*��ӡ�ַ���*/
void OutputStr(Str str)
{
	cout<<"\""<<str.ch<<"\""<<endl;
}

/*��ʼ�������ṹ��*/
void Init(Str &s)
{
	s.ch = (char *)malloc(sizeof(char));
	s.length = 0;
}

int main()
{
	char message[Maxsize];  //����Ĵ�
	int choice=0;   //ѡ����
	int tag[2];     //�Ӵ���β�±�
	
	Str S;      //��ֵ��Ĵ�
	Str ComS;   //���Ƚϴ�
	Str CatS;   //����S��ComS��Ĵ�
	Str SubS;   //S�ڵ��Ӵ�

	Init(S);    //��ʼ������
	Init(CatS);
	Init(ComS);
	Init(SubS);
	StrAssign(ComS,"South");    //Ԥ�豻�Ƚϴ�

	cout<<"Choose a function:"<<endl;
	cout<<"1)StrAssign  2)StrLength  3)StrCompare"<<endl;
	cout<<"4)StrConcat  5)SubString  Other)Quit"<<endl;
	cin>>choice;

	while(choice==1||choice==2||choice==3||choice==4||choice==5||choice==6)
	{
		switch(choice)      //����ѡ��
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

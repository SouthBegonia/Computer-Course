/*
�����ܣ���ģʽƥ���㷨��ʵ��
����˼·��������Ԫ�ضԱȲ�ƥ��ʱ����������ģʽ����ǻ���
���㷨���ܽ�����⣬��ʱ�临�Ӷ�ƫ�ߣ��ɲ���KMP�㷨�Ľ�
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

/*��ģʽƥ���㷨��ÿ�λ��ݱ����һ�Ƚ�*/
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
			i = ++k;    //i�Ļ���
		}
	}
	if(j>substr.len)
		return k;
	else return -1;
}

/*������ȡ�ַ���*/
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
	Str S;      //����
	Str Sb;     //�Ӵ�(ģʽ��)
	int ans = -1;    //ģʽƥ��λ��

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


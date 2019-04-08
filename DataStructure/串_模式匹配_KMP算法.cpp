/*
�����ܣ�����KMP�㷨������ģʽ������ת����next[]������ģʽ��sub������str�е���ʼ�±�λ�ã�
����˼·��˳��ɨ�裬����������i,j�ַ���ƥ��ʱ������תģʽ�����j��next[]λ�ã����������ݣ�
���KMP -[https://www.cnblogs.com/yjiyjige/p/3263858.html]
��ע��next[]��תԭ��KMP���Ż�
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

/*����ģʽ����next[]*/
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

/*�������ַ���*/
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

/*ģʽƥ�䣺KMP�㷨������ģʽ�����������±�*/
int KMP(Str str, Str substr, int next[])
{
	int i=0,j=0;
	
	while(i<str.len && j<substr.len)    //ĳ��ǵ���ĩβԪ�غ����
	{
		if(j==0 || str.ch[i]==substr.ch[j])
		{
			++i;
			++j;
		}else
			j = next[j];    //��ƥ�䣺��תģʽ����ǵ�next[j]λ��
	}

	if(j>=substr.len)   //ģʽ��ɨ���������������������±�
		return i-substr.len;
	else
		return 0;
}

int main()
{
	Str S;  //����
	Str SUB;    //ģʽ��
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
		CreateStr(S);   //����������ģʽ��
		CreateStr(SUB);
		GetNext(SUB,next);  //ȡ��ģʽ������ת����next[]
		
		cout<<"next[] :";
		for(int i=0;i<=SUB.len;i++)
			cout<<next[i]<<" ";

		ans = KMP(S,SUB,next);  //ģʽ��ƥ��
		cout<<endl<<"ans = "<<ans<<endl;
	}
	free(S.ch);
	free(SUB.ch);

	return 0;
}


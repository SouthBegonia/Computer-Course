#include<iostream>
#include<stdlib.h>
#include<string.h>
#define Maxsize 50
using namespace std;

typedef struct{
	char *ch;
	int len;
}Str;

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

int main()
{
	Str S;
	int next[Maxsize];
	S.ch = (char *)malloc(sizeof(char) * 10);
	strcpy(S.ch,"ABABAAB");
	S.len = strlen("ABABAAB");
	cout<<S.ch<<endl;
	/*
	while(1)
	{
		CreateStr(S);
		GetNext(S,next);
		for(int i=1;i<=S.len;i++)
			cout<<next[i]<<" ";
		cout<<endl;
	}
	*/
	GetNext(S,next);
	for(int i=1;i<=S.len;i++)
		cout<<next[i]<<" ";
	free(S.ch);
	getchar();
	return 0;
}


/*
�����ܣ������ַ�����A[]�ڵ������ַ��Ƿ����Ϊ "()"
����˼·������˳��ջ����ջһ�� '(' ��������������ַ����бȽϣ���һ������������ջ��ջ��ԭ������һ������
ջ�����ԣ�������������г�����һ�������⣬ƾĿǰ�������޷��������Ҫ��¼�£��������߱��������ٽ��
*/
#include<iostream>
#define Maxsize 50
using namespace std;

/*��������exp�ڵ������Ƿ���ȷ���*/
int Match(char exp[], int n)
{
	char stack[Maxsize];        //����˳��ջ
	int top = -1;               //ջ��

	for(int i=0;i<n;i++)
	{
		if(exp[i]=='(')         //��������������ջ������
			stack[++top] = '(';
		if(exp[i]==')')
		{
			if(top==-1)         //��������������ջ�����˳�
				return 0;
			else
				--top;          //ջ���գ�˵������ƥ�䣬���ջ
		}
	}

	if(top==-1)         //�����������ջΪ�գ���˵�����Ŷ�ƥ�䱻��ջ��
		return 1;
	else
		return 0;
}

int main()
{
	char A[10];
	int ans;
	cout<<"A[]:";
	cin>>A;

	ans = Match(A,10);
	if(ans>0)
		cout<<"�������!";
	else
		cout<<"���Ų����!";

	return 0;
}


/*
程序功能：检验字符数组A[]内的括号字符是否配对为 "()"
基本思路：采用顺序栈，入栈一个 '(' ，再与其后续的字符进行比较，若一个括号配对则出栈，栈还原进行下一个检验
栈的特性：若在问题过程中出现了一个子问题，凭目前条件暂无法解决，需要记录下，待后续具备条件后再解决
*/
#include<iostream>
#define Maxsize 50
using namespace std;

/*检验数组exp内的括号是否正确配对*/
int Match(char exp[], int n)
{
	char stack[Maxsize];        //创建顺序栈
	int top = -1;               //栈底

	for(int i=0;i<n;i++)
	{
		if(exp[i]=='(')         //遇到左括号则入栈待处理
			stack[++top] = '(';
		if(exp[i]==')')
		{
			if(top==-1)         //若遇到右括号且栈空则退出
				return 0;
			else
				--top;          //栈不空，说明括号匹配，则出栈
		}
	}

	if(top==-1)         //结束检验后若栈为空，及说明括号都匹配被出栈了
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
		cout<<"括号配对!";
	else
		cout<<"括号不配对!";

	return 0;
}


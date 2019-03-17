/*
程序功能：计算字符串S[]内保存的双目运算的后缀表达式(都为个位数)，如 41- 结果为 3
基本思路：采用顺序栈，从左往右检验字符；
若为数字字符，则入栈，当为运算符，则将栈内两数字出栈进行计算；
*/
#include<iostream>
#define Maxsize 50
using namespace std;

/*运算函数，计算 a Op b*/
int Option(int a, char Op, int b)
{
	if(Op=='+') return a+b;
	if(Op=='-') return a-b;
	if(Op=='*') return a*b;
	if(Op=='%') return a%b;
	if(Op=='/')
	{
		if(b==0){
			cout<<"Error!"<<endl;
			return 0;
		}else   return a/b;
	}
}

/*后缀式计算函数， ab Op类型*/
int Com(char exp[])
{
	int i,a,b,c;    //a，b 操作数字，c 结果
	char Op;        //保存运算符
	int stack[Maxsize];
	int top=-1;

	for(i=0;exp[i]!='\0';i++)   //从左往右扫描字符串
	{
		if(exp[i]>='0' && exp[i]<='9')  //遇到的个位数字符入栈
			stack[++top]=exp[i]-'0';
		else{
			Op=exp[i];      	//遇到运算符后将栈内2个操作数出栈
			b=stack[top--];
			a=stack[top--];
			c=Option(a,Op,b);  	 //计算
			stack[++top]=c;		 //运算结果入栈
		}
	}
	return stack[top];
}

int main()
{
	char S[]="73-";
	int ans=0;

	ans = Com(S);
	cout<<S<<" = "<<ans<<endl;

	return 0;
}


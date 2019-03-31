/*
程序功能：检验字符串内三种类型括号是否配对，要求忽略字符串里单双引号中的内容
基本思路：依次扫描字符，遇到单双引号原地循环直到跳过，
遇到左侧括号就入栈，当遇到右侧括号则将其与栈顶括号类型配对，匹配则出栈，重复该过程；
最终判断是否栈空，栈空说明括号全都匹配(或是没有任何括号)；
*/
#include<iostream>
#define Maxsize 50
using namespace std;

typedef struct Stack{
	int data[Maxsize];
	int top;
}Stack;

/*判断是否栈空，空返1，非空返0*/
int IsEmpty(Stack s)
{
	if(s.top ==-1)
		return 1;
	else
		return 0;
}

int Push(Stack &s, char x)
{
	if(s.top==Maxsize-1)
		return 0;
	else{
		++s.top;
		s.data[s.top] = x;
		return 1;
	}
}

int Pop(Stack &s, char x)
{
	if(s.top==-1)
		return 0;
	else{
		x = s.data[s.top];
		--s.top;
		return 1;
	}
}

/*取得栈顶元素到 ch*/
void GetTop(Stack s, char &ch)
{
	if(s.top==-1)
		return;
	else ch = s.data[s.top];
}

/*检验配对性函数：
单引号和双引号内的内容跳过不计；*/
int BracketsCheck(Stack &s, char f[])
{
	char ch;
	char *p = f;

	while(*p!='\0')     //扫描字符串内的每一个字符
	{
		if(*p==39)  //单引号39跳过
		{
			++p;
			while(*p!=39)
				++p;
			++p;
		}
		else if(*p==34) //双引号34跳过
		{
			++p;
			while(*p!=34)
				++p;
			++p;
		}else
		{
			switch(*p)
			{
				case '{':
				case '[':
				case '(': Push(s,*p);   //左括号入栈
					break;
				case '}': GetTop(s,ch); //遇到右括号则取出左侧括号与之配对
					if(ch=='{')
						Pop(s,ch);  //配对成功出栈完成一次配对
					else return 0;  //否则退出
					break;
				case ']': GetTop(s,ch); //同上述过程
					if(ch=='[')
						Pop(s,ch);
					else return 0;
					break;
				case ')': GetTop(s,ch);
					if(ch=='(')
						Pop(s,ch);
					else return 0;
			}
			++p;    //每次扫描字符后++
		}
	}
	if(IsEmpty(s))  //最终判断栈是否空，空说明全部配对
		return 1;
	else
		return 0;
}

int main()
{
	Stack S;
	S.top = -1;     //栈底
	char F[20] = "\')(\'[\"}{\"""]{}";
	int ans = 0;

	cout<<"Character string: "<<F<<endl;
	if((ans=BracketsCheck(S,F))==1)
		cout<<"Is Matching!";
	else cout<<"Is Not Matching!";

	return 0;
}


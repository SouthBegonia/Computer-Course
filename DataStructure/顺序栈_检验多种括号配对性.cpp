/*
�����ܣ������ַ������������������Ƿ���ԣ�Ҫ������ַ����ﵥ˫�����е�����
����˼·������ɨ���ַ���������˫����ԭ��ѭ��ֱ��������
����������ž���ջ���������Ҳ�����������ջ������������ԣ�ƥ�����ջ���ظ��ù��̣�
�����ж��Ƿ�ջ�գ�ջ��˵������ȫ��ƥ��(����û���κ�����)��
*/
#include<iostream>
#define Maxsize 50
using namespace std;

typedef struct Stack{
	int data[Maxsize];
	int top;
}Stack;

/*�ж��Ƿ�ջ�գ��շ�1���ǿշ�0*/
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

/*ȡ��ջ��Ԫ�ص� ch*/
void GetTop(Stack s, char &ch)
{
	if(s.top==-1)
		return;
	else ch = s.data[s.top];
}

/*��������Ժ�����
�����ź�˫�����ڵ������������ƣ�*/
int BracketsCheck(Stack &s, char f[])
{
	char ch;
	char *p = f;

	while(*p!='\0')     //ɨ���ַ����ڵ�ÿһ���ַ�
	{
		if(*p==39)  //������39����
		{
			++p;
			while(*p!=39)
				++p;
			++p;
		}
		else if(*p==34) //˫����34����
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
				case '(': Push(s,*p);   //��������ջ
					break;
				case '}': GetTop(s,ch); //������������ȡ�����������֮���
					if(ch=='{')
						Pop(s,ch);  //��Գɹ���ջ���һ�����
					else return 0;  //�����˳�
					break;
				case ']': GetTop(s,ch); //ͬ��������
					if(ch=='[')
						Pop(s,ch);
					else return 0;
					break;
				case ')': GetTop(s,ch);
					if(ch=='(')
						Pop(s,ch);
					else return 0;
			}
			++p;    //ÿ��ɨ���ַ���++
		}
	}
	if(IsEmpty(s))  //�����ж�ջ�Ƿ�գ���˵��ȫ�����
		return 1;
	else
		return 0;
}

int main()
{
	Stack S;
	S.top = -1;     //ջ��
	char F[20] = "\')(\'[\"}{\"""]{}";
	int ans = 0;

	cout<<"Character string: "<<F<<endl;
	if((ans=BracketsCheck(S,F))==1)
		cout<<"Is Matching!";
	else cout<<"Is Not Matching!";

	return 0;
}


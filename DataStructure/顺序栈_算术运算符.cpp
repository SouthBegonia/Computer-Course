/*
�����ܣ������ַ���S[]�ڱ����˫Ŀ����ĺ�׺���ʽ(��Ϊ��λ��)���� 41- ���Ϊ 3
����˼·������˳��ջ���������Ҽ����ַ���
��Ϊ�����ַ�������ջ����Ϊ���������ջ�������ֳ�ջ���м��㣻
*/
#include<iostream>
#define Maxsize 50
using namespace std;

/*���㺯�������� a Op b*/
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

/*��׺ʽ���㺯���� ab Op����*/
int Com(char exp[])
{
	int i,a,b,c;    //a��b �������֣�c ���
	char Op;        //���������
	int stack[Maxsize];
	int top=-1;

	for(i=0;exp[i]!='\0';i++)   //��������ɨ���ַ���
	{
		if(exp[i]>='0' && exp[i]<='9')  //�����ĸ�λ���ַ���ջ
			stack[++top]=exp[i]-'0';
		else{
			Op=exp[i];      	//�����������ջ��2����������ջ
			b=stack[top--];
			a=stack[top--];
			c=Option(a,Op,b);  	 //����
			stack[++top]=c;		 //��������ջ
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


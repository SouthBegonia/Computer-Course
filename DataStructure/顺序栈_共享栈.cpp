/*
�����ܣ���һ����СMaxsize��������Ϊ����˳��ջ�Ĺ�����������[0~Maxsize-1]������˳��ջ���г���ջ����
����˼·��
����elem[Maxsize]�������˷���Ϊջ s0 s1 ��ջ��(�� -1 �� Maxsize)�������в����������ջ������
��ջ��ջ�������top[]���棬����ջ��ջ�� top[0] �� top[1] ��ֵʱ��ջ��
*/
#include<iostream>
#define Maxsize 10      //����ռ��С
#define Empty 0         //�ռ���Ԫ�ؿ�״̬
using namespace std;

typedef struct{
	int elem[Maxsize];  //����ջ�ռ�
	int top[2];     	//top[0]Ϊs0ջ����top[1]Ϊs1ջ�������ߵ�ֵ˵��ջ��
}Sqstack;

/*��ջ������������ x �뵽 stNoջ*/
int Push(Sqstack &st, int stNo, int x)
{
	if(st.top[0]+1 < st.top[1])     //��ջ����ʱ
	{
		if(stNo==0){                //�жϲ���ջ
			++(st.top[0]);
			st.elem[st.top[0]] = x; //��ջ
			return 1;
		}else if(stNo==1){
			--(st.top[1]);
			st.elem[st.top[1]] = x;
			return 1;
		}else	return -1;          //ջ����������
	}else   return 0;       //ջ��
}

/*��ջ�������� stNo ջ���г�ջ��������ջ���ָ�Ϊ x*/
int Pop(Sqstack &st, int stNo, int &x)
{
	if(stNo==0)     //�жϲ���ջ
	{
		if(st.top[0] != -1){    		//�� s0 ջ�ǿ�
			x = st.elem[st.top[0]]; 	//��¼��ջ��
			st.elem[st.top[0]]=Empty;   //���㵱ǰλ��
			--(st.top[0]);              //��ջ
			return 1;
		}else	return 0;               //s0 �գ��޷���ջ
	}else
	if(stNo==1)
	{
		if(st.top[1] != Maxsize){
			x = st.elem[st.top[1]];
			st.elem[st.top[1]]=Empty;
			++(st.top[1]);
			return 1;
		}else   return 0;
	}else   return -1;
}

/*��ӡ����ռ�����(����������)*/
void DispStack(Sqstack st)
{
	cout<<"ShareStack :[";
	for(int i=0;i<Maxsize;i++)
		cout<<st.elem[i]<<" ";
	cout<<"]"<<endl;
}

int main()
{
	int tab = 0;        			//ѡ����� s0 �� s1 ջ
	int num = 0;        			//��ջ����
	int choice = 0;    		 		//ѡ�� ��ջ �� ��ջ

	Sqstack ShareStack; 			//��������ʼ��ջ����ʼ�ռ��Ϊ���� 0
	for(int i=0;i<Maxsize;i++)
		ShareStack.elem[i]=Empty;
	ShareStack.top[0] = -1;     	//s0 ջ�������
	ShareStack.top[1] = Maxsize;    //s1 ջ�����Ҳ�

	while(choice==0 || choice==1)   
	{
		cout<<"Push or Pop?(0/1):";//ѡ��ջ�Ĳ��� 0�� 1��
		cin>>choice;

		if(choice==0){
			cout<<"Input tab(0/1) and num:";    //ѡ����ջ�ı�ż�����
			cin>>tab>>num;
			Push(ShareStack,tab,num);           //��ջ
		}else if(choice==1){
			cout<<"Output tab:";                //ѡ���ջ�ı��
			cin>>tab;
			Pop(ShareStack,tab,num);            //��ջ
		}
		DispStack(ShareStack);                  //ִ��һ��ջ�������ӡ����ռ�����
		cout<<endl;
	}
	cout<<"Done!";
	return 0;
}


/*
程序功能：将一个大小Maxsize的数组作为两个顺序栈的共享储存区，即[0~Maxsize-1]，对两顺序栈进行出入栈操作
基本思路：
数组elem[Maxsize]左右两端分设为栈 s0 s1 的栈底(即 -1 和 Maxsize)，都向中部区域进行入栈操作；
两栈的栈顶标记用top[]储存，当两栈的栈顶 top[0] 及 top[1] 等值时则栈满
*/
#include<iostream>
#define Maxsize 10      //共享空间大小
#define Empty 0         //空间内元素空状态
using namespace std;

typedef struct{
	int elem[Maxsize];  //共享栈空间
	int top[2];     	//top[0]为s0栈顶，top[1]为s1栈顶；两者等值说明栈满
}Sqstack;

/*入栈操作：将数字 x 入到 stNo栈*/
int Push(Sqstack &st, int stNo, int x)
{
	if(st.top[0]+1 < st.top[1])     //当栈不满时
	{
		if(stNo==0){                //判断操作栈
			++(st.top[0]);
			st.elem[st.top[0]] = x; //入栈
			return 1;
		}else if(stNo==1){
			--(st.top[1]);
			st.elem[st.top[1]] = x;
			return 1;
		}else	return -1;          //栈标号输入错误
	}else   return 0;       //栈满
}

/*出栈操作：将 stNo 栈进行出栈操作，出栈数字赋为 x*/
int Pop(Sqstack &st, int stNo, int &x)
{
	if(stNo==0)     //判断操作栈
	{
		if(st.top[0] != -1){    		//若 s0 栈非空
			x = st.elem[st.top[0]]; 	//记录出栈数
			st.elem[st.top[0]]=Empty;   //清零当前位置
			--(st.top[0]);              //出栈
			return 1;
		}else	return 0;               //s0 空，无法出栈
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

/*打印共享空间的情况(本例下特用)*/
void DispStack(Sqstack st)
{
	cout<<"ShareStack :[";
	for(int i=0;i<Maxsize;i++)
		cout<<st.elem[i]<<" ";
	cout<<"]"<<endl;
}

int main()
{
	int tab = 0;        			//选择操作 s0 或 s1 栈
	int num = 0;        			//入栈数字
	int choice = 0;    		 		//选择 入栈 或 出栈

	Sqstack ShareStack; 			//创建并初始化栈，初始空间均为数字 0
	for(int i=0;i<Maxsize;i++)
		ShareStack.elem[i]=Empty;
	ShareStack.top[0] = -1;     	//s0 栈底在左侧
	ShareStack.top[1] = Maxsize;    //s1 栈底在右侧

	while(choice==0 || choice==1)   
	{
		cout<<"Push or Pop?(0/1):";//选择栈的操作 0入 1出
		cin>>choice;

		if(choice==0){
			cout<<"Input tab(0/1) and num:";    //选择入栈的编号及数据
			cin>>tab>>num;
			Push(ShareStack,tab,num);           //入栈
		}else if(choice==1){
			cout<<"Output tab:";                //选择出栈的编号
			cin>>tab;
			Pop(ShareStack,tab,num);            //出栈
		}
		DispStack(ShareStack);                  //执行一次栈操作后打印共享空间的情况
		cout<<endl;
	}
	cout<<"Done!";
	return 0;
}


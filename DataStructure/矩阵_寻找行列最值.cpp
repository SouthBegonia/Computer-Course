/*
�����ܣ��ҳ������ڣ���������С������С����
����˼·��ɨ��õ�i����Сֵ����ɨ����������minj������������С���ӡ
*/
#include<iostream>
#define Maxsize 4
using namespace std;

/*������Сֵ*/
void Printmin(int A[][Maxsize], int m, int n)
{
	int i,j,k,min;
	int minj;   //i������Сֵ���к�
	int flag;   //1���� 0������

	for(int i=0;i<m;i++){   //��ѭ��
		min = A[i][0];
		minj = 0;
		for(j=1;j<n;j++)    //��ѭ��
		if(A[i][j]<min){
			min = A[i][j];  //i������Сֵ���к�minj
			minj = j;
		}

		flag = 1;
		for(k=0;k<m;k++)
		if(min>A[k][minj]){ //ɨ���������ж�min�Ƿ�Ϊminj������Сֵ
			flag = 0;
			break;
		}

		if(flag)
			cout<<min<<",["<<i<<", "<<minj<<"]"<<" ";
	}
	cout<<endl;
}

/*�������ֵ*/
void Printmax(int A[][Maxsize], int m, int n)
{
	int i,j,k,max,maxj;
	int flag;

	for(i=0;i<m;i++){
		max = A[i][0];
		maxj = 0;

		for(j=1;j<n;j++)
		if(A[i][j]>max){
			max = A[i][j];
			maxj = j;
		}
		flag = 1;
		for(k=0;k<m;k++)
		if(max<A[k][maxj]){
			flag = 0;
			break;
		}
		if(flag)
			cout<<max<<",["<<i<<", "<<maxj<<"]"<<" ";
	}
	cout<<endl;
}

int main()
{
	int A[][Maxsize] = {
		{1,8,5,7},
		{2,3,6,8},
		{9,0,1,2},
		{4,6,8,1}
	};
	Printmin(A,4,4);
	Printmax(A,4,4);
	return 0;
}

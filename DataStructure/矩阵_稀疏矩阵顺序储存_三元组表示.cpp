/*
�����ܣ�ϡ������˳�򴢴淽��-��Ԫ���ʾ��
����˼·����Ԫ���ʾ������ �ṹ�� ����
��ά����B[][]�洢�����ڷ�0Ԫ�ص����꼰��ֵ�����������г�����Ϣ
	B[0][0]: ��ʾ�����ڷ���Ԫ�ظ���
	B[0][1]
	B[0][2]: ��ʾ�������г���
	B[1~Maxsize-1][0]: ��ʾ 1~Maxsize-1 ��ŵķ�0Ԫ�ص���ֵ
	B[1~Maxsize-1][1]
	B[1~Maxsize-1][2]: ��ʾ 1~Maxsize-1 ��ŵķ�0Ԫ�صľ�������
*/
#include<iostream>
using namespace std;
#define Maxsize 4

/*�ṹ���ʾ��Ԫ��*/
typedef struct{
	int val;
	int i,j;
}Trimat;

/*������Ԫ��*/
void CreateTrimat(float A[][Maxsize], int m, int n, float B[][3])
{
	int k = 1;  //����Ԫ�صĸ���(���)
	
	for(int i=0;i<m;i++)
		for(int j=0;j<n;j++)
			if(A[i][j]!=0)  //���������Ԫ��
			{
				B[k][0] = A[i][j];  //����Ԫ������
				B[k][1] = i;    //����Ԫ���ھ����ڵ�����
				B[k][2] = j;
				++k;
			}
	B[0][0] = k-1;  //���շ���Ԫ�ظ���
	B[0][1] = m;    //��������
	B[0][2] = n;    //��������
}

/*ͨ����Ԫ���ӡ����*/
void Printmat(float B[][3])
{
	int k = 1;
	for(int i=0;i<B[0][1];++i){
		for(int j=0;j<B[0][2];j++){
			if(i==(int)B[k][1] && j==(int)B[k][2]){
				cout<<B[k][0]<<" ";     //���ڷ���Ԫ��λ�ô�ӡ
				++k;
			}else
				cout<<"0 ";     //����λ����0����
		}
		cout<<endl;
	}
}

int main()
{
	float A[4][4] ={
		{0,0,0,1},
		{0,0,3,2},
		{1,0,0,0},
		{0,2,0,0}};
		
	float B[4][3];

	CreateTrimat(A,4,4,B);
	Printmat(B);
	
	return 0;
}


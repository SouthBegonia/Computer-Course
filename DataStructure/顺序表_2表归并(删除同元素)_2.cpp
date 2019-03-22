/*
�����ܣ�a��bΪ�ǵݼ�˳�����д˳���c��ab��鲢�������У�Ҫ��ab������ͬԪ��ֻ����һ��
����˼·���ȵ���Dels()������a��b�������ɾ��������ͬԪ�ش������޸��䳤�ȣ�
����ڵ���Unions()���жԱȹ鲢������ʵ��
*/
#include<iostream>
using namespace std;
#define Maxsize 50

/*ɾ��˳��� a[]���ظ�Ԫ�أ����޸����*/
int  Dels(int a[],int &len)     //�漰�޸� len ����
{
	int i=0;    //���ظ�Ƭ��ĩλԪ�ء���ʼΪa[0]
	int tag=1;  //Ԫ�ر��

	while(i<len)
	{
		while(a[tag]==a[i])
		{
			tag++;      //tag++ ɨ�����
			len--;      //��ʾ���Ԫ�ش�ɾ������-1
		}
		i++;            //ֱ�����ظ�Ԫ����������ĩβԪ��
		a[i] = a[tag];
		tag++;
	}
	return len;
}

/*�ϲ������鵽C*/
int Unions(int a[], int na, int b[], int nb, int *(c), int &nc)
{
	int i=0;    //������i,j
	int j=0;
	int k=0;    //�鲢˳�����

	if(na+nb>Maxsize)	//��������
		return -1;

	if(na<0 && nb>0)    //���ڿձ�
		return -1;//b��Ԫ�ع���c��

	if(nb<0 && na>0)
		return -1;//a��Ԫ�ع���c��


	while(i<na && j<nb)
	{
		if(a[i]<b[j])
		{
			c[k++] = a[i++];
		}

		if(a[i]>b[j])
		{
			c[k++] = b[j++];
		}

		if(a[i]==b[j])
		{
			c[k++] = a[i];
			i++;
			j++;
		}
	}
	if(i==na)
	{
		while(j!=nb)
			c[k++] = b[j++];
	}
	
	if(j==nb)
	{
		while(i!=na)
			c[k++] = a[i++];
	}
	nc = k;
	return nc;
}

int main()
{
	/*
	int LA = 5;
	int LB = 8;
	int A[LA] = {1,4,7,8,10};
	int B[LB] = {2,3,4,8,9,11,12,13};
	*/
	/*
	int LA = 7;
	int LB = 3;
	int A[LA] = {1,4,6,6,6,7,7};
	int B[LB] = {1,4,9};
	*/

	int LA = 7;
	int LB = 10;
	int A[LA] = {1,1,1,2,2,3,9};
	int B[LB] = {1,2,2,3,4,4,5,6,7,10};
	
	int Nc = 0;
	int C[Maxsize] = {0};

	Dels(A,LA);
	Dels(B,LB);
	
	Unions(A,LA,B,LB,C,Nc);
	for(int i=0;i<Nc;i++)
		cout<<C[i]<<" ";
	cout<<endl<<"Nc="<<Nc;
	return 0;
}


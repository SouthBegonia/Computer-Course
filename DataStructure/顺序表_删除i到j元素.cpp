/*�����ܣ�ɾ��˳���L���±�Ϊi~j��Ԫ��(����Ԫ��ǰ��)*/
#include<iostream>
#include<stdio.h>
using namespace std;

typedef struct
{
	int data[50];
	int length;
}Sqlist;

/*ɾ���±�Ϊ i~j ��Ԫ��*/
void deleteNodes(Sqlist &L, int i, int j)
{
	int k,delta;
	delta = j-i+1;      //��ɾ��Ԫ�صĸ���

	for(k=j+1;k<L.length;k++)
		L.data[k-delta] = L.data[k];    //�����㷨
	L.length -= delta;
}

int main()
{
	Sqlist L;
	int i,j;        //��ɾ��Ԫ�ط�Χ���±�

	cout<<"L.length:";      //��������Ϣ
	cin>>L.length;
	for(int m=0;m<L.length;m++)
	  cin>>L.data[m];
	cout<<"i j:";
	cin>>i>>j;

	if(i>=0 && j<L.length && i<=j)      //��ӡ�������ı�
	{
		deleteNodes(L,i,j);

		for(int m=0;m<L.length;m++)
			cout<<L.data[m]<<" ";
		cout<<endl<<"L.length="<<L.length<<endl;
	}
	else	cout<<"ERROR"<<endl;

	return 0;
}


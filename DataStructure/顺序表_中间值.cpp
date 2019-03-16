/*
�����ܣ�������˳���L�ڱȱ�ͷԪ��С��Ԫ��������ߣ���������ұߡ���[2 1 -7 13 5 6 -1]�����[-1 1 -7 -3 2 6 5]
*/
#include<iostream>
using namespace std;

typedef struct
{
	int data[50];
	int length;
}Sqlist;

void move(Sqlist &L)
{
	int temp;
	int i=0;    //����
	int j=L.length-1;   //�ұ��
	temp = L.data[i];

	/*�����㷨*/
	while(i<j)      //���ұ������Ϊֹ
	{
		while(i<j && L.data[j]>temp)    //j��������ɨ��ֱ����tempС��Ԫ��
			j--;
		if(i<j){
			L.data[i]=L.data[j];
			i++;
		}

		while(i<j && L.data[i]<temp)    //i��������ɨ��ֱ����temp���Ԫ��
			i++;
		if(i<j){
			L.data[j] = L.data[i];
			j--;
		}
	}
	L.data[i] = temp;       //i=jʱ�˳�����ͷԪ�����ڴ�
}

int main()
{
	Sqlist L;

	cout<<"L.length:";
	cin>>L.length;
	for(int i=0;i<L.length;i++)
		cin>>L.data[i];
		
	move(L);
	
	for(int i=0;i<L.length;i++)
		cout<<L.data[i]<<" ";
	return 0;
}


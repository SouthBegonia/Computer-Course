/*
�����ܣ�ɾ��(����)˳������ظ�Ԫ�أ�����ɾ����ı�
����˼·����������ɨ�裬tag���ɨ����̣�
��ɨ���ظ�Ԫ��˵�����Ǵ�ɾԪ�أ����ձ�-1;
��ɨ�赽���ظ�Ԫ��ʱ����������ظ����ĩβ(a[i+1]λ��)��
�����ձ�=ԭ��-ɾ��Ԫ�ظ���
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

int main()
{
	int LA = 4;
	int A[Maxsize] = {1,1,1,1};

	cout<<"LA="<<LA<<endl;
	for(int i=0;i<LA;i++)
		cout<<A[i]<<" ";
	cout<<endl;

	Dels(A,LA);

	cout<<"LA="<<LA<<endl;
	for(int i=0;i<LA;i++)
		cout<<A[i]<<" ";

	return 0;
}


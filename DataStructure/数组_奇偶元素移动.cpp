/*
�����ܣ��������飬��������ż������
����˼·�����ҷ����ǣ�ɨ�赽������ż���򽻻�
*/
#include<iostream>
using namespace std;

void Divide(int A[], int n)
{
	int i=0,j=n-1;
	int temp;

	while(i<j){
		while(A[i]%2==1 && i<j)     //��������ɨ�赽ż��
			++i;
		while(A[j]%2==0 && i<j)     //��������ɨ�赽����
			--j;
		if(i<j){
			temp = A[i];    //����
			A[i] = A[j];
			A[j] = temp;
			++i;
			--j;
		}
	}
}

int main()
{
	int a[10] = {0,1,2,3,4,5,6,7,8,9};
	for(int i=0;i<10;i++)
		cout<<a[i]<<" ";
	cout<<endl;

	Divide(a,10);
	for(int i=0;i<10;i++)
		cout<<a[i]<<" ";
	cout<<endl;
}


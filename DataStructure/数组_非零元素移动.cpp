/*
�����ܣ�������num[]�ڵķ�0Ԫ���������
����˼·�����������i,j��i��Ƿ���Ԫ��ĩλ��jɨ�����飬ɨ�赽��0Ԫ�����Ƶ�i++λ��
*/
#include<iostream>
using namespace std;

/*���ܺ���*/
void Movelement(int A[], int n)
{
	int i=-1;   //���ŷ�0����ĩλԪ��
	int j;      //ɨ�赽�ķ�0������Ԫ��
	int temp;   //�м�ֵ

	for(j=0;j<n;j++)
		if(A[j]!=0){
			++i;
			if(i!=j){
				temp = A[i];
				A[i] = A[j];
				A[j] = temp;
			}
		}
}

int main()
{
	int size = 8;
	int num[size] = {1,0,0,3,0,1,0,2};

	for(int i=0;i<size;i++)
		cout<<num[i]<<" ";
	cout<<endl;

	Movelement(num,size);

	for(int i=0;i<size;i++)
		cout<<num[i]<<" ";
	return 0;
}



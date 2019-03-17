/*�����ܣ���֪��������a[n]���ж������Ƿ��г��ִ������� n/2����Ԫ��*/
#include<iostream>
using namespace std;

/*�����Ԫ�غ�����
��ǰ��������ɨ��ÿһ��Ԫ�أ������ĵ�һ������num��Ϊ������Ԫ��C����¼�������count+1��
����һ��������������Ϊnum����+1����-1��
������count��Ϊ0ʱ���򽫵�ǰԪ�ص���һ��Ԫ�ؼ�Ϊ�µĴ�����Ԫ�أ�count+1���Դ�����
�ж����մ�����Ԫ���������ڳ��ִ����Ƿ���� n/2
*/
int Majority(int A[], int n)
{
	int count = 1;     		//��ʼcount+1
	int C = A[0];      		//�׸�Ԫ����Ϊ������Ԫ��

	for(int i=1;i<n;i++)
	{
		if(A[i]==C)     	//����ǰ����Ԫ�����¸�Ԫ����ͬ
			count++;
		else{
			if(count>0) 	//����ǰ������Ԫ�����¸�Ԫ�ز�ͬ
				count--;
			else{
				C = A[i];   //countΪ0��ѡȡ�µ���Ԫ�ز����¼���
				count = 1;
			}
		}
	}
	if(count>0){
		for(int i=count;i<n;i++)
			if(A[i]==C)
				count++;
	}
	if(count> n/2)   //�ж����Ĵ�����Ԫ�س��ִ����Ƿ���� n/2
		return C;
	else
		return -1;
}

int main()
{
	int N=0;            //���鳤��
	int models=-1;      //��Ԫ��
	
	cout<<"N:";
	cin>>N;
	int *a = new int (N);
	cout<<"a["<<N<<"]:";
	for(int i=0;i<N;i++)
		cin>>a[i];

	models = Majority(a,N);
	if(models>0){
		cout<<"����a[]�ڵ���Ԫ��Ϊ"<<models;
	}else   cout<<"����a[]��û����Ԫ��";
	
	return 0;
}


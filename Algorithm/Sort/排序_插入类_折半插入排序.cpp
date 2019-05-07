/*
�����ܣ��۰��������
����˼·��
����0~i~n-1�����飬0~i-1Ϊ�������У����Ҷ�ֵlow,high����i~n-1����ѭ����
ÿ��ѭ��ѡȡ�������е��м�ֵm=(low+high)/2����������Ԫ��i��m�Ƚϣ����ݴ�С�ı�Low/high��
�ظ�ѭ����low>high����ʱhigh+1λ�ü�Ϊ������λ�ã����������к󲿷��ƶ�����ʵ�ֲ��룻

ʱ�临�Ӷȣ�
��������O(N^2)
������O(NlogN)
*/
#include<iostream>
using namespace std;

/*�۰���룺��������*/
void InsertSort_UP(int Array[], int n)
{
	int low,high;       //�����������Ҷ��±�
	int x,m;            //������ֵx ���������м�ֵm
	int i,j;

	for(i=1;i<n;i++)
	{
		x = Array[i];
		low = 0;
		high = i-1;     //�������� [0~i-1]

		while(low<=high)    //low=high�ǱȽϹ����е����һ���Ƚ���
		{
			m = (low+high)/2;

			if(x>Array[m])  //���� 1 2 6 |4
				low = m+1;
			else
				high = m-1;
		}
		for(j=i-1;j>high;j--)   //����λ��~ԭλ����Ԫ�غ��Ƹ��ǣ����ֵx��ɲ���
			Array[j+1] = Array[j];
		Array[j+1] = x;
	}
}

/*�۰���룺��������*/
void InsertSort_Down(int Array[], int n)
{
	int low,high;
	int x,m;
	int i,j;

	for(i=1;i<n;i++)
	{
		x = Array[i];
		low = 0;
		high = i-1;

		while(low<=high)
		{
			m = (low+high)/2;

			if(x<Array[m])      //Ψһ���
				low = m+1;
			else
				high = m-1;
		}
		for(j=i-1;j>high;j--)
			Array[j+1] = Array[j];
		Array[j+1] = x;
	}
}

int main()
{
	int arr[10] = {8,3,2,1,6,5,7,4,9,0};
	for(int i=0;i<10;i++)
		cout<<arr[i]<<" ";
	cout<<endl;

	InsertSort_UP(arr,10);
	for(int i=0;i<10;i++)
		cout<<arr[i]<<" ";
	cout<<endl;
	
	return 0;
}

/*
�����ܣ�a��bΪ����˳�����д˳���c��ab��鲢�������У�Ҫ��ab������ͬԪ��ֻ����һ��
*/
#include<iostream>
using namespace std;
#define Maxsize 50

int Unions(int a[], int na, int b[], int nb, int c[], int &nc)
{
	int i=0,j=0,k=0;
	
	if(na+nb>Maxsize)
		return -1;      //��������
		
	while(i<na && j<nb)
	{
		if(a[i]<b[j])
		{
			if(k>0)         //��kΪ0ʱ�Ĵ�����Ϊa��b�����Ϊ��
			{
				if(c[k-1]!=a[i])    //������ͬԪ��
					c[k++] = a[i++];
				else
					i++;
			}else
				c[k++] = a[i++];
		}else
		{
			if(k>0)     //ͬ��������
			{
				if(c[k-1]!=b[j])
					c[k++] = b[j++];
				else
					j++;
			}else
				c[k++] = b[j++];
		}
	}
	while(i<na)
	{
		if(k>0)
		{
			if(c[k-1]!=a[i])
				c[k++] = a[i++];
			else
				i++;
		}else
			c[k++] = a[i++];
	}

	while(j<nb)
	{
		if(k>0)
		{
			if(c[k-1]!=b[j])
				c[k++] = b[j++];
			else
				j++;
		}else
			c[k++] = b[j++];
	}
	
	nc = k;
	return nc;
}

int main()
{
	//function
	return 0;
}

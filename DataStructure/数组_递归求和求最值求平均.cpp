/*
程序功能：递归实现数组求和求平均求最值
*/
#include<iostream>
#include <iomanip>
using namespace std;

/*求数组最大值*/
float Findmax(float A[], int i, int j)
{
	float max;
	if(i==j)
		return A[i];
	else{
		max = Findmax(A,i+1,j);
		if(A[i]>max)
			return A[i];
		else
			return max;
	}
}

/*求数组和*/
float Arraysum(float A[], int i, int j)
{
	if(i==j)
		return A[i];
	else
		return A[i]+Arraysum(A,i+1,j);
}

/*求数组平均值*/
float Arrayavg(float A[], int i, int j)
{
	if(i==j)
		return A[i];
	else
		return (A[i]+(j-i)*Arrayavg(A,i+1,j)) / (j-i+1);
}

int main()
{
	int size = 10;
	float a[size] = {0,1,2,3,4,5,6,7,8,9};

	cout<<"Array[";
	for(int i=0;i<size;i++)
		cout<<a[i]<<" ";
	cout<<"]"<<endl;

	cout<<"Maximum value = "<<Findmax(a,0,size)<<endl;
	cout<<"Total value   = "<<Arraysum(a,0,size)<<endl;
	cout<<"Average value = "<<setprecision(3)<<Arrayavg(a,0,size)<<endl;
	return 0;
}


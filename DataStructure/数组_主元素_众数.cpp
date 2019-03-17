/*程序功能：已知整数数组a[n]，判定其内是否有出现次数大于 n/2的主元素*/
#include<iostream>
using namespace std;

/*检测主元素函数：
从前往后依次扫描每一个元素，遇到的第一个整数num作为待定主元素C，记录其出次数count+1；
若下一个遇到的整数仍为num，则+1否则-1；
当计数count减为0时，则将当前元素的下一个元素记为新的待定主元素，count+1，以此类推
判定最终待定主元素在数组内出现次数是否大于 n/2
*/
int Majority(int A[], int n)
{
	int count = 1;     		//初始count+1
	int C = A[0];      		//首个元素作为待定主元素

	for(int i=1;i<n;i++)
	{
		if(A[i]==C)     	//若当前待定元素与下个元素相同
			count++;
		else{
			if(count>0) 	//若当前待定主元素与下个元素不同
				count--;
			else{
				C = A[i];   //count为0则选取新的主元素并重新计数
				count = 1;
			}
		}
	}
	if(count>0){
		for(int i=count;i<n;i++)
			if(A[i]==C)
				count++;
	}
	if(count> n/2)   //判断最后的待定主元素出现次数是否大于 n/2
		return C;
	else
		return -1;
}

int main()
{
	int N=0;            //数组长度
	int models=-1;      //主元素
	
	cout<<"N:";
	cin>>N;
	int *a = new int (N);
	cout<<"a["<<N<<"]:";
	for(int i=0;i<N;i++)
		cin>>a[i];

	models = Majority(a,N);
	if(models>0){
		cout<<"数组a[]内的主元素为"<<models;
	}else   cout<<"数组a[]内没有主元素";
	
	return 0;
}

